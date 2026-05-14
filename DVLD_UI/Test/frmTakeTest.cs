
using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses.Local_Licenses.Controls;
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
        private clsEnumerationsModel.enTestType _TestType;
        public frmTakeTest(int TestAppointmentID, clsEnumerationsModel.enTestType TestType)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestType = TestType;
        }
       private void _HandleLockedAppointmentState()
        {
            if (_IsTestLocked())
            {
                _Test = clsTests.FindByTestAppointmentID(_TestAppointmentID);

                if (_Test != null)
                {
                    if (Convert.ToBoolean(_Test.TestResult))
                    {
                        rb_Pass.Checked = true;
                    }
                    else
                    {
                        rb_Fail.Checked = true;


                    }
                    txt_Notes.Text = _Test.Notes;
                }
                
                lbl_Message.Visible = true;
                btn_Save.Enabled = false;
                rb_Pass.Enabled = false;
                rb_Fail.Enabled = false;
                txt_Notes.Enabled = false;
            }
        }
        private void frmTakeTest_Load(object sender, System.EventArgs e)
        {
            ctrlSecheduledTest1.TestTypeID = _TestType;
            ctrlSecheduledTest1.LoadScheduledTestInfo(_TestAppointmentID);
            _ResetDefaultValues();
            if(!InitializeTestAppointments())
            {
                btn_Save.Enabled = false;
                rb_Pass.Enabled = false;
                rb_Fail.Enabled = false;
            }
            _HandleLockedAppointmentState();

        }
        private bool InitializeTestAppointments()
        {
            _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);
            return _TestAppointment != null;
        }
        private void _ResetDefaultValues()
        {
            rb_Pass.Checked = true;
            txt_Notes.Text = string.Empty;
            lbl_Message.Visible = false;
        }
        private void _setTestInfo()
        {
            _Test = new clsTests();
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rb_Pass.Checked ? true : false;
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
