using BankOfPalestineSystemDesktopAppPresentationLayer.Employees.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Clients.Controls
{
    public partial class frmFindClient : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int ClientID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public frmFindClient()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlClientCardWithFilter1.ClientID);
            this.Close();
        }

        private void frmFindClient_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void CtrlBoxClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlClientCardWithFilter1.ClientID);
            this.Close();
        }

        private void frmFindClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBack?.Invoke(this, ctrlClientCardWithFilter1.ClientID);
            this.Close();
        }
    }
}
