using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Cards.CardTypes;
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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Cards
{
    public partial class frmMangeCards : Form
    {

        private static DataTable _dtAllCards = clsCard.GetAllCards();
        DataTable _dtCards = _dtAllCards.DefaultView.ToTable(false, "ID", "NameOnCard",
                                                  "TypeName", "CardNumber", "IssueDate", "ExpierdDate",
                                                  "AccountNumber", "IsActive", "Username");


        private void _RefreshEmployeesList()
        {
           

            _dtAllCards = clsCard.GetAllCards();

            _dtCards = _dtAllCards.DefaultView.ToTable(false, "ID", "NameOnCard",
                                                      "TypeName", "CardNumber", "IssueDate", "ExpierdDate",
                                                      "AccountNumber", "IsActive", "Username");


            dgvCards.DataSource = _dtCards;
            lblRecordsCount.Text = dgvCards.Rows.Count.ToString();

            if (dgvCards.Rows.Count >= 2 && dgvCards.Rows.Count <= 10)
                lblNameResaultsCount.Text = "بطاقات";
            else
                lblNameResaultsCount.Text = "بطاقة";

        }

        public frmMangeCards()
        {
            InitializeComponent();
        }

        private void btnMangeCardTpes_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("إدارة أنواع البطاقات"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmMangeCardTypes frm = new frmMangeCardTypes();
            frm.ShowDialog();
        }

        private void frmMangeCards_Load(object sender, EventArgs e)
        {
            if (_dtAllCards.Rows.Count == 0)
            {
                lblRecordsCount.Text = "0";
                lblNotFoundCards.Visible = true;
                return;
            }

            
            dgvCards.DataSource = _dtCards;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvCards.Rows.Count.ToString();


            if (dgvCards.Rows.Count >= 2 && dgvCards.Rows.Count <= 10)
                lblNameResaultsCount.Text = "بطاقات";
            else
                lblNameResaultsCount.Text = "بطاقة";


            if (dgvCards.Rows.Count > 0)
            {

                dgvCards.Columns[0].HeaderText = "ID";
                dgvCards.Columns[0].Width = 90;

                dgvCards.Columns[1].HeaderText = "الإسم على البطاقة";
                dgvCards.Columns[1].Width = 170;


                dgvCards.Columns[2].HeaderText = "النوع";
                dgvCards.Columns[2].Width = 120;

                dgvCards.Columns[3].HeaderText = "رقم البطاقة";
                dgvCards.Columns[3].Width = 120;

                dgvCards.Columns[4].HeaderText = "تاريخ الاإصدار";
                dgvCards.Columns[4].Width = 100;

                dgvCards.Columns[5].HeaderText = "اريخ الإنتهاء";
                dgvCards.Columns[5].Width = 100;


                dgvCards.Columns[6].HeaderText = "رقم الحساب";
                dgvCards.Columns[6].Width = 130;


                dgvCards.Columns[7].HeaderText = "فعال";
                dgvCards.Columns[7].Width = 100;

                dgvCards.Columns[8].HeaderText = "انشاء بواسطة";
                dgvCards.Columns[8].Width = 100;

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

                case "الإسم على البطاقة":
                    FilterColumn = "NameOnCard";
                    break;

                case "اسم المستخدم":
                    FilterColumn = "Username";
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
                _dtCards.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvCards.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ID")
                //in this case we deal with integer not string.

                _dtCards.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtCards.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvCards.Rows.Count.ToString();

            if (dgvCards.Rows.Count >= 2 && dgvCards.Rows.Count <= 10)
                lblNameResaultsCount.Text = "بطاقات";
            else
                lblNameResaultsCount.Text = "بطاقة";
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
            if (cbFilterBy.Text == "ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmsCards_Opening(object sender, CancelEventArgs e)
        {
            clsCard card = clsCard.Find((int)dgvCards.CurrentRow.Cells[0].Value);

            if(card.IsActive)
            {
                ActivateToolStripMenuItem.Enabled = false;
                CancelCardToolStripMenuItem.Enabled = true;
            }else
            {
                ActivateToolStripMenuItem.Enabled = true;
                CancelCardToolStripMenuItem.Enabled = false;
            }

        }

        private void ActivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("تغيير حالة البطاقة"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد تفعيل هذه البطاقة ؟", "حذف شخص", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int CardID = (int)dgvCards.CurrentRow.Cells[0].Value;

            clsCard card = clsCard.Find((int)dgvCards.CurrentRow.Cells[0].Value);
            card.IsActive = true;

            if (card.Save())
            {
                MessageBox.Show("تم تفعيل البطاقة بنجاح", "تم التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshEmployeesList();
            }

            else
                MessageBox.Show("لم يتم تفعيل البطاقة الموظف , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void CancelCardToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!clsGlobal.HasPermissions("تغيير حالة البطاقة"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد إلغاء تفعيل هذه البطاقة ؟", "حذف شخص", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int CardID = (int)dgvCards.CurrentRow.Cells[0].Value;

            clsCard card = clsCard.Find((int)dgvCards.CurrentRow.Cells[0].Value);
            card.IsActive = false;

            if (card.Save())
            {
                MessageBox.Show("تم إلغاء تفعيل البطاقة بنجاح", "تم إلغاء تفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshEmployeesList();
            }

            else
                MessageBox.Show("لم يتم إلغاء تفعيل البطاقة الموظف , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {

            if (!clsGlobal.HasPermissions("إضافة بطاقة"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmAddCard frmAddCard = new frmAddCard();
            frmAddCard.ShowDialog();
            _RefreshEmployeesList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض تفاصل و بحث عن بطاقة بطاقة"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmShowCardInfo frm = new frmShowCardInfo((int)dgvCards.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void findEmployeetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions("عرض تفاصل و بحث عن بطاقة بطاقة"))
            {
                frmAccessDenied frm1 = new frmAccessDenied();
                frm1.Show();
                return;
            }

            frmFindCard frm = new frmFindCard();
            frm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshEmployeesList();
        }
    }
}
