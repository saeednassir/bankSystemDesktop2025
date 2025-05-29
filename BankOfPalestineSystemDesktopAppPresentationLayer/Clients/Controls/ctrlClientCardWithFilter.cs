using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Employees;
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
    public partial class ctrlClientCardWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnClientSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void ClientSelected(int ClientID)
        {
            Action<int> handler = OnClientSelected;
            if (handler != null)
            {
                handler(ClientID); // Raise the event with the parameter
            }
        }

        private bool _ShowAddClient = true;
        public bool ShowAddClient
        {
            get
            {
                return _ShowAddClient;
            }
            set
            {
                _ShowAddClient = value;
                btnAddNewClient.Visible = _ShowAddClient;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        public ctrlClientCardWithFilter()
        {
            InitializeComponent();
        }

        private int _ClientID = -1;

        public int ClientID
        {
            get { return ctrlClientCard1.ClientID; }
        }

        public clsClient SelectedClientInfo
        {
            get { return ctrlClientCard1.SelectedClientInfo; }
        }

        public void LoadClientInfo(int ClientID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = ClientID.ToString();
            FindNow();

        }

        public void LoadClientInfo(string ClientNumber)
        {

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = ClientNumber.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {

                case "رقم العميل":
                    ctrlClientCard1.LoadClientInfo(txtFilterValue.Text);

                    break;

                case "ID":
                    ctrlClientCard1.LoadClientInfo(int.Parse(txtFilterValue.Text));
                    break;

                default:
                    break;
            }

            if (OnClientSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnClientSelected(ctrlClientCard1.ClientID);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void ctrlClientCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "هذا الحقل مطلوب!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        { 
            frmAddUpdateClient frm1 = new frmAddUpdateClient();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();
        }

        private void DataBackEvent(object sender, int ClientID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = ClientID.ToString();
            ctrlClientCard1.LoadClientInfo(ClientID);
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if Employee id is selected
            if (cbFilterBy.Text == "رقم العميل" || cbFilterBy.Text == "ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
