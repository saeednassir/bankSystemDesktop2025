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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Employees.Controls
{
    public partial class ctrlEmployeeCard : UserControl
    {
        private clsEmployee _Employee;
        private int _EmployeeID = -1;

        public int EmployeeID
        {
            get { return _EmployeeID; }
        }


        public clsEmployee SelectedEmployeeInfo
        {
            get { return _Employee; }
        }

        public ctrlEmployeeCard()
        {
            InitializeComponent();
        }

        public void LoadEmployeeInfo(int EmployeeID)
        {
            _Employee = clsEmployee.FindByID(EmployeeID);
            if (_Employee == null)
            {
                _ResetEmployeeInfo();
                MessageBox.Show("لا يوجد موظف بهذا الرقم = " + EmployeeID.ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillEmployeeInfo();
        }

        public void LoadEmployeeInfo(string NationalNo)
        {
            _Employee = clsEmployee.FindByNationalNumber(NationalNo);
            if (_Employee == null)
            {
                _ResetEmployeeInfo();
                MessageBox.Show("لا يوجد موظف بهذا رقم لهوية = " + EmployeeID.ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillEmployeeInfo();
        }

        private void _FillEmployeeInfo()
        {
            llEditEmployeeInfo.Enabled = true;
            _EmployeeID = _Employee.ID;
            ctrlPersonCard1.LoadPersonInfo(_Employee.PersonID);
            lblEmployeeID.Text = _Employee.ID.ToString();
            lblBranch.Text = clsBranche.FindByID(_Employee.BranchID).Name;
            lblJobTitle.Text = _Employee.JobTitle;
            lblDepartment.Text = _Employee.DepartmentInfo.Name;
            lblSalary.Text = Convert.ToInt32(_Employee.Salary).ToString();
            lblCreatedDate.Text = _Employee.CreatedDate.ToShortDateString();
        }

        public void _ResetEmployeeInfo()
        {
            llEditEmployeeInfo.Enabled = false;
            ctrlPersonCard1.ResetPersonInfo();
            lblEmployeeID.Text = "[؟؟؟]";
            lblBranch.Text = "[؟؟؟]";
            lblJobTitle.Text = "[؟؟؟]";
            lblDepartment.Text = "[؟؟؟]";
            lblSalary.Text = "[؟؟؟]";
            lblCreatedDate.Text = "[؟؟؟]";
        }

        private void llEditEmployeeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateEmployee frm = new frmAddUpdateEmployee(_EmployeeID);
            frm.ShowDialog();

            LoadEmployeeInfo(_EmployeeID);
        }

       
    }
}
