using DVLD_Business;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses.International_Licenses;
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

namespace DVLD_UI.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private DataTable _dtLicensList;
        private DataTable _dtInternationalLicenses;
        public int DriverID { get; set; }
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void _Format_dgvLocalLicensesHistoryColumn()
        {
            if (dgv_LocalLicensesHistory.Rows.Count > 0)
            {
                clsUtil.ConfigureColumn(dgv_LocalLicensesHistory.Columns["LicenseID"], "Lic.ID", 100);
                clsUtil.ConfigureColumn(dgv_LocalLicensesHistory.Columns["ApplicationID"], "App.ID", 100);
                clsUtil.ConfigureColumn(dgv_LocalLicensesHistory.Columns["className"], "class Name", 350);
                clsUtil.ConfigureColumn(dgv_LocalLicensesHistory.Columns["IssueDate"], "Issue Date", 190);
                clsUtil.ConfigureColumn(dgv_LocalLicensesHistory.Columns["ExpirationDate"], "Expiration Date", 190);
                clsUtil.ConfigureColumn(dgv_LocalLicensesHistory.Columns["IsActive"], "Is Active", 105);
           
            }
        }
        private void _Format_dgvInternationalLicensesListHistoryColumn()
        {
            if (dgv_InternationalLicensesHistory.Rows.Count > 0)
            {
                clsUtil.ConfigureColumn(dgv_InternationalLicensesHistory.Columns["InternationalLicenseID"], "Int.License ID", 180);
                clsUtil.ConfigureColumn(dgv_InternationalLicensesHistory.Columns["ApplicationID"], "App.ID", 100);
                clsUtil.ConfigureColumn(dgv_InternationalLicensesHistory.Columns["IssuedUsingLocalLicenseID"], "L.License ID", 140);
                clsUtil.ConfigureColumn(dgv_InternationalLicensesHistory.Columns["IssueDate"], "Issue Date", 205);
                clsUtil.ConfigureColumn(dgv_InternationalLicensesHistory.Columns["ExpirationDate"], "Expiration Date", 205);
                clsUtil.ConfigureColumn(dgv_InternationalLicensesHistory.Columns["IsActive"], "Is Active", 100);
           
            }
        }
     
        public void LoadLicensesInfo()
        {
            if (clsDrivers.IsExistByDriverID(DriverID))
            {
                _LoadLocalLicenseList();
                _LoadInternationalLicensesList();
            }
            else
            {
                MessageBox.Show($"Driver With ID [{DriverID}] not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadLicensesInfoByPersonID(int personID)
        {
            clsDrivers driver = clsDrivers.FindByPersonID(personID);
            if (driver != null)
            {
                DriverID = driver.DriverID;
                LoadLicensesInfo();
            }
            else
            {
                MessageBox.Show("No Driver associated with this Person ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _LoadLocalLicenseList()
        {
                _dtLicensList = clsLicenses.GetAllLicensesByDriverID(DriverID);
                if (_dtLicensList.Rows.Count > 0)
                {
                    dgv_LocalLicensesHistory.DataSource = _dtLicensList;
                    _Format_dgvLocalLicensesHistoryColumn();
                    clsUtil.UpdateRecordCount(lbl_LocalLicensesRecords, new DataView(_dtLicensList));
                }
                else
                {
                    lbl_LocalLicensesRecords.Text = "No Records Found";
                }
        }
        private void _LoadInternationalLicensesList()
        {
                _dtInternationalLicenses = clsInternationalLicense.GetAllInternationalLicensesByDriverID(DriverID);
                if (_dtInternationalLicenses.Rows.Count > 0)
                {
                    dgv_InternationalLicensesHistory.DataSource = _dtInternationalLicenses;
                    _Format_dgvInternationalLicensesListHistoryColumn();
                    clsUtil.UpdateRecordCount(lbl_InternationalLicensesRecords, new DataView(_dtInternationalLicenses));
                }
                else
                {
                    lbl_InternationalLicensesRecords.Text = "No Records Found";
                }    

        }

        private void showInterenationalLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frmShowInternationalLicenseInfo = new frmShowInternationalLicenseInfo((int)dgv_InternationalLicensesHistory.CurrentRow.Cells["InternationalLicenseID"].Value);
            frmShowInternationalLicenseInfo.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frmShowLicenseInfo = new frmShowLicenseInfo((int)dgv_LocalLicensesHistory.CurrentRow.Cells["LicenseID"].Value);
            frmShowLicenseInfo.ShowDialog();
        }
    }
}
