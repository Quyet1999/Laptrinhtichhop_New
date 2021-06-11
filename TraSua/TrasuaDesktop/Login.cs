using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrasuaDesktop.TrasuaWCFService;

namespace TrasuaDesktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            using (WCF_TrasuaClient client = new WCF_TrasuaClient())
            {
                string username = txbUsername.Text;
                string password = txbPassword.Text;
                string Loginresult = client._Login(username, password);
                if (Loginresult.Equals("ERROR"))
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Thread thr = new Thread(() => ShowMain(Loginresult));
                thr.Start();
                this.Close();
            }
        }
        void ShowMain(string sessionID)
        {
            Main formMain = new Main(sessionID);
            formMain.ShowDialog();
        }
    }
}
