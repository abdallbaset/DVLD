using DVLD_Business;
using DVLD_UI.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class frmAddAndEditPersonInfo : Form
    {
        enum enMode { AddNew, Edit }
        enum enGendor : byte { Male = 0, Female = 1 }

        private enMode _Mode;
        private int _PersonID;
        private clsPeople _Person;
        private string _SelectedImagePath ="";
        private string _OldPathImage = "";

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
        public void FillCountryInCombBx()
        {
            DataTable dtCountry = clsCountries.GetAllCountry();
            foreach (DataRow dr in dtCountry.Rows)
            {
                cmb_Countrys.Items.Add(dr["CountryName"].ToString());
            }
        }
        private void _loadData()
        {

            FillCountryInCombBx();
            dtp_DateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtp_DateOfBirth.Value = dtp_DateOfBirth.MaxDate;
            rdb_Male.Checked = true;
            cmb_Countrys.SelectedIndex = cmb_Countrys.FindString("libya");


            if (_Mode == enMode.AddNew)
            {
                lbl_Mode.Text = "Add New Person";
                _Person = new clsPeople();
                btn_RemoveImage.Visible = false;
                return;
            }

            lbl_Mode.Text = "Update Person";
            _Person = clsPeople.Find(_PersonID);

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
                    ptb_Image.ImageLocation = _Person.PersonInfo.ImagePath;
                    _OldPathImage = ptb_Image.ImageLocation;
                }
                else
                {
                    ptb_Image.Image = null;
                }

                btn_RemoveImage.Visible = (ptb_Image.ImageLocation != null);

            }


        }


        private void TextBox_Validating(object sender, CancelEventArgs e)
        {

            TextBox activeTextBox = sender as TextBox;

            if (string.IsNullOrEmpty(activeTextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(activeTextBox, $"{activeTextBox.Tag} is required");
            }
            else
            {

                if (clsPeople.IsExist(activeTextBox.Text) && activeTextBox.Text != _Person.PersonInfo.NationalNo.ToString())
                {
                    e.Cancel = true;
                    errorProvider1.SetError(activeTextBox, $"{activeTextBox.Tag} is Used For another Person!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(activeTextBox, "");

                }
            }

        }

        private  string _SaveImageToProjectFolder(string sourceFile)
        {
            string folderPath = @"C:\DVLD-People-Images\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string extension = Path.GetExtension(sourceFile);
            string newFileName = Guid.NewGuid().ToString() + extension;

            string destinationFile = Path.Combine(folderPath, newFileName);

            try
            {
                File.Copy(sourceFile, destinationFile, true);

                return destinationFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message);
                return null;
            }
        }

        private bool _HandlePersonImage()
        {
          
            if (_Person.PersonInfo.ImagePath == _SelectedImagePath)
            {
                return true;
            }

                clsGlobal.DeletePersonImageOnDisk(_Person.PersonInfo.ImagePath);


            if (_SelectedImagePath != "")
            {
                string NewPath = _SaveImageToProjectFolder(_SelectedImagePath);
               
                if (NewPath != "")
                {
                    _Person.PersonInfo.ImagePath = NewPath;
                    _OldPathImage = NewPath;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                _Person.PersonInfo.ImagePath = "";
                return true;
            }
        }


        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please fill all required fields correctly!",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int CountryID = clsCountries.GetCountryIDByCountryName(cmb_Countrys.Text);

            _Person.PersonInfo.FirstName = txt_FirstName.Text;
            _Person.PersonInfo.SecondName = txt_SecondName.Text;
            _Person.PersonInfo.ThirdName = txt_ThirdName.Text;
            _Person.PersonInfo.LastName = txt_LastName.Text;
            _Person.PersonInfo.NationalNo = txt_NotionalNO.Text;
            _Person.PersonInfo.DateOfBirth = dtp_DateOfBirth.Value;
            _Person.PersonInfo.Gendor = (rdb_Male.Checked) ? (byte)enGendor.Male : (byte)enGendor.Female;
            _Person.PersonInfo.phone = txt_Phone.Text;
            _Person.PersonInfo.Email = txt_Email.Text;
            _Person.PersonInfo.NationalityCountryID = CountryID;
            _Person.PersonInfo.Address = txt_Address.Text;

            if(_Mode == enMode.AddNew)
            _Person.PersonInfo.ImagePath = "";
            else
            {
                _Person.PersonInfo.ImagePath = (ptb_Image.Image != null) ? _OldPathImage : "";

            }


            if (!_HandlePersonImage())
            {
                MessageBox.Show("Could not save the image. Please check the file path or try again with a different image.",
                     "Image Save Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);

            }

         



            if (_Person.Save())
            {
                MessageBox.Show("Person information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_Mode.Text = "Update Person";
                lbl_PersonID.Text = _Person.PersonInfo.PersonID.ToString();
                _Mode = enMode.Edit;
            }
            else
            {
                MessageBox.Show("Failed to save Person information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void rdb_Male_Female_CheckedChanged(object sender, EventArgs e)
        {

            ptb_Image.Image = (rdb_Male.Checked) ? Properties.Resources.male_Man_face : Properties.Resources.female_girl_face;


        }

        private void txt_Email_Validating(object sender, CancelEventArgs e)
        {

            string Email = txt_Email.Text;
            if (!Email.Contains("@gmail.com") && txt_Email.Text != "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_Email, $"Valid Email Address Format!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_Email, "");

            }
        }
        private void frmAddAndEditPersonInfo_Load(object sender, EventArgs e)
        {
            _loadData();
        }



        private void btn_SetImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ptb_Image.ImageLocation = openFileDialog1.FileName;
                _SelectedImagePath = openFileDialog1.FileName;
                btn_RemoveImage.Visible = true;
            }
        }

        private void btn_RemoveImage_Click(object sender, EventArgs e)
        {
            ptb_Image.Image = null;
            btn_RemoveImage.Visible = false;
            _SelectedImagePath = "";
            clsGlobal.DeletePersonImageOnDisk(_OldPathImage);
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
    }
}
