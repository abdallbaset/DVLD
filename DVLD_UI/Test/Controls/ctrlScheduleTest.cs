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

        private clsEnumerationsModel.enCreationMode _CreationMode = clsEnumerationsModel.enCreationMode.FirstTimeSchedule;
        private enMode _CurrentMode = enMode.AddNew;
        private int _LocalDrivingLicenseApplicationID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        private int _AppointmentID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        private int _Trial = 0;
        private double _TestTypeFees = 0;
        private double _RetakeAppFees = 0;
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
            switch (_TestTypeID)
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

        private void _HandleCreationMode()
        {
            if(_Trial == 0)
            {
                _CreationMode = clsEnumerationsModel.enCreationMode.FirstTimeSchedule;
            }
            else
            {
                _CreationMode = clsEnumerationsModel.enCreationMode.RetakeTestSchedule;
            }
        }
        private void _HandleRetakeTestLogic()
        {
            _HandleCreationMode();
            switch (_CreationMode)
            {
                case clsEnumerationsModel.enCreationMode.FirstTimeSchedule:
                    _RetakeAppFees = 0;
                    gb_RetakeTestInfo.Enabled = false;
                    lbl_Title.Text = "Schedule Test";
                    break;

                case clsEnumerationsModel.enCreationMode.RetakeTestSchedule:
                    _RetakeAppFees = clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.RetakeTest).ApplicationFees;
                    gb_RetakeTestInfo.Enabled = true;
                    lbl_Title.Text = "Schedule Retake Test";
                    break;
            }

            if (_TestAppointment != null && _TestAppointment.RetakeTestApplicationID != (int)clsEnumerationsModel.enIdentityStatus.NonExistent)
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

     

            if (_CurrentMode == enMode.Update)
            {
                if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                    dtp_TestDate.MinDate = DateTime.Now;
                else
                    dtp_TestDate.MinDate = _TestAppointment.AppointmentDate;

                dtp_TestDate.Value = _TestAppointment.AppointmentDate;
            }
            else
            {
                dtp_TestDate.Value = DateTime.Now;
            }
            _HandleRetakeTestLogic();

            btn_Save.Enabled = true;
        }

        public void LoadScheduleTestInfo(int LocalDrivingLicenseApplicationID, clsEnumerationsModel.enTestType testTypeID, int AppointmentID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent)
        {

            _CurrentMode = (AppointmentID == (int)clsEnumerationsModel.enIdentityStatus.NonExistent) ?  enMode.AddNew: enMode.Update;
            if(_CurrentMode == enMode.AddNew)
            {
                _TestAppointment = new clsTestAppointments();

            }
            else
            {
                _TestAppointment = clsTestAppointments.Find(AppointmentID);
                if (_TestAppointment == null)
                {
                    _LoadDefaultData();
                    MessageBox.Show("No Test Appointment  with ID [" + AppointmentID + "] was found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            _AppointmentID = AppointmentID;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            TestTypeID = testTypeID;

            _LocalApp = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalApp == null)
            {
                _LoadDefaultData();
                MessageBox.Show("No Local Application with ID [" + _LocalDrivingLicenseApplicationID + "] was found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestTypeFees = clsTestTypes.Find(_TestTypeID).TestTypeFees;
            _Trial = clsTests.GetTotalTrialsPerTest(_LocalDrivingLicenseApplicationID,(int)_TestTypeID);

            _FillData();
        }

        private bool _PrepareTestAppointment()
        {
            
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointment.TestTypeID = (int)TestTypeID;
            _TestAppointment.AppointmentDate = dtp_TestDate.Value;
            _TestAppointment.PaidFees = Convert.ToDouble(lbl_TotalFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;

            if(_CreationMode == clsEnumerationsModel.enCreationMode.FirstTimeSchedule)
            _TestAppointment.RetakeTestApplicationID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
            else
            {
                _setApplicationInfo();
               if( !_Applications.Save())
                {
                    return false;
                }

                
                _TestAppointment.RetakeTestApplicationID = _Applications.ApplicationID;
                lbl_RetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();

            }
            return true;
        }
        private void _setApplicationInfo()
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
               if(!_PrepareTestAppointment())
                {
                    MessageBox.Show("Failed to save retake test application information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                _TestAppointment.AppointmentDate = dtp_TestDate.Value;
            }

            if (_TestAppointment.Save())
            {
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_RetakeTestAppID.Text = (_TestAppointment.RetakeTestApplicationID == (int)clsEnumerationsModel.enIdentityStatus.NonExistent) ? "N/A" : _TestAppointment.RetakeTestApplicationID.ToString();
                _CurrentMode = enMode.Update;
            }
            else
            {
                MessageBox.Show("Failed to save user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}