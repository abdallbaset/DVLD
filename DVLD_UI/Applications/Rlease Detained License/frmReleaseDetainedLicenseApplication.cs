using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses;
using DVLD_UI.Licenses.Local_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Rlease_Detained_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private clsLicenses _license = null;
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }
        public void LoadDefaultData()
        {
            lbl_ApplicationID.Text = "???";
            lbl_DetainID.Text = "???";
            lbl_LicenseID.Text = "???";
            lbl_DetainDate.Text = "??/??/????";
            lbl_FineFees.Text = "$$$";
            lbl_ApplicationFees.Text = "$$$";
            lbl_TotalFees.Text = "$$$";
            lbl_CreatedByUser.Text = "???";
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
        private void _FillDetainInfo()
        {
            lbl_LicenseID.Text = _license.DetainedInfo.LicenseID.ToString();
            lbl_DetainID.Text = _license.DetainedInfo.DetainID.ToString();
            lbl_DetainDate.Text = clsFormat.DateToShort(_license.DetainedInfo.DetainDate);
            double applicationFees = clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.ReleaseDetainedDrivingLicense).ApplicationFees;
            double FineFees = _license.DetainedInfo.FineFees;
            lbl_FineFees.Text = FineFees.ToString();
            lbl_ApplicationFees.Text = applicationFees.ToString();
            lbl_TotalFees.Text = (FineFees + applicationFees).ToString();
            lbl_CreatedByUser.Text = _license.DetainedInfo.CreatedByUserName;
        }
            
         
        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(clsLicenses license)
        {
            _license = license;
            if (_license == null)
            {
                _DisableShowLicenseHistoryLink();
                _DisableShowLicenseInfoLink();
                LoadDefaultData();
                lbl_LicenseID.Text = "???";
                lbl_ApplicationID.Text = "???";
                btn_Release.Enabled = false;
                return;
            }

            if (!_license.IsDitained)
            {
                btn_Release.Enabled = false;
                LoadDefaultData();
                MessageBox.Show("This license is not detained, please select a detained license!", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            if (_license.DetainedInfo == null)
            {
                MessageBox.Show("Failed to retrieve the detained license information, please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillDetainInfo();
            _EnableShowLicenseHistoryLink();
            _DisableShowLicenseInfoLink();
             btn_Release.Enabled = true;
        }

        private void frmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
             LoadDefaultData();
            _DisableShowLicenseHistoryLink();
            _DisableShowLicenseInfoLink();
            btn_Release.Enabled = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbl_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frmShowPersonLicenseHistory = new frmShowPersonLicenseHistory(_license.PersonID);
            frmShowPersonLicenseHistory.ShowDialog();
        }

        private void llbl_ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frmShowLicenseInfo = new frmShowLicenseInfo(_license.LicenseID);
            frmShowLicenseInfo.ShowDialog();
        }

        private void btn_Release_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to releas this license?", "Confirm releas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            bool isReleased = _license.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID);

            if (isReleased)
            {
                _EnableShowLicenseInfoLink();
                MessageBox.Show("The license has been released successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llbl_ShowLicenseInfo.Enabled = true;
                btn_Release.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                lbl_ApplicationID.Text = clsDetainedLicense.FindByLicenseID(_license.LicenseID).ReleaseApplicationID.ToString();

            }
            else
            {
                MessageBox.Show("Failed to releas the license. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
