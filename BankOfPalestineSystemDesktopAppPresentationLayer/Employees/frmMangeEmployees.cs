using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Generic;
using BankOfPalestineSystemDesktopAppPresentationLayer.Global_Classes;
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
    public partial class frmMangeEmployees : Form
    {
        private static DataTable _dtAllEmployees = clsEmployee.GetAllEmployees();

        private DataTable _dtEmployees = _dtAllEmployees.DefaultView.ToTable(false, "ID", "NationalNumber",
                                                      "FullName", "BrancheName", "JobTitle", "DepartmentName",
                                                      "Salary", "CreatedDate");

        private void _RefreshEmployeesList()
        {
            _dtAllEmployees = clsEmployee.GetAllEmployees();
            _dtEmployees = _dtAllEmployees.DefaultView.ToTable(false, "ID", "NationalNumber",
                                                      "FullName", "BrancheName", "JobTitle", "DepartmentName",
                                                      "Salary", "CreatedDate");
            dgvEmployee.DataSource = _dtEmployees;
            lblRecordsCount.Text = dgvEmployee.Rows.Count.ToString();

            if (dgvEmployee.Rows.Count >= 2 && dgvEmployee.Rows.Count <= 10)
                lblNameResaultsCount.Text = "موظفين";
            else
                lblNameResaultsCount.Text = "موظف";

        }



        public frmMangeEmployees()
        {
            InitializeComponent();
        }

        private void frmMangeEmployees_Load(object sender, EventArgs e)
        {
            dgvEmployee.DataSource = _dtEmployees;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvEmployee.Rows.Count.ToString();

            if (dgvEmployee.Rows.Count >= 2 && dgvEmployee.Rows.Count <= 10)
                lblNameResaultsCount.Text = "موظفين";
            else
                lblNameResaultsCount.Text = "موظف";

            if (dgvEmployee.Rows.Count > 0)
            {

                dgvEmployee.Columns[0].HeaderText = "رقم الموظف";
                dgvEmployee.Columns[0].Width = 110;

                dgvEmployee.Columns[1].HeaderText = "رقم الهوية";
                dgvEmployee.Columns[1].Width = 120;


                dgvEmployee.Columns[2].HeaderText = "الإسم كامل";
                dgvEmployee.Columns[2].Width = 160;

                dgvEmployee.Columns[3].HeaderText = "إسم الفرع";
                dgvEmployee.Columns[3].Width = 120;

                dgvEmployee.Columns[4].HeaderText = "الوظيفة";
                dgvEmployee.Columns[4].Width = 140;

                dgvEmployee.Columns[5].HeaderText = "القسم";
                dgvEmployee.Columns[5].Width = 120;


                dgvEmployee.Columns[6].HeaderText = "الراتب";
                dgvEmployee.Columns[6].Width = 120;


                dgvEmployee.Columns[7].HeaderText = "تاريخ الإضافة";
                dgvEmployee.Columns[7].Width = 170;
            }
        }

        public string GetFilterColumnName()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "رقم الموظف":
                    FilterColumn = "ID";
                    break;

                case "رقم لهوية":
                    FilterColumn = "NationalNumber";
                    break;

                case "الإسم كامل":
                    FilterColumn = "FullName";
                    break;

                case "الوظيفة":
                    FilterColumn = "JobTitle";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }
            return FilterColumn;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = GetFilterColumnName();


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtEmployees.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvEmployee.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                _dtEmployees.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtEmployees.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvEmployee.Rows.Count.ToString();

            if (dgvEmployee.Rows.Count >= 2 && dgvEmployee.Rows.Count <= 10)
                lblNameResaultsCount.Text = "موظفين";
            else
                lblNameResaultsCount.Text = "موظف";
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شيء");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "رقم الموظف" || cbFilterBy.Text == "رقم لهوية" )
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إضافةوتعديل موظف"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmAddUpdateEmployee frm = new frmAddUpdateEmployee();
            frm.ShowDialog();
            _RefreshEmployeesList();
        }

        private void AddEmployee_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إضافةوتعديل موظف"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }


            frmAddUpdateEmployee frm = new frmAddUpdateEmployee();
            frm.ShowDialog();
            _RefreshEmployeesList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إضافةوتعديل موظف"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }


            frmAddUpdateEmployee frm = new frmAddUpdateEmployee((int)dgvEmployee.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshEmployeesList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("حذف الموظفين"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا الموظف ؟", "حذف شخص", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int PersonID = (int)dgvEmployee.CurrentRow.Cells[0].Value;
            if (clsEmployee.DeleteEmployee(PersonID))
            {
                MessageBox.Show("تم حذف الموظف بنجاح", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshEmployeesList();
            }

            else
                MessageBox.Show("لم يتم جذف الموظف , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض تفاصيل و بحث عن موظف"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmShowEmployeeInfo frm = new frmShowEmployeeInfo((int)dgvEmployee.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void findEmployeetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض تفاصيل و بحث عن موظف"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            frmFindEmployee frm = new frmFindEmployee();
            frm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshEmployeesList();
        }
    }
}
