using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public event Action<clsLicenses> OnLicenseSelected;
        protected virtual void LicenseSelected(clsLicenses LicenseInfo)
        {
            Action<clsLicenses> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseInfo);
            }
        }
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {  
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                grb_Filter.Enabled = _FilterEnabled;
              
            }
        }
        public clsLicenses SelectedLicenseInfo
        {
          get
            {
                return ctrlDriverLicenseInfo1.Licenses;
            }
        }

        private void mtxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter;

            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Research.PerformClick();
            }
        }
        public void FilterFocus()
        {
            mtxt_Value.Focus();
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            mtxt_Value.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.Load_DriverLicenseInfoInfo(LicenseID);
            LicenseSelected(ctrlDriverLicenseInfo1.Licenses);
        }

        private void btn_Research_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32( mtxt_Value.Text.Trim());
            ctrlDriverLicenseInfo1.Load_DriverLicenseInfoInfo(LicenseID);
            LicenseSelected(ctrlDriverLicenseInfo1.Licenses);
        }
    }
}
