using DVLD_Model;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Test
{
    public partial class frmScheduleTest : Form
    {
       private  int _LocalDrivingLicenseApplicationID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
       private clsEnumerationsModel.enTestType _TestTypeID = clsEnumerationsModel.enTestType.NotSpecified;
        private int _AppointmentID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
       
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsEnumerationsModel.enTestType testTypeID,int AppointmentID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = testTypeID;
            _AppointmentID = AppointmentID;


        }
    

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {             
                ctrlScheduleTest1.LoadScheduleTestInfo(_LocalDrivingLicenseApplicationID, _TestTypeID, _AppointmentID);
        }

     
    }
}
