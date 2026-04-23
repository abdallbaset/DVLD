using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Properties;
using System.Windows.Forms;

namespace DVLD_UI.Licenses.Local_Licenses.Controls
{
    public partial class ctrlSecheduledTest : UserControl
    {

        private clsTestAppointments _TestAppointment;
        private clsLocalDrivingLicenseApplications _LocalApp;
        private clsTests _Test;
        public ctrlSecheduledTest()
        {
            InitializeComponent();
        }


        private void _SetTestImage(int testType)
        {
            switch ((clsEnumerationsModel.enTestType)testType)
            {
                case clsEnumerationsModel.enTestType.VisionTest:
                    pb_TestTypeImage.Image = Resources.Vision_512;
                    break;
                case clsEnumerationsModel.enTestType.WrittenTest:
                    pb_TestTypeImage.Image = Resources.Written_Test_512;
                    break;
                case clsEnumerationsModel.enTestType.StreetTest:
                    pb_TestTypeImage.Image = Resources.Street_Test_32;
                    break;
            }
        }
        private void _SetFormLayout()
        {
            _SetTestImage(_TestAppointment.TestTypeID);
            _UpdateGroupBoxTitle();
        }
        private void _UpdateGroupBoxTitle()
        {
            switch ((clsEnumerationsModel.enTestType)_TestAppointment.TestTypeID)
            {
                case clsEnumerationsModel.enTestType.VisionTest:
                    gb_TestType.Text = "Vision Test";
                    break;
                case clsEnumerationsModel.enTestType.WrittenTest:
                    gb_TestType.Text = "Written Test";
                    break;
                case clsEnumerationsModel.enTestType.StreetTest:
                    gb_TestType.Text = "Street Test";
                    break;
            }
        }

        private void _FillData()
        {
            lbl_LocalDrivingLicenseAppID.Text = _LocalApp.LocalDrivingLicenseApplicationID.ToString();
            lbl_DrivingClass.Text = _LocalApp.ClassName;
            lbl_FullName.Text = _LocalApp.ApplicantFullName;
            lbl_Trial.Text = clsTests.GetTotalTrialsPerTest(_TestAppointment.LocalDrivingLicenseApplicationID, _TestAppointment.TestTypeID).ToString();
            lbl_Fees.Text = _TestAppointment.PaidFees.ToString();
            lbl_TestDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            lbl_TestID.Text = (_Test == null)? "Not Taken Yet" : _Test.TestID.ToString();
            _UpdateGroupBoxTitle();

        }

        private void _LoadDefaultData()
        {
            lbl_DrivingClass.Text = "???";
            lbl_FullName.Text = "???";
            lbl_LocalDrivingLicenseAppID.Text = "???";
            lbl_Title.Text = "Scheduled Test";
            lbl_Fees.Text = "???";
            lbl_Trial.Text = "??";
            lbl_TestID.Text = "???";
            lbl_TestDate.Text = "???";   
        }
        public void LoadScheduledTestInfo(int TestAppointmentID)
        {

            _TestAppointment = clsTestAppointments.Find(TestAppointmentID);
            _LocalApp = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_TestAppointment.LocalDrivingLicenseApplicationID);
            _Test = clsTests.FindByTestAppointmentID(TestAppointmentID);
            _SetFormLayout();
            if (_TestAppointment == null)
            {
                _LoadDefaultData();
                MessageBox.Show("No Test Appointment with ID [" + TestAppointmentID + "] was found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillData();
        }
    }
}
