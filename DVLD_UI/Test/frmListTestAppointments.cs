using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static DVLD_Model.clsEnumerationsModel;
namespace DVLD_UI.Test
{
    public partial class frmListTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID = (int)clsGlobal.enIdentityStatus.NonExistent;
        private clsEnumerationsModel.enTestType _TestType = clsEnumerationsModel.enTestType.NotSpecified;
        private DataTable _ListTestAppointments;
        private clsTests _LastTest;
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsEnumerationsModel.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }

        private void _SetTitles(string formText, string labelText)
        {
            this.Text = formText;
            lbl_Title.Text = labelText;
        }

        private void _SetTestImage()
        {
            switch (_TestType)
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

            if (clsEnumerationsModel.enTestType.VisionTest == _TestType)
            {
                _SetTitles("Vision Test Appointment", "Vision Test");
            }
            else if (clsEnumerationsModel.enTestType.WrittenTest == _TestType)
            {
                _SetTitles("Written Test Appointment", "Written Test");
            }
            else
            {
                _SetTitles("Street Test Appointment", "Street Test");
            }

        }

        private void _Frm_OnTestSaved(object sender,clsTests LastTest)
        {
            _LastTest = LastTest;
        }


        private bool IsTestPassed()
        {
            return (_LastTest != null &&  Convert.ToBoolean( _LastTest.TestResult));
        }

        private void _LoadInitialData()
        {
            _SetFormLayout();
        }

        private void _HandleContextMenuState()
        {
            bool IsLocked = (dgv_ListTestAppointments.CurrentRow != null) ? Convert.ToBoolean(dgv_ListTestAppointments.CurrentRow.Cells["IsLocked"].Value) : false;

            if (IsLocked)
            {
                editToolStripMenuItem.Enabled = false;
                takeTestToolStripMenuItem.Enabled = false;
            }
            else
            {
                editToolStripMenuItem.Enabled = true;
                takeTestToolStripMenuItem.Enabled = true;
            }
        }

     
        private void _RefreshListTestAppointment()
        {
            _ListTestAppointments = clsTestAppointments.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, (int)_TestType);
            dgv_ListTestAppointments.DataSource = _ListTestAppointments;
            _FormatDataGridViewColumn();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, new DataView(_ListTestAppointments));
        }

        private void _FormatDataGridViewColumn()
        {
            if (dgv_ListTestAppointments.Rows.Count > 0)
            {
               clsUtil.ConfigureColumn(dgv_ListTestAppointments.Columns["TestAppointmentID"], "App.ID",100);
               clsUtil.ConfigureColumn(dgv_ListTestAppointments.Columns["AppointmentDate"], "Date", 200);
               clsUtil.ConfigureColumn(dgv_ListTestAppointments.Columns["PaidFees"], "Paid Fees", 140);
               clsUtil.ConfigureColumn(dgv_ListTestAppointments.Columns["IsLocked"], "Is Locked", 100); 
            }
        }
   
        private void _RefreshApplicationInfo()
        {
            ctrlDrivingLicenseApplicationInfo1.Load_LocalDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);

        }
        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _RefreshApplicationInfo();
            _LoadInitialData();
            _RefreshListTestAppointment();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListTestAppointments.Rows.Count > 0 && dgv_ListTestAppointments.CurrentRow != null)
            {
                int selectedTestAppointmentID = Convert.ToInt32(dgv_ListTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value);
                frmScheduleTest scheduleTestForm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType,selectedTestAppointmentID);
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
            if (dgv_ListTestAppointments.Rows.Count > 0 && dgv_ListTestAppointments.CurrentRow != null)
            {
                int selectedTestAppointmentID = Convert.ToInt32(dgv_ListTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value);
                frmTakeTest TakeTestForm = new frmTakeTest(selectedTestAppointmentID);
                TakeTestForm.DataBack += _Frm_OnTestSaved;
                TakeTestForm.ShowDialog();
                _RefreshApplicationInfo();
                _RefreshListTestAppointment();
            }
            else
            {
                MessageBox.Show("Please select a Appointment first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_AddNewAppointment_Click(object sender, EventArgs e)
        {

            if(IsTestPassed())
            {
                MessageBox.Show("This person has already passed this test. You cannot schedule another appointment.",
                                    "Test Already Passed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                return;
            }


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

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _HandleContextMenuState();
        }
    }
}
