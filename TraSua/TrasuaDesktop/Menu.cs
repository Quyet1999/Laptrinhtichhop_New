using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrasuaDesktop.TrasuaWCFService;
using TrasuaDesktop.EntityModel;
using System.Web.Script.Serialization;

namespace TrasuaDesktop
{
    public partial class Menu : UserControl
    {
        string sessionID;
        int accountID;

        //TrasuaWCFService.WCF_TrasuaClient service = new TrasuaWCFService.WCF_TrasuaClient();
        List<Drink> listDrink = new List<Drink>();
        List<TypeDrink> listTypeDrink = new List<TypeDrink>();
        public Menu(string _sessionID, int _accountID)
        {
            InitializeComponent();
            sessionID = _sessionID; 
            accountID = _accountID;
            LoadForm();
        }
        void LoadData()
        {
            using (WCF_TrasuaClient service = new WCF_TrasuaClient())
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                listDrink = jsSerializer.Deserialize<List<EntityModel.Drink>>(service.getAllDrink());
                listTypeDrink = jsSerializer.Deserialize<List<EntityModel.TypeDrink>>(service.getAllType());
            }
        }

        void LoadListDrink(List<Drink> _listDrink)
        {
            dgListDrink.Rows.Clear();
            //dgListDrink.Columns.Clear();
            //dgListDrink.Columns.Add("ID", "ID");
            //dgListDrink.Columns.Add("Name", "Tên đồ uống");
            //dgListDrink.Columns.Add("Type", "Loại đồ uống");
            //dgListDrink.Columns.Add("Price", "Giá");
            //dgListDrink.Columns.Add("Status", "Trạng thái");
            //DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            //btnCol.Name = "btnChangeStatus";
            //btnCol.CellTemplate.Value = "Sửa";
            //btnCol.CellTemplate.Style.BackColor = Color.GreenYellow;
            //dgListDrink.Columns.Add(btnCol);

            if (_listDrink == null || _listDrink.Count == 0)
                return;

            foreach(Drink dr in _listDrink)
            {
                int id = dr.ID;
                string name = dr.Name;
                string typeDrink = listTypeDrink.Where(x => x.ID == dr.Type).First().Name;
                string price = dr.Price.ToString();
                string status = dr.Status == true ? "Còn" : "Hết";
                bool check= false;
                dgListDrink.Rows.Add(id.ToString(), name, typeDrink, price, status, check);
            }
        }
        void LoadForm()
        {
            LoadData();
            LoadListDrink(listDrink);
            cbDrinkType.Items.Clear();
            cbShowDrinkType.Items.Clear();
            listTypeDrink = listTypeDrink.OrderBy(x => x.ID).ToList();
            foreach (TypeDrink type in listTypeDrink)
            {
                cbDrinkType.Items.Add(type.Name);
                cbShowDrinkType.Items.Add(type.Name);
            }
            btSave.Visible = btCancel.Visible = false;
        }
        void LoadDetailsDrink(int DrinkID)
        {
            using(TrasuaWCFService.WCF_TrasuaClient service=new WCF_TrasuaClient())
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                Drink dr = jsSerializer.Deserialize<Drink>(service.getDrinkByID(DrinkID));
                txbID.Text = DrinkID.ToString();
                txbDrink.Text = dr.Name;
                txbDescription.Text = dr.Description;
                txbEmployeeCreate.Text = dr.AccountCreate.ToString();
                txbPrice.Text = dr.Price.ToString();
                TypeDrink type = jsSerializer.Deserialize<TypeDrink>(service.getTypeByID(dr.Type));
                cbDrinkType.SelectedItem = type.Name;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (WCF_TrasuaClient service = new WCF_TrasuaClient())
            {
                if (txbSearch.Text.Equals(string.Empty))
                    return;
                string search = txbSearch.Text;
                List<Drink> result = new JavaScriptSerializer().Deserialize<List<Drink>>(service.searchDrink(search));
                LoadListDrink(result);
            }
        }

        private void cbShowDrinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (WCF_TrasuaClient service = new WCF_TrasuaClient())
            {
                string type = cbShowDrinkType.SelectedItem.ToString();
                int typeID = listTypeDrink.Where(x => x.Name.Equals(type)).First().ID;
                List<Drink> result = new JavaScriptSerializer().Deserialize<List<Drink>>(service.getDrinkByType(typeID));
                LoadListDrink(result);
            }
        }

        private void dgListDrink_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            int ID = Convert.ToInt32(dgListDrink.Rows[e.RowIndex].Cells[0].Value);
            LoadDetailsDrink(ID);
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dgListDrink.Rows.Count == 0)
                return;
            using (WCF_TrasuaClient service = new WCF_TrasuaClient())
            {
                foreach (DataGridViewRow row in dgListDrink.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[5].Value) == true)
                    {
                        int drinkID = Convert.ToInt32(row.Cells[0].Value);
                        bool status = row.Cells[4].Value.ToString().Equals("Còn") ? false : true;
                        bool result = service.changeStatusDrink(sessionID, drinkID, status);
                        if (result == false)
                        {
                            MessageBox.Show("Bạn không thể thực hiện thao tác này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                LoadData();
                LoadListDrink(listDrink);
            }
        }
        void EnableBtnSave()
        {
            btSave.Visible = btCancel.Visible = true;
            btnUpdate.Enabled = btnDelete.Enabled = btnAdd.Enabled = false;
        }
        void DisableBtnSave()
        {
            btSave.Visible = btCancel.Visible = false;
            btnUpdate.Enabled = btnDelete.Enabled = btnAdd.Enabled = true;
        }
        void ClearDetailInfo()
        {
            txbID.Text = txbDescription.Text = txbDrink.Text = txbEmployeeCreate.Text = txbPrice.Text = string.Empty;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableBtnSave();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EnableBtnSave();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                using (WCF_TrasuaClient service = new WCF_TrasuaClient())
                {
                    int ID = Int32.Parse(txbID.Text);
                    bool resutDelete = service.deleteDrink(sessionID, ID);
                    if (resutDelete == true)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (txbID.Text == "")
            {
                int price = Int32.Parse(txbPrice.Text);
                int type = listTypeDrink.Where(x => x.Name == cbDrinkType.SelectedItem.ToString()).First().ID;
                using(WCF_TrasuaClient service=new WCF_TrasuaClient())
                {
                    int result = service.addNewDrink(sessionID, txbDrink.Text, txbDescription.Text, type, true, price);
                    if (result == -1)
                    {
                        MessageBox.Show("Bạn không thể thêm đồ uống này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        LoadListDrink(listDrink);
                        DisableBtnSave();
                        return;
                    }
                }
            }
            else
            {
                int ID = Int32.Parse(txbID.Text);
                int price = Int32.Parse(txbPrice.Text);
                int type = listTypeDrink.Where(x => x.Name == cbDrinkType.SelectedItem.ToString()).First().ID;
                bool status = cbStatusDrink.SelectedIndex == 0 ? true : false;
                using(WCF_TrasuaClient service=new WCF_TrasuaClient())
                {
                    bool result = service.editDrink(sessionID, ID, txbDrink.Text, txbDescription.Text, type, status, price);
                    if (result == true)
                    {
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        LoadListDrink(listDrink);
                        DisableBtnSave();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Bạn không thể sửa đồ uống này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (txbID.Text.Equals(string.Empty))
            {
                ClearDetailInfo();
                DisableBtnSave();
            }
            else
            {
                LoadDetailsDrink(Int32.Parse(txbID.Text));
                DisableBtnSave();
            }
        }
    }
}
