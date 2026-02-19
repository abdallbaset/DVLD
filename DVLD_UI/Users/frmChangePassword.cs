using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserID =-1;
        private clsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID =   UserID;
            
        }

        private void _LoadUserInfo()
        {
                _User = clsUser.FindByUserID(_UserID);
                if (_User == null)
                {
                    MessageBox.Show($"No User with ID [{_UserID}] was found in the system.",
                                        "Not Found",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    this.Close();
            }
            ctrlUserCard1.LoadUserInfo(_UserID);

        }

        private void _ResetDefaultValues()
        {
            txt_CurrentPassword.Text = string.Empty;
            txt_NewPassword.Text = string.Empty;
            txt_ConfirmPassWord.Text = string.Empty;
            txt_CurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _LoadUserInfo();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void txt_CurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_CurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(txt_CurrentPassword, "");
                return;
            }


            if (txt_CurrentPassword.Text.Trim() != _User.UserInfo.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_CurrentPassword, $"Current Password is Worng!");
            }
            else
            {
                errorProvider1.SetError(txt_CurrentPassword, "");
            }
        }

        private void txt_NewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_NewPassword.Text.Trim()))
            {
                errorProvider1.SetError(txt_NewPassword, "");
                return;
            }
           
        }

        private void txt_ConfirmPassWord_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_NewPassword.Text.Trim()))
            {
                errorProvider1.SetError(txt_ConfirmPassWord, "");
                return;
            }

            if (txt_ConfirmPassWord.Text.Trim() != txt_NewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_ConfirmPassWord, $"Password Confirmation does not match New Password!");
            }
            else
            {
                errorProvider1.SetError(txt_ConfirmPassWord, "");
            }
        }

        private bool _txtBoxValidate()
        {
            return (string.IsNullOrEmpty(txt_NewPassword.Text.Trim()) || string.IsNullOrEmpty(txt_CurrentPassword.Text.Trim()) || string.IsNullOrEmpty(txt_ConfirmPassWord.Text.Trim()));
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (_txtBoxValidate())
            {
                MessageBox.Show("Please fill all required fields correctly!",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txt_CurrentPassword.Focus();

                return;
            }

            if (!this.ValidateChildren())
                return;

                _User.UserInfo.Password = txt_NewPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show("Password has been changed successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _ResetDefaultValues();
            }
            else
            {
                MessageBox.Show("Failed to save User password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RejectWhiteSpace(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
    }
}
