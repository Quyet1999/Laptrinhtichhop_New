using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using TrasuaService.Model;
using TrasuaService.Process;

namespace TrasuaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCF_Trasua" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WCF_Trasua.svc or WCF_Trasua.svc.cs at the Solution Explorer and start debugging.
    public class WCF_Trasua : IWCF_Trasua
    {
        Models db = new Models();
        public bool AddAccount(string sessionID, string username, string password, int groupID)
        {
            if (!CheckInput.CheckInputSqli(username) || !CheckInput.CheckInputSqli(password) || !CheckInput.CheckInputSqli(groupID.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) == -1)
                return false;

            Model.Account acc = new Model.Account();
            acc.Username = username;
            acc.Password = password;
            acc.GroupID = groupID;
            try
            {
                db.Accounts.Add(acc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAccount(string sessionID, int accountID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(accountID.ToString()))
                return false;
            int groupID = SessionProcessing.CheckSessionID(sessionID);
            if (groupID == -1)
                return false;

            Model.Account acc = db.Accounts.Where(x => x.ID == accountID).ToList().FirstOrDefault();
            if (acc == null)
                return false;
            if (acc.GroupID > groupID)
                return false;
            try
            {
                db.Accounts.Remove(acc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditPasswordAccount(string sessionID, int accountID, string newPassword)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(accountID.ToString()) || !CheckInput.CheckInputSqli(newPassword))
                return false;
            int groupID = SessionProcessing.CheckSessionID(sessionID);
            if (groupID == -1)
                return false;

            if (groupID == 3)
            {
                Model.Account acc = db.Accounts.Where(x => x.ID == accountID).ToList().FirstOrDefault();
                if (acc == null)
                    return false;
                acc.Password = newPassword;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                Model.Account acc = db.Accounts.Where(x => x.ID == accountID).ToList().FirstOrDefault();
                if (acc == null)
                    return false;
                Model.Session sess = db.Sessions.Where(x => x.SessionID == sessionID).ToList().First();
                if (sess.AccountID != acc.ID)
                    return false;
                acc.Password = newPassword;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool EditPermissionAccount(string sessionID, int accountID, int newGroupID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(newGroupID.ToString()))
                return false;
            int groupID = SessionProcessing.CheckSessionID(sessionID);
            if (groupID != 3)
                return false;

            Model.Account acc = db.Accounts.Where(x => x.ID == accountID).ToList().FirstOrDefault();
            if (acc == null)
                return false;
            acc.GroupID = newGroupID;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditStatusAccount(string sessionID, int accountID, bool newStatus)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(accountID.ToString()) || !CheckInput.CheckInputSqli(newStatus.ToString()))
                return false;
            int groupID = SessionProcessing.CheckSessionID(sessionID);
            if (groupID != 3)
                return false;

            Model.Account acc = db.Accounts.Where(x => x.ID == accountID).ToList().FirstOrDefault();
            if (acc == null)
                return false;
            acc.StatusAccount = newStatus;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int getAccountID(string sessionID)
        {
            if (!CheckInput.CheckInputSqli(sessionID))
                return -1;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID).FirstOrDefault();
            if (sess == null)
                return -1;
            return sess.AccountID;
        }

        public int addBill(string sessionID, int customerID, bool statusBill)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(customerID.ToString()) || !CheckInput.CheckInputSqli(statusBill.ToString()))
                return -1;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID).FirstOrDefault();
            if (sess == null)
                return -1;
            Model.Account acc = db.Accounts.Where(x => x.ID == sess.AccountID).FirstOrDefault();
            if (acc.GroupID != 2)
                return -1;
            Bill bill = new Bill();
            if (db.Bills.ToList().Count == 0)
            {
                bill.ID = 1;
            }
            else
            {
                bill.ID = db.Bills.OrderByDescending(x => x.ID).First().ID + 1;
            }
            if (customerID > 0)
            {
                Model.Customer cus = db.Customers.Where(x => x.ID == customerID).ToList().FirstOrDefault();
                if (cus == null)
                    return -1;
                bill.CustomerID = customerID;
            }
            else
            {
                bill.CustomerID = -1;
            }
            bill.StatusBill = statusBill;
            bill.EmployeeCreate = acc.ID;
            bill.TimeCreate = DateTime.Now;
            try
            {
                db.Bills.Add(bill);
                db.SaveChanges();
                return bill.ID;
            }
            catch
            {
                return -1;
            }
        }

        public bool addBillDetail(string sessionID, int billID, int itemID, int numberItem, bool typeItem)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(billID.ToString()) || !CheckInput.CheckInputSqli(itemID.ToString())
                || !CheckInput.CheckInputSqli(numberItem.ToString()) || !CheckInput.CheckInputSqli(typeItem.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 2)
                return false;
            Bill bill = db.Bills.Where(x => x.ID == billID).FirstOrDefault();
            if (bill == null)
                return false;
            BillDetail billDetail = db.BillDetails.Where(x => x.BillID == billID && x.ItemID == itemID && x.TypeItem == typeItem).FirstOrDefault();
            if (billDetail != null)
                return false;
            if (typeItem == true)
            {
                Model.Drink dr = db.Drinks.Where(x => x.ID == itemID).ToList().FirstOrDefault();
                BillDetail newDetail = new BillDetail();
                if (db.BillDetails.ToList().Count == 0)
                {
                    newDetail.ID_Detail = 1;
                }
                else
                {
                    newDetail.ID_Detail = db.BillDetails.OrderByDescending(x => x.ID_Detail).First().ID_Detail + 1;
                }
                newDetail.BillID = bill.ID;
                newDetail.ItemID = itemID;
                newDetail.NumberItem = numberItem;
                newDetail.Price = dr.Price;
                newDetail.TotalMoneyDetail = numberItem * dr.Price;
                newDetail.TypeItem = typeItem;
                bill.TotalMoney += newDetail.TotalMoneyDetail;
                try
                {
                    db.BillDetails.Add(newDetail);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                Model.Topping topp = db.Toppings.Where(x => x.ID == itemID).ToList().FirstOrDefault();
                BillDetail newDetail = new BillDetail();
                if (db.BillDetails.ToList().Count == 0)
                {
                    newDetail.ID_Detail = 1;
                }
                else
                {
                    newDetail.ID_Detail = db.BillDetails.OrderByDescending(x => x.ID_Detail).First().ID_Detail + 1;
                }
                newDetail.BillID = bill.ID;
                newDetail.ItemID = itemID;
                newDetail.NumberItem = numberItem;
                newDetail.Price = topp.Price;
                newDetail.TotalMoneyDetail = numberItem * topp.Price;
                newDetail.TypeItem = typeItem;
                bill.TotalMoney += newDetail.TotalMoneyDetail;
                try
                {
                    db.BillDetails.Add(newDetail);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


        public bool editBill(string sessionID, int billID, int customerID, bool statusBill)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(billID.ToString()) || !CheckInput.CheckInputSqli(customerID.ToString())
               || !CheckInput.CheckInputSqli(statusBill.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 2)
                return false;
            Bill bill = db.Bills.Where(x => x.ID == billID).FirstOrDefault();
            if (bill == null)
                return false;
            if (customerID > 0)
            {
                Model.Customer cus = db.Customers.Where(x => x.ID == customerID).ToList().FirstOrDefault();
                if (cus == null)
                    return false;
                bill.CustomerID = customerID;
            }
            else
            {
                bill.CustomerID = -1;
            }
            bill.StatusBill = statusBill;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editBillDetail(string sessionID, int billID, int itemID, int numberItem, bool typeItem)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(billID.ToString()) || !CheckInput.CheckInputSqli(itemID.ToString())
               || !CheckInput.CheckInputSqli(numberItem.ToString()) || !CheckInput.CheckInputSqli(typeItem.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 2)
                return false;
            Bill bill = db.Bills.Where(x => x.ID == billID).FirstOrDefault();
            if (bill == null)
                return false;
            BillDetail billDetail = db.BillDetails.Where(x => x.BillID == billID && x.ItemID == itemID && x.TypeItem == typeItem).FirstOrDefault();
            if (billDetail == null)
                return false;
            if (numberItem == 0)
            {
                try
                {
                    db.BillDetails.Remove(billDetail);
                    db.SaveChanges();
                    updateTotalMoney(bill.ID);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                billDetail.NumberItem = numberItem;
                billDetail.TotalMoneyDetail = billDetail.Price * numberItem;
                updateTotalMoney(bill.ID);
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
        private void updateTotalMoney(int billID)
        {
            Bill bill = db.Bills.Where(x => x.ID == billID).First();
            List<BillDetail> listDetail = db.BillDetails.Where(x => x.BillID == billID).ToList();
            bill.TotalMoney = 0;
            foreach (BillDetail item in listDetail)
            {
                bill.TotalMoney += item.TotalMoneyDetail;
            }
            db.SaveChanges();
        }

        public bool acceptCustomer(string sessionID, int CustomerID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(CustomerID.ToString()))
                return false;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID && x.Status == true).FirstOrDefault();
            if (sess == null)
                return false;
            Model.Account acc = db.Accounts.Where(x => x.ID == sess.AccountID).First();
            if (acc.GroupID < 2)
                return false;
            Model.Customer cus = db.Customers.Where(x => x.ID == CustomerID).FirstOrDefault();
            if (cus == null)
                return false;
            cus.EmployeeAccept = acc.ID;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int addCustomer(string fullname, bool sex, string birthday, string address)
        {
            if (!CheckInput.CheckInputSqli(fullname) || !CheckInput.CheckInputSqli(sex.ToString()) || !CheckInput.CheckInputSqli(birthday)
                || !CheckInput.CheckInputSqli(address))
                return -1;
            Model.Customer cus = new Model.Customer();
            cus.FullName = fullname;
            cus.Sex = sex;
            cus.Birthday = Convert.ToDateTime(birthday);
            cus.Address = address;
            cus.AccountID = -1;
            cus.EmployeeAccept = -1;
            try
            {
                db.Customers.Add(cus);
                db.SaveChanges();
                return cus.ID;
            }
            catch
            {
                return -1;
            }
        }

        public bool editCustomer(string sessionID, string fullname, bool sex, string birthday, string address)
        {
            if (!CheckInput.CheckInputSqli(fullname) || !CheckInput.CheckInputSqli(sex.ToString()) || !CheckInput.CheckInputSqli(birthday)
                || !CheckInput.CheckInputSqli(address))
                return false;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID && x.Status == true).FirstOrDefault();
            if (sess == null)
                return false;
            Model.Account acc = db.Accounts.Where(x => x.ID == sess.AccountID).First();
            Model.Customer cus = db.Customers.Where(x => x.AccountID == acc.ID).First();
            cus.FullName = fullname;
            cus.Sex = sex;
            cus.Birthday = Convert.ToDateTime(birthday);
            cus.Address = address;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool addAccountToCustomer(int customerID, int accountID)
        {
            if (!CheckInput.CheckInputSqli(customerID.ToString()) || !CheckInput.CheckInputSqli(accountID.ToString()))
                return false;
            Model.Customer cus = db.Customers.Where(x => x.ID == customerID).FirstOrDefault();
            Model.Account acc = db.Accounts.Where(x => x.ID == accountID).FirstOrDefault();
            if (cus == null || acc == null || cus.AccountID != -1)
                return false;
            cus.AccountID = accountID;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string getAllCustomer(string sessionID)
        {
            if (!CheckInput.CheckInputSqli(sessionID))
                return string.Empty;
            if (SessionProcessing.CheckSessionID(sessionID) < 2)
                return string.Empty;
            List<Customer> listCustomer = db.Customers.ToList();
            if (listCustomer == null)
                return string.Empty;
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(listCustomer);
        }
        public string getCustomerByID(string sessionID, int customerID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(customerID.ToString()))
                return string.Empty;
            Customer result = new Customer();
            if (SessionProcessing.CheckSessionID(sessionID) < 2)
            {
                Session sess = db.Sessions.Where(x => x.SessionID == sessionID).First();
                Customer cus = db.Customers.Where(x => x.ID == customerID).FirstOrDefault();
                if (cus == null)
                    return string.Empty;
                if (sess.AccountID != cus.AccountID)
                    return string.Empty;
                result = cus;
            }
            else
            {
                Customer cus = db.Customers.Where(x => x.ID == customerID).FirstOrDefault();
                if (cus == null)
                    return string.Empty;
                result = cus;
            }
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(result);
        }
        public int addNewDrink(string sessionID, string name, string description, int typeDrink, bool status, int price)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(name) || !CheckInput.CheckInputSqli(description)
                || !CheckInput.CheckInputSqli(typeDrink.ToString()) || !CheckInput.CheckInputSqli(status.ToString()) || !CheckInput.CheckInputSqli(price.ToString()))
                return -1;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return -1;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID && x.Status == true).FirstOrDefault();

            Model.Drink dr = new Model.Drink();
            if (db.Drinks.ToList().Count == 0)
                dr.ID = 1;
            else
                dr.ID = db.Drinks.OrderByDescending(x => x.ID).First().ID + 1;
            dr.Name = name;
            dr.Description = description;
            dr.Type = typeDrink;
            dr.Status = status;
            dr.Price = price;
            dr.TimeCreate = DateTime.Now;
            dr.AccountCreate = sess.AccountID;
            try
            {
                db.Drinks.Add(dr);
                db.SaveChanges();
                return dr.ID;
            }
            catch
            {
                return -1;
            }
        }

        public int addNewTypeDrink(string sessionID, string name, string description)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(name) || !CheckInput.CheckInputSqli(description))
                return -1;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return -1;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID && x.Status == true).FirstOrDefault();

            TypeDrink type = new TypeDrink();
            if (db.TypeDrinks.ToList().Count == 0)
                type.ID = 1;
            else
                type.ID = db.TypeDrinks.OrderByDescending(x => x.ID).First().ID + 1;
            type.Name = name;
            type.Description = description;
            type.AccountCreate = sess.AccountID;
            type.TimeCreate = DateTime.Now;
            try
            {
                db.TypeDrinks.Add(type);
                db.SaveChanges();
                return type.ID;
            }
            catch
            {
                return -1;
            }
        }

        public bool deleteDrink(string sessionID, int drinkID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(drinkID.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return false;
            Model.Drink dr = db.Drinks.Where(x => x.ID == drinkID).FirstOrDefault();
            if (dr == null)
                return false;
            try
            {
                db.Drinks.Remove(dr);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteTypeDrink(string sessionID, int typeDrinkID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(typeDrinkID.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return false;
            TypeDrink type = db.TypeDrinks.Where(x => x.ID == typeDrinkID).FirstOrDefault();
            if (type == null)
                return false;
            try
            {
                db.TypeDrinks.Remove(type);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editDrink(string sessionID, int drinkID, string name, string description, int typeDrink, bool status, int price)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(name) || !CheckInput.CheckInputSqli(description) ||
                !CheckInput.CheckInputSqli(typeDrink.ToString()) || !CheckInput.CheckInputSqli(status.ToString()) || !CheckInput.CheckInputSqli(price.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return false;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID).First();
            Model.Drink dr = db.Drinks.Where(x => x.ID == drinkID).FirstOrDefault();
            if (dr == null)
                return false;
            dr.Name = name;
            dr.Description = description;
            dr.Type = typeDrink;
            dr.Status = status;
            dr.Price = price;
            dr.AccountChange = sess.AccountID;
            dr.TimeChange = DateTime.Now;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editTypeDrink(string sessionID, int typeDrinkID, string name, string description)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(name) || !CheckInput.CheckInputSqli(description) ||
                !CheckInput.CheckInputSqli(typeDrinkID.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) < 2)
                return false;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID).First();
            TypeDrink type = db.TypeDrinks.Where(x => x.ID == typeDrinkID).FirstOrDefault();
            if (type == null)
                return false;
            type.Name = name;
            type.Description = description;
            type.AccountChange = sess.AccountID;
            type.TimeChange = DateTime.Now;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool changeStatusDrink(string sessionID, int drinkID, bool status)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(drinkID.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) < 2)
                return false;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID).First();
            Model.Drink dr = db.Drinks.Where(x => x.ID == drinkID).FirstOrDefault();
            if (dr == null)
                return false;
            dr.Status = status;
            dr.AccountChange = sess.AccountID;
            dr.TimeChange = DateTime.Now;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string getAllDrink()
        {
            List<Model.Drink> list = db.Drinks.ToList();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string json = jsSerializer.Serialize(list);
            return json;
        }

        public string getDrinkByType(int type)
        {
            List<Model.Drink> list = db.Drinks.Where(x => x.Type == type).ToList();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string json = jsSerializer.Serialize(list);
            return json;
        }
        public string searchDrink(string txSearch)
        {
            List<Model.Drink> list = db.Drinks.Where(x => x.ID.ToString() == txSearch || x.Name == txSearch || x.Price.ToString() == txSearch).ToList();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string json = jsSerializer.Serialize(list);
            return json;
        }
        public string getAllType()
        {
            List<Model.TypeDrink> list = db.TypeDrinks.ToList();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string json = jsSerializer.Serialize(list);
            return json;
        }
        public string getTypeByID(int ID)
        {
            Model.TypeDrink list = db.TypeDrinks.Where(x => x.ID == ID).FirstOrDefault();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string json = jsSerializer.Serialize(list);
            return json;
        }
        public string getDrinkByID(int ID)
        {
            Model.Drink list = db.Drinks.Where(x => x.ID == ID).FirstOrDefault();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string json = jsSerializer.Serialize(list);
            return json;
        }

        #region topping
        public string getAllTopping()
        {
            List<Model.Topping> list = db.Toppings.ToList();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string json = jsSerializer.Serialize(list);
            return json;
        }
        public string searchTopping(string txSearch)
        {
            List<Model.Topping> list = db.Toppings.Where(x => x.ID.ToString() == txSearch || x.Name == txSearch || x.Price.ToString() == txSearch).ToList();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string json = jsSerializer.Serialize(list);
            return json;
        }
        public string getToppingByID(int ID)
        {
            Model.Topping list = db.Toppings.Where(x => x.ID == ID).FirstOrDefault();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string json = jsSerializer.Serialize(list);
            return json;
        }
        public int addNewTopping(string sessionID, string name, string description, bool status, int price)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(name) || !CheckInput.CheckInputSqli(description)
                || !CheckInput.CheckInputSqli(status.ToString()) || !CheckInput.CheckInputSqli(price.ToString()))
                return -1;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return -1;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID && x.Status == true).FirstOrDefault();

            Model.Topping tp = new Model.Topping();
            if (db.Toppings.ToList().Count == 0)
                tp.ID = 1;
            else
                tp.ID = db.Drinks.OrderByDescending(x => x.ID).First().ID + 1;
            tp.Name = name;
            tp.Description = description;
            tp.Status = status;
            tp.Price = price;
            tp.TimeCreate = DateTime.Now;
            tp.AccountCreate = sess.AccountID;
            try
            {
                db.Toppings.Add(tp);
                db.SaveChanges();
                return tp.ID;
            }
            catch
            {
                return -1;
            }
        }
        public bool editTopping(string sessionID, int drinkID, string name, string description, bool status, int price)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(name) || !CheckInput.CheckInputSqli(description) ||
                !CheckInput.CheckInputSqli(status.ToString()) || !CheckInput.CheckInputSqli(price.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return false;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID).First();
            Model.Topping tp = db.Toppings.Where(x => x.ID == drinkID).FirstOrDefault();
            if (tp == null)
                return false;
            tp.Name = name;
            tp.Description = description;
            tp.Status = status;
            tp.Price = price;
            tp.AccountChange = sess.AccountID;
            tp.TimeChange = DateTime.Now;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool changeStatusTopping(string sessionID, int toppingID, bool status)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(toppingID.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) < 2)
                return false;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID).First();
            Model.Topping tp = db.Toppings.Where(x => x.ID == toppingID).FirstOrDefault();
            if (tp == null)
                return false;
            tp.Status = status;
            tp.AccountChange = sess.AccountID;
            tp.TimeChange = DateTime.Now;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteTopping(string sessionID, int toppingID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(toppingID.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return false;
            Model.Topping tp = db.Toppings.Where(x => x.ID == toppingID).FirstOrDefault();
            if (tp == null)
                return false;
            try
            {
                db.Toppings.Remove(tp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        public bool addAccountToEmployee(string sessionID, int employeeID, int accountID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(employeeID.ToString()) || !CheckInput.CheckInputSqli(accountID.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return false;
            Model.Employee emp = db.Employees.Where(x => x.ID == employeeID).FirstOrDefault();
            Model.Account acc = db.Accounts.Where(x => x.ID == accountID).FirstOrDefault();
            if (emp == null || acc == null || emp.AccountID == -1)
            {
                return false;
            }
            emp.AccountID = accountID;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int addEmployee(string sessionID, string fullName, bool sex, string birthday, string address)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(fullName) || !CheckInput.CheckInputSqli(sex.ToString())
                || !CheckInput.CheckInputSqli(birthday) || !CheckInput.CheckInputSqli(address))
                return -1;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return -1;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID).First();

            Model.Employee emp = new Model.Employee();
            if (db.Employees.ToList().Count == 0)
                emp.ID = 1;
            else
                emp.ID = db.Employees.OrderByDescending(x => x.ID).First().ID + 1;
            emp.FullName = fullName;
            emp.Sex = sex;
            DateTime dt = new DateTime();
            if (!DateTime.TryParse(birthday, out dt))
            {
                return -1;
            }
            emp.Birthday = dt;
            emp.Address = address;
            emp.AccountID = -1;
            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return emp.ID;
            }
            catch
            {
                return -1;
            }
        }

        public bool deleteEmployee(string sessionID, int employeeID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(employeeID.ToString()))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return false;
            Model.Employee emp = db.Employees.Where(x => x.ID == employeeID).FirstOrDefault();
            if (emp == null)
                return false;
            if (emp.AccountID != -1)
            {
                Model.Account acc = db.Accounts.Where(x => x.ID == emp.AccountID).FirstOrDefault();
                if (acc != null)
                {
                    try
                    {
                        db.Accounts.Remove(acc);
                        db.SaveChanges();
                    }
                    catch
                    {

                    }
                }
            }
            try
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editEmployee(string sessionID, int employeeID, string fullname, bool sex, string birthday, string address)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(employeeID.ToString()) || !CheckInput.CheckInputSqli(fullname) || !CheckInput.CheckInputSqli(sex.ToString())
                || !CheckInput.CheckInputSqli(birthday) || !CheckInput.CheckInputSqli(address))
                return false;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return false;
            Model.Employee emp = db.Employees.Where(x => x.ID == employeeID).FirstOrDefault();
            if (emp == null)
                return false;
            emp.FullName = fullname;
            emp.Sex = sex;
            DateTime dt = new DateTime();
            if (!DateTime.TryParse(birthday, out dt))
            {
                return false;
            }
            emp.Birthday = dt;
            emp.Address = address;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Logout(string sessionID, int accountID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(accountID.ToString()))
                return false;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID).FirstOrDefault();
            if (sess == null)
                return false;
            sess.Status = false;
            sess.TimeEnd = DateTime.Now;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string _Login(string username, string password)
        {
            if (!CheckInput.CheckInputSqli(username) || !CheckInput.CheckInputSqli(password))
                return "ERROR";
            Model.Account acc = db.Accounts.Where(x => x.Username == username || x.Password == password).ToList().FirstOrDefault();
            if (acc == null)
                return "ERROR";
            List<string> listSess = db.Sessions.Select(x => x.SessionID).ToList();
            bool check = false;
            string newSess = "";
            while (!check)
            {
                newSess = SessionProcessing.RandomString(10);
                if (listSess.Where(x => x.Equals(newSess)).ToList().Count > 0)
                    continue;
                else
                    check = true;
            }
            Session sess = new Session();
            sess.SessionID = newSess;
            sess.AccountID = acc.ID;
            sess.Timecreate = DateTime.Now;
            sess.TimeEnd = DateTime.Now;
            sess.Status = true;
            try
            {
                db.Sessions.Add(sess);
                db.SaveChanges();
                return sess.SessionID;
            }
            catch
            {
                return "ERROR";
            }
        }

        public bool acceptOrder(string sessionID, int orderID, bool accept)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(orderID.ToString()) || !CheckInput.CheckInputSqli(accept.ToString()))
                return false;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID && x.Status == true).FirstOrDefault();
            if (sess == null)
                return false;
            OrderOnline order = db.OrderOnlines.Where(x => x.ID == orderID).FirstOrDefault();
            if (order == null)
                return false;
            if (order.EmployeeAccept != -1)
                return false;
            if (accept == true)
            {
                order.EmployeeAccept = db.Employees.Where(x => x.AccountID == sess.AccountID).First().ID;
                order.TimeAccept = DateTime.Now;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public int addOrder(string sessionID, string address, string phoneNumber)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(address) || !CheckInput.CheckInputSqli(phoneNumber))
                return -1;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID && x.Status == true).FirstOrDefault();
            if (sess == null)
                return -1;
            Customer cus = db.Customers.Where(x => x.AccountID == sess.AccountID).FirstOrDefault();
            if (cus == null)
                return -1;
            OrderOnline order = new OrderOnline();
            if (db.OrderOnlines.ToList().Count == 0)
                order.ID = 1;
            else
                order.ID = db.OrderOnlines.OrderByDescending(x => x.ID).First().ID + 1;
            order.CustomerID = cus.ID;
            order.PhoneNumber = phoneNumber;
            order.Address = address;
            order.EmployeeAccept = -1;
            order.TimeOrder = DateTime.Now;
            order.TimeAccept = DateTime.MinValue;
            order.TotalMoney = 0;
            try
            {
                db.OrderOnlines.Add(order);
                db.SaveChanges();
                return order.ID;
            }
            catch
            {
                return -1;
            }
        }

        public bool addOrderDetail(string sessionID, int orderID, int itemOrderID, int numberOrder, bool typeItem)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(orderID.ToString()) || !CheckInput.CheckInputSqli(itemOrderID.ToString())
                || !CheckInput.CheckInputSqli(numberOrder.ToString()) || !CheckInput.CheckInputSqli(typeItem.ToString()))
                return false;
            Session sess = db.Sessions.Where(x => x.SessionID == sessionID && x.Status == true).FirstOrDefault();
            if (sess == null)
                return false;
            int price;
            if (typeItem)
            {
                Drink dr = db.Drinks.Where(x => x.ID == itemOrderID).FirstOrDefault();
                if (dr == null)
                    return false;
                price = dr.Price;
            }
            else
            {
                Topping tp = db.Toppings.Where(x => x.ID == itemOrderID).FirstOrDefault();
                if (tp == null)
                    return false;
                price = tp.Price;
            }
            OrderOnlineDetail orderDetail = new OrderOnlineDetail();
            orderDetail.OrderOnlineID = orderID;
            orderDetail.ItemOrderID = itemOrderID;
            orderDetail.NumberOrder = numberOrder;
            orderDetail.Price = price;
            orderDetail.TotalMoneyDetail = price * numberOrder;
            orderDetail.TypeItem = typeItem;
            try
            {
                db.OrderOnlineDetails.Add(orderDetail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CancelOrder(string sessionID, int orderID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(orderID.ToString()))
                return false;
            int check = SessionProcessing.CheckSessionID(sessionID);
            if (check != 1 && check != 3)
                return false;
            return true;
        }

        public bool editOrderDetail(string sessionID, int orderID, int itemOrderID, int numberOrder)
        {
            throw new NotImplementedException();
        }

        public string getAllOrder(string sessionID)
        {
            if (!CheckInput.CheckInputSqli(sessionID))
                return string.Empty;
            if (SessionProcessing.CheckSessionID(sessionID) < 2)
                return string.Empty;
            List<OrderOnline> listOrder = db.OrderOnlines.ToList();
            if (listOrder == null)
                return string.Empty;
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(listOrder);
        }
        public string getOrderByID(string sessionID, int OrderID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(OrderID.ToString()))
                return string.Empty;
            if (SessionProcessing.CheckSessionID(sessionID) < 2)
                return string.Empty;
            List<OrderOnline> listOrder = db.OrderOnlines.Where(x => x.ID == OrderID).ToList();
            if (listOrder == null)
                return string.Empty;
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(listOrder);
        }
        public string getOrderDetail(string sessionID, int OrderID)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(OrderID.ToString()))
                return string.Empty;
            if (SessionProcessing.CheckSessionID(sessionID) < 2)
                return string.Empty;
            List<OrderOnlineDetail> listOrderDetail = db.OrderOnlineDetails.Where(x => x.OrderOnlineID == OrderID).ToList();
            if (listOrderDetail == null)
                return string.Empty;
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(listOrderDetail);
        }

        public string SalesStatistics(string sessionID, string typeSatistic, int year, int numberQuarter, int month, int week)
        {
            if (!CheckInput.CheckInputSqli(sessionID) || !CheckInput.CheckInputSqli(typeSatistic) || !CheckInput.CheckInputSqli(year.ToString())
                || !CheckInput.CheckInputSqli(numberQuarter.ToString()) || !CheckInput.CheckInputSqli(month.ToString()) || !CheckInput.CheckInputSqli(week.ToString()))
                return string.Empty;
            if (SessionProcessing.CheckSessionID(sessionID) != 3)
                return string.Empty;
            DataTable result = new DataTable();
            result.Columns.Add("SALES");
            result.Columns.Add("TIME");
            switch (typeSatistic)
            {
                case "YEAR":
                    {
                        List<Bill> listBillInYear = db.Bills.Where(x => x.TimeCreate.Year == year && x.StatusBill == true).OrderBy(y => y.TimeCreate.Month).ToList();
                        if (listBillInYear == null)
                        {

                        }
                        for(int i = 1; i <= 12; i++)
                        {
                            int totalSales = 0;
                            List<Bill> listBillInMonth = listBillInYear.Where(x => x.TimeCreate.Month == i).ToList();
                            
                        }
                        break;
                    }
                case "QUARTER":
                    {
                        break;
                    }
                case "MONTH":
                    {
                        break;
                    }
                case "WEEK":
                    {
                        break;
                    }
            }
            return string.Empty;
        }
    }
}
