using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Global_Classes;
using BankOfPalestineSystemDesktopAppPresentationLayer.People.Controls;
using BankOfPalestineSystemDesktopAppPresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Cards
{
    public partial class frmAddCard : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int CardID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;


        public frmAddCard()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlAccountCardWithFilter1.AccountID != -1)
            {
              
                    btnSave.Enabled = true;
                    tpCardInfo.Enabled = true;
                    tcCardInfo.SelectedTab = tcCardInfo.TabPages["tpCardInfo"];
            }

            else

            {
                MessageBox.Show("الرجاء اختيار حساب", "اختر حساب", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlAccountCardWithFilter1.FilterFocus();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if(ctrlAccountCardWithFilter1.SelectedAccountInfo.Status != clsAccount.enStatus.Active)
            {
                MessageBox.Show("لا يمكن انشاء بطاقة لحساب غير فعال !",
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsCard card = new clsCard();

            card.NameOnCard = txtNameOnCard.Text;
            card.CardNumber = clsGlobal.CreateCardNumber();
            card.CVVNumber = clsGlobal.CreateCvvNumberCard();
            card.IssueDate = DateTime.Now;
            card.ExpierdDate = DateTime.Now.AddYears(clsCardType.Find(cbCardType.Text).DefaultValidityLength);
            card.AccountLinked = ctrlAccountCardWithFilter1.AccountID;
            card.IsActive = true;
            card.CreatedByUser = clsGlobal.CurrentUser.ID;
            card.PinCode = txtPinCode.Text;
            card.CardTypeID = clsCardType.Find(cbCardType.Text).ID;
            if (card.Save())
            {
                lblCardID.Text = card.ID.ToString();
                


                MessageBox.Show("تم حفظ البيانات بنجاح .", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, card.ID);
                this.Close();
            }
            else
                MessageBox.Show("خطأ : لم يتم حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void _FillCardTypesInComoboBox()
        {
            DataTable dtCardTypes = clsCardType.GetAllCardTypes();

            foreach (DataRow row in dtCardTypes.Rows)
            {
                cbCardType.Items.Add(row["TypeName"]);
            }
        }

        private void frmAddCard_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            _FillCardTypesInComoboBox();
            cbCardType.SelectedIndex = 0;
            tpCardInfo.Enabled = false;

        }

        private void ctrlAccountCardWithFilter1_OnAccountSelected(int obj)
        {
            if (ctrlAccountCardWithFilter1.SelectedAccountInfo.Status != clsAccount.enStatus.Active)
            {
                MessageBox.Show("لا يمكن انشاء بطقة لحساب غير فعال !",
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnNext.Enabled = false;
                btnSave.Enabled = false;
            }
        }
    }
}
