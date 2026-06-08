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

namespace DVLD_UI.Applications.ReplaceLostOrDamagedLicense
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        private clsLicenses _Oldlicense = null;
        private clsLicenses _Newlicense = null;
        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }
        public void LoadDefaultData()
        {
            rb_DamagedLicense.Checked = true;
            lbl_ApplicationID.Text = "???";
            lbl_ReplacedLicenseID.Text = "???";
            lbl_OldLicenseID.Text = "???";
            lbl_ApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
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
                btn_IssueReplacement.Enabled = false;
                return;
            }

            lbl_OldLicenseID.Text = _Oldlicense.LicenseID.ToString();

            _EnableShowLicenseHistoryLink();
            _DisableShowLicenseInfoLink();

            if (!_Oldlicense.IsActive)
            {
                btn_IssueReplacement.Enabled = false;
                MessageBox.Show("You cannot Replacement this license because it is inactive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btn_IssueReplacement.Enabled = true;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_IssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Replacement this license?", "Confirm Replacement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _Newlicense = (rb_DamagedLicense.Checked) ? _Oldlicense.Replacement(clsLicenseModel.enIssueReason.ReplacementForDamaged, clsGlobal.CurrentUser.UserID) :
                _Oldlicense.Replacement(clsLicenseModel.enIssueReason.ReplacementForLost, clsGlobal.CurrentUser.UserID);
            

            if (_Newlicense != null)
            {
                _EnableShowLicenseInfoLink();
                MessageBox.Show($"License Replacement successfully. New License ID: {_Newlicense.LicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gb_ReplacementFor.Enabled = false;
                btn_IssueReplacement.Enabled = false;
                llbl_ShowLicenseInfo.Enabled = true;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                lbl_ApplicationID.Text = _Newlicense.ApplicationID.ToString();
                lbl_ReplacedLicenseID.Text = _Newlicense.LicenseID.ToString();
            }
            else
            {
                MessageBox.Show("Failed to Replacement the license. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReplaceLostOrDamagedLicenseApplication_Load(object sender, EventArgs e)
        {
             LoadDefaultData();
            _DisableShowLicenseHistoryLink();
            _DisableShowLicenseInfoLink();
            btn_IssueReplacement.Enabled = false;
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

        private void rb_DamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_DamagedLicense.Checked)
            {
                lbl_ApplicationFees.Text = clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.ReplacementForDamagedDrivingLicense).ApplicationFees.ToString();
                this.Text = "Replacement for Damaged  License ";
                lbl_Title.Text = "Replacement for Damaged  License";
            }
            else
            {
                lbl_ApplicationFees.Text =  clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.ReplacementForLostDrivingLicense).ApplicationFees.ToString();
                this.Text = "Replacement for Lost License";
                lbl_Title.Text = "Replacement for Lost License";
            }
         
        }
    }
}
