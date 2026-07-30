using DVLD_Business;
using DVLD_UI.GlobalClasses;
using Infrastructure;
using Infrastructure.Configuration;
using Infrastructure.Security;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLD_UI.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void ptcb_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _HandleRememberMe()
        {
            string userName = txt_UserName.Text.Trim();
            string password = txt_PassWord.Text.Trim();

            if (ckb_RememberMe.Checked)
            {
                string encryptedPassword = SecurityHelper.Encrypt(password);

                if (encryptedPassword != null)
                {
                    RegistryManager.WriteToRegistry("UserName", userName);
                    RegistryManager.WriteToRegistry("Password", encryptedPassword);
                }
            }
            else
            {
                RegistryManager.DeleteFromRegistry("UserName");
                RegistryManager.DeleteFromRegistry("Password");
            }
        }

        private void _RetrieveRememberedData()
        {
             string savedUser = RegistryManager.ReadFromRegistry("UserName");
             string savedPass = RegistryManager.ReadFromRegistry("Password");

           if (!string.IsNullOrEmpty(savedUser) &&  !string.IsNullOrEmpty(savedPass))
            {  
              txt_UserName.Text = savedUser;
              txt_PassWord.Text = SecurityHelper.Decrypt(savedPass);
              ckb_RememberMe.Checked = true;
            }
        }
        private bool _IsUserLoginSuccessful()
        {
           clsGlobal.CurrentUser = clsUser.FindByUserameAndPassword(txt_UserName.Text.Trim(), txt_PassWord.Text.Trim());
            return clsGlobal.CurrentUser != null;
        }

       private  bool _IsUserActive()
        {
            return clsGlobal.CurrentUser.UserInfo.IsActive;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                   "Validation Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                return;
            }

            if (_IsUserLoginSuccessful())
            {
                if (_IsUserActive())
                {
                    this.DialogResult = DialogResult.OK;
                    _HandleRememberMe();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your account is not active, please contact the administrator",
                        "Account Inactive",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password, please try again",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


        }

        private void txt_Box_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox != null)
            {
                if (string.IsNullOrEmpty(txtBox.Text))
                {
                    errorProvider1.SetError(txtBox, $"{txtBox.Tag} is required.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtBox, string.Empty);
                }
            }


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _RetrieveRememberedData();
        }
    }
}
