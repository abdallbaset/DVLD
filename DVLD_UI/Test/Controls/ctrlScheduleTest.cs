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
        private int _LocalDrivingLicenseApplicationID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        private int _TestTypeID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        private int _Trial = 0;
        private double _TestTypeFees = 0;
        private double _RetakeAppFees = 0;

        private clsLocalDrivingLicenseApplications _LocalApp;
        private clsTestAppointments _Appointment;

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
            dtp_TestDate.Value = DateTime.Now;
            dtp_TestDate.MinDate = DateTime.Now; 
            btn_Save.Enabled = false;
        }

        private void _UpdateGroupBoxTitle()
        {
            switch ((clsEnumerationsModel.enTestType)_TestTypeID)
            {
                case clsEnumerationsModel.enTestType.VisionTest:
                    gb_TestType.Text = "Vision Test";
                    pb_TestTypeImage.Image = Resources.Vision_512;
                    break;
                case clsEnumerationsModel.enTestType.WrittenTest:
                    gb_TestType.Text = "Written Test";
                    pb_TestTypeImage.Image = Resources.Written_Test_512;
                    break;
                case clsEnumerationsModel.enTestType.StreetTest:
                    gb_TestType.Text = "Street Test";
                    pb_TestTypeImage.Image = Resources.Street_Test_32;
                    break;
            }
        }

        private void _HandleRetakeTestLogic()
        {
            // إذا كان هناك محاولات سابقة، فهذا يعني أنه "إعادة اختبار"
            if (_Trial > 0)
            {
                _RetakeAppFees = clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.RetakeTest).ApplicationFees;
                gb_RetakeTestInfo.Enabled = true;
                lbl_Title.Text = "Schedule Retake Test";
                lbl_RetakeTestAppID.Text = "N/A"; // سيتم توليده عند الحفظ
            }
            else
            {
                _RetakeAppFees = 0;
                gb_RetakeTestInfo.Enabled = false;
                lbl_Title.Text = "Schedule Test";
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

            _UpdateGroupBoxTitle();
            _HandleRetakeTestLogic();

            btn_Save.Enabled = true;
        }

        //private bool _ValidateAppointment()
        //{
        //    // التأكد من عدم وجود موعد نشط لنفس نوع الاختبار
        //    if (clsTestAppointments.IsThereAnActiveAppointment(_LocalDrivingLicenseApplicationID, _TestTypeID))
        //    {
        //        lbl_UserMessage.Text = "Person already has an active appointment for this test.";
        //        lbl_UserMessage.Visible = true;
        //        btn_Save.Enabled = false;
        //        return false;
        //    }
        //    return true;
        //}



        public void LoadScheduleTestInfo(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;

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
           // _ValidateAppointment();
        }


        private void btn_Save_Click(object sender, EventArgs e)
        {
            // هنا ستضع منطق الحفظ (إنشاء كائن Application جديد للإعادة إذا لزم الأمر، ثم إنشاء الموعد)
        }

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {
            _LoadDefaultData();
        }
    }
}