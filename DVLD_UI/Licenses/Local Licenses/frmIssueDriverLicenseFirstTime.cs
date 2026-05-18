using DVLD_Business;
using DVLD_Model;
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

namespace DVLD_UI.Licenses.Local_Licenses
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        private int _LocalDrivingLicenseApplicationID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        private clsLocalDrivingLicenseApplications _localDrivingLicenseApplications = null;
        private clsLicenses _Licenses = null;
        public frmIssueDriverLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void _initialize_localDrivingLicenseApplication()
        {
            _localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);
        }
        private void SetLicenseInfo()
        {
            _Licenses = new clsLicenses();
            _Licenses.LicenseClassID = _localDrivingLicenseApplications.LicenseClassID;
            _Licenses.ApplicationID = _localDrivingLicenseApplications.ApplicationID;
            _Licenses.IssueDate = DateTime.Now;
            clsLicenseClasses clsLicenseClasses = clsLicenseClasses.Find(_localDrivingLicenseApplications.LicenseClassID);
            _Licenses.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.DefaultValidityLength);
            _Licenses.IssueReason = clsLicenseModel.enIssueReason.FirstTime;
            _Licenses.Notes = txt_Notes.Text.Trim();
            _Licenses.PaidFees = clsLicenseClasses.ClassFees;
            _Licenses.IsActive = true;
            _Licenses.CreatedByUserID = clsGlobal.CurrentUser.UserID;  
        }

        private bool _IsLicenseExist()
        {
            return clsLicenses.IsLicenseExist(_localDrivingLicenseApplications.ApplicantPersonID, _localDrivingLicenseApplications.LicenseClassID);
        }
        private bool _IsPassedAllTests()
        {
            return clsTests.IsAllTestsPassed(_LocalDrivingLicenseApplicationID);
        }
        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _initialize_localDrivingLicenseApplication();

            if (!_IsPassedAllTests())
            {
                MessageBox.Show("Cannot issue Driver License. Applicant has not passed all required tests.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (_localDrivingLicenseApplications != null)
            {
                if (_IsLicenseExist())
                {
                    MessageBox.Show("A Driver License already exists for this applicant and license class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Failed to load Local Driving License Application information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlDrivingLicenseApplicationInfo1.Load_LocalDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);

        }


        private void btn_Save_Click(object sender, EventArgs e)
        {

            SetLicenseInfo();

            if (_Licenses.Save())
            {
                MessageBox.Show("License Issued Successfully with License ID = " + _Licenses.LicenseID,
                                   "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Failed to issue Driver License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmIssueDriverLicenseFirstTime_Shown(object sender, EventArgs e)
        {
            txt_Notes.Focus();
        }
    }
}
