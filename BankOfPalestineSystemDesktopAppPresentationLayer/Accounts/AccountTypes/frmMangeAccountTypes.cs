using BankOfPalestineSystemBusinessLayer;
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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Accounts.AccountTypes
{
    public partial class frmMangeAccountTypes : Form
    {

        private static DataTable _dtAllAccountTypes = clsAccountType.GetAllAccountTypes();

        private DataTable _dtAccountTypes = _dtAllAccountTypes.DefaultView.ToTable(false, "ID", "Name",
                                                      "Code", "Description", "MinimumBalance", "IsActive",
                                                      "CreatedAt");

        private void _RefreshAccountTypesList()
        {
            _dtAllAccountTypes = clsAccountType.GetAllAccountTypes();
            _dtAccountTypes = _dtAllAccountTypes.DefaultView.ToTable(false, "ID", "Name",
                                                       "Code", "Description", "MinimumBalance", "IsActive",
                                                       "CreatedAt");
            dgvAccountTypes.DataSource = _dtAccountTypes;
            lblRecordsCount.Text = dgvAccountTypes.Rows.Count.ToString();

            if (dgvAccountTypes.Rows.Count >= 2 && dgvAccountTypes.Rows.Count <= 10)
                lblNameResaultsCount.Text = "أنواع حسابات";
            else
                lblNameResaultsCount.Text = "نوع حساب";


        }

        public frmMangeAccountTypes()
        {
            InitializeComponent();
        }

        private void frmMangeAccountTypes_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);


            dgvAccountTypes.DataSource = _dtAccountTypes;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvAccountTypes.Rows.Count.ToString();

            if (dgvAccountTypes.Rows.Count >= 2 && dgvAccountTypes.Rows.Count <= 10)
                lblNameResaultsCount.Text = "أنواع حسابات";
            else
                lblNameResaultsCount.Text = "نوع حساب";

            if (dgvAccountTypes.Rows.Count > 0)
            {

                dgvAccountTypes.Columns[0].HeaderText = "ID";
                dgvAccountTypes.Columns[0].Width = 70;

                dgvAccountTypes.Columns[1].HeaderText = "الإسم";
                dgvAccountTypes.Columns[1].Width = 100;


                dgvAccountTypes.Columns[2].HeaderText = "الرمز";
                dgvAccountTypes.Columns[2].Width = 100;

                dgvAccountTypes.Columns[3].HeaderText = "الوصف";
                dgvAccountTypes.Columns[3].Width = 120;

                dgvAccountTypes.Columns[4].HeaderText = "أقل رصيد";
                dgvAccountTypes.Columns[4].Width = 100;

                dgvAccountTypes.Columns[5].HeaderText = "فعال";
                dgvAccountTypes.Columns[5].Width = 70;


                dgvAccountTypes.Columns[6].HeaderText = "تاريخ الإضافة";
                dgvAccountTypes.Columns[6].Width = 120;


            }



        }

        public string GetFilterColumnName()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "ID":
                    FilterColumn = "ID";
                    break;

                case "الاسم":
                    FilterColumn = "FullName";
                    break;

                case "الرمز":
                    FilterColumn = "AccountNumber";
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
                _dtAccountTypes.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvAccountTypes.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ID")
                //in this case we deal with integer not string.

                _dtAccountTypes.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAccountTypes.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvAccountTypes.Rows.Count.ToString();

            if (dgvAccountTypes.Rows.Count >= 2 && dgvAccountTypes.Rows.Count <= 10)
                lblNameResaultsCount.Text = "أنواع حسابات";
            else
                lblNameResaultsCount.Text = "نوع حساب";
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
            if (cbFilterBy.Text == "ID" || cbFilterBy.Text == "الرمز")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد حذف  نوع الحساب ؟", "حذف دور للمستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int AccountTupeID = (int)dgvAccountTypes.CurrentRow.Cells[0].Value;
            if (clsAccountType.DeleteAccountType(AccountTupeID))
            {
                MessageBox.Show("تم حذف  نوع الحساب بنجاح", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshAccountTypesList();
            }

            else
                MessageBox.Show("لم يتم حذف  نوع الحساب , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnAddAccountType_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("الرجاء إدخال إسم نوع الحساب !", "الحقل فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsAccountType accountType = new clsAccountType();

            accountType.Name = txtName.Text;
            accountType.Code = clsGlobal.CreateAccountTypeCode();
            accountType.Description = txtDescription.Text;

            if(txtMinimumBalance.Text != "")
                accountType.MinimumBalance = Convert.ToDecimal(txtMinimumBalance.Text);
            else
                accountType.MinimumBalance = 0;

            accountType.IsActive = true;
            accountType.CreatedAt = DateTime.Now;

            if (accountType.Save())
            {
                txtAccounttypeID.Text = accountType.ID.ToString();
                _RefreshAccountTypesList();
                MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("خطأ : لم يتم حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtAccounttypeID.Text = dgvAccountTypes.CurrentRow.Cells[0].Value.ToString();

            clsAccountType accountType = clsAccountType.Find(Convert.ToInt32(txtAccounttypeID.Text));

            txtCode.Text = accountType.Code;
            txtName.Text = accountType.Name;
            txtDescription.Text = accountType.Description;
            txtMinimumBalance.Text = accountType.MinimumBalance.ToString();

        }

        private void btnUpdateAccountType_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("الرجاء إدخال إسم  !", "الحقل فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsAccountType accountType = clsAccountType.Find(Convert.ToInt32(txtAccounttypeID.Text));

            accountType.Name = txtName.Text;
            accountType.Description = txtDescription.Text;
            accountType.MinimumBalance = Convert.ToDecimal(txtMinimumBalance.Text);


            if (accountType.Save())
            {
                txtAccounttypeID.Text = accountType.ID.ToString();
                _RefreshAccountTypesList();
                MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("خطأ : لم يتم حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void ActivatetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد تفعيل نوع الحساب ؟", "تفعيل", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int AccountTupeID = (int)dgvAccountTypes.CurrentRow.Cells[0].Value;

            clsAccountType accountType = clsAccountType.Find(AccountTupeID);
            accountType.IsActive = true;

            if (accountType.Save())
            {
                MessageBox.Show("تم تفعيل  نوع الحساب بنجاح", "تم التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshAccountTypesList();
            }

            else
                MessageBox.Show("لم يتم تفعيل  نوع الحساب , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد إلغاء تفعيل نوع الحساب ؟", " الغاء تفعيل", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int AccountTupeID = (int)dgvAccountTypes.CurrentRow.Cells[0].Value;

            clsAccountType accountType = clsAccountType.Find(AccountTupeID);
            accountType.IsActive = false;

            if (accountType.Save())
            {
                MessageBox.Show("تم إلغاء تفعيل  نوع الحساب بنجاح", "تم إلغاء التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshAccountTypesList();
            }

            else
                MessageBox.Show("لم يتم إلغاء تفعيل  نوع الحساب , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void cmsAccountType_Opening(object sender, CancelEventArgs e)
        {
            int AccountTupeID = (int)dgvAccountTypes.CurrentRow.Cells[0].Value;

            clsAccountType accountType = clsAccountType.Find(AccountTupeID);

            if (accountType.IsActive)
            {
                ActivatetoolStripMenuItem1.Enabled = false;
                CancelToolStripMenuItem.Enabled = true;
            }else
            {
                ActivatetoolStripMenuItem1.Enabled = true;
                CancelToolStripMenuItem.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshAccountTypesList();
        }
    }
}
