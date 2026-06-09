using DVLD_Business;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses;
using DVLD_UI.Licenses.Detain_License;
using DVLD_UI.Licenses.Local_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Rlease_Detained_License
{
    public partial class frmListDetainedLicenses : Form
    {
        enum enFilterMode { None, DetainID, IsReleased, NationalNo, FullName, ReleaseApplicationID }

        private enFilterMode _FilterMode = enFilterMode.None;

        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private DataView _ListDetainedLicenses;

        private void _RefreshDetainedLicensesList()
        {
            DataTable dtDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();
            _ListDetainedLicenses = new DataView(dtDetainedLicenses);
            dgv_ListDetainedLicenses.DataSource = _ListDetainedLicenses;
            _FormatDataGridViewColumn();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, _ListDetainedLicenses);
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDetainedLicensesList();
            _InitializeFilterComboBox();
            _InitializeIsReleasedComboBox();
            cmb_IsReleased.Visible = false;
        }
        private void _FilterResult()
        {
            string filterExpression = "";

            if (string.IsNullOrWhiteSpace(mtxt_Value.Text) && mtxt_Value.Visible)
            {
                _ListDetainedLicenses.RowFilter = "";
                return;
            }

            string filterValue = mtxt_Value.Text.Trim().Replace("'", "''");

            switch (_FilterMode)
            {
                case enFilterMode.DetainID:
                case enFilterMode.ReleaseApplicationID:
                    filterExpression = $"{_FilterMode} = {filterValue}";
                    break;

                case enFilterMode.NationalNo:
                    filterExpression = $"{_FilterMode} LIKE '{filterValue}%'";
                    break;

                case enFilterMode.FullName:
                    filterExpression = $"{_FilterMode} LIKE '{filterValue}%'";
                    break;

                case enFilterMode.IsReleased:
                    if (cmb_IsReleased.Text != "All")
                    {
                        bool bitValue = (cmb_IsReleased.Text == "Yes") ? true : false;
                        filterExpression = $"{_FilterMode} = {bitValue}";
                    }
                    break;

                default:
                    filterExpression = "";
                    break;
            }

            _ListDetainedLicenses.RowFilter = filterExpression;
        }

        private void _FormatDataGridViewColumn()
        {
            if (dgv_ListDetainedLicenses.Rows.Count > 0)
            {
                clsUtil.ConfigureColumn(dgv_ListDetainedLicenses.Columns["DetainID"], "D.ID", 100);
                clsUtil.ConfigureColumn(dgv_ListDetainedLicenses.Columns["LicenseID"], "L.ID", 100);
                clsUtil.ConfigureColumn(dgv_ListDetainedLicenses.Columns["DetainDate"], "D.Date", 160);
                clsUtil.ConfigureColumn(dgv_ListDetainedLicenses.Columns["IsReleased"], "Is Released", 110);
                clsUtil.ConfigureColumn(dgv_ListDetainedLicenses.Columns["FineFees"], "Fine Fees", 110);
                clsUtil.ConfigureColumn(dgv_ListDetainedLicenses.Columns["ReleaseDate"], "Release Date", 160);
                clsUtil.ConfigureColumn(dgv_ListDetainedLicenses.Columns["NationalNo"], "N.No", 120);
                clsUtil.ConfigureColumn(dgv_ListDetainedLicenses.Columns["FullName"], "Full Name", 220);
                clsUtil.ConfigureColumn(dgv_ListDetainedLicenses.Columns["ReleaseApplicationID"], "Release App.ID", 130);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_DetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void btn_ReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void _ErrorMessageWhenNoRowIsSelected()
        {
            MessageBox.Show("Please select a record first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _ShowPersonDetails()
        {
            if (dgv_ListDetainedLicenses.Rows.Count > 0 && dgv_ListDetainedLicenses.CurrentRow != null)
            {
                int licenseID = Convert.ToInt32(dgv_ListDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
                int personID = clsLicenses.Find(licenseID).PersonID;

                frmPersonDetails frmPersonDetails = new frmPersonDetails(personID);
                frmPersonDetails.ShowDialog();
                _RefreshDetainedLicensesList();
                mtxt_Value.Clear();
            }
            else
            {
                _ErrorMessageWhenNoRowIsSelected();
            }
        }

        private void _ShowLicenseDetails()
        {
            if (dgv_ListDetainedLicenses.Rows.Count > 0 && dgv_ListDetainedLicenses.CurrentRow != null)
            {
                int licenseID = Convert.ToInt32(dgv_ListDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);

                frmShowLicenseInfo frm = new frmShowLicenseInfo(licenseID);
                frm.ShowDialog();
                _RefreshDetainedLicensesList();
                mtxt_Value.Clear();
            }
            else
            {
                _ErrorMessageWhenNoRowIsSelected();
            }
        }

        private void _ShowPersonLicenseHistory()
        {
            if (dgv_ListDetainedLicenses.Rows.Count > 0 && dgv_ListDetainedLicenses.CurrentRow != null)
            {
                int licenseID = Convert.ToInt32(dgv_ListDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
                int personID = clsLicenses.Find(licenseID).PersonID;

                frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(personID);
                frm.ShowDialog();
                _RefreshDetainedLicensesList();
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
            cmb_AllFilter.Items.AddRange(new object[] { "None", "Detain ID", "Is Released", "National No.", "Full Name", "Release Application ID" });
            cmb_AllFilter.SelectedIndex = cmb_AllFilter.FindString("None");
        }

        private void _InitializeIsReleasedComboBox()
        {
            cmb_IsReleased.Items.Clear();
            cmb_IsReleased.Items.AddRange(new object[] { "All", "Yes", "No" });
            cmb_IsReleased.SelectedIndex = cmb_IsReleased.FindString("All");
        }

        private void cmb_AllFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterMode = (enFilterMode)cmb_AllFilter.SelectedIndex;

            if (_FilterMode == enFilterMode.None)
            {
                _RefreshDetainedLicensesList();
                mtxt_Value.Visible = false;
                cmb_IsReleased.Visible = false;
            }
            else if (_FilterMode == enFilterMode.IsReleased)
            {
                _RefreshDetainedLicensesList();
                mtxt_Value.Visible = false;
                cmb_IsReleased.Visible = true;
                cmb_IsReleased.SelectedIndex = cmb_IsReleased.FindString("All");
            }
            else
            {
                cmb_IsReleased.Visible = false;
                mtxt_Value.Visible = true;
                mtxt_Value.Clear();
                mtxt_Value.Focus();
            }
        }

        private void mtxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterMode == enFilterMode.DetainID || _FilterMode == enFilterMode.ReleaseApplicationID || _FilterMode == enFilterMode.NationalNo)
            {
               e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
            }
        }

        private void cmb_IsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterResult();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, _ListDetainedLicenses);
        }

        private void mtxt_Value_TextChanged(object sender, EventArgs e)
        {
            _FilterResult();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, _ListDetainedLicenses);
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
        private void _ShowReleaseDetainedLicenseApplication()
        {
            if (dgv_ListDetainedLicenses.CurrentRow != null)
            {
                bool isReleased = Convert.ToBoolean(dgv_ListDetainedLicenses.CurrentRow.Cells["IsReleased"].Value);
                if (isReleased)
                {
                    MessageBox.Show("This license is already released!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int licenseID = Convert.ToInt32(dgv_ListDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
                frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication(licenseID);
                frm.ShowDialog();
                _RefreshDetainedLicensesList();
            }
        }
        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowReleaseDetainedLicenseApplication();
        }
        private void _UpdateContextMenuState()
        {
            if (dgv_ListDetainedLicenses.CurrentRow != null)
            {
                bool isReleased = Convert.ToBoolean(dgv_ListDetainedLicenses.CurrentRow.Cells["IsReleased"].Value);
                releaseDetainedLicenseToolStripMenuItem.Enabled = !isReleased;
            }
        }
        private void cms_Applications_Opening(object sender, CancelEventArgs e)
        {
            _UpdateContextMenuState();
        }
    }
}
