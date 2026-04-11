using DVLD_Model;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Test
{
    public partial class frmScheduleTest : Form
    {
       private  int _LocalDrivingLicenseApplicationID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
       private int _TestTypeID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, int testTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = testTypeID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.LoadScheduleTestInfo(_LocalDrivingLicenseApplicationID, _TestTypeID);
        }
    }
}
