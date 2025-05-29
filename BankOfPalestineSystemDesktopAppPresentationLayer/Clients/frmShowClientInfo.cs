using Guna.UI2.WinForms;
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
    public partial class frmShowClientInfo : Form
    {
        public frmShowClientInfo(int ClientID)
        {
            InitializeComponent();
            ctrlClientCard1.LoadClientInfo(ClientID);
        }

        private void frmShowClientInfo_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

      
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
