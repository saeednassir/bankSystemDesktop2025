using BankOfPalestineSystemBusinessLayer;
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

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
            guna2ShadowForm1.SetShadowForm(this);

            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUsername.Text = UserName;
                txtPassword.Text = Password;
                chkRemmberMe.Checked = true;
                
            }
            else
            {
                chkRemmberMe.Checked = false;
                txtUsername.Focus();
            }

           

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            pbLoading.Visible = true;

            clsUser user = clsUser.FindByUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {

                if (chkRemmberMe.Checked)
                {
                    //store username and password
                    clsGlobal.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    //store empty username and password
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                //incase the user is not active
                if (!user.IsActive)
                {
                    txtUsername.Focus();
                    MessageBox.Show("المسخدم غير فعال, تواصل مع مسؤول النظام.", "المستخجم غير فعال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pbLoading.Visible = false;
                    return;
                }

                clsGlobal.LastLogin = user.LastLogin;

                user.LastLogin = DateTime.Now;
                user.Save();

                clsGlobal.CurrentUser = user;
                clsGlobal.hashSetPermissions = clsPermission.GetAllPermissionNameByUserID(user.ID);

                
                pbLoading.Visible = false;
                this.Hide();

                frmLoading frmLoading = new frmLoading();
                frmLoading.ShowDialog();

                frmMain frmMain = new frmMain(this);
                frmMain.ShowDialog();


            }
            else
            {
                pbLoading.Visible = false;
                txtUsername.Focus();
                MessageBox.Show("اسم المستخدم/كلمة المرور غير صحيحة.", "معلومات خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Enter(object sender, EventArgs e)
        {
            btnLogin.PerformClick();
        }
    }
}
