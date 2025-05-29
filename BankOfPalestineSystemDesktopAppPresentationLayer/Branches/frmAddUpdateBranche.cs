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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Branches
{
    public partial class frmAddUpdateBranche : Form
    {
        public delegate void DataBackEventHandler(object sender, int BrancheID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _BrancheID = -1;
        clsBranche _Branche;


        public frmAddUpdateBranche()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateBranche(int BrancheID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _BrancheID = BrancheID;
        }

        private void _FillBanksInComoboBox()
        {
            DataTable dtBanks = clsBank.GetAllBanks();

            foreach (DataRow row in dtBanks.Rows)
            {
                cbBank.Items.Add(row["Name"]);
            }
        }

        private void _FillMangersInComoboBox()
        {
            DataTable dtMangers = clsEmployee.GetAllMangerEmployees();

            foreach (DataRow row in dtMangers.Rows)
            {
                cbManger.Items.Add(row["FullName"]);
            }
        }

        private void _ResetDefualtValues()
        {
            dtpOpeningDate.MaxDate = DateTime.Now;
            dtpOpeningDate.Value = dtpOpeningDate.MaxDate;

            //this will initialize the reset the defaule values
            _FillBanksInComoboBox();
            _FillMangersInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitleHeader.Text = "إضافة فرع جديد";
                lblTitleBody.Text = "إضافة فرع جديد";
                pbIconHeader.Image = Resources.commission__1_;
                pbIconBody.Image = Resources.commission__1_;

                _Branche = new clsBranche();
            }
            else
            {
                lblTitleHeader.Text = "تعديل فرع";
                lblTitleBody.Text = "تعديل فرع";
                pbIconHeader.Image = Resources.edit__1_;
                pbIconBody.Image = Resources.edit__1_;
            }



            cbBank.SelectedIndex = 0;
            cbManger.SelectedIndex = 0;

            txtName.Text = "";
            txtAddress.Text = "";
            txtPhoneNumber.Text = "";


        }

        private void _LoadData()
        {

            _Branche = clsBranche.FindByID(_BrancheID);

            if (_Branche == null)
            {
                MessageBox.Show("No Brance with ID = " + _BrancheID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lblBranceID.Text = _BrancheID.ToString();
            lblBrancheCode.Text = _Branche.Code;
            txtName.Text = _Branche.Name;
            txtAddress.Text = _Branche.Address;
            txtPhoneNumber.Text = _Branche.PhoneNumber;
            dtpOpeningDate.Value = _Branche.OpeningDate;
            cbBank.SelectedIndex = cbBank.FindString(_Branche.BankInfo.Name);
            cbManger.SelectedIndex = cbManger.FindString(clsEmployee.FindEmployeeNameByID(_Branche.MangerID));


        }

        private void frmAddUpdateBranche_Load(object sender, EventArgs e)
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



            int BankID = clsBank.Find(cbBank.Text).ID;
            int MangerID = clsEmployee.FindByFullName(cbManger.Text);

            _Branche.Name = txtName.Text.Trim();
            _Branche.Address = txtAddress.Text.Trim();
            _Branche.PhoneNumber = txtPhoneNumber.Text.Trim();
            _Branche.BankID = BankID;
            _Branche.MangerID = MangerID;
            _Branche.OpeningDate = dtpOpeningDate.Value;

            if (_Mode == enMode.AddNew)
            {
                _Branche.Code = clsGlobal.CreateBrancheCode();

            }


            if (_Branche.Save())
            {
                lblBranceID.Text = _Branche.ID.ToString();
                lblBrancheCode.Text = _Branche.Code.ToString();

                //change form mode to update.
                _Mode = enMode.Update;
                lblTitleHeader.Text = "تعديل فرع";
                lblTitleBody.Text = "تعديل فرع";
                pbIconHeader.Image = Resources.edit__1_;
                pbIconBody.Image = Resources.edit__1_;

                MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Branche.ID);
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
