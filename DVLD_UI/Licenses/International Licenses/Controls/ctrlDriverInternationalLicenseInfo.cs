using DVLD_Business;
using DVLD_UI.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses.International_Licenses.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        enum enGendor : byte { Male = 0, Female = 1 };
        private clsInternationalLicense _InternationalLicense;

        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadDefaultData()
        {
            lbl_ApplicationID.Text = "???";
            lbl_InternationalLicenseID.Text = "???";
            lbl_DateOfBirth.Text = "???";
            lbl_DriverID.Text = "???";
            lbl_ExpirationDate.Text = "???";
            lbl_IssueDate.Text = "???";
            lbl_FullName.Text = "???";
            lbl_IsActive.Text = "???";
            lbl_NationalNo.Text = "???";
            lbl_LocalLicenseID.Text = "???";
            lbl_Gendor.Text = "???";
            ptb_PersonalPhoto.Image = Properties.Resources.Male_512;

        }
        private void _FillInternationalLicenseInfo()
        {
            lbl_ApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lbl_InternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lbl_DateOfBirth.Text = clsFormat.DateToShort(_InternationalLicense.DateOfBirth);
            lbl_IssueDate.Text = clsFormat.DateToShort(_InternationalLicense.IssueDate); 
            lbl_ExpirationDate.Text = clsFormat.DateToShort(_InternationalLicense.ExpirationDate); 
            lbl_DriverID.Text = _InternationalLicense.DriverID.ToString();
            lbl_FullName.Text = _InternationalLicense.FullName;
            lbl_IsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No"; ;
            lbl_NationalNo.Text = _InternationalLicense.NationalNo;
            lbl_LocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString(); ;
            lbl_Gendor.Text = (_InternationalLicense.Gendor == (byte)enGendor.Male) ? enGendor.Male.ToString() : enGendor.Female.ToString();
            ptb_PersonalPhoto.ImageLocation = _InternationalLicense.PersonalPhoto;
        }
        public void Load_InternationalLicenseInfoInfo(int InternationalLicenseID)
        {

            _InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);

            if (_InternationalLicense == null)
            {
                _LoadDefaultData();
                MessageBox.Show($"No International License with ID [{InternationalLicenseID}] was found in the system.",
                                     "Not Found",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);
                return;
            }

            _FillInternationalLicenseInfo();

        }
    }
}
