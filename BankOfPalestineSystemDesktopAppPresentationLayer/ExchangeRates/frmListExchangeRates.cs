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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.ExchangeRates
{
    public partial class frmListExchangeRates : Form
    {
        private static DataTable _dtAllExchangeRates = clsExchangeRate.GetAllExchangeRates();

        private DataTable _dtExchangeRates = _dtAllExchangeRates.DefaultView.ToTable(false, "ExchangeRateID", "FromCurrency",
                                                      "ToCurrency", "Rate", "EffectiveDateTime", "RateType",
                                                      "RateSource", "CreatedAt");


        private void _RefreshExchangeRatesList()
        {
            _dtAllExchangeRates = clsExchangeRate.GetAllExchangeRates();
            _dtExchangeRates = _dtAllExchangeRates.DefaultView.ToTable(false, "ExchangeRateID", "FromCurrency",
                                                      "ToCurrency", "Rate", "EffectiveDateTime", "RateType",
                                                      "RateSource", "CreatedAt");
            dgvExchangeRates.DataSource = _dtExchangeRates;
            lblRecordsCount.Text = dgvExchangeRates.Rows.Count.ToString();

            if (dgvExchangeRates.Rows.Count >= 2 && dgvExchangeRates.Rows.Count <= 10)
                lblNameResaultsCount.Text = "عملات";
            else
                lblNameResaultsCount.Text = "عملة";
        }


        public frmListExchangeRates()
        {
            InitializeComponent();
        }

        private void btnAddExchangeRate_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إضافة سعر عملة"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            frmAddUpdateExchangeRate frm = new frmAddUpdateExchangeRate();
            frm.ShowDialog();
            _RefreshExchangeRatesList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إضافة سعر عملة"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmAddUpdateExchangeRate frm = new frmAddUpdateExchangeRate(Convert.ToInt32(dgvExchangeRates.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _RefreshExchangeRatesList();

        }

        private void frmListExchangeRates_Load(object sender, EventArgs e)
        {
            dgvExchangeRates.DataSource = _dtExchangeRates;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvExchangeRates.Rows.Count.ToString();


            if (dgvExchangeRates.Rows.Count >= 2 && dgvExchangeRates.Rows.Count <= 10)
                lblNameResaultsCount.Text = "عملات";
            else
                lblNameResaultsCount.Text = "عملة";

            if (dgvExchangeRates.Rows.Count > 0)
            {

                dgvExchangeRates.Columns[0].HeaderText = "رقم سعر العملة";
                dgvExchangeRates.Columns[0].Width = 110;

                dgvExchangeRates.Columns[1].HeaderText = "من عملة";
                dgvExchangeRates.Columns[1].Width = 120;


                dgvExchangeRates.Columns[2].HeaderText = "إلى عملة";
                dgvExchangeRates.Columns[2].Width = 120;

                dgvExchangeRates.Columns[3].HeaderText = "السعر";
                dgvExchangeRates.Columns[3].Width = 120;

                dgvExchangeRates.Columns[4].HeaderText = "تاريخ تأثيرالسعر ";
                dgvExchangeRates.Columns[4].Width = 140;

                dgvExchangeRates.Columns[5].HeaderText = "نوع السعر";
                dgvExchangeRates.Columns[5].Width = 120;


                dgvExchangeRates.Columns[6].HeaderText = "مصدر السعر";
                dgvExchangeRates.Columns[6].Width = 120;


                dgvExchangeRates.Columns[7].HeaderText = "تاريخ الإضافة";
                dgvExchangeRates.Columns[7].Width = 140;
            }
        }

   
        public string GetFilterColumnName()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "رقم سعر العملة":
                    FilterColumn = "ExchangeRateID";
                    break;

                case "من عملة":
                    FilterColumn = "FromCurrency";
                    break;

                case "إلى عملة":
                    FilterColumn = "ToCurrency";
                    break;

                case "السعر":
                    FilterColumn = "Rate";
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
                _dtExchangeRates.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvExchangeRates.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ExchangeRateID")
                //in this case we deal with integer not string.

                _dtExchangeRates.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtExchangeRates.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvExchangeRates.Rows.Count.ToString();


            if (dgvExchangeRates.Rows.Count >= 2 && dgvExchangeRates.Rows.Count <= 10)
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
            if (cbFilterBy.Text == "رقم سعر العملة" || cbFilterBy.Text == "السعر")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا السعر ؟", "حذف سعر", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int ExchangeRateID = Convert.ToInt32(dgvExchangeRates.CurrentRow.Cells[0].Value);
            if (clsExchangeRate.DeleteExchangeRate(ExchangeRateID))
            {
                MessageBox.Show("تم حذف السعر بنجاح", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshExchangeRatesList();
            }

            else
                MessageBox.Show("لم يتم حذف السعر , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshExchangeRatesList();
        }
    }
}
