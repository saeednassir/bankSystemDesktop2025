using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Global_Classes;
using BankOfPalestineSystemDesktopAppPresentationLayer.People.Controls;
using BankOfPalestineSystemDesktopAppPresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Accounts
{
    public partial class frmfrmAddUpdateAccount : Form
    {

        public delegate void DataBackEventHandler(object sender, int AccountID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _AccountID = -1;
        clsAccount _Account;

        public frmfrmAddUpdateAccount()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

           
        }
      

        private void _FillAccountTypesInComoboBox()
        {
            DataTable dtAccountTypes = clsAccountType.GetAllAccountTypes();

            foreach (DataRow row in dtAccountTypes.Rows)
            {
                cbAccountType.Items.Add(row["Name"]);
            }
        }

        private void _FillCurenciesInComoboBox()
        {
            DataTable dtCurencies = clsCurrency.GetAllCurrencies();

            foreach (DataRow row in dtCurencies.Rows)
            {
                cbCurrency.Items.Add(row["CodeCurrency"]);
            }
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillAccountTypesInComoboBox();
            _FillCurenciesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitleHeader.Text = "إضافة حساب جديد";
                lblTitleBody.Text = "إضافة حساب جديد";
                this.Text = "إضافة حساب جديد";
                _Account = new clsAccount();

                tpAccountInfo.Enabled = false;

                ctrlClientCardWithFilter1.FilterFocus();
            }
            else
            {
                lblTitleHeader.Text = "تعديل حساب";
                lblTitleBody.Text = "تعديل حساب";
                this.Text = "تعديل حساب";
                pbIconBody.Image = Resources.edit__1_;
                pbIconHeader.Image = Resources.edit__1_;

                tpAccountInfo.Enabled = true;
                btnSave.Enabled = true;


            }

            
            cbAccountType.SelectedIndex = 0;
            cbCurrency.SelectedIndex = 0;


        }

        private void _LoadData()
        {

            _Account = clsAccount.Find(_AccountID);
            ctrlClientCardWithFilter1.FilterEnabled = false;

            if (_Account == null)
            {
                MessageBox.Show("لا يوجد حساب بهذا الرقم : " + _AccountID, "الموظف غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            ctrlClientCardWithFilter1.LoadClientInfo(_Account.ClientID);
            lblAccountID.Text = _Account.ID.ToString();
            lblAccountNumber.Text = _Account.AccountNumber;
            cbAccountType.SelectedIndex = cbAccountType.FindString(_Account.AccountTypeInfo.Name);
            cbCurrency.SelectedIndex = cbCurrency.FindString(_Account.CurrencyInfo.CodeCurrency);

        }

        private void frmfrmAddUpdateAccount_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            clsAccountType accountType = clsAccountType.Find(cbAccountType.Text);
            clsCurrency currency = clsCurrency.FindByCodeCurrency(cbCurrency.Text);
            clsBranche branche = clsBranche.FindByID(clsGlobal.CurrentUser.EmployeeInfo.BranchID);
            clsClient client = clsClient.Find(ctrlClientCardWithFilter1.ClientID);

            _Account.ClientID = client.ID;
            _Account.AccountTypeID = accountType.ID;
            _Account.CurrencyID = currency.ID;


            if(_Mode == enMode.AddNew)
            {
                string subAccount = clsGlobal.GetSubAccount(client.ID,accountType.ID,currency.ID);

                _Account.BranchID = branche.ID;
                _Account.AccountNumber = clsGlobal.CreateFullAccountNumber(branche.Code, client.ClientNumber,
                   accountType.Code, currency.CurrencyNumber, subAccount);
                _Account.Balance = 0;
                _Account.Status = clsAccount.enStatus.Active;
                _Account.NicName = clsGlobal.CreateDefaultNicName(accountType.Name,currency.CodeCurrency, Convert.ToInt32(subAccount));
                _Account.SubAccount = subAccount;
                _Account.IBAN = clsGlobal.Create_IBAN(_Account.AccountNumber);
                _Account.OpenDate = DateTime.Now;
                _Account.CreatedAt = DateTime.Now;
                _Account.CreatedByUserID = clsGlobal.CurrentUser.ID;
            }
            else
            {
                _Account.UpdatedAt = DateTime.Now;

            }

            if (_Account.Save())
            {
                lblAccountID.Text = _Account.ID.ToString();
                lblAccountNumber.Text = _Account.AccountNumber.ToString();
                //change form mode to update.
                _Mode = enMode.Update;

                lblTitleHeader.Text = "تعديل حساب";
                lblTitleBody.Text = "تعديل حساب";
                this.Text = "تعديل حساب";
                pbIconBody.Image = Resources.edit__1_;
                pbIconHeader.Image = Resources.edit__1_;


                MessageBox.Show("تم حفظ البيانات بنجاح .", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Account.ID);
                this.Close();
            }
            else
                MessageBox.Show("خطأ : لم يتم حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlClientCardWithFilter1.ClientID != -1)
            {

                btnSave.Enabled = true;
                tpAccountInfo.Enabled = true;
                tcAccountInfo.SelectedTab = tcAccountInfo.TabPages["tpAccountInfo"];

            }

            else

            {
                MessageBox.Show("الرجاء ابحث عن عميل", "Select a Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlClientCardWithFilter1.FilterFocus();

            }
        }
    }
}
