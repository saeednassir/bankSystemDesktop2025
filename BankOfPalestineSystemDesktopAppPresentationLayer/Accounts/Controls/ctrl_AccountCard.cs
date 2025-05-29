using BankOfPalestineSystemBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Accounts.Controls
{
    public partial class ctrl_AccountCard : UserControl
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


        public ctrl_AccountCard()
        {
            InitializeComponent();
        }

        private string GetStatusString()
        {
            switch (_Account.Status)
            {
                case clsAccount.enStatus.Pending:
                    return "قيد المراجعة";
                case clsAccount.enStatus.Active:
                    return "فعال";
                case clsAccount.enStatus.Dormant:
                    return "خامل";
                case clsAccount.enStatus.Closed:
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
            lblBalance.Text = _Account.Balance.ToString();
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

    }
}
