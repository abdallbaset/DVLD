using DVLD_Model;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Test
{
    public partial class frmScheduleTest : Form
    {
       private  int _LocalDrivingLicenseApplicationID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
       private int _TestTypeID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        private int _AppointmentID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        enum enMode
        {
            AddNew = 1,
            Update = 2
        }
       private  enMode _Mode;
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, int testTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = testTypeID;
            _Mode = enMode.AddNew;


        }
        public frmScheduleTest(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _Mode = enMode.Update;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                ctrlScheduleTest1.LoadScheduleTestInfo(_AppointmentID);
            }
            else
                ctrlScheduleTest1.LoadScheduleTestInfo(_LocalDrivingLicenseApplicationID, _TestTypeID);
          
        }

     
    }
}
