using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses;
using DVLD_UI.Licenses.International_Licenses;
using DVLD_UI.Licenses.Local_Licenses;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Applications.International_License
{
    public partial class frmNewInternationalLicenseApplication : Form
    {

        private clsLicenses _license = null;
        private clsInternationalLicense _InternationalLicense = null;
        private int _InternationalLicenseID = (int)clsGlobal.enIdentityStatus.NonExistent;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        public void LoadDefaultData()
        {
            lbl_ApplicationID.Text = "???";
            lbl_InternationalLicenseID.Text = "???";
            lbl_LocalLicenseID.Text = "???";
            lbl_ApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lbl_IssueDate.Text = clsFormat.DateToShort(DateTime.Now);
            lbl_ExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));
            lbl_Fees.Text = clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.NewInternationalLicense).ApplicationFees.ToString();
            lbl_CreatedByUser.Text = clsGlobal.CurrentUser.UserName;

        }

        private void SetInternationalLicenseInfo()
        {
            _InternationalLicense = new clsInternationalLicense();
            _InternationalLicense.IssuedUsingLocalLicenseID = _license.LicenseID;
            _InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            _InternationalLicense.IsActive = true;
            _InternationalLicense.DriverID = _license.DriverID;
        }


        private bool IsInternationalLicenseExist()
        {
            _InternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicense(_license.LicenseID);
            return _InternationalLicenseID != (int)clsGlobal.enIdentityStatus.NonExistent;
        }
        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            LoadDefaultData();
           _DisableShowLicenseHistoryLink();
           _DisableShowLicenseInfoLink();
            btn_Save.Enabled = false;
        }
        private void _EnableShowLicenseHistoryLink()
        {
            llbl_ShowLicenseHistory.Enabled = true;
        }
        private void _DisableShowLicenseHistoryLink()
        {
            llbl_ShowLicenseHistory.Enabled = false;
        }

        private void _EnableShowLicenseInfoLink()
        {
            llbl_ShowLicenseInfo.Enabled = true;
        }
        private void _DisableShowLicenseInfoLink()
        {
            llbl_ShowLicenseInfo.Enabled = false;
        }
        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(clsLicenses license)
        {
            _license = license;
            if(license == null )
            {
               _DisableShowLicenseHistoryLink();
               _DisableShowLicenseInfoLink();
                lbl_LocalLicenseID.Text = "???";
                return;
            }
            lbl_LocalLicenseID.Text = _license.LicenseID.ToString();

            _EnableShowLicenseHistoryLink();
            _DisableShowLicenseInfoLink();

            if (_license.LicenseClassID != (int)clsLicenseClassesModel.enLicenseClass.OrdinaryDrivingLicense)
            {
                MessageBox.Show("You cannot apply for an international license because your local license is not of type Ordinary Driving License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsInternationalLicenseExist())
            {
                _EnableShowLicenseInfoLink();
                MessageBox.Show($"You cannot apply for an international license because you already have one with ID : {_InternationalLicenseID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);
                return;
            }
       
            if (!_license.IsActive)
            {
                MessageBox.Show("You cannot issue an international license because your local license is inactive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_license.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("You cannot issue an international license because your local license is expired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btn_Save.Enabled = true;

        }

 
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SetInternationalLicenseInfo();

            if (_InternationalLicense.Save())
            {
                MessageBox.Show("International License Application saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llbl_ShowLicenseInfo.Enabled = true;
                btn_Save.Enabled = false;
             
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                lbl_ApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                lbl_InternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            }
            else
            {
               MessageBox.Show("Failed to save the International License Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void llbl_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory ShowPersonLicenseHistory = new frmShowPersonLicenseHistory(_license.PersonID);
            ShowPersonLicenseHistory.ShowDialog();
        }
        
        private void llbl_ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo ShowInternationalLicenseInfo = new frmShowInternationalLicenseInfo(_InternationalLicense.InternationalLicenseID);
            ShowInternationalLicenseInfo.ShowDialog();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
 