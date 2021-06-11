using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using TrasuaDesktop.EntityModel;
using TrasuaDesktop.TrasuaWCFService;

namespace TrasuaDesktop
{
    public partial class AddBill : UserControl
    {
        string sessionID;

        List<Drink> listDrink;
        List<TypeDrink> listTypeDrink;
        List<Topping> listTopping;
        List<MenuItem> listControlItem;
        List<BillDetail> listItemInBill;

        BillDetail curDetail;

        bool StatusBill = false;

        public enum type
        {
            DRINK,
            TOPPING
        }

        string TYPE_MENU = type.DRINK.ToString();

        public AddBill(string _sessionID)
        {
            InitializeComponent();
            sessionID = _sessionID;
            LoadForm();
        }
        void LoadData()
        {
            using (WCF_TrasuaClient service = new WCF_TrasuaClient())
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                listDrink = jsSerializer.Deserialize<List<Drink>>(service.getAllDrink());
                listTypeDrink = jsSerializer.Deserialize<List<TypeDrink>>(service.getAllType());
                listTopping = jsSerializer.Deserialize<List<Topping>>(service.getAllTopping());
            }
            listControlItem = new List<MenuItem>();
            listItemInBill = new List<BillDetail>();
        }
        void LoadForm()
        {
            LoadData();
            DrawListItem(listDrink);
        }
        void LoadDefaultBill()
        {
            txBillID.Text = txbCustomerName.Text = string.Empty;
            cbBillStatus.SelectedIndex = 0;
            lbTotalMoney.Text = "0 đ";
            dgBillDetail.Rows.Clear();
            btnPrintBill.Enabled = false;
        }

