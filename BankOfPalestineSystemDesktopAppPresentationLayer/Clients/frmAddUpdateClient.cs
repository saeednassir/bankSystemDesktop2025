using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Global_Classes;
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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Clients
{
    public partial class frmAddUpdateClient : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int ClientID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _ClientID = -1;
        clsClient _Client;

        public frmAddUpdateClient()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateClient(int ClientID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _ClientID = ClientID;
        }

        private void _ResetDefualtValues()
        {
           
            if (_Mode == enMode.AddNew)
            {
                lblTitleHeader.Text = "إضافة عميل جديد";
                lblTitleBody.Text = "إضافة عميل جديد";
                this.Text = "إضافة عميل جديد";
                _Client = new clsClient();

                tpClientInfo.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblTitleHeader.Text = "تعديل عميل";
                lblTitleBody.Text = "تعديل عميل";
                this.Text = "تعديل عميل";
                pbIconBody.Image = Resources.edit__1_;
                pbIconHeader.Image = Resources.edit__1_;

                tpClientInfo.Enabled = true;
                btnSave.Enabled = true;


            }

            lblClientID.Text = "؟؟؟؟";
            lblClientNumber.Text = "؟؟؟؟";
            txtProfession.Text = "";
            txtCompanyName.Text = "";
            cbClientType.SelectedIndex = 0;
            gbCompanyName.Visible = false;


        }

        private void _LoadData()
        {

            _Client = clsClient.Find(_ClientID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_Client == null)
            {
                MessageBox.Show("لا يوجد عميل بهذا الرقم : " + _ClientID, "عميل غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            ctrlPersonCardWithFilter1.LoadPersonInfo(_Client.PersonID);

            lblClientID.Text = _Client.ID.ToString();
            lblClientNumber.Text = _Client.ClientNumber;
            txtProfession.Text = _Client.Profession;

            if (_Client.ClientType == clsClient.enClientType.Individual)
                cbClientType.SelectedIndex = 0;
            else
            {
                cbClientType.SelectedIndex = 1;
                gbCompanyName.Visible = true;
                txtCompanyName.Text= _Client.CompanyName;
            }


        }

        private void frmAddUpdateClient_Load(object sender, EventArgs e)
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

            _Client.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _Client.Profession = txtProfession.Text;

            if(cbClientType.SelectedIndex == 0)
            {
                _Client.ClientType = clsClient.enClientType.Individual;

                _Client.CompanyName = "";
            }
            else
            {
                _Client.ClientType = clsClient.enClientType.Corporate;
                _Client.CompanyName = txtCompanyName.Text;
            }


            if (_Mode == enMode.AddNew)
            {
                _Client.ClientNumber= clsGlobal.CreateClientNumber();
                _Client.Status = clsClient.enStatus.Active;
                _Client.CreatedAt = DateTime.Now;

                if (clsGlobal.CurrentUser != null)
                    _Client.CreatedByUserID = clsGlobal.CurrentUser.ID;
            }else
            {
                _Client.UpdatedAt = DateTime.Now;
                _Client.UpdatedByUserID = clsGlobal.CurrentUser.ID;

            }


            if (_Client.Save())
            {
                lblClientID.Text = _Client.ID.ToString();
                lblClientNumber.Text = _Client.ClientNumber.ToString();
                //change form mode to update.
                _Mode = enMode.Update;

                lblTitleHeader.Text = "تعديل عميل";
                lblTitleBody.Text = "تعديل عميل";
                this.Text = "تعديل عميل";
                pbIconBody.Image = Resources.edit__1_;
                pbIconHeader.Image = Resources.edit__1_;


                MessageBox.Show("تم حفظ البيانات بنجاح .", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Client.ID);
                this.Close();
            }
            else
                MessageBox.Show("خطأ : لم يتم حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpClientInfo.Enabled = true;
                tcClientInfo.SelectedTab = tcClientInfo.TabPages["tpClientInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                if (clsClient.isClientExistByPersonID(ctrlPersonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("هذا الشخص مسجل مسبقا كعميل, اختر شخص اخر.", "Select another Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpClientInfo.Enabled = true;
                    tcClientInfo.SelectedTab = tcClientInfo.TabPages["tpClientInfo"];
                }
            }

            else

            {
                MessageBox.Show("الرجاء اختيار شخص", "اختر شخص", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbClientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbClientType.SelectedIndex == 0)
            {
                pbClientType.Image = Resources.user;
                gbCompanyName.Visible = false;

            }else
            {
                pbClientType.Image = Resources.building;
                gbCompanyName.Visible = true;

            }
        }



    }
}
