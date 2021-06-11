using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TrasuaService.Model;

namespace TrasuaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCF_Trasua" in both code and config file together.
    [ServiceContract]
    public interface IWCF_Trasua
    {
        [OperationContract]
        bool AddAccount(string sessionID, string username, string password, int groupID);
        [OperationContract]
        bool EditPasswordAccount(string sessionID, int accountID, string newPassword);
        [OperationContract]
        bool EditPermissionAccount(string sessionID, int accountID, int newGroupID);
        [OperationContract]
        bool DeleteAccount(string sessionID, int accountID);
        [OperationContract]
        bool EditStatusAccount(string sessionID, int accountID, bool newStatus);
        [OperationContract]
        int getAccountID(string sessionID);

        [OperationContract]
        int addBill(string sessionID, int customerID, bool statusBill);
        [OperationContract]
        bool editBill(string sessionID, int billID, int customerID, bool statusBill);
        [OperationContract]
        bool addBillDetail(string sessionID, int billID, int itemID, int numberItem, bool typeItem);
        [OperationContract]
        bool editBillDetail(string sessionID, int billID, int itemID, int nNumberItem, bool typeItem);

        [OperationContract]
        int addCustomer(string fullname, bool sex, string birthday, string address);
        [OperationContract]
        bool editCustomer(string sessionID, string fullname, bool sex, string birthday, string address);
        [OperationContract]
        bool acceptCustomer(string sessionID, int CustomerID);
        [OperationContract]
        bool addAccountToCustomer(int CustomerID, int AccountID);
        [OperationContract]
        string getAllCustomer(string sessionID);
        [OperationContract]
        string getCustomerByID(string sessionID, int customerID);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        string getAllDrink();
        [OperationContract]
        string getDrinkByType(int type);
        [OperationContract]
        string searchDrink(string txSearch);
        [OperationContract]
        string getAllType();
        [OperationContract]
        string getTypeByID(int ID);
        [OperationContract]
        string getDrinkByID(int ID);
        [OperationContract]
        int addNewDrink(string sessionID, string name, string description, int typeDrink, bool status
            , int price);
        [OperationContract]
        int addNewTypeDrink(string sessionID, string name, string description);
        [OperationContract]
        bool editDrink(string sessionID, int drinkID, string name, string description, int typeDrink, bool status
            , int price);
        [OperationContract]
        bool changeStatusDrink(string sessionID, int drinkID, bool status);
        [OperationContract]
        bool editTypeDrink(string sessionID, int typeDrinkID, string name, string description);
        [OperationContract]
        bool deleteDrink(string sessionID, int drinkID);
        [OperationContract]
        bool deleteTypeDrink(string sessionID, int typeDrinkID);


        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        string getAllTopping();
        [OperationContract]
        string searchTopping(string txSearch);
        [OperationContract]
        string getToppingByID(int ID);
        [OperationContract]
        int addNewTopping(string sessionID, string name, string description,  bool status
            , int price);
        [OperationContract]
        bool editTopping(string sessionID, int drinkID, string name, string description, bool status
            , int price);
        [OperationContract]
        bool changeStatusTopping(string sessionID, int toppingID, bool status);
        [OperationContract]
        bool deleteTopping(string sessionID, int toppingID);


        [OperationContract]
        int addEmployee(string sessionID, string fullName, bool sex, string birthday, string address);
        [OperationContract]
        bool editEmployee(string sessionID, int employeeID, string fullename, bool sex, string birthday, string address);
        [OperationContract]
        bool addAccountToEmployee(string sessionID, int employeeID, int accountID);
        [OperationContract]
        bool deleteEmployee(string sessionID, int employeeID);

        [OperationContract]
        string _Login(string username, string password);
        [OperationContract]
        bool Logout(string sessionID, int accountID);

        [OperationContract]
        int addOrder(string sessionID, string address, string phoneNumber);
        [OperationContract]
        bool acceptOrder(string sessionID, int orderID, bool accept);
        [OperationContract]
        bool CancelOrder(string sessionID, int orderID);
        [OperationContract]
        bool addOrderDetail(string sessionID, int orderID, int itemOrderID, int numberOrder
            ,  bool typeItem);
        [OperationContract]
        bool editOrderDetail(string sessionID, int orderID, int itemOrderID, int numberOrder);
        [OperationContract]
        string getAllOrder(string sessionID);
        [OperationContract]
        string getOrderByID(string sessionID, int OrderID);
        [OperationContract]
        string getOrderDetail(string sessionID, int OrderID);



        [OperationContract]
        string SalesStatistics(string sessionID, string typeSatistic, int year, int numberQuarter, int month, int week);
    }
}
