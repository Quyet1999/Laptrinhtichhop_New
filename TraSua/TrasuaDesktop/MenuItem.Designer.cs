
namespace TrasuaDesktop
{
    partial class MenuItem
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
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lbItemName = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.ptImageItem = new System.Windows.Forms.PictureBox();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptImageItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnAddItem);
            this.panel9.Controls.Add(this.lbItemName);
            this.panel9.Controls.Add(this.lbPrice);
            this.panel9.Controls.Add(this.ptImageItem);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(200, 240);
            this.panel9.TabIndex = 4;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(167, 207);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(30, 30);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // lbItemName
            // 
            this.lbItemName.BackColor = System.Drawing.Color.White;
            this.lbItemName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbItemName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbItemName.Location = new System.Drawing.Point(0, 145);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(200, 69);
            this.lbItemName.TabIndex = 2;
            this.lbItemName.Text = "Trà sữa trân châu đường đen";
            this.lbItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPrice
            // 
            this.lbPrice.BackColor = System.Drawing.Color.White;
            this.lbPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbPrice.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbPrice.Location = new System.Drawing.Point(0, 214);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(200, 26);
            this.lbPrice.TabIndex = 1;
            this.lbPrice.Text = "20 000đ";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptImageItem
            // 
            this.ptImageItem.BackColor = System.Drawing.SystemColors.Control;
            this.ptImageItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptImageItem.Image = global::TrasuaDesktop.Properties.Resources.trà_sữa_trân_châu;
            this.ptImageItem.Location = new System.Drawing.Point(0, 0);
            this.ptImageItem.Name = "ptImageItem";
            this.ptImageItem.Size = new System.Drawing.Size(200, 142);
            this.ptImageItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptImageItem.TabIndex = 0;
            this.ptImageItem.TabStop = false;
            // 
            // MenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.panel9);
            this.Name = "MenuItem";
            this.Size = new System.Drawing.Size(200, 240);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptImageItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.PictureBox ptImageItem;
        public System.Windows.Forms.Button btnAddItem;
    }
}
