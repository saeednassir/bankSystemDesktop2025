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
    public partial class frmFindAccount : Form
    {
        public delegate void DataBackEventHandler(object sender, int AccountID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public frmFindAccount()
        {
            InitializeComponent();
        }

        private void frmFindAccount_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            ctrlAccountCardWithFilter1.Focus();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlAccountCardWithFilter1.AccountID);
            this.Close();
        }
    }
}
