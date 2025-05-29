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
    public partial class ctrlEmployeeCardWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnEmployeeSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void EmployeeSelected(int EmployeeID)
        {
            Action<int> handler = OnEmployeeSelected;
            if (handler != null)
            {
                handler(EmployeeID); // Raise the event with the parameter
            }
        }

        private bool _ShowAddEmployee = true;
        public bool ShowAddEmployee
        {
            get
            {
                return _ShowAddEmployee;
            }
            set
            {
                _ShowAddEmployee = value;
                btnAddNewEmployee.Visible = _ShowAddEmployee;
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
        public ctrlEmployeeCardWithFilter()
        {
            InitializeComponent();
        }

        private int _EmployeeID = -1;

        public int EmployeeID
        {
            get { return ctrlEmployeeCard1.EmployeeID; }
        }

        public clsEmployee SelectedEmployeeInfo
        {
            get { return ctrlEmployeeCard1.SelectedEmployeeInfo; }
        }

        public void LoadEmployeeInfo(int EmployeeID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = EmployeeID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            { 
 
                case "رقم الموظف":
                    ctrlEmployeeCard1.LoadEmployeeInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "رقم الهوية":
                    ctrlEmployeeCard1.LoadEmployeeInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnEmployeeSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnEmployeeSelected(ctrlEmployeeCard1.EmployeeID);
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

            FindNow();
        }

        private void ctrlEmployeeCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "هذا الحقل مطلوب!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frm1 = new frmAddUpdateEmployee();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();
        }

        private void DataBackEvent(object sender, int EmployeeID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = EmployeeID.ToString();
            ctrlEmployeeCard1.LoadEmployeeInfo(EmployeeID);
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if Employee id is selected
            if (cbFilterBy.Text == "رقم الموظف")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