        #region design menu
        int ITEM_WIDTH = 200;
        int ITEM_HEIGHT = 240;
        int SPACE_X = 25;
        int SPACE_Y = 22;
        int NUMBER_IN_ROW = 5;
        int START_POSITION_X = 3;
        int START_POSITION_Y = 3;
        int CURRENT_POSITION_X = 3;
        int CURRENT_POSITION_Y = 3;
        void DrawListItem(List<Drink> listDrink)
        {
            CURRENT_POSITION_X = START_POSITION_X;
            CURRENT_POSITION_Y = START_POSITION_Y;
            pnDrawMenu.Controls.Clear();
            int numberItem = listDrink.Count;
            int numberColumn = listDrink.Count / NUMBER_IN_ROW + 1;
            for (int i = 0; i < numberColumn; i++)
            {
                int numberInrow = i != (numberColumn - 1) ? NUMBER_IN_ROW : (listDrink.Count - NUMBER_IN_ROW * (numberColumn - 1));
                for (int j = 0; j < numberInrow; j++)
                {
                    int index = i * NUMBER_IN_ROW + j;
                    Drink drinkCurrent = listDrink[index];
                    MenuItem item = new MenuItem(drinkCurrent.Name, drinkCurrent.Price);
                    item.Location = new Point(CURRENT_POSITION_X, CURRENT_POSITION_Y);
                    item.Name = "item" + drinkCurrent.ID;
                    item.btnAddItem.Click += BtnAddItem_Click;
                    pnDrawMenu.Controls.Add(item);
                    listControlItem.Add(item);
                    CURRENT_POSITION_X += ITEM_WIDTH + SPACE_X;
                }
                CURRENT_POSITION_X = START_POSITION_X;
                CURRENT_POSITION_Y += ITEM_HEIGHT + SPACE_Y;
            }
        }
        void DrawListItem(List<Topping> listTopping)
        {
            CURRENT_POSITION_X = START_POSITION_X;
            CURRENT_POSITION_Y = START_POSITION_Y;
            pnDrawMenu.Controls.Clear();
            listControlItem.Clear();
            int numberItem = listDrink.Count;
            int numberColumn = listDrink.Count / NUMBER_IN_ROW + 1;
            for (int i = 0; i < numberColumn; i++)
            {
                int numberInrow = i != (numberColumn - 1) ? NUMBER_IN_ROW : (listDrink.Count - NUMBER_IN_ROW * (numberColumn - 1));
                for (int j = 0; j < numberInrow; j++)
                {
                    int index = i * NUMBER_IN_ROW + j;
                    Topping topppingCurrent = listTopping[index];
                    MenuItem item = new MenuItem(topppingCurrent.Name, topppingCurrent.Price);
                    item.Location = new Point(CURRENT_POSITION_X, CURRENT_POSITION_Y);
                    item.Name = "item" + topppingCurrent.ID;
                    item.btnAddItem.Click += BtnAddItem_Click;
                    pnDrawMenu.Controls.Add(item);
                    listControlItem.Add(item);
                    CURRENT_POSITION_X += ITEM_WIDTH + SPACE_X;
                }
                CURRENT_POSITION_X = START_POSITION_X;
                CURRENT_POSITION_Y += ITEM_HEIGHT + SPACE_Y;
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (StatusBill == true)
            {
                MessageBox.Show("Không thể thêm vào hóa đơn đã lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Button btn = sender as Button;
            foreach (MenuItem item in listControlItem)
            {
                if (item.btnAddItem == btn)
                {
                    int ItemID = Convert.ToInt32(item.Name.Replace("item", string.Empty));
                    int Price;
                    bool typeItem;
                    if (TYPE_MENU == type.DRINK.ToString())
                    {
                        Drink dr = listDrink.Where(x => x.ID == ItemID).First();
                        Price = dr.Price;
                        typeItem = true;
                    }
                    else
                    {
                        Topping tp = listTopping.Where(x => x.ID == ItemID).First();
                        Price = tp.Price;
                        typeItem = false;
                    }
                    BillDetail curDetail = listItemInBill.Where(x => x.ItemID == ItemID && x.TypeItem == typeItem).ToList().FirstOrDefault();
                    if (curDetail == null)
                    {
                        curDetail = new BillDetail();
                        curDetail.ItemID = ItemID;
                        curDetail.NumberItem = 1;
                        curDetail.Price = Price;
                        curDetail.TotalMoneyDetail = Price;
                        curDetail.TypeItem = typeItem;
                        listItemInBill.Add(curDetail);
                    }
                    else
                    {
                        for (int i = 0; i < listItemInBill.Count; i++)
                        {
                            if (listItemInBill[i].ItemID == curDetail.ItemID && listItemInBill[i].TypeItem == curDetail.TypeItem)
                            {
                                listItemInBill[i].NumberItem += 1;
                                listItemInBill[i].TotalMoneyDetail = curDetail.NumberItem * curDetail.Price;
                            }
                        }
                    }
                    LoadBillDetail(listItemInBill);
                    return;
                }
            }
        }

        #endregion

        void LoadBillDetail(List<BillDetail> listDetail)
        {
            dgBillDetail.Rows.Clear();
            int TotalMoney = 0;
            if (listDetail == null || listDetail.Count == 0)
            {
                return;
            }
            foreach (BillDetail detail in listDetail)
            {
                string nameItem = string.Empty;
                if (detail.TypeItem == true)
                {
                    Drink dr = listDrink.Where(x => x.ID == detail.ItemID).First();
                    nameItem = dr.Name;
                }
                else
                {
                    Topping tp = listTopping.Where(x => x.ID == detail.ItemID).First();
                    nameItem = tp.Name;
                }
                dgBillDetail.Rows.Add(nameItem, detail.NumberItem, detail.TotalMoneyDetail, detail.TypeItem, detail.ItemID);
                TotalMoney += detail.TotalMoneyDetail;
            }
            lbTotalMoney.Text = TotalMoney.ToString() + " đ";
            cbBillStatus.SelectedIndex = 0;
        }

        private void dgBillDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool typeItem = Convert.ToBoolean(dgBillDetail.Rows[e.RowIndex].Cells[3].Value);
            string itemName = dgBillDetail.Rows[e.RowIndex].Cells[0].Value.ToString();
            int ItemID = Convert.ToInt32(dgBillDetail.Rows[e.RowIndex].Cells[4].Value);
            curDetail = listItemInBill.Where(x => x.ItemID == ItemID && x.TypeItem == typeItem).First();
        }

        private void btnAddNumberItem_Click(object sender, EventArgs e)
        {
            if (curDetail == null)
                return;
            for (int i = 0; i < listItemInBill.Count; i++)
            {
                if (listItemInBill[i].ItemID == curDetail.ItemID && listItemInBill[i].TypeItem == curDetail.TypeItem)
                {
                    listItemInBill[i].NumberItem++;
                    listItemInBill[i].TotalMoneyDetail = listItemInBill[i].Price * listItemInBill[i].NumberItem;
                    LoadBillDetail(listItemInBill);
                    return;
                }
            }
        }

        private void btnSubtractNumberItem_Click(object sender, EventArgs e)
        {
            if (curDetail == null)
                return;
            for (int i = 0; i < listItemInBill.Count; i++)
            {
                if (listItemInBill[i].ItemID == curDetail.ItemID && listItemInBill[i].TypeItem == curDetail.TypeItem)
                {
                    if (listItemInBill[i].NumberItem == 1)
                    {
                        listItemInBill.RemoveAt(i);
                    }
                    else
                    {
                        listItemInBill[i].NumberItem--;
                        listItemInBill[i].TotalMoneyDetail = listItemInBill[i].Price * listItemInBill[i].NumberItem;
                    }
                    LoadBillDetail(listItemInBill);
                    return;
                }
            }
        }

        private void btnCancelBill_Click(object sender, EventArgs e)
        {
            LoadDefaultBill();
        }

        private void btnCreateNewBill_Click(object sender, EventArgs e)
        {
            LoadDefaultBill();
        }

        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            bool StatusBill = cbBillStatus.SelectedIndex == 0 ? false : true;
            int IDCustomer = 0;
            int result = -1;
            using (WCF_TrasuaClient service = new WCF_TrasuaClient())
            {
                result = service.addBill(sessionID, IDCustomer, StatusBill);
                if (result != -1)
                {
                    txBillID.Text = result.ToString();
                    foreach (BillDetail item in listItemInBill)
                    {
                        service.addBillDetail(sessionID, result, item.ItemID, item.NumberItem, item.TypeItem);
                    }
                    btnPrintBill.Enabled = true;
                    btnSaveBill.Enabled = btnCancelBill.Enabled = false;
                    StatusBill = true;
                }
                else
                {
                    MessageBox.Show("Không thể lưu hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {

        }

        private void btDrink_Click(object sender, EventArgs e)
        {
            TYPE_MENU = type.DRINK.ToString();
            DrawListItem(listDrink);

        }

        private void btTopping_Click(object sender, EventArgs e)
        {
            TYPE_MENU = type.TOPPING.ToString();
            DrawListItem(listTopping);
        }
    }
}
