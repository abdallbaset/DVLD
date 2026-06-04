using DVLD_Business;
using DVLD_Model;
using DVLD_UI.Applications;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD_UI.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        public clsLicenses Licenses { get; set; }
        private int _LicensesID = (int)clsGlobal.enIdentityStatus.NonExistent;
        public int LicensesID
        {
            get => _LicensesID;
        }
        private void _LoadDefaultData()
        {
            lbl_class.Text = "???";
            lbl_DateOfBirth.Text = "???";
            lbl_DriverID.Text = "???";
            lbl_ExpirationDate.Text = "???";
            lbl_IssueDate.Text = "???";
            lbl_FullName.Text = "???";
            lbl_IsActive.Text = "???";
            lbl_IsDetained.Text = "???";
            lbl_Notes.Text = "???";
            lbl_NationalNo.Text = "???";
            lbl_LicenseID.Text = "???";
            lbl_IssueReason.Text = "???";
            lbl_Gendor.Text = "???";
            ptb_PersonalPhoto.Image = Properties.Resources.Male_512;

        }
        private void _LoadPerosnalPhoto()
        {
            if (Licenses.Gendor == (byte)clsEnumerationsModel.enGendor.Male)
            {
                ptb_PersonalPhoto.Image = Resources.male_Man_face;
            } 
            else
                ptb_PersonalPhoto.Image = Resources.female_girl_face;

            string ImagePath = Licenses.PersonalPhoto;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    ptb_PersonalPhoto.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void _FillDriverLicenseInfo()
        {

            lbl_class.Text = Licenses.ClassName;
            lbl_DateOfBirth.Text = clsFormat.DateToShort(Licenses.DateOfBirth);
            lbl_DriverID.Text = Licenses.DriverID.ToString();
            lbl_ExpirationDate.Text = clsFormat.DateToShort(Licenses.ExpirationDate);
            lbl_IssueDate.Text = clsFormat.DateToShort( Licenses.IssueDate);
            lbl_FullName.Text = Licenses.PersonName;
            lbl_IsActive.Text = Licenses.IsActive ? "Yes" : "No";
            lbl_IsDetained.Text =(Licenses.IsDitained) ? "Yes" : "No";
            lbl_Notes.Text = (Licenses.Notes == string.Empty)? "No Notes" : Licenses.Notes;
            lbl_NationalNo.Text = Licenses.NationalNo;
            lbl_LicenseID.Text = Licenses.LicenseID.ToString();
            lbl_IssueReason.Text = Licenses.IssueReasonTitle;
            lbl_Gendor.Text = (Licenses.Gendor == (byte)clsEnumerationsModel.enGendor.Male) ? clsEnumerationsModel.enGendor.Male.ToString(): clsEnumerationsModel.enGendor.Female.ToString();
            _LoadPerosnalPhoto();
        }
        public void Load_DriverLicenseInfoInfo(int LicenseID)
        {
            _LicensesID = LicenseID;
             Licenses = clsLicenses.Find(LicenseID);

            if (Licenses == null)
            {
                _LoadDefaultData();
                MessageBox.Show($"No License with ID [{_LicensesID}] was found in the system.",
                                     "Not Found",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);
                return;
            }

            _FillDriverLicenseInfo();

        }

    }
}
