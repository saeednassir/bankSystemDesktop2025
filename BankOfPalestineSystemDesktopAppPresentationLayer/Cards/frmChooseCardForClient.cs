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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Cards
{
    public partial class frmChooseCardForClient : Form
    {
        string _ClientNumber = "";

        public delegate void DataBackEventHandler(object sender, int CardID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public frmChooseCardForClient(string clientNumber)
        {
            InitializeComponent();
            _ClientNumber = clientNumber;

        }

        private void frmChooseCardForClient_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            //
            DataTable _dtAllCards = clsCard.GetAllCardsForClient(_ClientNumber);

            if(_dtAllCards.Rows.Count == 0)
            {
                lblNotFoundCards.Visible = true;
                return;
            }

            DataTable _dtCards = _dtAllCards.DefaultView.ToTable(false, "CardID", "CardNumber", "TypeName",
                                                      "IsActive", "IssueDate", "ExpierdDate");
            dgvCards.DataSource = _dtCards;


            if (dgvCards.Rows.Count > 0)
            {

                dgvCards.Columns[0].HeaderText = "CardID";
                dgvCards.Columns[0].Width = 70;

                dgvCards.Columns[1].HeaderText = "رقم البطاقة";
                dgvCards.Columns[1].Width = 130;


                dgvCards.Columns[2].HeaderText = "نوع البطاقة";
                dgvCards.Columns[2].Width = 100;

                dgvCards.Columns[3].HeaderText = "فعالة";
                dgvCards.Columns[3].Width = 100;

                dgvCards.Columns[4].HeaderText = "تاريخ الإصدار";
                dgvCards.Columns[4].Width = 70;

                dgvCards.Columns[5].HeaderText = "تاريخ الإنتهاء";
                dgvCards.Columns[5].Width = 120;




            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCards_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataBack?.Invoke(this, (int)dgvCards.CurrentRow.Cells[0].Value);
            this.Close();
        }
    }
}
