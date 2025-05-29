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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Employees
{
    public partial class frmAddUpdateEmployee : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int EmployeeID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _EmployeeID = -1;
        clsEmployee _Employee;

        public frmAddUpdateEmployee()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateEmployee(int EmployeeID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _EmployeeID = EmployeeID;
        }

        private void _FillBranchesInComoboBox()
        {
            DataTable dtBranchs = clsBranche.GetAllBranches();

            foreach (DataRow row in dtBranchs.Rows)
            {
                cbBranch.Items.Add(row["Name"]);
            }
        }

        private void _FillDepartmentsInComoboBox()
        {
            DataTable dtDepartments = clsDepartment.GetAllDepartments();

            foreach (DataRow row in dtDepartments.Rows)
            {
                cbDepartment.Items.Add(row["Name"]);
            }
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillBranchesInComoboBox();
            _FillDepartmentsInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitleHeader.Text = "إضافة موظف جديد";
                lblTitleBody.Text = "إضافة موظف جديد";
                this.Text = "إضافة موظف جديد";
                _Employee = new clsEmployee();

                tpEmployeeInfo.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblTitleHeader.Text = "تعديل موظف";
                lblTitleBody.Text = "تعديل موظف";
                this.Text = "تعديل موظف";
                pbIconBody.Image = Resources.edit__1_;
                pbIconHeader.Image = Resources.edit__1_;

                tpEmployeeInfo.Enabled = true;
                btnSave.Enabled = true;


            }

            txtJobTitle.Text = "";
            txtSalary.Text = "";
            cbBranch.SelectedIndex = 0;
            cbDepartment.SelectedIndex = 0;


        }

        private void _LoadData()
        {

            _Employee = clsEmployee.FindByID(_EmployeeID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_Employee == null)
            {
                MessageBox.Show("لا يوجد موظف بهذا الرقم : " + _EmployeeID, "الموظف غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblEmployeeID.Text = _Employee.ID.ToString();
            txtJobTitle.Text = _Employee.JobTitle;
            txtSalary.Text =  _Employee.Salary.ToString();
            cbBranch.SelectedIndex = cbBranch.FindString(clsBranche.FindByID(_Employee.BranchID).Name);
            cbDepartment.SelectedIndex = cbDepartment.FindString(_Employee.DepartmentInfo.Name);
            ctrlPersonCardWithFilter1.LoadPersonInfo(_Employee.PersonID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateEmployee_Load(object sender, EventArgs e)
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

            _Employee.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _Employee.JobTitle = txtJobTitle.Text.Trim();
            _Employee.Salary = Convert.ToDecimal(txtSalary.Text);
            _Employee.BranchID = clsBranche.FindByName(cbBranch.Text).ID;
            _Employee.DepartmentID = clsDepartment.Find(cbDepartment.Text).ID;

            if(_Mode == enMode.AddNew)
                _Employee.CreatedDate = DateTime.Now;

            if (_Employee.Save())
            {
                lblEmployeeID.Text = _Employee.ID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;

                lblTitleHeader.Text = "تعديل موظف";
                lblTitleBody.Text = "تعديل موظف";
                this.Text = "تعديل موظف";
                pbIconBody.Image = Resources.edit__1_;
                pbIconHeader.Image = Resources.edit__1_;


                MessageBox.Show("تم حفظ البيانات بنجاح .", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Employee.ID);
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
                tpEmployeeInfo.Enabled = true;
                tcEmployeeInfo.SelectedTab = tcEmployeeInfo.TabPages["tpEmployeeInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                if (clsEmployee.isEmployeeExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("هذا الشخص مسجل مسبقا كموظف, اختر شخص اخر.", "Select another Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpEmployeeInfo.Enabled = true;
                    tcEmployeeInfo.SelectedTab = tcEmployeeInfo.TabPages["tpEmployeeInfo"];
                }
            }

            else

            {
                MessageBox.Show("الرجاء اختيار شخص", "اختر شخص", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();

            }
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !clsValidatoin.ISDot(e.KeyChar);
        }

        private void CtrlBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
