using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Properties;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Test.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        enum enMode
        {
            AddNew = 1,
            Update = 2
        }
        private enMode _CurrentMode = enMode.AddNew;
        private int _LocalDrivingLicenseApplicationID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        private int _TestTypeID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        private int _Trial = 0;
        private double _TestTypeFees = 0;
        private double _RetakeAppFees = 0;

        private clsLocalDrivingLicenseApplications _LocalApp;
        private clsTestAppointments _TestAppointment;
        private clsApplications _Applications;

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }


        private void _LoadDefaultData()
        {
            lbl_DrivingClass.Text = "???";
            lbl_FullName.Text = "???";
            lbl_LocalDrivingLicenseAppID.Text = "???";
            lbl_RetakeAppFees.Text = "0";
            lbl_Title.Text = "Schedule Test";
            lbl_TotalFees.Text = "???";
            lbl_Fees.Text = "???";
            lbl_Trial.Text = "???";
            lbl_RetakeTestAppID.Text = "N/A";
            lbl_UserMessage.Visible = false;
            gb_RetakeTestInfo.Enabled = false;
            dtp_TestDate.MinDate = DateTime.Today; 
            dtp_TestDate.Value = DateTime.Now;
            btn_Save.Enabled = false;
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
            _SetTestImage(_TestTypeID);
            _UpdateGroupBoxTitle();
        }
        private void _UpdateGroupBoxTitle()
        {
            switch ((clsEnumerationsModel.enTestType)_TestTypeID)
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

        private void _HandleRetakeTestLogic()
        {

            if (_Trial > 0)
            {
                _RetakeAppFees = clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.RetakeTest).ApplicationFees;
                gb_RetakeTestInfo.Enabled = true;
                lbl_Title.Text = "Schedule Retake Test";
            }
            else
            {
                _RetakeAppFees = 0;
                gb_RetakeTestInfo.Enabled = false;
                lbl_Title.Text = "Schedule Test";
            }

            
            if(_TestAppointment != null && _TestAppointment.RetakeTestApplicationID != (int)clsEnumerationsModel.enIdentityStatus.NonExistent)
            {
                lbl_RetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
            }
            else
            {
                lbl_RetakeTestAppID.Text = "N/A";
            }


            lbl_RetakeAppFees.Text = _RetakeAppFees.ToString();
            lbl_TotalFees.Text = (_TestTypeFees + _RetakeAppFees).ToString();
        }

        private void _FillData()
        {
            lbl_LocalDrivingLicenseAppID.Text = _LocalApp.LocalDrivingLicenseApplicationID.ToString();
            lbl_DrivingClass.Text = _LocalApp.ClassName;
            lbl_FullName.Text = _LocalApp.ApplicantFullName; 
            lbl_Trial.Text = _Trial.ToString();
            lbl_Fees.Text = _TestTypeFees.ToString();
            lbl_RetakeAppFees.Text = _RetakeAppFees.ToString();
            if(_CurrentMode == enMode.Update)
            {
                dtp_TestDate.Value = _TestAppointment.AppointmentDate;
            }
            else
            {
                dtp_TestDate.Value = DateTime.Now;
            }
                _UpdateGroupBoxTitle();
            _HandleRetakeTestLogic();

            btn_Save.Enabled = true;
        }

        public void LoadScheduleTestInfo(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            _CurrentMode = enMode.AddNew;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;

            _LocalApp = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            _SetFormLayout();
            if (_LocalApp == null)
            {
                _LoadDefaultData();
                MessageBox.Show("No Local Application with ID [" + _LocalDrivingLicenseApplicationID + "] was found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestTypeFees = clsTestTypes.Find((clsTestTypesModel.enTestType)_TestTypeID).TestTypeFees;
            _Trial = clsTests.GetTotalTrialsPerTest(_LocalDrivingLicenseApplicationID, _TestTypeID);

            _FillData();
        }
        public void LoadScheduleTestInfo(int AppointmentID)
        {
            _CurrentMode = enMode.Update;
            _TestAppointment = clsTestAppointments.Find(AppointmentID);
            _TestTypeID = _TestAppointment.TestTypeID;
            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            if (_TestAppointment == null)
            {
                _LoadDefaultData();
                MessageBox.Show("No Test Appointment  with ID [" + AppointmentID + "] was found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SetFormLayout();
            _LocalApp = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalApp == null)
            {
                _LoadDefaultData();
                MessageBox.Show("No Local Application with ID [" + _LocalDrivingLicenseApplicationID + "] was found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestTypeFees = clsTestTypes.Find((clsTestTypesModel.enTestType)_TestTypeID).TestTypeFees;
            _Trial = clsTests.GetTotalTrialsPerTest(_LocalDrivingLicenseApplicationID, _TestTypeID);

            _FillData();
        }


   

        private void _setTestAppointmentInfo()
        {
            
            _TestAppointment = new clsTestAppointments();
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.AppointmentDate = dtp_TestDate.Value;
            _TestAppointment.PaidFees = Convert.ToDouble(lbl_TotalFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;
            if(_Trial == 0)
            _TestAppointment.RetakeTestApplicationID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
            else
            {
                _setApplicationsInfo();
                _Applications.Save();
                _TestAppointment.RetakeTestApplicationID = _Applications.ApplicationID;
                lbl_RetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();

            }
        }
        private void _setApplicationsInfo()
        {
            _Applications = new clsApplications();
            _Applications.ApplicantPersonID = _LocalApp.ApplicantPersonID;
            _Applications.ApplicationDate = DateTime.Now;
            _Applications.ApplicationTypeID = clsApplicationTypesModel.enApplicationTypes.RetakeTest;
            _Applications.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Applications.PaidFees = clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.RetakeTest).ApplicationFees;
            _Applications.LastStatusDate = DateTime.Now;
            _Applications.Status = clsApplicationModel.enApplicationStatus.Completed;    
        }


        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {
            _LoadDefaultData();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(_CurrentMode == enMode.AddNew)
            {
                _setTestAppointmentInfo();
               
            }
            else
            {
                _TestAppointment.AppointmentDate = dtp_TestDate.Value;
            }

            if (_TestAppointment.Save())
            {
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_RetakeTestAppID.Text = (_TestAppointment.RetakeTestApplicationID == (int)clsEnumerationsModel.enIdentityStatus.NonExistent) ? "N/A" : _TestAppointment.RetakeTestApplicationID.ToString();
                btn_Save.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed to save user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}