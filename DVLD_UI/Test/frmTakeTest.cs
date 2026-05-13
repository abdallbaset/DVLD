
using DVLD_Business;
using DVLD_UI.GlobalClasses;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Test
{
    public partial class frmTakeTest : Form
    {

        public delegate void DataBackEventHandler(object seneder , clsTests Test);
        public event DataBackEventHandler DataBack;

        private int _TestAppointmentID = (int)clsGlobal.enIdentityStatus.NonExistent;
        private clsTests _Test;
        clsTestAppointments _TestAppointment;
        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
        }

        private void frmTakeTest_Load(object sender, System.EventArgs e)
        {
            ctrlSecheduledTest1.LoadScheduledTestInfo(_TestAppointmentID);
            _ResetDefaultValues();
            InitializeTestAppointments();
            if (_IsTestLocked())
            {
                btn_Save.Enabled = false;
                rb_Pass.Enabled = false;
                rb_Fail.Enabled = false;
                txt_Notes.Enabled = false;
            }
        }
        private void InitializeTestAppointments()
        {
            _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);
        }
        private void _ResetDefaultValues()
        {
            rb_Pass.Checked = true;
            txt_Notes.Text = string.Empty;
        }
        private void LockedAppointment()
        {
            _TestAppointment.IsLocked = true;
            _TestAppointment.Save();
        }
        private void _setTestInfo()
        {
            _Test = new clsTests();
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = Convert.ToInt32(rb_Pass.Checked ? true : false);
            _Test.Notes = txt_Notes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }
        private void btn_Close_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private bool _IsTestLocked()
        {
             return _TestAppointment != null && _TestAppointment.IsLocked;
        }
        private void btn_Save_Click(object sender, System.EventArgs e)
        {
            _setTestInfo();
            if(MessageBox.Show("Are you sure you want to save the test result?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
               if (_Test.Save())
                {
                    LockedAppointment();
                    MessageBox.Show("Test result saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctrlSecheduledTest1.LoadScheduledTestInfo(_TestAppointmentID);
                    DataBack?.Invoke(this,_Test);
                    btn_Save.Enabled = false;
                }
               else
                {
                    MessageBox.Show("Failed to save test result.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }       
             
            }
        }
    }
}
