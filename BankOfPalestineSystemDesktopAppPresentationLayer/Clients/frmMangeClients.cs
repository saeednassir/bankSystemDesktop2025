using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Accounts;
using BankOfPalestineSystemDesktopAppPresentationLayer.Clients.Controls;
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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Clients
{
    public partial class frmMangeClients : Form
    {
        private static DataTable _dtAllClients = clsClient.GetAllClients();

        private DataTable _dtClients = _dtAllClients.DefaultView.ToTable(false, "ID", "FullName",
                                                      "ClientNumber", "Profession", "CompanyName", "ClientType",
                                                      "Status", "CreatedAt");

        private void _RefreshClientsList()
        {
            _dtAllClients = clsClient.GetAllClients();
            _dtClients = _dtAllClients.DefaultView.ToTable(false, "ID", "FullName",
                                                      "ClientNumber", "Profession", "CompanyName", "ClientType",
                                                      "Status", "CreatedAt");
            dgvClients.DataSource = _dtClients;
            lblRecordsCount.Text = dgvClients.Rows.Count.ToString();

            if (dgvClients.Rows.Count >= 2 && dgvClients.Rows.Count <= 10)
                lblNameResaultsCount.Text = "عملاء";
            else
                lblNameResaultsCount.Text = "عميل";

        }


        public frmMangeClients()
        {
            InitializeComponent();
        }

        private void frmMangeClients_Load(object sender, EventArgs e)
        {
            if(_dtClients.Rows.Count > 0)
                dgvClients.DataSource = _dtClients;

            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvClients.Rows.Count.ToString();

            if (dgvClients.Rows.Count >= 2 && dgvClients.Rows.Count <= 10)
                lblNameResaultsCount.Text = "عملاء";
            else
                lblNameResaultsCount.Text = "عميل";

            if (dgvClients.Rows.Count > 0)
            {

                dgvClients.Columns[0].HeaderText = "ID";
                dgvClients.Columns[0].Width = 110;

                dgvClients.Columns[1].HeaderText = "الإسم كامل";
                dgvClients.Columns[1].Width = 160;


                dgvClients.Columns[2].HeaderText = "رقم العميل";
                dgvClients.Columns[2].Width = 120;

                dgvClients.Columns[3].HeaderText = "المهنة";
                dgvClients.Columns[3].Width = 140;

                dgvClients.Columns[4].HeaderText = "إسم الشركة";
                dgvClients.Columns[4].Width = 120;

                dgvClients.Columns[5].HeaderText = "نوع العميل";
                dgvClients.Columns[5].Width = 100;


                dgvClients.Columns[6].HeaderText = "الحالة";
                dgvClients.Columns[6].Width = 100;


                dgvClients.Columns[7].HeaderText = "تاريخ الإضافة";
                dgvClients.Columns[7].Width = 120;
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

                case "الإسم كامل":
                    FilterColumn = "FullName";
                    break;

                case "رقم العميل":
                    FilterColumn = "ClientNumber";
                    break;

                case "المهنة":
                    FilterColumn = "Profession";
                    break;

                case "إسم الشركة":
                    FilterColumn = "CompanyName";
                    break;

                case "نوع العميل":
                    FilterColumn = "ClientType";
                    break;
                case "الحالة":
                    FilterColumn = "Status";
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
                _dtClients.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvClients.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ID")
                //in this case we deal with integer not string.

                _dtClients.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtClients.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvClients.Rows.Count.ToString();

            if (dgvClients.Rows.Count >= 2 && dgvClients.Rows.Count <= 10)
                lblNameResaultsCount.Text = "عملاء";
            else
                lblNameResaultsCount.Text = "عميل";
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
            if (cbFilterBy.Text == "ID" || cbFilterBy.Text == "رقم العميل")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إضافة وتعديل عميل"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            frmAddUpdateClient frm = new frmAddUpdateClient();
            frm.ShowDialog();
            _RefreshClientsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إضافة وتعديل عميل"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            frmAddUpdateClient frm = new frmAddUpdateClient((int)dgvClients.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshClientsList();
        }

        private void AddEmployee_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إضافة وتعديل عميل"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            frmAddUpdateClient frm = new frmAddUpdateClient();
            frm.ShowDialog();
            _RefreshClientsList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض تفاصيل و بحث عن عميل"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmShowClientInfo frm = new frmShowClientInfo((int)dgvClients.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void findEmployeetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض تفاصيل و بحث عن عميل"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmFindClient frm = new frmFindClient();
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("حذف عميل"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد حذف العميل ؟", "حذف دور للمستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;
            if (clsClient.DeleteClient(ClientID))
            {
                MessageBox.Show("تم حذف  العميل بنجاح", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshClientsList();
            }

            else
                MessageBox.Show("لم يتم حذف  العميل , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshClientsList();
        }

        private void ShowAccountClienttoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض حسابات عميل"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }
            frmChooseAccountForClient frm = new frmChooseAccountForClient((string)dgvClients.CurrentRow.Cells[2].Value);
            frm.ShowDialog();
        }
    }
}
