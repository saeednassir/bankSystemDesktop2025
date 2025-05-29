using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.People;
using BankOfPalestineSystemDesktopAppPresentationLayer.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Accounts.Controls
{
    public partial class ctrlAccountCardWithFilter : UserControl
    {
        public event Action<int> OnAccountSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void AccountSelected(int AccountID)
        {
            Action<int> handler = OnAccountSelected;
            if (handler != null)
            {
                handler(AccountID); // Raise the event with the parameter
            }
        }

        private bool _ShowAddAccount = true;
        public bool ShowAddAccount
        {
            get
            {
                return _ShowAddAccount;
            }
            set
            {
                _ShowAddAccount = value;
                btnAddNewAccount.Visible = _ShowAddAccount;
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
        public ctrlAccountCardWithFilter()
        {
            InitializeComponent();
        }



        public void FindByClientNumber(string ClientNumber)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = ClientNumber;
            btnFind.PerformClick();
            

        }


        private int _AccountID = -1;

        public int AccountID
        {
            get { return ctrlAccountCard1.AccountID; }
        }

        public clsAccount SelectedAccountInfo
        {
            get { return ctrlAccountCard1.SelectedAccountInfo; }
        }

        public void LoadAccountInfo(int AccountID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = AccountID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "رقم الحساب":
                    ctrlAccountCard1.LoadAccountInfo(txtFilterValue.Text);

                    break;

                case "ID":
                    ctrlAccountCard1.LoadAccountInfo(int.Parse(txtFilterValue.Text));
                    break;

                default:
                    ctrlAccountCard1.LoadAccountInfo(int.Parse(txtFilterValue.Text));
                    break;
            }

            if (OnAccountSelected != null&& ctrlAccountCard1.AccountID != -1 && FilterEnabled)
                // Raise the event with a parameter
                OnAccountSelected(ctrlAccountCard1.AccountID);
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

            if(cbFilterBy.Text == "رقم العميل")
            {
                clsClient client = clsClient.Find(txtFilterValue.Text);
                if (client == null)
                {
                    MessageBox.Show("رقم العميل خاطئ !", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlAccountCard1.ResetAccountInfo();
                    return;
                }
                frmChooseAccountForClient frm = new frmChooseAccountForClient(client.ClientNumber);
                frm.DataBack += DataBackEvent; // Subscribe to the event

                frm.ShowDialog();



            }
            else
            {
                FindNow();
            }

           
        }

      
        private void ctrlAccountCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnAddNewAccount_Click(object sender, EventArgs e)
        {
            frmfrmAddUpdateAccount frm1 = new frmfrmAddUpdateAccount();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();
        }

        private void DataBackEvent(object sender, int AccountID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 2;
            txtFilterValue.Text = AccountID.ToString();
            ctrlAccountCard1.LoadAccountInfo(AccountID);
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

            //this will allow only digits if person id is selected
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
