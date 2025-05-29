using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Accounts.AccountTypes;
using BankOfPalestineSystemDesktopAppPresentationLayer.Generic;
using BankOfPalestineSystemDesktopAppPresentationLayer.Global_Classes;
using BankOfPalestineSystemDesktopAppPresentationLayer.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Accounts
{
    public partial class frmMangeAccounts : Form
    {

        private static DataTable _dtAllAccounts = clsAccount.GetAllAccounts();

        private DataTable _dtAccounts = _dtAllAccounts.DefaultView.ToTable(false, "ID", "BrancheName",
                                                      "FullName", "AccountNumber", "AccountTypeName", "Balance",
                                                      "CodeCurrency", "Status", "NicName",
                                                      "IBAN");

        private void _RefreshAccountsList()
        {
            _dtAllAccounts = clsAccount.GetAllAccounts();
            _dtAccounts = _dtAllAccounts.DefaultView.ToTable(false, "ID", "BrancheName",
                                                      "FullName", "AccountNumber", "AccountTypeName", "Balance",
                                                      "CodeCurrency", "Status", "NicName",
                                                      "IBAN");
            dgvAccounts.DataSource = _dtAccounts;
            lblRecordsCount.Text = dgvAccounts.Rows.Count.ToString();

            if (dgvAccounts.Rows.Count >= 2 && dgvAccounts.Rows.Count <= 10)
                lblNameResaultsCount.Text = "حسابات";
            else
                lblNameResaultsCount.Text = "حساب";


        }


        public frmMangeAccounts()
        {
            InitializeComponent();
        }

        private void frmMangeAccounts_Load(object sender, EventArgs e)
        {
            dgvAccounts.DataSource = _dtAccounts;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvAccounts.Rows.Count.ToString();

            if (dgvAccounts.Rows.Count >= 2 && dgvAccounts.Rows.Count <= 10)
                lblNameResaultsCount.Text = "حسابات";
            else
                lblNameResaultsCount.Text = "حساب";

            if (dgvAccounts.Rows.Count > 0)
            {

                dgvAccounts.Columns[0].HeaderText = "ID";
                dgvAccounts.Columns[0].Width = 70;

                dgvAccounts.Columns[1].HeaderText = "الفرع";
                dgvAccounts.Columns[1].Width = 100;


                dgvAccounts.Columns[2].HeaderText = "الإسم كامل";
                dgvAccounts.Columns[2].Width = 150;

                dgvAccounts.Columns[3].HeaderText = "رقم الحساب";
                dgvAccounts.Columns[3].Width = 120;

                dgvAccounts.Columns[4].HeaderText = "نوع الحساب";
                dgvAccounts.Columns[4].Width = 100;

                dgvAccounts.Columns[5].HeaderText = "الرصيد";
                dgvAccounts.Columns[5].Width = 100;


                dgvAccounts.Columns[6].HeaderText = "العملة";
                dgvAccounts.Columns[6].Width = 70;


                dgvAccounts.Columns[7].HeaderText = "الحالة";
                dgvAccounts.Columns[7].Width = 100;

                dgvAccounts.Columns[8].HeaderText = "كنية الحساب";
                dgvAccounts.Columns[8].Width = 140;

                dgvAccounts.Columns[9].HeaderText = "الرقم العالمي-IBAN";
                dgvAccounts.Columns[9].Width = 200;

                //dgvAccounts.Columns[11].HeaderText = "تاريخ الإنشاء";
                //dgvAccounts.Columns[11].Width = 100;

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

                case "الاسم كامل":
                    FilterColumn = "FullName";
                    break;

                case "رقم الحساب":
                    FilterColumn = "AccountNumber";
                    break;
                case "نوع الحساب":
                    FilterColumn = "AccountTypeName";
                    break;
                case "العملة":
                    FilterColumn = "CodeCurrency";
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
                _dtAccounts.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvAccounts.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ID")
                //in this case we deal with integer not string.

                _dtAccounts.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAccounts.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvAccounts.Rows.Count.ToString();

            if (dgvAccounts.Rows.Count >= 2 && dgvAccounts.Rows.Count <= 10)
                lblNameResaultsCount.Text = "حسابات";
            else
                lblNameResaultsCount.Text = "حساب";
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
            if (cbFilterBy.Text == "ID" || cbFilterBy.Text == "رقم الحساب")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnMangeAccountTpes_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إدارة أنواع الحسابات"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            frmMangeAccountTypes frm = new frmMangeAccountTypes();
            frm.ShowDialog();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إضافة حساب"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            frmfrmAddUpdateAccount frm = new frmfrmAddUpdateAccount();
            frm.ShowDialog();
            _RefreshAccountsList();
        }

        private void AddAccount_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إضافة حساب"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            frmfrmAddUpdateAccount frm = new frmfrmAddUpdateAccount();
            frm.ShowDialog();
            _RefreshAccountsList();
        }


        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض تفاصيل و بحث عن حساب"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            frmShowAccountInfo frm = new frmShowAccountInfo((int)dgvAccounts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

                
        }

        private void ActivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("تغيير حالة الحساب"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد تفعيل  الحساب ؟", "حذف دور للمستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int AccountID = (int)dgvAccounts.CurrentRow.Cells[0].Value;
            clsAccount account = clsAccount.Find(AccountID);
            account.Status = clsAccount.enStatus.Active;
            account.UpdatedAt = DateTime.Now;

            if (account.Save())
            {
                MessageBox.Show("تم تفعيل الحساب بنجاح", "تم التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshAccountsList();
            }

            else
                MessageBox.Show("لم يتم تفعيل  الحساب , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("تغيير حالة الحساب"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد إغلاق  الحساب ؟", "حذف دور للمستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int AccountID = (int)dgvAccounts.CurrentRow.Cells[0].Value;
            clsAccount account = clsAccount.Find(AccountID);
            account.Status = clsAccount.enStatus.Closed;
            account.ClosedDate = DateTime.Now;
            account.UpdatedAt = DateTime.Now;
            if (account.Save())
            {
                MessageBox.Show("تم إغلاق الحساب بنجاح", "تم الإغلاق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshAccountsList();
            }

            else
                MessageBox.Show("لم يتم إغلاق  الحساب , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void CancelActvatetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("تغيير حالة الحساب"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد تعليق  الحساب ؟", "حذف دور للمستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int AccountID = (int)dgvAccounts.CurrentRow.Cells[0].Value;
            clsAccount account = clsAccount.Find(AccountID);
            account.Status = clsAccount.enStatus.Pending;
            account.UpdatedAt = DateTime.Now;

            if (account.Save())
            {
                MessageBox.Show("تم تعليق الحساب بنجاح", "تم التعليق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshAccountsList();
            }

            else
                MessageBox.Show("لم يتم تعليق  الحساب , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void cmsAccounts_Opening(object sender, CancelEventArgs e)
        {

            int AccountID = (int)dgvAccounts.CurrentRow.Cells[0].Value;
            clsAccount account = clsAccount.Find(AccountID);

            if(account.Status == clsAccount.enStatus.Closed)
            {
                ActivateToolStripMenuItem.Enabled = false;
                CloseToolStripMenuItem.Enabled = false;
                CancelActvatetoolStripMenuItem1.Enabled = false;
            }else if(account.Status == clsAccount.enStatus.Active)
            {
                ActivateToolStripMenuItem.Enabled = false;
                CloseToolStripMenuItem.Enabled = true;
                CancelActvatetoolStripMenuItem1.Enabled = true;
            }
            else if(account.Status == clsAccount.enStatus.Pending ||
                 (account.Status == clsAccount.enStatus.Dormant))
            {
                ActivateToolStripMenuItem.Enabled = true;
                CloseToolStripMenuItem.Enabled = true;
                CancelActvatetoolStripMenuItem1.Enabled = false;
            }

        }

        private void findAccounttoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض تفاصيل و بحث عن حساب"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmFindAccount frmFindAccount = new frmFindAccount();
            frmFindAccount.ShowDialog();
        }

        private void showAccountTransactionstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض معاملات حساب"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmListTransactionsForAccount frm = new frmListTransactionsForAccount((int)dgvAccounts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshAccountsList();
        }
    }
}
