using DVLD_Business;
using DVLD_Model;
using DVLD_UI.GlobalClasses;
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

namespace DVLD_UI.Licenses.Detain_License
{
    public partial class frmDetainLicenseApplication : Form
    {
        private clsLicenses _license = null;
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }
        public void LoadDefaultData()
        {
            lbl_DetainID.Text = "???";
            lbl_LicenseID.Text = "???";
            lbl_DetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lbl_CreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }
        private void _EnableShowLicenseHistoryLink()
        {
            llbl_ShowLicenseHistory.Enabled = true;
        }
        private void _DisableShowLicenseHistoryLink()
        {
            llbl_ShowLicenseHistory.Enabled = false;
        }

        private void _EnableShowLicenseInfoLink()
        {
            llbl_ShowLicenseInfo.Enabled = true;
        }
        private void _DisableShowLicenseInfoLink()
        {
            llbl_ShowLicenseInfo.Enabled = false;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
             LoadDefaultData();
            _DisableShowLicenseHistoryLink();
            _DisableShowLicenseInfoLink();
            btn_Detain.Enabled = false;
        }

        private void btn_Detain_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


            if(MessageBox.Show("Are you sure you want to detain this license?", "Confirm Detain", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            double fineFees = Convert.ToDouble(txt_FineFees.Text.Trim());
            int DetainID = _license.Detain(fineFees, clsGlobal.CurrentUser.UserID);

            if (DetainID != (int)clsEnumerationsModel.enIdentityStatus.NonExistent)
            {
                MessageBox.Show($"License has been detained successfully With ID : {DetainID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Detain.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                _EnableShowLicenseInfoLink();
                txt_FineFees.Enabled = false;
                lbl_DetainID.Text = DetainID.ToString();
            }
            else
            {
                MessageBox.Show("Failed to detain the license, please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(clsLicenses license)
        {
            _license = license;
            if (_license == null)
            {
                _DisableShowLicenseHistoryLink();
                _DisableShowLicenseInfoLink();
                lbl_LicenseID.Text = "???";
                btn_Detain.Enabled = false;
                return;
            }

            lbl_LicenseID.Text = _license.LicenseID.ToString();

            _EnableShowLicenseHistoryLink();
            _DisableShowLicenseInfoLink();

            if (_license.IsDitained)
            {
                btn_Detain.Enabled = false;
                MessageBox.Show("This License is already detained!,Choose another one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txt_FineFees.Focus();
            btn_Detain.Enabled = true;
        }

        private void txt_FineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txt_FineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_FineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_FineFees, $"{txt_FineFees.Tag} is required");
            }
            else
            {
                errorProvider1.SetError(txt_FineFees, "");
            }
        }

        private void llbl_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frmShowPersonLicenseHistory = new frmShowPersonLicenseHistory(_license.PersonID);
            frmShowPersonLicenseHistory.ShowDialog();
        }

        private void llbl_ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frmShowLicenseInfo = new frmShowLicenseInfo(_license.LicenseID);
            frmShowLicenseInfo.ShowDialog();
        }
    }
}
