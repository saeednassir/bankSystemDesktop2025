using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Accounts;
using BankOfPalestineSystemDesktopAppPresentationLayer.Cards;
using BankOfPalestineSystemDesktopAppPresentationLayer.Clients;
using BankOfPalestineSystemDesktopAppPresentationLayer.Global_Classes;
using BankOfPalestineSystemDesktopAppPresentationLayer.Transactions.Transfer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Generic
{
    public partial class frmMenuGenericSerch : Form
    {
        
        private clsClient _Client;

        public frmMenuGenericSerch(clsClient Client)
        {
            InitializeComponent();

            _Client = Client;

        }

        private void frmMenuGenericSerch_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnshowClientInfo_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض تفاصيل و بحث عن عميل"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmShowClientInfo frm = new frmShowClientInfo(_Client.ID);
            frm.ShowDialog();
        }

        private void btnShowAccountsForClient_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض حسابات عميل"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmChooseAccountForClient frm = new frmChooseAccountForClient(_Client.ClientNumber);
            frm.ShowDialog();
        }

        private void btnTransfeBetwwenAccounts_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("تحويل بين حسابات العميل"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmTransferBetweenClientAccounts fm = new frmTransferBetweenClientAccounts(_Client.ClientNumber);
            fm.ShowDialog();

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إيداع"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmDeposit frm = new frmDeposit(_Client.ClientNumber);
            frm.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("سحب"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmWithdrawal frm = new frmWithdrawal(_Client.ClientNumber);
            frm.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("تحويل داخلي"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmInternalTransfer frm = new frmInternalTransfer(_Client.ClientNumber);
            frm.ShowDialog();
        }
    }
}
