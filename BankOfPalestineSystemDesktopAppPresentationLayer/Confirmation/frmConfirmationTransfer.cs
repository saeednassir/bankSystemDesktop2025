using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Confirmation
{
    public partial class frmConfirmationTransfer : Form
    {
        public bool isConfirm = false;

        private  string _From = "";
        private string _To = "";
        private decimal _Amount = 0;
        private decimal _ExchangeRateUsed = 1;
        private decimal _Fees = 0;
        public frmConfirmationTransfer(string From,string To,decimal Amount,
            decimal ExchangeRateUsed,decimal Fees)
        {
            InitializeComponent();

            _From = From;
           _To = To;
            _Amount = Amount;
            _ExchangeRateUsed = ExchangeRateUsed;
            _Fees = Fees;

        }

        private void frmConfirmationTransfer_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

            if(_From != "")
                lblFromValue.Text = _From;
            else
            {
                lblFrom.Visible = false;
                lblFromValue.Visible = false;
                this.Size = new System.Drawing.Size(355, 285);

            }
            if (_To != "")
                lblToValue.Text = _To;
            else
            {
                lblTo.Visible = false;
                lblToValue.Visible = false; ; 
                this.Size = new System.Drawing.Size(355, 297);
            }
            lblAmont.Text = _Amount.ToString();
            lblExchangeRateUsed.Text = _ExchangeRateUsed.ToString();
            lblFees.Text = _Fees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            isConfirm = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            isConfirm = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            isConfirm = false;
            this.Close();
        }

    }
}
