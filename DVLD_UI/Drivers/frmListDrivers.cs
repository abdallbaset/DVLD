using DVLD_Business;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Model.clsEnumerationsModel;

namespace DVLD_UI.Drivers
{
    public partial class frmListDrivers : Form
    {
        enum enFilterMode { None, DriverID, PersonID, NationalNo, FullName }
        enFilterMode _FilterMode;
        private DataView _ListDrivers;
        public frmListDrivers()
        {
            InitializeComponent();
        }
        private void _InitializeFilterComboBox()
        {
            cmb_AllFilter.Items.Clear();
            cmb_AllFilter.Items.AddRange(new object[] { "None", "Driver ID", "Person ID", "National No", "Full Name" });
            cmb_AllFilter.SelectedIndex = cmb_AllFilter.FindString("None");
        }

        private void _RefreshListDrivers()
        {
            _ListDrivers = new DataView( clsDrivers.GetAllDrivers());
            if(_ListDrivers.Count == 0)
            {
                MessageBox.Show("No drivers found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_ListDrivers.DataSource = null;
                lbl_NumberOfRecords.Text = "0 Records";
                return;
            }
            dgv_ListDrivers.DataSource = _ListDrivers;
            _FormatDataGridViewColumn();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, _ListDrivers);
        }

        private void _FormatDataGridViewColumn()
        {
            if (dgv_ListDrivers.Rows.Count > 0)
            {
                clsUtil.ConfigureColumn(dgv_ListDrivers.Columns["DriverID"], "Driver ID", 100);
                clsUtil.ConfigureColumn(dgv_ListDrivers.Columns["PersonID"], "Person ID", 100);
                clsUtil.ConfigureColumn(dgv_ListDrivers.Columns["NationalNo"], "National No", 120);
                clsUtil.ConfigureColumn(dgv_ListDrivers.Columns["FullName"], "Full Name", 200);
                clsUtil.ConfigureColumn(dgv_ListDrivers.Columns["CreatedDate"], "Date", 100);
                clsUtil.ConfigureColumn(dgv_ListDrivers.Columns["NumberOfActiveLicenses"], "Active Licenses", 200);
            }
        }
        private void _FilterResult()
        {
            string filterExpression = "";

            if (string.IsNullOrWhiteSpace(mtxt_Value.Text) && mtxt_Value.Visible)
            {
                _ListDrivers.RowFilter = "";
                return;
            }

            string filterValue = mtxt_Value.Text.Trim().Replace("'", "''");

            switch (_FilterMode)
            {
                case enFilterMode.DriverID:
                case enFilterMode.PersonID:
                    filterExpression = $"{_FilterMode} = {filterValue}";
                    break;

                case enFilterMode.NationalNo:
                case enFilterMode.FullName:
                    filterExpression = $"{_FilterMode} LIKE '%{filterValue}%'";
                    break;

                default:
                    filterExpression = "";
                    break;
            }

            _ListDrivers.RowFilter = filterExpression;
        }
        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _InitializeFilterComboBox();
            _RefreshListDrivers();
        }

        private void cmb_AllFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterMode = (enFilterMode)cmb_AllFilter.SelectedIndex;

            if (_FilterMode == enFilterMode.None)
            {
                _RefreshListDrivers();
                mtxt_Value.Visible = false;
            }
            else
            {
                mtxt_Value.Visible = true;
                mtxt_Value.Clear();
                mtxt_Value.Focus();

                if(_FilterMode == enFilterMode.FullName)
                    mtxt_Value.Width = 350;
                else
                    mtxt_Value.Width = 260;
            }
        }

        private void mtxt_Value_TextChanged(object sender, EventArgs e)
        {
            _FilterResult();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, _ListDrivers);
        }

        private void mtxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterMode == enFilterMode.DriverID || _FilterMode == enFilterMode.PersonID || _FilterMode == enFilterMode.NationalNo)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void _ErrorMessageWhenNoRowIsSelected()
        {
            MessageBox.Show("Please select a License first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void _ShowPersonDetails()
        {
            if (dgv_ListDrivers.Rows.Count > 0 && dgv_ListDrivers.CurrentRow != null)
            {

                int PersonID = Convert.ToInt32(dgv_ListDrivers.CurrentRow.Cells["PersonID"].Value);

                frmPersonDetails frmPersonDetails = new frmPersonDetails(PersonID);
                frmPersonDetails.ShowDialog();
                _RefreshListDrivers();
                mtxt_Value.Clear();

            }
            else
            {
                _ErrorMessageWhenNoRowIsSelected();
            }

        }
        private void _ShowPersonLicenseHistory()
        {
            if (dgv_ListDrivers.Rows.Count > 0 && dgv_ListDrivers.CurrentRow != null)
            {
                int PersonID = Convert.ToInt32(dgv_ListDrivers.CurrentRow.Cells["PersonID"].Value);
         
                frmShowPersonLicenseHistory frmShowPersonLicenseHistory = new frmShowPersonLicenseHistory(PersonID);
                frmShowPersonLicenseHistory.ShowDialog();
                _RefreshListDrivers();
                mtxt_Value.Clear();

            }
            else
            {
                _ErrorMessageWhenNoRowIsSelected();
            }

        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonDetails();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonLicenseHistory();
        }
    }
}
