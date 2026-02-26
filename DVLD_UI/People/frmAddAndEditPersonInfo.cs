using DVLD_Business;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace DVLD_UI
{
    public partial class frmAddAndEditPersonInfo : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;


        enum enMode { AddNew, Edit }
        enum enGendor : byte { Male = 0, Female = 1 }

        private enMode _Mode;
        private int _PersonID;
        private clsPeople _Person;
    

        public frmAddAndEditPersonInfo(int PersonID)
        {
             

            InitializeComponent();
            if (PersonID == -1)
            {
                _Mode = enMode.AddNew;

            }
            else
            {
                _Mode = enMode.Edit;
            }

            _PersonID = PersonID;

        }
        public void _FillCountriesInComoboBox()
        {
            DataTable dtCountry = clsCountries.GetAllCountry();
            foreach (DataRow dr in dtCountry.Rows)
            {
                cmb_Countrys.Items.Add(dr["CountryName"].ToString());
            }
        }


        private void _ResetDefualtValues()
        {
            _FillCountriesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lbl_Mode.Text = "Add New Person";
                this.Text = "Add New Person";
                _Person = new clsPeople();

            }
            else
            {
                lbl_Mode.Text = "Update Person";
                this.Text = "Update Person";
            }

            rdb_Male.Checked = true;

            if (rdb_Male.Checked)
                ptb_PersonImage.Image = Properties.Resources.male_Man_face; 
            else
                ptb_PersonImage.Image = Properties.Resources.female_girl_face;

            btn_RemoveImage.Visible = (ptb_PersonImage.ImageLocation != null);

            dtp_DateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtp_DateOfBirth.Value = dtp_DateOfBirth.MaxDate;

            dtp_DateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cmb_Countrys.SelectedIndex = cmb_Countrys.FindString("libya");

            txt_FirstName.Text = string.Empty;
            txt_SecondName.Text = string.Empty;
            txt_ThirdName.Text = string.Empty;
            txt_LastName.Text = string.Empty;
            txt_NotionalNO.Text = string.Empty;
          
            txt_Phone.Text = string.Empty;
            txt_Email.Text = string.Empty;
            txt_Address.Text = string.Empty;


        }
        private void _loadData()
        {
            _Person = clsPeople.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            if (_Person != null)
            {
                lbl_PersonID.Text = _Person.PersonInfo.PersonID.ToString();
                txt_FirstName.Text = _Person.PersonInfo.FirstName;
                txt_SecondName.Text = _Person.PersonInfo.SecondName;
                txt_ThirdName.Text = _Person.PersonInfo.ThirdName;
                txt_LastName.Text = _Person.PersonInfo.LastName;
                txt_NotionalNO.Text = _Person.PersonInfo.NationalNo;
                dtp_DateOfBirth.Value = _Person.PersonInfo.DateOfBirth;

                if (_Person.PersonInfo.Gendor == (byte)enGendor.Female)
                    rdb_Female.Checked = true;
                else
                    rdb_Male.Checked = true;

                txt_Phone.Text = _Person.PersonInfo.phone;
                txt_Email.Text = _Person.PersonInfo.Email;
                cmb_Countrys.SelectedIndex = cmb_Countrys.FindString(clsCountries.GetCountryNameByCountryID(_Person.PersonInfo.NationalityCountryID));
                txt_Address.Text = _Person.PersonInfo.Address;
                if (_Person.PersonInfo.ImagePath != "")
                {
                    ptb_PersonImage.ImageLocation = _Person.PersonInfo.ImagePath;
                }
                else
                {
                    ptb_PersonImage.Image = (_Person.PersonInfo.Gendor == (byte)enGendor.Male) ? Properties.Resources.male_Man_face : Properties.Resources.female_girl_face;
                }

                btn_RemoveImage.Visible = (ptb_PersonImage.ImageLocation != null);

            }


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



        private bool _HandlePersonImage()
        {

       
            if (_Person.PersonInfo.ImagePath != ptb_PersonImage.ImageLocation)
            {
                if (_Person.PersonInfo.ImagePath != "")
                {

                    clsUtil.DeletePersonImageOnDisk(_Person.PersonInfo.ImagePath);
                }

                if (ptb_PersonImage.ImageLocation != null)
                {
                    string SourceImageFile = ptb_PersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        ptb_PersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!_HandlePersonImage())
            {
                return;
            }


            int CountryID = clsCountries.GetCountryIDByCountryName(cmb_Countrys.Text);

            _Person.PersonInfo.FirstName = txt_FirstName.Text.Trim();
            _Person.PersonInfo.SecondName = txt_SecondName.Text.Trim();
            _Person.PersonInfo.ThirdName = txt_ThirdName.Text.Trim();
            _Person.PersonInfo.LastName = txt_LastName.Text.Trim();
            _Person.PersonInfo.NationalNo = txt_NotionalNO.Text.Trim();
            _Person.PersonInfo.DateOfBirth = dtp_DateOfBirth.Value;
            _Person.PersonInfo.Gendor = (rdb_Male.Checked) ? (byte)enGendor.Male : (byte)enGendor.Female;
            _Person.PersonInfo.phone = txt_Phone.Text.Trim();
            _Person.PersonInfo.Email = txt_Email.Text.Trim();
            _Person.PersonInfo.NationalityCountryID = CountryID;
            _Person.PersonInfo.Address = txt_Address.Text.Trim();  
            _Person.PersonInfo.ImagePath = (ptb_PersonImage.ImageLocation != null) ? ptb_PersonImage.ImageLocation : "";

           

            if (_Person.Save())
            {
                lbl_Mode.Text = "Update Person";
                lbl_PersonID.Text = _Person.PersonInfo.PersonID.ToString();
                _Mode = enMode.Edit;
                MessageBox.Show("Person information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this, _Person.PersonInfo.PersonID);
            }
            else
            {
                MessageBox.Show("Failed to save Person information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
  

        private void txt_Email_Validating(object sender, CancelEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(txt_Email.Text)) return;

            if (!clsValidatoin.ValidateEmail(txt_Email.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_Email, $"Valid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txt_Email, "");

            }
        }
        private void frmAddAndEditPersonInfo_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if(_Mode == enMode.Edit)
                _loadData();
        }



        private void btn_SetImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ptb_PersonImage.ImageLocation = openFileDialog1.FileName;
                btn_RemoveImage.Visible = true;
            }
        }

        private void btn_RemoveImage_Click(object sender, EventArgs e)
        {
            ptb_PersonImage.ImageLocation = null;
            btn_RemoveImage.Visible = false;

            ptb_PersonImage.Image = (rdb_Male.Checked) ? Properties.Resources.male_Man_face : Properties.Resources.female_girl_face;

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txt_NotionalNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void rdb_Male_Click(object sender, EventArgs e)
        {
            if (ptb_PersonImage.ImageLocation == null)
                ptb_PersonImage.Image = Properties.Resources.male_Man_face; 
        }

        private void rdb_Female_Click(object sender, EventArgs e)
        {
            if (ptb_PersonImage.ImageLocation == null)
                ptb_PersonImage.Image = Properties.Resources.female_girl_face;
        }

        private void txt_NotionalNO_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_NotionalNO.Text.Trim()))
            {
                 e.Cancel = true;
                errorProvider1.SetError(txt_NotionalNO, $"{txt_NotionalNO.Tag} is required");
            }
            else

            {

                if (clsPeople.IsExist(txt_NotionalNO.Text.Trim()) && txt_NotionalNO.Text.Trim() != _Person.PersonInfo.NationalNo)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txt_NotionalNO, $"{txt_NotionalNO.Tag} is Used For another Person!");
                }
                else
                {

                    errorProvider1.SetError(txt_NotionalNO, "");
                }

            }

           

        }

        private void txt_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar)) return;

            if (char.IsControl(e.KeyChar)) return;

            if (e.KeyChar == '@' || e.KeyChar == '.' || e.KeyChar == '_' ) return;

          
            e.Handled = true;
        }
    }
}
