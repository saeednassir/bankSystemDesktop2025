using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Accounts;
using BankOfPalestineSystemDesktopAppPresentationLayer.Branches;
using BankOfPalestineSystemDesktopAppPresentationLayer.Cards;
using BankOfPalestineSystemDesktopAppPresentationLayer.Clients;
using BankOfPalestineSystemDesktopAppPresentationLayer.Currencies;
using BankOfPalestineSystemDesktopAppPresentationLayer.Dashboard;
using BankOfPalestineSystemDesktopAppPresentationLayer.Employees;
using BankOfPalestineSystemDesktopAppPresentationLayer.ExchangeRates;
using BankOfPalestineSystemDesktopAppPresentationLayer.Generic;
using BankOfPalestineSystemDesktopAppPresentationLayer.Global_Classes;
using BankOfPalestineSystemDesktopAppPresentationLayer.Login;
using BankOfPalestineSystemDesktopAppPresentationLayer.People;
using BankOfPalestineSystemDesktopAppPresentationLayer.Permissions;
using BankOfPalestineSystemDesktopAppPresentationLayer.Properties;
using BankOfPalestineSystemDesktopAppPresentationLayer.RolePermissions;
using BankOfPalestineSystemDesktopAppPresentationLayer.Roles;
using BankOfPalestineSystemDesktopAppPresentationLayer.Transactions;
using BankOfPalestineSystemDesktopAppPresentationLayer.Transactions.TransactionTypes;
using BankOfPalestineSystemDesktopAppPresentationLayer.Transactions.Transfer;
using BankOfPalestineSystemDesktopAppPresentationLayer.UserRoles;
using BankOfPalestineSystemDesktopAppPresentationLayer.Users;
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

namespace BankOfPalestineSystemDesktopAppPresentationLayer
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;

       
        public frmMain(frmLogin frm)
        {
            InitializeComponent();

            _frmLogin = frm;
        }
        public frmMain()
        {
            InitializeComponent();
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
           guna2ShadowForm1.SetShadowForm(this);

            lblLastLogin.Text = clsGlobal.LastLogin.ToString();

            lblUsename.Text = clsGlobal.CurrentUser.EmployeeInfo.PersonInfo.FirstName
                + " " + clsGlobal.CurrentUser.EmployeeInfo.PersonInfo.LastName;

            if (clsGlobal.CurrentUser.EmployeeInfo.PersonInfo.Gender == clsPerson.enGender.Male)
                pbDefaultImage.Image = Resources.user__1_1;
            else
                pbDefaultImage.Image = Resources.human;

           btnDashboard.PerformClick();

        }

        public void AddformInPanelcontainer(Form form, string title, Image image)
        {
            
            this.Text = title;
            if (PanelContainer.Controls.Count > 0)
            {
                foreach (Control control in PanelContainer.Controls)
                {
                    control.Dispose();
                }
                PanelContainer.Controls.Clear();
            }

            lblTitle.Text = title;
            pbTitle.Image = image;
            
            Form frm = form as Form;

            if (frm != null)
            {
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                PanelContainer.Controls.Add(frm);
                PanelContainer.Tag = frm;
                frm.Show();
            }

            

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AddformInPanelcontainer(new frmDashboard(),((Guna2Button)sender).Text, ((Guna2Button)sender).Image);
        }

        private void btnMangePeople_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض قائمة الأشخاص"))
            {
                frmAccessDenied frm = new frmAccessDenied();
                frm.Show();
                return;
            }

            AddformInPanelcontainer(new frmMangePeople(), ((Guna2Button)sender).Text,
               ((Guna2Button)sender).Image);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //clsGlobal.ClearSession();

            this.Close();

            //if (_frmLogin != null)
            //    _frmLogin.Show();
        }

        private void btnMangeEmployees_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض قائمة الموظفين"))
            {
                frmAccessDenied frm = new frmAccessDenied();
                frm.Show();
                return;
            }

            AddformInPanelcontainer(new frmMangeEmployees(), ((Guna2Button)sender).Text,
               ((Guna2Button)sender).Image);
        }

        private void btnBranches_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إدارة الفروع"))
            {
                frmAccessDenied frm = new frmAccessDenied();
                frm.Show();
                return;
            }

            AddformInPanelcontainer(new frmListBranches(), ((Guna2Button)sender).Text,
              ((Guna2Button)sender).Image);
        }

        private void btnMangeUsers_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إدارة المستخدمين"))
            {
                frmAccessDenied frm = new frmAccessDenied();
                frm.Show();
                return;
            }

            AddformInPanelcontainer(new frmListUsers(), ((Guna2Button)sender).Text,
              ((Guna2Button)sender).Image);
        }

        private void btnCurencies_Click(object sender, EventArgs e)
        {
            AddformInPanelcontainer(new frmListCurrencies(), ((Guna2Button)sender).Text,
             ((Guna2Button)sender).Image);
        }

        private void btnCurrencyRates_Click(object sender, EventArgs e)
        {
            AddformInPanelcontainer(new frmListExchangeRates(), ((Guna2Button)sender).Text,
             ((Guna2Button)sender).Image);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGlobal.ClearSession();

            //this.Close();

            if (_frmLogin != null)
                _frmLogin.Show();
        }

        private void btnMangeCliets_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض قائمة العملاء"))
            {
                frmAccessDenied frm = new frmAccessDenied();
                frm.Show();
                return;
            }

            AddformInPanelcontainer(new frmMangeClients(), ((Guna2Button)sender).Text,
            ((Guna2Button)sender).Image);
        }

        private void btnMangeAccounts_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض قائمة الخسابات"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            AddformInPanelcontainer(new frmMangeAccounts(), ((Guna2Button)sender).Text,
            ((Guna2Button)sender).Image);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmDeposit deposit = new frmDeposit();
            deposit.Show();
        }

        private void btnTransactons_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض قائمة المعاملات"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            AddformInPanelcontainer(new frmMangeTransactions(), ((Guna2Button)sender).Text,
            ((Guna2Button)sender).Image);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            AddformInPanelcontainer(new frmMangeTransfer(), ((Guna2Button)sender).Text,
            ((Guna2Button)sender).Image);
        }

        private void btnMangeCards_Click(object sender, EventArgs e)
        {
            AddformInPanelcontainer(new frmMangeCards(), ((Guna2Button)sender).Text,
           ((Guna2Button)sender).Image);
        }

        private void btnMangeCards_Click_1(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض قائمة البطاقات"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }


            AddformInPanelcontainer(new frmMangeCards(), ((Guna2Button)sender).Text,
           ((Guna2Button)sender).Image);
        }

       
        private void txtGenericSerch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                clsClient client = clsClient.Find(txtGenericSerch.Text.Trim());
                if (client != null)
                {
                    frmMenuGenericSerch frm = new frmMenuGenericSerch(client);
                    frm.ShowDialog();
                    txtGenericSerch.Clear();
                }else
                {
                    MessageBox.Show("رقم العميل غير صحيح !", "غير صحيح", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
