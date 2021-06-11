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

namespace TrasuaDesktop
{
    public partial class Main : Form
    {
        string sessionID;
        int accountID;
        int permission;
        
        public Main(string _sessionID)
        {
            InitializeComponent();
            sessionID = _sessionID;
            using (WCF_TrasuaClient service = new WCF_TrasuaClient())
            {
                accountID = service.getAccountID(sessionID);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new Menu(sessionID, accountID));
        }

        private void btAddBill_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new AddBill(sessionID));
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (WCF_TrasuaClient service = new WCF_TrasuaClient())
            {
                service.Logout(sessionID, accountID);
            }
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            using (WCF_TrasuaClient service = new WCF_TrasuaClient())
            {
                service.Logout(sessionID, accountID);
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new Profile());
        }

        private void btnMenuManager_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new Menu(sessionID, accountID));
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new Home());
        }
    }
}
