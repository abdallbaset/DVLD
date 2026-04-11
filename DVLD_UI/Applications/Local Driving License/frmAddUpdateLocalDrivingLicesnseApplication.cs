using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Local_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {
        enum enMode { AddNew = 1, Update = 2 }

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = (int)clsGlobal.enIdentityStatus.NonExistent;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplications;

       private int _PersonID = (int)clsGlobal.enIdentityStatus.NonExistent;
       private int _ActiveApplicationID = (int)clsGlobal.enIdentityStatus.NonExistent;
       private int _ActiveLicenseID = (int)clsGlobal.enIdentityStatus.NonExistent;
        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID) 
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _Mode = enMode.Update;
        }

        private void frmAddAndUpdateApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _ApplicationModeSetup()
        {
            if (_Mode == enMode.AddNew)
            {
                lbl_Mode.Text = "New Local Driving Licesnse Application";
                this.Text = "Add New Local Driving Licesnse Application";
                _LocalDrivingLicenseApplications = new clsLocalDrivingLicenseApplications();
                btn_Save.Enabled = false;
            }
            else
            {
                lbl_Mode.Text = "Update Local Driving Licesnse Application";
                this.Text = "Update Local Driving Licesnse Application";
                _LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);
                btn_Save.Enabled = true;
                return;
               
            }
        }
        private void _ResetDefaultValues()
        {
            _FillLicenseClassesComboBox();
            _ApplicationModeSetup();

            _LocalDrivingLicenseApplications.ApplicationTypeID = clsApplicationTypesModel.enApplicationTypes.NewLocalDrivingLicenseService;
            lbl_ApplicationDate.Text = clsFormat.DateToShort( DateTime.Now);
            lblAppFees.Text = _LocalDrivingLicenseApplications.PaidFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lbl_LocalDrivingLicenseApplicationID.Text = "???";
        }

        private void _FillLicenseClassesComboBox()
        {
            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();
            if (dt != null && dt.Rows.Count > 0)
            {
                cbLicenseClass.DataSource = dt;
                cbLicenseClass.DisplayMember = "ClassName";
                cbLicenseClass.ValueMember = "LicenseClassID";
            }
        }

        private void _LoadData()
        {
            if (_LocalDrivingLicenseApplications == null)
            {
                MessageBox.Show("No Local Driving License Application record with ID = " + _LocalDrivingLicenseApplicationID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplications.ApplicantPersonID);
            ctrlPersonCardWithFilter1.DisableFilter();

            lbl_LocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID.ToString();
            lbl_ApplicationDate.Text =clsFormat.DateToShort(_LocalDrivingLicenseApplications.ApplicationDate);
            cbLicenseClass.SelectedValue = _LocalDrivingLicenseApplications.LicenseClassID;
            lblCreatedByUser.Text = _LocalDrivingLicenseApplications.CreatedByUserName;
            lblAppFees.Text = _LocalDrivingLicenseApplications.PaidFees.ToString();

            _PersonID = ctrlPersonCardWithFilter1.PersonID;
        }

        bool _IsPersonNotSelected()
        {
            _PersonID = ctrlPersonCardWithFilter1.PersonID;
            return (_PersonID == (int)clsGlobal.enIdentityStatus.NonExistent);
        }

        private bool _IsPersonSelection()
        {
            if (_Mode == enMode.Update)
            {
                btn_Save.Enabled = true;
                return true;
            }

            if (_IsPersonNotSelected())
            {
                MessageBox.Show("Please select a person first before moving to the next step.",
                               "Selection Required",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return false;
            }

            btn_Save.Enabled = true;
            return true;
        }

        private bool _IsPersonInvalidForSaving()
        {
            if (_Mode == enMode.Update) return false;

            if (_IsPersonNotSelected())
            {
                MessageBox.Show("Please select a person first before Save.",
                           "Selection Required",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                btn_Save.Enabled = false;
                return true;
            }

            return false;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex != 0 && !_IsPersonSelection())
            {
                e.Cancel = true;
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                tabControl1.SelectedIndex = 1;
                return;
            }

            if (!_IsPersonSelection())
            {
                return;
            }

            tabControl1.SelectedIndex = 1;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void _SetApplictionInfo()
        {
            _LocalDrivingLicenseApplications.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplications.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplications.ApplicationTypeID = clsApplicationTypesModel.enApplicationTypes.NewLocalDrivingLicenseService;
            _LocalDrivingLicenseApplications.ApplicationStatus = clsApplicationModel.enApplicationStatus.New; 
            _LocalDrivingLicenseApplications.PaidFees = Convert.ToDouble(lblAppFees.Text);
            _LocalDrivingLicenseApplications.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplications.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }
        private void _SetLocalDrivingLicenseInfo()
        {
            _LocalDrivingLicenseApplications.LicenseClassID =(int)cbLicenseClass.SelectedValue;
        }

        private bool _hasActiveApplicationForPerson()
        {
            _ActiveApplicationID = clsApplications.GetActiveApplicationIDForLicenseClass(_PersonID,
                              clsApplicationTypesModel.enApplicationTypes.NewLocalDrivingLicenseService, _LocalDrivingLicenseApplications.LicenseClassID);  
            return _ActiveApplicationID != (int)clsGlobal.enIdentityStatus.NonExistent;
        }
        private bool _DoesPersonHaveActiveLicenseForClass()
        {
            _ActiveLicenseID = clsLicenses.GetActiveLicenseIDByPersonIDAndLicenseClassID(_PersonID, _LocalDrivingLicenseApplications.LicenseClassID);
            return _ActiveLicenseID != (int)clsGlobal.enIdentityStatus.NonExistent;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (_IsPersonInvalidForSaving())
                return;


            _SetApplictionInfo();
            _SetLocalDrivingLicenseInfo();

            if (_hasActiveApplicationForPerson())
            {
                MessageBox.Show($"The selected person already has an active application for the selected license class with ID = [{_ActiveApplicationID}].Please select a different person or license class.",
                                "Active Application Exists",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                return;
            }

            if (_DoesPersonHaveActiveLicenseForClass())
            {MessageBox.Show($"The selected person already holds an active license for this class License ID: [{_ActiveLicenseID}]. Please select a different person or license class.",
                                "License Already Exists",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                return;
            }

            if (_LocalDrivingLicenseApplications.Save())
                {
                MessageBox.Show("Application saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbl_LocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID.ToString();
                    _Mode = enMode.Update;
                    _ApplicationModeSetup();
                    ctrlPersonCardWithFilter1.DisableFilter();
                }
               else
               {
                MessageBox.Show("Failed to save application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }

      
    }
}