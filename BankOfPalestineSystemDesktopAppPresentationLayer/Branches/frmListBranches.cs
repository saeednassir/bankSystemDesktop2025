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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Branches
{
    public partial class frmListBranches : Form
    {
        private static DataTable _dtAllBranches = clsBranche.GetAllBranches();

        private DataTable _dtBranches = _dtAllBranches.DefaultView.ToTable(false, "ID", "Code",
                                                      "Name", "Address",
                                                      "PhoneNumber", "OpeningDate",
                                                      "BankName", "BrancheManger");

        private void _RefreshBranchesList()
        {
            _dtAllBranches = clsBranche.GetAllBranches();
            _dtBranches = _dtAllBranches.DefaultView.ToTable(false, "ID", "Code",
                                                      "Name", "Address",
                                                      "PhoneNumber", "OpeningDate",
                                                      "BankName", "BrancheManger");
            dgvBranches.DataSource = _dtBranches;
            lblRecordsCount.Text = dgvBranches.Rows.Count.ToString();

            if (dgvBranches.Rows.Count >= 2 && dgvBranches.Rows.Count <= 10)
                lblNameResaultsCount.Text = "فروع";
            else
                lblNameResaultsCount.Text = "فرع";

        }
        public frmListBranches()
        {
            InitializeComponent();
        }

        private void frmListBranches_Load(object sender, EventArgs e)
        {
            dgvBranches.DataSource = _dtBranches;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvBranches.Rows.Count.ToString();

            if (dgvBranches.Rows.Count >= 2 && dgvBranches.Rows.Count <= 10)
                lblNameResaultsCount.Text = "فروع";
            else
                lblNameResaultsCount.Text = "فرع";

            if (dgvBranches.Rows.Count > 0)
            {

                dgvBranches.Columns[0].HeaderText = "رقم الفرع";
                dgvBranches.Columns[0].Width = 70;

                dgvBranches.Columns[1].HeaderText = "رمز الفرع";
                dgvBranches.Columns[1].Width = 70;

                dgvBranches.Columns[2].HeaderText = "إسم الفرع";
                dgvBranches.Columns[2].Width = 110;

                dgvBranches.Columns[3].HeaderText = "العنوان";
                dgvBranches.Columns[3].Width = 140;

                dgvBranches.Columns[4].HeaderText = "رقم الهاتف";
                dgvBranches.Columns[4].Width = 100;

                dgvBranches.Columns[5].HeaderText = "تاريخ الإفتتاح";
                dgvBranches.Columns[5].Width = 120;

                dgvBranches.Columns[6].HeaderText = "إسم البنك";
                dgvBranches.Columns[6].Width = 140;

                dgvBranches.Columns[7].HeaderText = "مدير الفرع";
                dgvBranches.Columns[7].Width = 150;
            }

        }


        public string GetFilterColumnName()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "رقم الفرع":
                    FilterColumn = "ID";
                    break;

                case "رمز الفرع":
                    FilterColumn = "Code";
                    break;

                case "إسم الفرع":
                    FilterColumn = "Name";
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
                _dtBranches.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvBranches.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ID")
                //in this case we deal with integer not string.

                _dtBranches.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtBranches.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvBranches.Rows.Count.ToString();

            if (dgvBranches.Rows.Count >= 2 && dgvBranches.Rows.Count <= 10)
                lblNameResaultsCount.Text = "فروع";
            else
                lblNameResaultsCount.Text = "فرع";
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
            if (cbFilterBy.Text == "رقم الفرع" || cbFilterBy.Text == "رمز الفرع" )
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddBranche_Click(object sender, EventArgs e)
        {
            frmAddUpdateBranche frm = new frmAddUpdateBranche();
            frm.ShowDialog();
            _RefreshBranchesList();
        }

        private void AddBranche_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateBranche frm = new frmAddUpdateBranche();
            frm.ShowDialog();
            _RefreshBranchesList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateBranche frm = new frmAddUpdateBranche((int)dgvBranches.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshBranchesList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا الفرع ؟", "حذف شخص", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int PersonID = (int)dgvBranches.CurrentRow.Cells[0].Value;
            if (clsBranche.DeleteBranche(PersonID))
            {
                MessageBox.Show("تم حذف الفرع بنجاح", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshBranchesList();
            }

            else
                MessageBox.Show("لم يتم جذف الفرع , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshBranchesList();
        }
    }
}
