using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace DVLD_UI.Test
{
    public partial class frmListTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID = (int)clsGlobal.enIdentityStatus.NonExistent;
        //   private clsTestAppointments TestAppointments;
        private int _TestType = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        private DataTable _ListTestAppointments;
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
     
        private void _LoadTestTypeSettings()
        {
             ;
            if ((int)clsTestTypesModel.enTestType.VisionTest == ctrlDrivingLicenseApplicationInfo1.PassedTestsCount)
            {
                _TestType = (int)clsEnumerationsModel.enTestType.VisionTest ;
            }
            else if ((int)clsTestTypesModel.enTestType.WrittenTest == ctrlDrivingLicenseApplicationInfo1.PassedTestsCount)
            {
                _TestType = (int)clsEnumerationsModel.enTestType.WrittenTest;
            }
            else
            {
                _TestType = (int)clsEnumerationsModel.enTestType.StreetTest;
            }
        }

        private void _SetTitles(string formText, string labelText)
        {
            this.Text = formText;
            lbl_Title.Text = labelText;
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
            _LoadTestTypeSettings();
            _SetTestImage(_TestType);

            if ((int)clsEnumerationsModel.enTestType.VisionTest == _TestType)
            {
                _SetTitles("Vision Test Appointment", "Vision Test");
            }
            else if ((int)clsEnumerationsModel.enTestType.WrittenTest == _TestType)
            {
                _SetTitles("Written Test Appointment", "Written Test");
            }
            else
            {
                _SetTitles("Street Test Appointment", "Street Test");
            }

        }
        private void _LoadInitialData()
        {
            _SetFormLayout();     
        }
        private void _GetNumberOfRecords()
        {
            lbl_NumberOfRecords.Text = _ListTestAppointments.Rows.Count.ToString();
        }
        private void _RefreshListTestAppointment()
        {
            _ListTestAppointments = clsTestAppointments.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);
            dgv_ListTestAppointments.DataSource = _ListTestAppointments;
            _FormatDataGridView();
            _GetNumberOfRecords();
        }
        private void _FormatDataGridView()
        {
            if (dgv_ListTestAppointments.Rows.Count > 0)
            {
                if (dgv_ListTestAppointments.Columns.Contains("TestAppointmentID"))
                {
                    dgv_ListTestAppointments.Columns["TestAppointmentID"].HeaderText = "App.ID";
                    dgv_ListTestAppointments.Columns["TestAppointmentID"].Width = 100;
                }

                if (dgv_ListTestAppointments.Columns.Contains("AppointmentDate"))
                {
                    dgv_ListTestAppointments.Columns["AppointmentDate"].HeaderText = "Date";
                    dgv_ListTestAppointments.Columns["AppointmentDate"].Width = 200;
                }

                if (dgv_ListTestAppointments.Columns.Contains("PaidFees"))
                {
                    dgv_ListTestAppointments.Columns["PaidFees"].HeaderText = "Paid Fees";
                    dgv_ListTestAppointments.Columns["PaidFees"].Width = 140;
                }

                if (dgv_ListTestAppointments.Columns.Contains("IsLocked"))
                {
                    dgv_ListTestAppointments.Columns["IsLocked"].HeaderText = "Is Locked";
                    dgv_ListTestAppointments.Columns["IsLocked"].Width = 100;
                }  
            }
        }
   

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _RefreshListTestAppointment();
            ctrlDrivingLicenseApplicationInfo1.Load_LocalDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);
            _LoadInitialData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListTestAppointments.Rows.Count > 0 && dgv_ListTestAppointments.CurrentRow != null)
            {
                frmScheduleTest scheduleTestForm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                scheduleTestForm.ShowDialog();
                _RefreshListTestAppointment();
            }
            else
            {
                MessageBox.Show("Please select a Appointment first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_AddNewAppointment_Click(object sender, EventArgs e)
        {
            if (clsTestAppointments.HasActiveAppointment(_LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("An active appointment already exists for this application. Please edit the existing appointment or" +
                    " wait until it is completed before scheduling a new one.", "Active Appointment Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                            frmScheduleTest scheduleTestForm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
        scheduleTestForm.ShowDialog();
        _RefreshListTestAppointment();
            }

    
        }
    }
}
