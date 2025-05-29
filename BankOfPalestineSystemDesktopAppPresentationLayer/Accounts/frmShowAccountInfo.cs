using BankOfPalestineSystemDesktopAppPresentationLayer.People.Controls;
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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Accounts
{
    public partial class frmShowAccountInfo : Form
    {
        public frmShowAccountInfo(int AccountID)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            ctrlAccountCard1.LoadAccountInfo(AccountID);
        }

        public frmShowAccountInfo(string AccountNumber)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            ctrlAccountCard1.LoadAccountInfo(AccountNumber);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
