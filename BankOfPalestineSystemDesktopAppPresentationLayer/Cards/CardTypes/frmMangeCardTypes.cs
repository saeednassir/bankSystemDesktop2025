using BankOfPalestineSystemBusinessLayer;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BankOfPalestineSystemBusinessLayer.clsTransactionType;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Cards.CardTypes
{
    public partial class frmMangeCardTypes : Form
    {

        private static DataTable _dtAllCardTypes = clsCardType.GetAllCardTypes();

        private DataTable _dtCardTypes = _dtAllCardTypes.DefaultView.ToTable(false, "ID", "TypeName",
                                                      "DefaultValidityLength", "CardTypeFees");

        private void _RefreshCardTypesList()
        {
            _dtAllCardTypes = clsCardType.GetAllCardTypes();
            _dtCardTypes = _dtAllCardTypes.DefaultView.ToTable(false, "ID", "TypeName",
                                                      "DefaultValidityLength", "CardTypeFees");
            dgvCardTypes.DataSource = _dtCardTypes;
            lblRecordsCount.Text = dgvCardTypes.Rows.Count.ToString();

            if (dgvCardTypes.Rows.Count >= 2 && dgvCardTypes.Rows.Count <= 10)
                lblNameResaultsCount.Text = "أنواع بطاقات";
            else
                lblNameResaultsCount.Text = "نوع بطاقة";


        }



        public frmMangeCardTypes()
        {
            InitializeComponent();
        }

        private void frmMangeCardTypes_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);


            dgvCardTypes.DataSource = _dtCardTypes;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvCardTypes.Rows.Count.ToString();

            if (dgvCardTypes.Rows.Count >= 2 && dgvCardTypes.Rows.Count <= 10)
                lblNameResaultsCount.Text = "أنواع بطاقات";
            else
                lblNameResaultsCount.Text = "نوع بطاقة";


            if (dgvCardTypes.Rows.Count > 0)
            {

                dgvCardTypes.Columns[0].HeaderText = "ID";
                dgvCardTypes.Columns[0].Width = 70;

                dgvCardTypes.Columns[1].HeaderText = "الإسم";
                dgvCardTypes.Columns[1].Width = 100;

                dgvCardTypes.Columns[2].HeaderText = "مدة الصلاحية بالسنين";
                dgvCardTypes.Columns[2].Width = 120;

                dgvCardTypes.Columns[3].HeaderText = "رسوم الإصدار";
                dgvCardTypes.Columns[3].Width = 100;



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
                    FilterColumn = "TypeName";
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
                _dtCardTypes.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvCardTypes.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ID")
                //in this case we deal with integer not string.

                _dtCardTypes.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtCardTypes.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvCardTypes.Rows.Count.ToString();


            if (dgvCardTypes.Rows.Count >= 2 && dgvCardTypes.Rows.Count <= 10)
                lblNameResaultsCount.Text = "أنواع بطاقات";
            else
                lblNameResaultsCount.Text = "نوع بطاقة";
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("هل أنت متأكد أنك تريد حذف  نوع البطاقة ؟", "حذف دور للمستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            int CardTypeID = (int)dgvCardTypes.CurrentRow.Cells[0].Value;
            if (clsCardType.DeleteCardType(CardTypeID))
            {
                MessageBox.Show("تم حذف  نوع البطاقة بنجاح", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshCardTypesList();
            }

            else
                MessageBox.Show("لم يتم حذف  نوع البطاقة , حاول مرة اخرى.", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTypeName.Text == "")
            {
                MessageBox.Show("الرجاء إدخال إسم نوع البطاقة !", "الحقل فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsCardType cardType = new clsCardType();

            cardType.TypeName = txtTypeName.Text;
            cardType.DefaultValidityLength = (byte)nudDefaultValidityLength.Value;
            cardType.CardTypeFees = Convert.ToDecimal(txtCardTypeFees.Text);

            if (cardType.Save())
            {
                txtCardTypeID.Text = cardType.ID.ToString();
                _RefreshCardTypesList();
                MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("خطأ : لم يتم حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCardTypeID.Text = dgvCardTypes.CurrentRow.Cells[0].Value.ToString();

            clsCardType cardType = clsCardType.Find(Convert.ToInt32(txtCardTypeID.Text));

            txtTypeName.Text = cardType.TypeName;
            nudDefaultValidityLength.Value = cardType.DefaultValidityLength;
            txtCardTypeFees.Text = cardType.CardTypeFees.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTypeName.Text == "")
            {
                MessageBox.Show("الرجاء إدخال إسم  !", "الحقل فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsCardType cardType = new clsCardType();

            cardType.TypeName = txtTypeName.Text;
            cardType.DefaultValidityLength = (byte)nudDefaultValidityLength.Value;
            cardType.CardTypeFees = Convert.ToDecimal(txtCardTypeFees.Text);

            if (cardType.Save())
            {
                txtCardTypeID.Text = cardType.ID.ToString();
                _RefreshCardTypesList();
                MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("خطأ : لم يتم حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _RefreshCardTypesList();
        }
    }
}
