using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Properties;
using Guna.UI2.HtmlRenderer.Adapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.ExchangeRates
{
    public partial class frmAddUpdateExchangeRate : Form
    {
        public delegate void DataBackEventHandler(object sender, int ExchangeRateID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _ExchangeRateID = -1;
        clsExchangeRate _ExchangeRate;

        public frmAddUpdateExchangeRate()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateExchangeRate(int ExchangeRateID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _ExchangeRateID = ExchangeRateID;
        }

        private void _FillFromCurrenciesInComoboBox()
        {
            cbFromCurrency.Items.Clear();

            DataTable dtCurrencies = clsCurrency.GetAllCurrencies();

            foreach (DataRow row in dtCurrencies.Rows)
            {
                cbFromCurrency.Items.Add(row["CodeCurrency"]);
            }
        }

        private void _FillToCurrenciesInComoboBox()
        {
            cbToCurrencyCode.Items.Clear();

            DataTable dtCurrencies = clsCurrency.GetAllCurrencies();

            foreach (DataRow row in dtCurrencies.Rows)
            {
                if(row["CodeCurrency"].ToString() != cbFromCurrency.Text)
                    cbToCurrencyCode.Items.Add(row["CodeCurrency"]);
            }
        }

        private void cbFromCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbToCurrencyCode.Items.Clear();
        }

        private void cbToCurrencyCode_Click(object sender, EventArgs e)
        {
            if (cbFromCurrency.Text == "")
            {
                MessageBox.Show("الرجاء اختر من اي عملة تريد التحويل !");
                cbToCurrencyCode.Items.Clear();
                return;
            }
           
            _FillToCurrenciesInComoboBox();
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillFromCurrenciesInComoboBox();
            

            if (_Mode == enMode.AddNew)
            {
                lblTitleBody.Text = "إضافة سعر عملة جديد";
                lblTitleHeader.Text = "إضافة سعر عملة جديد";
                //pbIconHeader.Image = Resources.icons8_add_user_100;
                //pbIconBody.Image = Resources.icons8_add_user_100;
                _ExchangeRate = new clsExchangeRate();
            }
            else
            {
                lblTitleBody.Text = "تعديل سعر عملة";
                lblTitleHeader.Text = "تعديل سعر عملة";
                //pbIconHeader.Image = Resources.icons8_female_user_update_100;
                //pbIconBody.Image = Resources.icons8_female_user_update_100;

            }



            //we set the max date to 18 years from today, and set the default value the same.
            
                //dtpEffectiveDateTime.MaxDate = DateTime.Now.AddDays(1);
                //dtpEffectiveDateTime.Value = dtpEffectiveDateTime.MaxDate;
                //if(_Mode== enMode.AddNew) 
                //    dtpEffectiveDateTime.MinDate = DateTime.Now;





            //this will set default country to jordan.
            cbRateType.SelectedIndex = 0;
            cbRateSource.SelectedIndex = 1;

            txtRate.Text = "";
           
           


        }

        private void _LoadData()
        {

            _ExchangeRate = clsExchangeRate.Find(_ExchangeRateID);

            if (_ExchangeRate == null)
            {
                MessageBox.Show("لا يوجد سعر عملة بهذا الرقم : " + _ExchangeRate, "سعر عملة غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            
            //the following code will not be executed if the person was not found
            
            lblExchangeRateID.Text = _ExchangeRateID.ToString();

            cbFromCurrency.Enabled = false;
            cbFromCurrency.Text = _ExchangeRate.FromCurrencyInfo.CodeCurrency;

            _FillToCurrenciesInComoboBox();
            cbToCurrencyCode.Enabled = false;
            cbToCurrencyCode.Text = _ExchangeRate.ToCurrencyInfo.CodeCurrency;

            txtRate.Text = _ExchangeRate.Rate.ToString("0.0000"); 

            cbRateType.SelectedIndex = (byte)_ExchangeRate.RateType;
            cbRateSource.SelectedIndex = (byte)_ExchangeRate.RateSource;

            dtpEffectiveDateTime.Value = _ExchangeRate.EffectiveDateTime;



        }

        private void frmAddUpdateExchangeRate_Load(object sender, EventArgs e)
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
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }



            int FromCurrencyID = clsCurrency.FindByCodeCurrency(cbFromCurrency.Text).ID;
            int ToCurrencyID = clsCurrency.FindByCodeCurrency(cbToCurrencyCode.Text).ID;
            
            _ExchangeRate.FromCurrencyCode = FromCurrencyID;
            _ExchangeRate.ToCurrencyCode = ToCurrencyID;
            _ExchangeRate.Rate = Convert.ToDecimal(txtRate.Text);
            _ExchangeRate.EffectiveDateTime =DateTime.Now;
            _ExchangeRate.RateType = (clsExchangeRate.enRateType)cbRateType.SelectedIndex;
            _ExchangeRate.RateSource = (clsExchangeRate.enRateSource)cbRateSource.SelectedIndex;
            
            if(_Mode == enMode.AddNew)
                _ExchangeRate.CreatedAt = DateTime.Now;
         

            if (_ExchangeRate.Save())
            {
                lblExchangeRateID.Text = _ExchangeRate.ExchangeRateID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;


                MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _ExchangeRate.ExchangeRateID);
                this.Close();
            }
            else
                MessageBox.Show("خطأ : لم يتم حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
