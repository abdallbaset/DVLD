using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_UI.Users
{
    public partial class frmAddNewAndEditUser : Form
    {
        enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode;
        private int _UserID = -1;
        private clsUser _User;

        bool _IsPersonExist = false;

        public frmAddNewAndEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddNewAndEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private void tp_PersonInfo_Click(object sender, EventArgs e)
        {

        }

        private void frmAddNewAndEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _ResetDefaultValues()
        {
            
            if(_Mode == enMode.AddNew)
            {
                lbl_Mode.Text = "Add New User";
                _User = new clsUser();
            }

            txt_UserName.Text = string.Empty;
            txt_PassWord.Text = string.Empty;
            txt_ConfirmPassWord.Text = string.Empty;
            ckb_IsActive.Checked = true;
            
            btn_Save.Enabled = false; 
        }

        private void _LoadData()
        {
            _User = clsUser.FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lbl_Mode.Text = "Update User";
            lbl_UserID.Text = _User.UserInfo.UserID.ToString();
            txt_UserName.Text = _User.UserInfo.UserName;
            txt_PassWord.Text = _User.UserInfo.Password;
            txt_ConfirmPassWord.Text = _User.UserInfo.Password;
            ckb_IsActive.Checked = _User.UserInfo.IsActive;             
       }

        private void _ResetLoginInfo()
        {
            txt_UserName.Text = string.Empty;
            txt_PassWord.Text = string.Empty;
            txt_ConfirmPassWord.Text = string.Empty;
            ckb_IsActive.Checked = true;
        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {
                            
        }

        private void _MesseageIfPersonNotSelected()
        {
            MessageBox.Show("Please select a person first before moving to the next step.",
                               "Selection Required",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
        }

        private bool _IsUserExistForPersonID()
        {
            if (_Mode == enMode.Update)
            {
                btn_Save.Enabled = true;
                return true;
            }

            int PersonID = ctrlPersonCardWithFilter1.PersonID;
            if (clsUser.isUserExistForPersonID(PersonID))
            {
                MessageBox.Show("This person is already linked to another user. Please select a different person.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
            btn_Save.Enabled = true;
            return true;
        }
        private bool _IsPersonSelected()
        {
            _IsPersonExist = ctrlPersonCardWithFilter1.IsPersonExist;

            if (!_IsPersonExist)
            {
                _ResetLoginInfo();

                return false;
            }

            return true;

        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                return;
            }

            if (e.TabPageIndex != 0 && !_IsPersonSelected())
            {
                _MesseageIfPersonNotSelected();
                e.Cancel = true;

            }
            else if (e.TabPageIndex != 0 && !_IsUserExistForPersonID())
            {

                e.Cancel = true;

            }


        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                tabControl1.SelectedIndex = 1;

                return;
            }

            if (!_IsPersonSelected())
            {
                _MesseageIfPersonNotSelected();
            }
            else
            {
                if (!_IsUserExistForPersonID())
                {
                    return;
                }
                
                tabControl1.SelectedIndex = 1;

            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!_IsUserExistForPersonID())
            {
                return;
            }

            if (!_IsPersonSelected())
            {
                MessageBox.Show("Please select a person first before Save.",
                           "Selection Required",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                return;
            }


            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please fill all required fields correctly!",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

        

            

            _User.UserInfo.UserName = txt_UserName.Text.Trim();
            _User.UserInfo.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserInfo.Password = txt_PassWord.Text.Trim();
            _User.UserInfo.IsActive = ckb_IsActive.Checked;

         

            if (_User.Save())
            {
                MessageBox.Show("User information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_Mode.Text = "Update User";
                lbl_UserID.Text = _User.UserInfo.UserID.ToString();
                _Mode = enMode.Update;

              
                    ctrlPersonCardWithFilter1.DisableFilter();
                
            }
            else
            {
                MessageBox.Show("Failed to save user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {

            TextBox activeTextBox = sender as TextBox;

            if (string.IsNullOrEmpty(activeTextBox.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(activeTextBox, $"{activeTextBox.Tag} is required");
            }
            else
            {

                errorProvider1.SetError(activeTextBox, "");

            }

        }

        private void txt_ConfirmPassWord_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ConfirmPassWord.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_ConfirmPassWord, $"{txt_ConfirmPassWord.Tag} is required");
            }
            else
            {
                if(txt_ConfirmPassWord.Text != txt_PassWord.Text)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txt_ConfirmPassWord, $"Password Confirmation does not match Password!");
                }
                else
                    errorProvider1.SetError(txt_ConfirmPassWord, "");

            }
        }
    }
}
