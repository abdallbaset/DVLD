using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses.Local_Licenses;
using DVLD_UI.Test;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Local_Driving_License
{
    public partial class frmMangeLocalDrivingLicesnseApplications : Form
    {
        enum enFilterMode { None, LdLAppID, NationalNo, FullName, Status }
        enFilterMode _FilterMode;
   
        private DataView _ListLocalDL;

        public frmMangeLocalDrivingLicesnseApplications()
        {
            InitializeComponent();
        }
        private void _FormatDataGridViewColumn()
        {
            if (dgv_ListLocalDrivingLicenseApplications.Rows.Count > 0)
            {
                 clsUtil.ConfigureColumn(dgv_ListLocalDrivingLicenseApplications.Columns["LocalDrivingLicenseApplicationID"], "L.D.L.AppID", 120);
                 clsUtil.ConfigureColumn(dgv_ListLocalDrivingLicenseApplications.Columns["ClassName"], "Driving Classe", 250);
                 clsUtil.ConfigureColumn(dgv_ListLocalDrivingLicenseApplications.Columns["NationalNo"], "National No", 150);
                 clsUtil.ConfigureColumn(dgv_ListLocalDrivingLicenseApplications.Columns["FullName"], "Full Name", 350);
                 clsUtil.ConfigureColumn(dgv_ListLocalDrivingLicenseApplications.Columns["ApplicationDate"], "Application Date", 170);
                 clsUtil.ConfigureColumn(dgv_ListLocalDrivingLicenseApplications.Columns["PassedTestCount"], "Passed Test", 110);
                clsUtil.ConfigureColumn(dgv_ListLocalDrivingLicenseApplications.Columns["Status"], "Status", 120); 
            }
        }

        private void _GetNumberOfRecords()
        {
            lbl_NumberOfRecords.Text = (_ListLocalDL != null) ? _ListLocalDL.Count.ToString() : "0";
        }

        private void _RefreshLocalDrivingLicenseApplicationsList()
        {
            DataTable dt = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
            _ListLocalDL = new DataView(dt);
            dgv_ListLocalDrivingLicenseApplications.DataSource = _ListLocalDL;
            _FormatDataGridViewColumn();
            _GetNumberOfRecords();
        }
        private void _InitializeFilterComboBox()
        {
            cmb_AllFilter.Items.Clear();
            cmb_AllFilter.Items.AddRange(new object[] { "None", "L.D.L.AppID", "National No.", "Full Name", "Status" });
            cmb_AllFilter.SelectedIndex = cmb_AllFilter.FindString("None");
        }

        private void frmMangeLocalDrivingLicesnseApplications_Load(object sender, EventArgs e)
        {
            _InitializeFilterComboBox();
            _RefreshLocalDrivingLicenseApplicationsList();
             mtxt_Value.Visible = false;
        }

        private void _FilterResult()
        {
            string filterExpression = "";

            if (string.IsNullOrWhiteSpace(mtxt_Value.Text) && mtxt_Value.Visible)
            {
                _ListLocalDL.RowFilter = "";
                return;
            }

            string filterValue = mtxt_Value.Text.Trim().Replace("'", "''");

            switch (_FilterMode)
            {
                case enFilterMode.LdLAppID:
                    filterExpression = $"LocalDrivingLicenseApplicationID = {filterValue}";
                    break;

                case enFilterMode.NationalNo:
                case enFilterMode.FullName:
                case enFilterMode.Status:
                    filterExpression = $"{_FilterMode} LIKE '%{filterValue}%'";
                    break;

                default:
                    filterExpression = "";
                    break;
            }

            _ListLocalDL.RowFilter = filterExpression;
        }

        private void mtxt_Value_TextChanged(object sender, EventArgs e)
        {
            _FilterResult();
            _GetNumberOfRecords();
        }

        private void cmb_AllFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterMode = (enFilterMode)cmb_AllFilter.SelectedIndex;

            if (_FilterMode == enFilterMode.None)
            {
                _RefreshLocalDrivingLicenseApplicationsList();
                mtxt_Value.Visible = false;
            }
            else
            {
                mtxt_Value.Visible = true;
                mtxt_Value.Clear();
                mtxt_Value.Focus();
            }
        }

        private void mtxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterMode == enFilterMode.LdLAppID)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
        }

        private void btn_AddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication();
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _HandleContextMenuState()
        {
            clsEnumerationsModel.enPassedTestCount passedTests = (clsEnumerationsModel.enPassedTestCount)Convert.ToInt32(dgv_ListLocalDrivingLicenseApplications.CurrentRow.Cells["PassedTestCount"].Value);

            string applicationStatus = Convert.ToString(dgv_ListLocalDrivingLicenseApplications.CurrentRow.Cells["Status"].Value);

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (passedTests == clsEnumerationsModel.enPassedTestCount.StreetTestPassed && applicationStatus != clsApplicationModel.enApplicationStatus.Completed.ToString());

            if (applicationStatus == clsApplicationModel.enApplicationStatus.Completed.ToString())
            {
                showLicenseToolStripMenuItem.Enabled = true;
                EditApplicationToolStripMenuItem.Enabled = false;
                DeleteApplicationToolStripMenuItem.Enabled = false;
                CancelApplicationToolStripMenuItem.Enabled = false;
            }
            else if (applicationStatus == clsApplicationModel.enApplicationStatus.Cancelled.ToString())
            {
                showLicenseToolStripMenuItem.Enabled = false;
                EditApplicationToolStripMenuItem.Enabled = false;
                DeleteApplicationToolStripMenuItem.Enabled = false;
                CancelApplicationToolStripMenuItem.Enabled = false;
                sechduleTestsToolStripMenuItem.Enabled = false;
                return;
            }
            else
            {
                showLicenseToolStripMenuItem.Enabled = false;
                EditApplicationToolStripMenuItem.Enabled = true;
                DeleteApplicationToolStripMenuItem.Enabled = true;
                CancelApplicationToolStripMenuItem.Enabled = true;
            }

                sechduleTestsToolStripMenuItem.Enabled = (passedTests != clsEnumerationsModel.enPassedTestCount.StreetTestPassed);

            scheduleVisionTestToolStripMenuItem.Enabled = (passedTests == clsEnumerationsModel.enPassedTestCount.None);
            scheduleWrittenTestToolStripMenuItem.Enabled = (passedTests == clsEnumerationsModel.enPassedTestCount.VisionTestPassed);
            scheduleStreetTestToolStripMenuItem.Enabled = (passedTests == clsEnumerationsModel.enPassedTestCount.WrittenTestPassed);
        }
        private void ShowApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListLocalDrivingLicenseApplications.Rows.Count > 0 && dgv_ListLocalDrivingLicenseApplications.CurrentRow != null)
            {
                int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgv_ListLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
                frmLocalDrivingLicenseApplicationInfo LocalDrivingLicenseApplicationInfo = new frmLocalDrivingLicenseApplicationInfo(LocalDrivingLicenseApplicationID);
                LocalDrivingLicenseApplicationInfo.ShowDialog();
                _RefreshLocalDrivingLicenseApplicationsList();
            }
            else
            {
                MessageBox.Show("Please select an application first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListLocalDrivingLicenseApplications.Rows.Count > 0 && dgv_ListLocalDrivingLicenseApplications.CurrentRow != null)
            {
                int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgv_ListLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
                frmAddUpdateLocalDrivingLicesnseApplication frmAddUpdateLocalDrivingLicesnseApplication = new frmAddUpdateLocalDrivingLicesnseApplication(LocalDrivingLicenseApplicationID);
                frmAddUpdateLocalDrivingLicesnseApplication.ShowDialog();
                _RefreshLocalDrivingLicenseApplicationsList();
            }
            else
            {
                MessageBox.Show("Please select an application first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListLocalDrivingLicenseApplications.Rows.Count > 0 && dgv_ListLocalDrivingLicenseApplications.CurrentRow != null)
            {
               int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgv_ListLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
               if(MessageBox.Show($"Are you sure you want to delete this application with ID: [{LocalDrivingLicenseApplicationID}] ?", "Confirm Delete",
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (clsLocalDrivingLicenseApplications.IsExist(LocalDrivingLicenseApplicationID))
                    {
                        if (clsLocalDrivingLicenseApplications.DeleteLocalDrivingLicense(LocalDrivingLicenseApplicationID))
                        {
                            MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _RefreshLocalDrivingLicenseApplicationsList();
                        }
                        else
                        {
                            MessageBox.Show("Application was not deleted because it has linked data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No Application with ID [{LocalDrivingLicenseApplicationID}] exists in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an application first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListLocalDrivingLicenseApplications.Rows.Count > 0 && dgv_ListLocalDrivingLicenseApplications.CurrentRow != null)
            {
                int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgv_ListLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);

                if (MessageBox.Show($"Are you sure you want to cancel application with ID [{LocalDrivingLicenseApplicationID}]?",
                                    "Confirm Cancellation",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (clsLocalDrivingLicenseApplications.IsExist(LocalDrivingLicenseApplicationID))
                    {
                        if (clsLocalDrivingLicenseApplications.CancelApplication(LocalDrivingLicenseApplicationID))
                        {
                            MessageBox.Show("Application has been cancelled successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _RefreshLocalDrivingLicenseApplicationsList();
                        }
                        else
                        {
                            MessageBox.Show("Could not cancel the application. It might be linked to other data or already completed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Application with ID [{LocalDrivingLicenseApplicationID}] was not found in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an application from the list first!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListLocalDrivingLicenseApplications.Rows.Count > 0 && dgv_ListLocalDrivingLicenseApplications.CurrentRow != null)
            {
                int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgv_ListLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
                frmListTestAppointments ListTestAppointments = new frmListTestAppointments(LocalDrivingLicenseApplicationID);
                ListTestAppointments.ShowDialog();
                _RefreshLocalDrivingLicenseApplicationsList();
            }
            else
            {
                MessageBox.Show("Please select an application first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListLocalDrivingLicenseApplications.Rows.Count > 0 && dgv_ListLocalDrivingLicenseApplications.CurrentRow != null)
            {
                int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgv_ListLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
                frmListTestAppointments ListTestAppointments = new frmListTestAppointments(LocalDrivingLicenseApplicationID);
                ListTestAppointments.ShowDialog();
                _RefreshLocalDrivingLicenseApplicationsList();
            }
            else
            {
                MessageBox.Show("Please select an application first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListLocalDrivingLicenseApplications.Rows.Count > 0 && dgv_ListLocalDrivingLicenseApplications.CurrentRow != null)
            {
                int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgv_ListLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
                frmListTestAppointments ListTestAppointments = new frmListTestAppointments(LocalDrivingLicenseApplicationID);
                ListTestAppointments.ShowDialog();
                _RefreshLocalDrivingLicenseApplicationsList();
            }
            else
            {
                MessageBox.Show("Please select an application first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To  Issue Driving License for an application.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListLocalDrivingLicenseApplications.Rows.Count > 0 && dgv_ListLocalDrivingLicenseApplications.CurrentRow != null)
            {
                int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgv_ListLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
                int LicenseID = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID)?.GetActiveLicensesID()
                    ?? (int)clsGlobal.enIdentityStatus.NonExistent;

                if (LicenseID == (int)clsGlobal.enIdentityStatus.NonExistent)
                {
                    MessageBox.Show($"No License was found for LicenseID with ID [{LicenseID}] in the system.",
                                         "Not Found",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Exclamation);
                    return;
                }

                frmShowLicenseInfo ShowLicenseInfo = new frmShowLicenseInfo(LicenseID);
                ShowLicenseInfo.ShowDialog();
                _RefreshLocalDrivingLicenseApplicationsList();
            }
            else
            {
                MessageBox.Show("Please select an application first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To  Show Person License History for an application.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmsApplications_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _HandleContextMenuState();
        }

        private void dgv_ListLocalDrivingLicenseApplications_DoubleClick(object sender, EventArgs e)
        {
            ShowApplicationDetailsToolStripMenuItem_Click(sender, e);
        }
    }
}