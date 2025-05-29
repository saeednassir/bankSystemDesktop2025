using BankOfPalestineSystemBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Accounts
{
    public partial class frmChooseAccountForClient : Form
    {
        string _ClientNumber = "";

        public delegate void DataBackEventHandler(object sender, int AccountID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;


        public frmChooseAccountForClient(string clientNumber)
        {
            InitializeComponent();

            _ClientNumber = clientNumber;
        }

        private void frmChooseAccountForClient_Load(object sender, EventArgs e)
        {
            
            guna2ShadowForm1.SetShadowForm(this);

            DataTable _dtAllAccounts = clsAccount.GetAllAccountsForClient(_ClientNumber);

            if(_dtAllAccounts.Rows.Count == 0)
            {
                lblNotFoundAccount.Visible = true;
                return;
            }

            DataTable _dtAccounts = _dtAllAccounts.DefaultView.ToTable(false, "AccountID", "AccountNumber",
                                                      "AccountType", "Balance", "CodeCurrency", "NicName");
            dgvAccounts.DataSource = _dtAccounts;


            if (dgvAccounts.Rows.Count > 0)
            {

                dgvAccounts.Columns[0].HeaderText = "ID";
                dgvAccounts.Columns[0].Width = 70;

                dgvAccounts.Columns[1].HeaderText = "رقم الحساب";
                dgvAccounts.Columns[1].Width = 130;


                dgvAccounts.Columns[2].HeaderText = "نوع الحساب";
                dgvAccounts.Columns[2].Width = 100;

                dgvAccounts.Columns[3].HeaderText = "الرصيد";
                dgvAccounts.Columns[3].Width = 100;

                dgvAccounts.Columns[4].HeaderText = "العملة";
                dgvAccounts.Columns[4].Width = 70;

                dgvAccounts.Columns[5].HeaderText = "كنية الحساب";
                dgvAccounts.Columns[5].Width = 120;


                

            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataBack?.Invoke(this,(int)dgvAccounts.CurrentRow.Cells[0].Value);
            this.Close();

        }
    }
}
