using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Cards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Cards.Controls
{
    public partial class ctrlCardInfoWithFilter : UserControl
    {
        public event Action<int> OnCardSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void CardSelected(int CardID)
        {
            Action<int> handler = OnCardSelected;
            if (handler != null)
            {
                handler(CardID); // Raise the event with the parameter
            }
        }

        private bool _ShowAddCard = true;
        public bool ShowAddCard
        {
            get
            {
                return _ShowAddCard;
            }
            set
            {
                _ShowAddCard = value;
                btnAddNewCard.Visible = _ShowAddCard;
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
        public ctrlCardInfoWithFilter()
        {
            InitializeComponent();
        }


        private int _CardID = -1;

        public int CardID
        {
            get { return ctrlCardInfo1.CardID; }
        }

        public clsCard SelectedCardInfo
        {
            get { return ctrlCardInfo1.SelectedCardInfo; }
        }

        public void LoadCardInfo(int CardID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = CardID.ToString();
            FindNow();

        }

       

        private void FindNow()
        {

            ctrlCardInfo1.LoadCardInfo(int.Parse(txtFilterValue.Text));
                   

            if (OnCardSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnCardSelected(ctrlCardInfo1.CardID);
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

            if (cbFilterBy.Text == "رقم العميل")
            {
                clsClient client = clsClient.Find(txtFilterValue.Text);
                if (client == null)
                {
                    MessageBox.Show("رقم العميل خاطئ !", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlCardInfo1._ResetCardInfo();
                    return;
                }
                frmChooseCardForClient frm = new frmChooseCardForClient(client.ClientNumber);
                frm.DataBack += DataBackEvent; // Subscribe to the event

                frm.ShowDialog();



            }
            else
            {
                FindNow();
            }
        }

        private void ctrlCardInfoWithFilter_Load(object sender, EventArgs e)
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

        private void btnAddNewCard_Click(object sender, EventArgs e)
        {
            frmAddCard frm1 = new frmAddCard();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();
        }

        private void DataBackEvent(object sender, int CardID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = CardID.ToString();
            ctrlCardInfo1.LoadCardInfo(CardID);
        }


        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
