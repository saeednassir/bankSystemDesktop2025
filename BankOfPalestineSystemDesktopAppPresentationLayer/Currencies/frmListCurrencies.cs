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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Currencies
{
    public partial class frmListCurrencies : Form
    {
        private static DataTable _dtAllCurrencies = clsCurrency.GetAllCurrencies();

        private DataTable _dtCurrencies = _dtAllCurrencies.DefaultView.ToTable(false, "ID", "Name",
                                                      "CurrencyNumber", "CodeCurrency", "CountryName", "IsActive",
                                                      "CreatedAt");

        private void _RefreshCurrenciesList()
        {
            _dtAllCurrencies = clsCurrency.GetAllCurrencies();
            _dtCurrencies = _dtAllCurrencies.DefaultView.ToTable(false, "ID", "Name",
                                                      "CurrencyNumber", "CodeCurrency", "CountryName", "IsActive",
                                                      "CreatedAt");
            dgvCurrencies.DataSource = _dtCurrencies;
            lblRecordsCount.Text = dgvCurrencies.Rows.Count.ToString();

            if (dgvCurrencies.Rows.Count >= 2 && dgvCurrencies.Rows.Count <= 10)
                lblNameResaultsCount.Text = "عملات";
            else
                lblNameResaultsCount.Text = "عملة";
        }


        public frmListCurrencies()
        {
            InitializeComponent();
        }

        private void frmListCurrencies_Load(object sender, EventArgs e)
        {
            dgvCurrencies.DataSource = _dtCurrencies;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvCurrencies.Rows.Count.ToString();

            if (dgvCurrencies.Rows.Count >= 2 && dgvCurrencies.Rows.Count <= 10)
                lblNameResaultsCount.Text = "عملات";
            else
                lblNameResaultsCount.Text = "عملة";

            if (dgvCurrencies.Rows.Count > 0)
            {

                dgvCurrencies.Columns[0].HeaderText = "ID";
                dgvCurrencies.Columns[0].Width = 110;

                dgvCurrencies.Columns[1].HeaderText = "إسم العملة";
                dgvCurrencies.Columns[1].Width = 120;


                dgvCurrencies.Columns[2].HeaderText = "رقم العملة";
                dgvCurrencies.Columns[2].Width = 160;

                dgvCurrencies.Columns[3].HeaderText = "رمز العملة";
                dgvCurrencies.Columns[3].Width = 120;

                dgvCurrencies.Columns[4].HeaderText = "الدولة";
                dgvCurrencies.Columns[4].Width = 140;

                dgvCurrencies.Columns[5].HeaderText = "فعالة";
                dgvCurrencies.Columns[5].Width = 120;


                dgvCurrencies.Columns[6].HeaderText = "تاريخ الإضافة";
                dgvCurrencies.Columns[6].Width = 120;


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

                case "إسم العملة":
                    FilterColumn = "Name";
                    break;

                case "رقم العملة":
                    FilterColumn = "CurrencyNumber";
                    break;

                case "رمز العملة":
                    FilterColumn = "CodeCurrency";
                    break;

                case "الدولة":
                    FilterColumn = "CountryName";
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
                _dtCurrencies.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvCurrencies.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ID")
                //in this case we deal with integer not string.

                _dtCurrencies.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtCurrencies.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvCurrencies.Rows.Count.ToString();

            if (dgvCurrencies.Rows.Count >= 2 && dgvCurrencies.Rows.Count <= 10)
                lblNameResaultsCount.Text = "عملات";
            else
                lblNameResaultsCount.Text = "عملة";

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
            if (cbFilterBy.Text == "ID" || cbFilterBy.Text == "رقم العملة")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد تفعيل هذه العملة ؟", "حذف شخص", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }


            clsCurrency currency = clsCurrency.FindByID((int)dgvCurrencies.CurrentRow.Cells[0].Value);
            currency.IsActive = true;

            if (currency.Save())
            {
                MessageBox.Show("تم تفعيل العملة بنجاح", "تفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshCurrenciesList();
            }

            else
                MessageBox.Show("لم يتم تفعيل العملة , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد إلغاء تفعيل هذه العملة ؟", "حذف شخص", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }


            clsCurrency currency = clsCurrency.FindByID((int)dgvCurrencies.CurrentRow.Cells[0].Value);
            currency.IsActive = false;

            if (currency.Save())
            {
                MessageBox.Show("تم إلغاء تفعيل العملة بنجاح", "إلغاء تفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshCurrenciesList();
            }

            else
                MessageBox.Show("لم يتم إلغاء تفعيل العملة , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void cmsCurrencies_Opening(object sender, CancelEventArgs e)
        {
            clsCurrency currency = clsCurrency.FindByID((int)dgvCurrencies.CurrentRow.Cells[0].Value);

            if (currency.IsActive)
            {
                activateToolStripMenuItem.Enabled = false;
                CancelToolStripMenuItem.Enabled = true;

            }
            else
            {
                activateToolStripMenuItem.Enabled = true;
                CancelToolStripMenuItem.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshCurrenciesList();
        }
    }
}
