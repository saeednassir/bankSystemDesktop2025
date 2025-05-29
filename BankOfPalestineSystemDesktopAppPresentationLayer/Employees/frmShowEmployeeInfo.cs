using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Employees
{
    public partial class frmShowEmployeeInfo : Form
    {
        public frmShowEmployeeInfo(int EmployeeID)
        {
            InitializeComponent();

            ctrlEmployeeCard1.LoadEmployeeInfo(EmployeeID);
        }

        private void frmShowEmployeeInfo_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
