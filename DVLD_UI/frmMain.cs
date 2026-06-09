using DVLD_UI.Applications.Application_Types;
using DVLD_UI.Applications.International_License;
using DVLD_UI.Applications.Local_Driving_License;
using DVLD_UI.Applications.Renew_Local_License;
using DVLD_UI.Applications.ReplaceLostOrDamagedLicense;
using DVLD_UI.Applications.Rlease_Detained_License;
using DVLD_UI.Drivers;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses.Detain_License;
using DVLD_UI.Test.Test_Type;
using DVLD_UI.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frmManagePeople = new frmManagePeople();
            frmManagePeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }


        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CurrentUserID = clsGlobal.CurrentUser.UserInfo.UserID;
            frmUserInfo frmUserInfo = new frmUserInfo(CurrentUserID);
            frmUserInfo.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(clsGlobal.CurrentUser.UserInfo.UserID);
            frmChangePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            this.Close();

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frmManageApplicationTypes = new frmManageApplicationTypes();
            frmManageApplicationTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frmManageTestTypes = new frmManageTestTypes();
            frmManageTestTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frmAddUpdateLocalDrivingLicesnseApplication = new frmAddUpdateLocalDrivingLicenseApplication();
            frmAddUpdateLocalDrivingLicesnseApplication.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeLocalDrivingLicesnseApplications frmManageLocalDrivingLicenseApplications = new frmMangeLocalDrivingLicesnseApplications();
            frmManageLocalDrivingLicenseApplications.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeLocalDrivingLicesnseApplications frmManageLocalDrivingLicenseApplications = new frmMangeLocalDrivingLicesnseApplications();
            frmManageLocalDrivingLicenseApplications.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frmListDrivers = new frmListDrivers();
            frmListDrivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frmNewInternationalLicenseApplication = new frmNewInternationalLicenseApplication();
            frmNewInternationalLicenseApplication.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicesnseApplications frmListInternationalLicesnseApplications = new frmListInternationalLicesnseApplications();
            frmListInternationalLicesnseApplications.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication frmRenewLocalDrivingLicenseApplication = new frmRenewLocalDrivingLicenseApplication();
            frmRenewLocalDrivingLicenseApplication.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frmReplaceLostOrDamagedLicenseApplication = new frmReplaceLostOrDamagedLicenseApplication();
            frmReplaceLostOrDamagedLicenseApplication.ShowDialog();
        }

        private void dVLDPropertiesResourcesDetain32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frmDetainLicenseApplication = new frmDetainLicenseApplication();
            frmDetainLicenseApplication.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frmReleaseDetainedLicenseApplication = new frmReleaseDetainedLicenseApplication();
            frmReleaseDetainedLicenseApplication.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frmReleaseDetainedLicenseApplication = new frmReleaseDetainedLicenseApplication();
            frmReleaseDetainedLicenseApplication.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frmListDetainedLicenses = new frmListDetainedLicenses();
            frmListDetainedLicenses.ShowDialog();
        }
    }
}
