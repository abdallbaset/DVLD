using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
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

namespace DVLD_UI.Applications.Local_Driving_License
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = (int)clsGlobal.enIdentityStatus.NonExistent;
        public int LocalDrivingLicenseApplicationID
        {
            get => _LocalDrivingLicenseApplicationID;
        }
        public int PassedTestsCount
        {
            get => _PassedTestsCount;
        }


        private int _PassedTestsCount  = 0;

        private int _LicenseID = (int)clsGlobal.enIdentityStatus.NonExistent;


        private void _LoadDefaultData()
        {
            lbl_AppliedFor.Text = "???";
            lbl_LocalDrivingLicenseApplicationID.Text = "???";
            lbl_PassedTests.Text = "0";
            ctrlApplicationBasicInfo1.LoadDefaultData();
        }


        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);

            lbl_LocalDrivingLicenseApplicationID.Text = LocalDrivingLicenseApplicationID.ToString();
            lbl_AppliedFor.Text = _LocalDrivingLicenseApplication.ClassName;
            lbl_PassedTests.Text = $"{_PassedTestsCount}/3";
        }
        public void Load_LocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            _PassedTestsCount = clsTests.GetTestPassedCount(LocalDrivingLicenseApplicationID);
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);
            llbl_ShowLicenseInfo.Enabled = false;

            if (_LocalDrivingLicenseApplication == null)
            {
                _LoadDefaultData();
                MessageBox.Show($"No Local Driving License Application  with ID [{_LocalDrivingLicenseApplicationID}] was found in the system.",
                                     "Not Found",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);
                return;
            }

             _HandleLicenseLinkState();
            _FillLocalDrivingLicenseApplicationInfo();

        }

        private void llbl_ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
        private void _HandleLicenseLinkState()
        {
             _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicensesID();

            llbl_ShowLicenseInfo.Enabled = (_LicenseID != (int)clsGlobal.enIdentityStatus.NonExistent) ;

        }

       
    }
}
