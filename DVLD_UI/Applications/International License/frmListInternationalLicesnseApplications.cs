using DVLD_Business;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses;
using DVLD_UI.Licenses.International_Licenses;
using DVLD_UI.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.International_License
{
    public partial class frmListInternationalLicesnseApplications : Form
    {
        enum enFilterMode { None, InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IsActive }
     
        private enFilterMode _FilterMode = enFilterMode.None;
        public frmListInternationalLicesnseApplications()
        {
            InitializeComponent();
        }

        private DataView _ListInternationalLicesnses;

        private void _RefreshUsersList()
        {
            DataTable dtInternationalLicesnses = clsInternationalLicense.GetAllInternationalLicenses();
            _ListInternationalLicesnses = new DataView(dtInternationalLicesnses);
            dgv_ListInternationalLicenses.DataSource = _ListInternationalLicesnses;
            _FormatDataGridViewColumn();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, _ListInternationalLicesnses);
        }
        private void frmListInternationalLicesnseApplications_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
            _InitializeFilterComboBox();
            _InitializeIsActiveComboBox();
            cmb_IsActive.Visible = false;
        }


        private void _FilterResult()
        {
            string filterExpression = "";

            if (string.IsNullOrWhiteSpace(mtxt_Value.Text) && mtxt_Value.Visible)
            {
                _ListInternationalLicesnses.RowFilter = "";
                return;
            }

            string filterValue = mtxt_Value.Text.Trim().Replace("'", "''");

            switch (_FilterMode)
            {
                case enFilterMode.IssuedUsingLocalLicenseID:
                case enFilterMode.ApplicationID:
                case enFilterMode.InternationalLicenseID:
                case enFilterMode.DriverID:

                    filterExpression = $"{_FilterMode} = {filterValue}";
                    break;

                case enFilterMode.IsActive:
                    if (cmb_IsActive.Text != "All")
                    {
                        bool bitValue = (cmb_IsActive.Text == "Yes") ? true : false;
                        filterExpression = $"IsActive = {bitValue}";
                    }
                    break;

                default:
                    filterExpression = "";
                    break;
            }

            _ListInternationalLicesnses.RowFilter = filterExpression;
        }

        private void _FormatDataGridViewColumn()
        {
            if (dgv_ListInternationalLicenses.Rows.Count > 0)
            {

                clsUtil.ConfigureColumn(dgv_ListInternationalLicenses.Columns["InternationalLicenseID"], "Int.License ID", 120);
                clsUtil.ConfigureColumn(dgv_ListInternationalLicenses.Columns["ApplicationID"], "Application ID", 120);
                clsUtil.ConfigureColumn(dgv_ListInternationalLicenses.Columns["DriverID"], "Driver ID", 120);
                clsUtil.ConfigureColumn(dgv_ListInternationalLicenses.Columns["IssuedUsingLocalLicenseID"], "L.License ID", 150);
                clsUtil.ConfigureColumn(dgv_ListInternationalLicenses.Columns["IssueDate"], "Issue Date", 170);
                clsUtil.ConfigureColumn(dgv_ListInternationalLicenses.Columns["ExpirationDate"], "Expiration Date", 170);
                clsUtil.ConfigureColumn(dgv_ListInternationalLicenses.Columns["IsActive"], "Is Active", 120);

            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_NewApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frmNewInternationalLicenseApplication = new frmNewInternationalLicenseApplication();
            frmNewInternationalLicenseApplication.ShowDialog();
        }


        private void _ErrorMessageWhenNoRowIsSelected()
        {
            MessageBox.Show("Please select a License first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void _ShowPersonDetails()
        {
            if (dgv_ListInternationalLicenses.Rows.Count > 0 && dgv_ListInternationalLicenses.CurrentRow != null)
            {
       
                int DriverID = Convert.ToInt32(dgv_ListInternationalLicenses.CurrentRow.Cells["DriverID"].Value);
                int PersonID = clsDrivers.Find(DriverID).PersonID;

                frmPersonDetails frmPersonDetails = new frmPersonDetails(PersonID);
                frmPersonDetails.ShowDialog();
                _RefreshUsersList();
                mtxt_Value.Clear();

            }
            else
            {
                _ErrorMessageWhenNoRowIsSelected();
            }

        }
        private void _ShowLicenseDetails()
        {
            if (dgv_ListInternationalLicenses.Rows.Count > 0 && dgv_ListInternationalLicenses.CurrentRow != null)
            {
                int InternationalLicenseID = Convert.ToInt32(dgv_ListInternationalLicenses.CurrentRow.Cells["InternationalLicenseID"].Value);
                frmShowInternationalLicenseInfo frmShowInternationalLicenseInfo = new frmShowInternationalLicenseInfo(InternationalLicenseID);

                frmShowInternationalLicenseInfo.ShowDialog();
                _RefreshUsersList();
                mtxt_Value.Clear();

            }
            else
            {
                _ErrorMessageWhenNoRowIsSelected();
            }

        }
        private void _ShowPersonLicenseHistory()
        {
            if (dgv_ListInternationalLicenses.Rows.Count > 0 && dgv_ListInternationalLicenses.CurrentRow != null)
            {
                int DriverID = Convert.ToInt32(dgv_ListInternationalLicenses.CurrentRow.Cells["DriverID"].Value);
                int PersonID = clsDrivers.Find(DriverID).PersonID;

                frmShowPersonLicenseHistory frmShowPersonLicenseHistory = new frmShowPersonLicenseHistory(PersonID);

                frmShowPersonLicenseHistory.ShowDialog();
                _RefreshUsersList();
                 mtxt_Value.Clear();

            }
            else
            {
                _ErrorMessageWhenNoRowIsSelected();
            }

        }

        private void _InitializeFilterComboBox()
        {
            cmb_AllFilter.Items.Clear();
            cmb_AllFilter.Items.AddRange(new object[] { "None", "International License ID", "Application ID", "Driver ID", "Local License ID", "Is Active" });
            cmb_AllFilter.SelectedIndex = cmb_AllFilter.FindString("None");
        }
        private void _InitializeIsActiveComboBox()
        {
            cmb_IsActive.Items.Clear();
            cmb_IsActive.Items.AddRange(new object[] { "All", "Yes", "No" });
            cmb_IsActive.SelectedIndex = cmb_AllFilter.FindString("All");
        }
       
        private void cmb_AllFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterMode = (enFilterMode)cmb_AllFilter.SelectedIndex;


            if (_FilterMode == enFilterMode.None)
            {
                _RefreshUsersList();
                mtxt_Value.Visible = false;
                cmb_IsActive.Visible = false;
            }
            else if (_FilterMode == enFilterMode.IsActive)
            {
                _RefreshUsersList();
                mtxt_Value.Visible = false;
                cmb_IsActive.Visible = true;
                cmb_IsActive.SelectedIndex = cmb_IsActive.FindString("All");
            }
            else
            {
                cmb_IsActive.Visible = false;
                mtxt_Value.Visible = true;
            }
        }

        private void mtxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterMode == enFilterMode.IssuedUsingLocalLicenseID || _FilterMode == enFilterMode.InternationalLicenseID || _FilterMode == enFilterMode.DriverID 
                || _FilterMode == enFilterMode.ApplicationID)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void cmb_IsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterResult();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, _ListInternationalLicesnses);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonDetails();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowLicenseDetails();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonLicenseHistory();
        }

        private void mtxt_Value_TextChanged(object sender, EventArgs e)
        {
            _FilterResult();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, _ListInternationalLicesnses);
        }
    }
}
