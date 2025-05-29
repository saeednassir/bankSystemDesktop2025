using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Clients.Controls
{
    public partial class ctrlClientCard : UserControl
    {
        private clsClient _Client;
        private int _ClientID = -1;

        public int ClientID
        {
            get { return _ClientID; }
        }


        public clsClient SelectedClientInfo
        {
            get { return _Client; }
        }

        public ctrlClientCard()
        {
            InitializeComponent();
        }

        public void LoadClientInfo(int ClientID)
        {
            _Client = clsClient.Find(ClientID);
            if (_Client == null)
            {
                _ResetClientInfo();
                MessageBox.Show("لا يوجد عميل بهذا الرقم = " + _ClientID.ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillClientInfo();
        }

        public void LoadClientInfo(string ClientNumber)
        {
            _Client = clsClient.Find(ClientNumber);
            if (_Client == null)
            {
                _ResetClientInfo();
                MessageBox.Show("لا يوجد عميل بهذا الرقم = " + _ClientID.ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillClientInfo();
        }
        private string GetStausString()
        {

            switch (_Client.Status)
            {
                case clsClient.enStatus.Pending:
                    return "قيد المراجعة";
                case clsClient.enStatus.Active:
                    return "فعال";
                case clsClient.enStatus.Inactive:
                    return "غير فعال";
                case clsClient.enStatus.Blocked:
                    return "محظور";

                default:
                    return "غير معروف";

            }
        }
        private void _FillClientInfo()
        {
            llEditClientInfo.Enabled = true;
            _ClientID = _Client.ID;
            ctrlPersonCard1.LoadPersonInfo(_Client.PersonID);
            lblClientID.Text = _Client.ID.ToString();
            lblClientNumber.Text = _Client.ClientNumber;
            lblCreatedAt.Text = _Client.CreatedAt.ToShortDateString();
            lblProfession.Text = _Client.Profession.ToString();
            lblStatus.Text = GetStausString();

            if (_Client.ClientType == clsClient.enClientType.Individual)
            {
                lblClientType.Text = "أفراد";
                gbCompanyName.Visible = false;
            }
            else if(_Client.ClientType == clsClient.enClientType.Corporate)
            {
                lblClientType.Text = "شركة";
                gbCompanyName.Visible = true;
                lblCompanyName.Text = _Client.CompanyName;
            }

            

        }

        public void _ResetClientInfo()
        {
            llEditClientInfo.Enabled = false;
            ctrlPersonCard1.ResetPersonInfo();
            lblClientID.Text = "[؟؟؟]";
            lblClientNumber.Text = "[؟؟؟]";
            lblClientType.Text = "[؟؟؟]";
            lblCreatedAt.Text = "[؟؟؟]";
            lblCompanyName.Text = "[؟؟؟]";
            lblProfession.Text = "[؟؟؟]";
            lblStatus.Text = "[؟؟؟]";
        }

        private void llEditClientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateClient frm = new frmAddUpdateClient(_ClientID);
            frm.ShowDialog();

            LoadClientInfo(_ClientID);
        }



    }
}
