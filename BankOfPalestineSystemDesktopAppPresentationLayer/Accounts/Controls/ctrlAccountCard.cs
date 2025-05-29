using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Properties;
using BankOfPalestineSystemDesktopAppPresentationLayer.Transactions;
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
    public partial class ctrlAccountCard : UserControl
    {
        private clsAccount _Account;

        private int _AccountID = -1;

        public int AccountID
        {
            get { return _AccountID; }
        }

        public clsAccount SelectedAccountInfo
        {
            get { return _Account; }
        }


        public ctrlAccountCard()
        {
            InitializeComponent();
        }
        private string GetStatusString()
        {
            switch(_Account.Status)
            {
                case clsAccount.enStatus.Pending:
                    lblStatus.ForeColor = Color.OrangeRed;
                    return "قيد المراجعة";
                case clsAccount.enStatus.Active:
                    lblStatus.ForeColor = Color.DarkGreen;
                    return "فعال";
                case clsAccount.enStatus.Dormant:
                    lblStatus.ForeColor = Color.Gray;
                    return "خامل";
                case clsAccount.enStatus.Closed:
                    lblStatus.ForeColor = Color.DarkRed;
                    return "مغلق";
                default:
                    return "غير معروف";

            }
        }
        public void ResetAccountInfo()
        {
            _AccountID = -1;
            lblAccountNumber.Text = "[؟؟؟]";
            lblFullName.Text = "[؟؟؟]";
            lblBranch.Text = "[؟؟؟]";
            lblAccountType.Text = "[؟؟؟]";
            lblBalance.Text = "[؟؟؟]";
            lblNicName.Text = "[؟؟؟]";
            lblIBAN.Text = "[؟؟؟]";
            lblStatus.Text = "[؟؟؟]";
            lblSubAccount.Text = "[؟؟؟]";
            lblCurrency.Text = "[؟؟؟]";
            lblOpenDate.Text = "[؟؟؟]";

        }

        private void _FillAccountInfo()
        {
            
            _AccountID = _Account.ID;
            lblAccountNumber.Text = _Account.AccountNumber;
            lblFullName.Text = _Account.ClientInfo.PersonInfo.FullName;
            lblBranch.Text = _Account.BranchInfo.Name;
            lblAccountType.Text = _Account.AccountTypeInfo.Name;
            lblBalance.Text = Math.Round(_Account.Balance, _Account.CurrencyInfo.DecimalPlaces, MidpointRounding.ToEven).ToString();
            lblNicName.Text = _Account.NicName;
            lblIBAN.Text = _Account.IBAN;
            lblStatus.Text = GetStatusString();
            lblSubAccount.Text = _Account.SubAccount;
            lblCurrency.Text = _Account.CurrencyInfo.CodeCurrency;
            lblOpenDate.Text = _Account.OpenDate.ToShortDateString();


        }

        public void LoadAccountInfo(int AccountID)
        {
            _Account = clsAccount.Find(AccountID);
            if (_Account == null)
            {
                ResetAccountInfo();
                MessageBox.Show("لا يوجد حساب بهذا الرقم : " + AccountID.ToString(), "حطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillAccountInfo();
        }
        public void LoadAccountInfo(string AccountNumber)
        {
            _Account = clsAccount.Find(AccountNumber);
            if (_Account == null)
            {
                ResetAccountInfo();
                MessageBox.Show("لا يوجد حساب بهذا الرقم : " + AccountID.ToString(), "حطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillAccountInfo();
        }

        private void llshowAcountTransaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // استدعي فورم عرض المعاملات لهذا الحساب
           frmListTransactionsForAccount frm = new frmListTransactionsForAccount(_AccountID);
            frm.ShowDialog();
        }
    }
}
