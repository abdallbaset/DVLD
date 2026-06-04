using DVLD_Business;
using DVLD_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID;
        private clsDrivers _driverInfo;
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        private void _LoadPersonalInfo()
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
            ctrlPersonCardWithFilter1.DisableFilter();
        }
        private void _LoadDriverLicensesInfo()
        {
            if(clsPeople.IsExist(_PersonID))
            {
                
                    _LoadPersonalInfo();
                    _driverInfo = clsDrivers.FindByPersonID(_PersonID);
                if (_driverInfo != null)
                {
                    ctrlDriverLicenses1.DriverID = _driverInfo.DriverID;
                    ctrlDriverLicenses1.LoadLicensesInfo();
                }
                else
                {   
                    MessageBox.Show($"No Driver record found for Person with ID [{_PersonID}].", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
            else
            {
                MessageBox.Show($"Person with ID [{_PersonID}] not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            _LoadDriverLicensesInfo();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
