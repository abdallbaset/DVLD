using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using System;
using System.Windows.Forms;
namespace DVLD_UI.Applications
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private int _applicationId = (int)clsGlobal.enIdentityStatus.NonExistent;
        public int ApplicationID
        {
            get  => _applicationId; 
        }

        private clsApplications _Application;

        public clsApplicationModel SelectedApplicationInfo
        {
            get  => _Application?.ApplicationInfo; 
        }

        public int ApplicantPersonID
        {
            get => _Application != null ? _Application.ApplicantPersonID : (int)clsGlobal.enIdentityStatus.NonExistent;
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplications.Find(ApplicationID);
            if (_Application == null)
            {
                LoadDefaultData();
                MessageBox.Show($"No Application with ID [{ApplicationID}] was found in the system.",
                                "Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            _FillApplicationData();
        }

        private void _FillApplicationData()
        {
            if (_Application == null || _Application.ApplicationInfo == null)
            {
                LoadDefaultData();
                return;
            }
            _applicationId = _Application.ApplicationID;
           lbl_ApplicationID.Text = ApplicationID.ToString();
           lbl_ApplicantName.Text = _Application != null ? _Application.ApplicantName : "???";
           lbl_Status.Text = _Application.Status.ToString();
           lbl_Fees.Text = _Application.PaidFees.ToString();
           lbl_Type.Text = _Application.ApplicationTypeName;
           lbl_ApplicationDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
           lbl_LastStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
           lbl_CreatedBy.Text = _Application.CreatedByUserName;

        }

        public void LoadDefaultData()
        {
            _applicationId = (int)clsGlobal.enIdentityStatus.NonExistent;
            _Application = null;
          
            lbl_ApplicationID.Text = "???";
            lbl_ApplicantName.Text = "???";
            lbl_Status.Text = "???";
            lbl_Fees.Text = "???";
            lbl_Type.Text = "???";
            lbl_ApplicationDate.Text = "??/??/????";
            lbl_LastStatusDate.Text = "??/??/????";
            lbl_CreatedBy.Text = "???";
        }

        private void llbl_ViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (_Application.ApplicantPersonID == (int)clsGlobal.enIdentityStatus.NonExistent)
                {
                    MessageBox.Show("No applicant associated with this application.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmPersonDetails frmPersonDetails = new frmPersonDetails(_Application.ApplicantPersonID);
                frmPersonDetails.ShowDialog();
                _FillApplicationData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open person details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

    }
}