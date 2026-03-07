using DVLD_Business;
using DVLD_UI.Controls;
using DVLD_UI.GlobalClasses;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace DVLD_UI.Users
{
    public partial class frmAddNewAndEditUser : Form
    {
        enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode;
        private int _UserID = (int)clsGlobal.enIdentityStatus.NonExistent;
        private clsUser _User;

        int _PersonID = (int)clsGlobal.enIdentityStatus.NonExistent;

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
                this.Text = "Add New User";
                _User = new clsUser();
                btn_Save.Enabled = false;
            }
            else
            {
                lbl_Mode.Text = "Update User";
                this.Text = "Update User";
                btn_Save.Enabled = true;

            }

            txt_UserName.Text = string.Empty;
            txt_PassWord.Text = string.Empty;
            txt_ConfirmPassWord.Text = string.Empty;
            ckb_IsActive.Checked = true;
            
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

            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            
            ctrlPersonCardWithFilter1.DisableFilter();
            lbl_UserID.Text = _User.UserID.ToString();
            txt_UserName.Text = _User.UserName;
            txt_PassWord.Text = _User.Password;
            txt_ConfirmPassWord.Text = _User.Password;
            ckb_IsActive.Checked = _User.IsActive; 
        }


        bool _IsPersonNotSelected()
        {
            _PersonID = ctrlPersonCardWithFilter1.PersonID;

            if (_PersonID == (int)clsGlobal.enIdentityStatus.NonExistent)
            {
                return true;
            }

            return false;
        }
      
        private bool _IsPersonSelection()
        {
            if (_Mode == enMode.Update)
            {
                btn_Save.Enabled = true;
                return true;
            }


            if(_IsPersonNotSelected())
            {
                MessageBox.Show("Please select a person first before moving to the next step.",
                               "Selection Required",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return false;
            }

            if (clsUser.isUserExistForPersonID(_PersonID))
            {
                MessageBox.Show("This person is already linked to another user. Please select a different person.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
            else
            {
                btn_Save.Enabled = true;
            }
            return true;

        }


   

        private  bool _IsPersonInvalidForSaving()
        {
            if (_Mode == enMode.Update)
                return false;
            
            if (_IsPersonNotSelected())
            {
                MessageBox.Show("Please select a person first before Save.",
                           "Selection Required",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                btn_Save.Enabled = false;
                return true;
            }

            if (clsUser.isUserExistForPersonID(_PersonID))
            {
                MessageBox.Show("This person is already linked to another user. Please select a different person.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                btn_Save.Enabled = false;
                return true;
            }
            return false;
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
        
            if (e.TabPageIndex != 0 && !_IsPersonSelection())
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

            if (!_IsPersonSelection())
            {
                return;
            }
            else
            {
                tabControl1.SelectedIndex = 1;
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SetUserInfoFromForm()
        {
            _User.UserName = txt_UserName.Text.Trim();
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.Password = txt_PassWord.Text.Trim();
            _User.IsActive = ckb_IsActive.Checked;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {


           if(_IsPersonInvalidForSaving())
             {
                return;
            }

       
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", 
                    "Validation Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                return;
            }


            _SetUserInfoFromForm();

            if (_User.Save())
            {
                MessageBox.Show("User information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_Mode.Text = "Update User";
                this.Text = "Update User";
                lbl_UserID.Text = _User.UserID.ToString();
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

   

        private void txt_ConfirmPassWord_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ConfirmPassWord.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_ConfirmPassWord, $"{txt_ConfirmPassWord.Tag} is required");
            }
            else
            {
                if(txt_ConfirmPassWord.Text.Trim() != txt_PassWord.Text.Trim())
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txt_ConfirmPassWord, $"Password Confirmation does not match Password!");
                }
                else
                    errorProvider1.SetError(txt_ConfirmPassWord, "");

            }
        }

        private void txt_UserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_UserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_UserName, $"{txt_UserName.Tag} is required");
                return;
            }
            else
            {
                if (_Mode == enMode.AddNew || (_Mode == enMode.Update && txt_UserName.Text.Trim() != _User.UserInfo.UserName))
                {
                    if (clsUser.IsUserExist(txt_UserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txt_UserName, $"This User Name is already exist, please choose another one!");
                    }
                    else
                    {
                        errorProvider1.SetError(txt_UserName, "");
                    }
                }
            }

            


        }

        private void txt_PassWord_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_PassWord.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_PassWord, $"{txt_PassWord.Tag} is required");
            }
            else
            {

                errorProvider1.SetError(txt_PassWord, "");

            }
        }

        private void frmAddNewAndEditUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }

        private void frmAddNewAndEditUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

             if(btn_Save.Enabled == true)
                {
                    btn_Save.PerformClick();
                }
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                btn_Close.PerformClick();
            }

        }
    }
}
