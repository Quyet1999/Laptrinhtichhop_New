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
using TrasuaDesktop.Process;
using TrasuaDesktop.TrasuaWCFService;

namespace TrasuaDesktop
{
    public partial class OnlineOrder : UserControl
    {
        string sessionID;

        List<OrderOnline> listOrder;
        List<Customer> listCustomer;

        OrderOnline curOrder;
        public OnlineOrder(string _sessionID)
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
                listOrder = jsSerializer.Deserialize<List<OrderOnline>>(service.getAllOrder(sessionID));
                listCustomer = jsSerializer.Deserialize<List<Customer>>(service.getAllCustomer(sessionID));
            }
        }
        void LoadListOrder(List<OrderOnline> _listOrder)
        {
            dgListOrder.Rows.Clear();
            if (_listOrder == null)
                return;
            foreach (OrderOnline item in _listOrder)
            {
                Customer cus = listCustomer.Where(x => x.ID == item.CustomerID).First();
                dgListOrder.Rows.Add(item.ID, item.TimeOrder, cus.FullName, cus.ID, item.Address, item.PhoneNumber, item.TotalMoney);
            }
        }
        void LoadForm()
        {
            LoadData();
            LoadListOrder(listOrder);
        }

        void LoadOrderDetail(OrderOnline order)
        {
            txbOrderID.Text = order.ID.ToString();
            txBillID.Text = string.Empty;
            txbAddress.Text = order.Address;
            txbCustomerName.Text = listCustomer.Where(x => x.ID == order.CustomerID).First().FullName;
            txbPhoneNumber.Text = order.PhoneNumber;
            cbBillStatus.SelectedIndex = 0;
            lbTotalMoney.Text = order.TotalMoney.ToString();
            using (WCF_TrasuaClient service = new WCF_TrasuaClient())
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<OrderOnlineDetail> listOrderDetail = jsSerializer.Deserialize<List<OrderOnlineDetail>>(service.getOrderDetail(sessionID, order.ID));
                if (listOrderDetail == null)
                    return;
                foreach (OrderOnlineDetail item in listOrderDetail)
                {
                    string itemName;
                    if (item.TypeItem == 1)
                    {
                        Drink dr = jsSerializer.Deserialize<Drink>(service.getDrinkByID(item.ItemOrderID));
                        itemName = dr.Name;
                    }
                    else
                    {
                        Topping tp = jsSerializer.Deserialize<Topping>(service.getToppingByID(item.ItemOrderID));
                        itemName = tp.Name;
                    }
                    dgBillDetail.Rows.Add(itemName, item.Price, item.TotalMoneyDetail, item.TypeItem, item.ItemOrderID);
                }
            }
        }

        private void dgListOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            int OrderID = Convert.ToInt32(dgListOrder.Rows[e.RowIndex].Cells[0].Value);
            curOrder = listOrder.Where(x => x.ID == OrderID).First();
            LoadOrderDetail(curOrder);
        }

        private void btn_Click(object sender, EventArgs e)
        {

        }

        private void btnAcceptBill_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveBill_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {

        }
    }
}
