using DVLD_Business;
using DVLD_UI.Applications;
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

namespace DVLD_UI.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        enum enGendor : byte { Male = 0, Female = 1 };

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        private clsLicenses _Licenses;
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
        private void _FillDriverLicenseInfo()
        {

            lbl_class.Text = _Licenses.ClassName;
            lbl_DateOfBirth.Text = clsFormat.DateToShort(_Licenses.DateOfBirth);
            lbl_DriverID.Text = _Licenses.DriverID.ToString();
            lbl_ExpirationDate.Text = clsFormat.DateToShort(_Licenses.ExpirationDate);
            lbl_IssueDate.Text = clsFormat.DateToShort( _Licenses.IssueDate);
            lbl_FullName.Text = _Licenses.PersonName;
            lbl_IsActive.Text = _Licenses.IsActived ? "Yes" : "No";
            lbl_IsDetained.Text =(_Licenses.IsDitained) ? "Yes" : "No";
            lbl_Notes.Text = _Licenses.Notes;
            lbl_NationalNo.Text = _Licenses.NationalNo;
            lbl_LicenseID.Text = _Licenses.LicenseID.ToString();
            lbl_IssueReason.Text = _Licenses.IssueReason;
            lbl_Gendor.Text = (_Licenses.Gendor == (byte)enGendor.Male) ? enGendor.Male.ToString(): enGendor.Female.ToString();
            ptb_PersonalPhoto.ImageLocation = _Licenses.PersonalPhoto;
        }
        public void Load_DriverLicenseInfoInfo(int LicenseID)
        {
            _LicensesID = LicenseID;
            _Licenses = clsLicenses.Find(LicenseID);

            if (_Licenses == null)
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
