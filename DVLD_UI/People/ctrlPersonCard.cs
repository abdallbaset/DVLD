using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UI
{
    public partial class ctrlPersonCard : UserControl
    {
      
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
       public int PersonID = -1;
        private   clsPeople _Person;
        public clsPeopleModel SelectedPersonInfo
        {
            get { return _Person.PersonInfo; }
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPeople.Find(PersonID);
            if (_Person == null)
            {
                LoadDefaultData();
                MessageBox.Show($"No Person with ID [{PersonID}] was found in the system.",
                                    "Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                return;
            }

            _FillPersonInfo();

          }
      public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPeople.Find(NationalNo);
            if (_Person == null)
            {
                LoadDefaultData();
                MessageBox.Show($"No Person with National Number [{NationalNo}] was found in the system.",
                                    "Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                return;
            }
            _FillPersonInfo();
          }

     

        public void LoadDefaultData ()
        {
            PersonID = (int)clsGlobal.enIdentityStatus.NonExistent ;
            lbl_PersonID.Text = "???";
            lbl_FullName.Text = "???";
            lbl_NotionalNumber.Text = "???";
            lbl_Phone.Text = "???";
            lbl_Address.Text = "???";
            lbl_Email.Text = "???";
            lbl_Gendor.Text = "???";
            lbl_Country.Text = "???";
            lbl_DateOfBirth.Text = "???";

            ptb_Gendor.Image = Properties.Resources.male_svgrepo_com ;

            ptb_PersonalPhoto.Image = null;
        }

      
        private void btn_EditPerson_Click(object sender, EventArgs e)
        {
            if(PersonID == (int)clsGlobal.enIdentityStatus.NonExistent)
            {
                MessageBox.Show($"No Person was found in the system.",
                                   "Not Found",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation);
                return;
            }

            frmAddAndEditPersonInfo frm = new frmAddAndEditPersonInfo(PersonID);
            frm.ShowDialog();
            LoadPersonInfo(PersonID);
        }

        private void _LoadPersonImage()
        {
            ptb_Gendor.Image = (_Person.Gendor == (byte)clsEnumerationsModel.enGendor.Male) ? Properties.Resources.male_svgrepo_com : Properties.Resources.female_svgrepo_com;


            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    ptb_PersonalPhoto.ImageLocation = ImagePath;
                else
                {
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                ptb_PersonalPhoto.Image = (_Person.Gendor == (byte)clsEnumerationsModel.enGendor.Male) ? Properties.Resources.male_Man_face : Properties.Resources.female_girl_face;


        }

        private void _FillPersonInfo()
        {
            PersonID = _Person.PersonID;
            lbl_PersonID.Text = PersonID.ToString();
            lbl_FullName.Text = _Person.FullName;
            lbl_NotionalNumber.Text = _Person.NationalNo;
            lbl_Phone.Text = _Person.Phone;
            lbl_Address.Text = _Person.Address;
            lbl_Email.Text = _Person.Email;
            lbl_Gendor.Text = (_Person.Gendor == (byte)clsEnumerationsModel.enGendor.Male) ? "Male" : "Female";
            lbl_Country.Text = clsCountries.GetCountryNameByCountryID(_Person.NationalityCountryID);
            lbl_DateOfBirth.Text = clsFormat.DateToShort( _Person.DateOfBirth);
            _LoadPersonImage();
        }

    }
}
