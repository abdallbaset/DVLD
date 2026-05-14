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
        private clsTests _Test;

        private clsEnumerationsModel.enTestType _TestTypeID;
        public clsEnumerationsModel.enTestType TestTypeID
        {
            get => _TestTypeID;
            set
            {
                _TestTypeID = value;
                _SetFormLayout();
            }
        }
        public ctrlSecheduledTest()
        {
            InitializeComponent();
        }


        private void _SetTestImage()
        {
            switch (_TestTypeID)
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
            _SetTestImage();
            _UpdateGroupBoxTitle();
        }
        private void _UpdateGroupBoxTitle()
        {
            switch (TestTypeID)
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
            lbl_LocalDrivingLicenseAppID.Text = _TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lbl_DrivingClass.Text = _TestAppointment.className;
            lbl_FullName.Text = _TestAppointment.ApplicantFullName;
            lbl_Trial.Text = clsTests.GetTotalTrialsPerTest(_TestAppointment.LocalDrivingLicenseApplicationID, TestTypeID).ToString();
            lbl_Fees.Text = _TestAppointment.PaidFees.ToString();
            lbl_TestDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            lbl_TestID.Text = (_Test == null)? "Not Taken Yet" : _Test.TestID.ToString();

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
            if (_TestAppointment == null)
            {
                _TestAppointment = clsTestAppointments.Find(TestAppointmentID);

            }
            _Test = clsTests.FindByTestAppointmentID(TestAppointmentID);
           
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
