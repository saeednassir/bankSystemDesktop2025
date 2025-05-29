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
    public partial class frmFindEmployee : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int EmployeeID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;


        public frmFindEmployee()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlEmployeeCardWithFilter1.EmployeeID);
            this.Close();
        }

        private void frmFindEmployee_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void CtrlBoxClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlEmployeeCardWithFilter1.EmployeeID);
            this.Close();
        }
    }
}
