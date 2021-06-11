
namespace TrasuaDesktop
{
    partial class BillManager
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnAddNumberItem = new System.Windows.Forms.Button();
            this.btnSubtractNumberItem = new System.Windows.Forms.Button();
            this.lbTotalMoney = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgBillDetail = new System.Windows.Forms.DataGridView();
            this.DrinkOrTopping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoneyItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbTypeCustomer = new System.Windows.Forms.ComboBox();
            this.txbCustomerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txBillID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 34);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hóa đơn";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillID,
            this.Employee,
            this.EmployeeID,
            this.SaleType,
            this.TimeCreate,
            this.StatusBill});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(32, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1134, 795);
            this.dataGridView1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(902, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1045, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 40);
            this.button2.TabIndex = 9;
            this.button2.Text = "Xuất ra file";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(1141, 893);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 25);
            this.button3.TabIndex = 10;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(1010, 893);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 25);
            this.button4.TabIndex = 11;
            this.button4.Text = "<";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(1041, 895);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Trang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1116, 895);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BillID
            // 
            this.BillID.HeaderText = "Mã hóa đơn";
            this.BillID.MinimumWidth = 6;
            this.BillID.Name = "BillID";
            // 
            // Employee
            // 
            this.Employee.HeaderText = "Nhân viên thanh toán";
            this.Employee.MinimumWidth = 6;
            this.Employee.Name = "Employee";
            // 
            // EmployeeID
            // 
            this.EmployeeID.HeaderText = "Column1";
            this.EmployeeID.MinimumWidth = 6;
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.Visible = false;
            // 
            // SaleType
            // 
            this.SaleType.HeaderText = "Kênh mua hàng";
            this.SaleType.MinimumWidth = 6;
            this.SaleType.Name = "SaleType";
            // 
            // TimeCreate
            // 
            this.TimeCreate.HeaderText = "Thời gian tạo";
            this.TimeCreate.MinimumWidth = 6;
            this.TimeCreate.Name = "TimeCreate";
            // 
            // StatusBill
            // 
            this.StatusBill.HeaderText = "Trạng thái";
            this.StatusBill.MinimumWidth = 6;
            this.StatusBill.Name = "StatusBill";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.textBox2);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.btnAddNumberItem);
            this.panel5.Controls.Add(this.btnSubtractNumberItem);
            this.panel5.Controls.Add(this.lbTotalMoney);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.dgBillDetail);
            this.panel5.Controls.Add(this.cbTypeCustomer);
            this.panel5.Controls.Add(this.txbCustomerName);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.txBillID);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(1186, 81);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(469, 795);
            this.panel5.TabIndex = 14;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // btnAddNumberItem
            // 
            this.btnAddNumberItem.Location = new System.Drawing.Point(400, 234);
            this.btnAddNumberItem.Name = "btnAddNumberItem";
            this.btnAddNumberItem.Size = new System.Drawing.Size(30, 30);
            this.btnAddNumberItem.TabIndex = 35;
            this.btnAddNumberItem.Text = "+";
            this.btnAddNumberItem.UseVisualStyleBackColor = true;
            // 
            // btnSubtractNumberItem
            // 
            this.btnSubtractNumberItem.Location = new System.Drawing.Point(436, 234);
            this.btnSubtractNumberItem.Name = "btnSubtractNumberItem";
            this.btnSubtractNumberItem.Size = new System.Drawing.Size(30, 30);
            this.btnSubtractNumberItem.TabIndex = 6;
            this.btnSubtractNumberItem.Text = "-";
            this.btnSubtractNumberItem.UseVisualStyleBackColor = true;
            // 
            // lbTotalMoney
            // 
            this.lbTotalMoney.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTotalMoney.Location = new System.Drawing.Point(357, 753);
            this.lbTotalMoney.Name = "lbTotalMoney";
            this.lbTotalMoney.Size = new System.Drawing.Size(109, 19);
            this.lbTotalMoney.TabIndex = 34;
            this.lbTotalMoney.Text = "100 000đ";
            this.lbTotalMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(253, 753);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 19);
            this.label7.TabIndex = 33;
            this.label7.Text = "Tổng tiền";
            // 
            // dgBillDetail
            // 
            this.dgBillDetail.AllowUserToAddRows = false;
            this.dgBillDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBillDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgBillDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgBillDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgBillDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgBillDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgBillDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBillDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DrinkOrTopping,
            this.NumberItem,
            this.TotalMoneyItem,
            this.TypeItem,
            this.ID});
            this.dgBillDetail.GridColor = System.Drawing.Color.White;
            this.dgBillDetail.Location = new System.Drawing.Point(0, 270);
            this.dgBillDetail.Name = "dgBillDetail";
            this.dgBillDetail.RowHeadersVisible = false;
            this.dgBillDetail.RowHeadersWidth = 51;
            this.dgBillDetail.RowTemplate.Height = 24;
            this.dgBillDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBillDetail.Size = new System.Drawing.Size(466, 459);
            this.dgBillDetail.TabIndex = 30;
            // 
            // DrinkOrTopping
            // 
            this.DrinkOrTopping.HeaderText = "Tên món";
            this.DrinkOrTopping.MinimumWidth = 6;
            this.DrinkOrTopping.Name = "DrinkOrTopping";
            // 
            // NumberItem
            // 
            this.NumberItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumberItem.HeaderText = "SL";
            this.NumberItem.MinimumWidth = 6;
            this.NumberItem.Name = "NumberItem";
            this.NumberItem.Width = 60;
            // 
            // TotalMoneyItem
            // 
            this.TotalMoneyItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalMoneyItem.HeaderText = "Thành tiền";
            this.TotalMoneyItem.MinimumWidth = 6;
            this.TotalMoneyItem.Name = "TotalMoneyItem";
            this.TotalMoneyItem.Width = 170;
            // 
            // TypeItem
            // 
            this.TypeItem.HeaderText = "Loại";
            this.TypeItem.MinimumWidth = 6;
            this.TypeItem.Name = "TypeItem";
            this.TypeItem.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // cbTypeCustomer
            // 
            this.cbTypeCustomer.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbTypeCustomer.FormattingEnabled = true;
            this.cbTypeCustomer.Location = new System.Drawing.Point(167, 109);
            this.cbTypeCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTypeCustomer.Name = "cbTypeCustomer";
            this.cbTypeCustomer.Size = new System.Drawing.Size(143, 27);
            this.cbTypeCustomer.TabIndex = 28;
            // 
            // txbCustomerName
            // 
            this.txbCustomerName.Location = new System.Drawing.Point(167, 154);
            this.txbCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbCustomerName.Name = "txbCustomerName";
            this.txbCustomerName.Size = new System.Drawing.Size(280, 28);
            this.txbCustomerName.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 21);
            this.label5.TabIndex = 26;
            this.label5.Text = "Loại khách hàng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 21);
            this.label8.TabIndex = 25;
            this.label8.Text = "Tên khách hàng";
            // 
            // txBillID
            // 
            this.txBillID.Location = new System.Drawing.Point(167, 63);
            this.txBillID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txBillID.Name = "txBillID";
            this.txBillID.Size = new System.Drawing.Size(143, 28);
            this.txBillID.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 21);
            this.label9.TabIndex = 23;
            this.label9.Text = "Trạng thái";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 28);
            this.textBox1.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 21);
            this.label4.TabIndex = 36;
            this.label4.Text = "Mã hóa đơn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(1190, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 34);
            this.label6.TabIndex = 15;
            this.label6.Text = "Chi tiết hóa đơn";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(167, 200);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(280, 28);
            this.textBox2.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 21);
            this.label10.TabIndex = 38;
            this.label10.Text = "Thời gian tạo";
            // 
            // BillManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "BillManager";
            this.Size = new System.Drawing.Size(1678, 944);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusBill;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddNumberItem;
        private System.Windows.Forms.Button btnSubtractNumberItem;
        private System.Windows.Forms.Label lbTotalMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgBillDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrinkOrTopping;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoneyItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.ComboBox cbTypeCustomer;
        private System.Windows.Forms.TextBox txbCustomerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txBillID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
    }
}
