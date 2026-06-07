using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses;
using DVLD_UI.Licenses.International_Licenses;
using DVLD_UI.Licenses.Local_Licenses;
using DVLD_UI.Licenses.Local_Licenses.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Renew_Local_License
{
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        private clsLicenses _Oldlicense = null;
        private clsLicenses _Newlicense = null;
        private double _applicationFees = 0;
        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        public void LoadDefaultData()
        {
            lbl_ApplicationID.Text = "???";
            lbl_RenewLicenseID.Text = "???";
            lbl_OldLicenseID.Text = "???";
            lbl_ApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lbl_IssueDate.Text = clsFormat.DateToShort(DateTime.Now);
            lbl_ExpirationDate.Text = "???";
            _applicationFees = clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.RenewDrivingLicenseService).ApplicationFees;
            lbl_ApplicationFees.Text = _applicationFees.ToString();
            lbl_LicenseFeez.Text = "$$$";
            lbl_TotalFees.Text = "$$$";
            lbl_CreatedByUser.Text = clsGlobal.CurrentUser.UserName;

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
            _Oldlicense = license;
            if (_Oldlicense == null)
            {
                _DisableShowLicenseHistoryLink();
                _DisableShowLicenseInfoLink();
                lbl_OldLicenseID.Text = "???";
                return;
            }
          
            lbl_OldLicenseID.Text = _Oldlicense.LicenseID.ToString();
            lbl_LicenseFeez.Text = _Oldlicense.LicenseFees.ToString();
            lbl_TotalFees.Text = (_Oldlicense.LicenseFees + _applicationFees).ToString();
            byte DefaultValidityLength = _Oldlicense.DefaultValidityLength;
            lbl_ExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
            txt_Notes.Text = _Oldlicense.Notes.ToString();

            _EnableShowLicenseHistoryLink();
            _DisableShowLicenseInfoLink();

            if (!_Oldlicense.IsLicenseExpired())
            {
               MessageBox.Show($"The selected license is not expired yet. Please select an expired license to renew.The license  expir in {_Oldlicense.ExpirationDate}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!_Oldlicense.IsActive)
            {
                MessageBox.Show("You cannot renew this license because it is inactive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btn_RenewLicense.Enabled = true;
        }

        private void frmRenewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
             LoadDefaultData();
            _DisableShowLicenseHistoryLink();
            _DisableShowLicenseInfoLink();
            btn_RenewLicense.Enabled = false;
        }

        private void llbl_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory ShowPersonLicenseHistory = new frmShowPersonLicenseHistory(_Oldlicense.PersonID);
            ShowPersonLicenseHistory.ShowDialog();
        }

        private void llbl_ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo ShowLicenseInfo = new frmShowLicenseInfo(_Newlicense.LicenseID);
            ShowLicenseInfo.ShowDialog();
        }

        private void btn_RenewLicense_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to renew this license?", "Confirm Renewal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            _Newlicense = _Oldlicense.RenewLicense(txt_Notes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (_Newlicense != null)
            {
                _EnableShowLicenseInfoLink();
                MessageBox.Show($"License renewed successfully. New License ID: {_Newlicense.LicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llbl_ShowLicenseInfo.Enabled = true;
                btn_RenewLicense.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                lbl_ApplicationID.Text = _Newlicense.ApplicationID.ToString();
                lbl_RenewLicenseID.Text = _Newlicense.LicenseID.ToString();
            }
            else
            {
                MessageBox.Show("Failed to renew the license. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
