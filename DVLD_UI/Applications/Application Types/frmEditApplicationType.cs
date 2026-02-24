using DVLD_Business;
using DVLD_UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Application_Types
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplictionTypeID;
        private clsApplicationType _applicationTypeDetails = null;
        public frmEditApplicationType(int ApplictionTypeID)
        {
            InitializeComponent();
            _ApplictionTypeID = ApplictionTypeID;
        }


       private void _LoadApplicationTypeDetails()
        {
             _applicationTypeDetails = clsApplicationType.Find(_ApplictionTypeID);
            if (_applicationTypeDetails != null)
            {
                lbl_ApplicationID.Text    = _applicationTypeDetails.ApplicationTypeInfo.ApplicationTypeID.ToString();
                txt_ApplicationTitle.Text = _applicationTypeDetails.ApplicationTypeInfo.ApplicationTypeTitle;
                txt_ApplicationFees.Text  = _applicationTypeDetails.ApplicationTypeInfo.ApplicationFees.ToString();
            }
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypeDetails();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

                _applicationTypeDetails.ApplicationTypeInfo.ApplicationTypeTitle = txt_ApplicationTitle.Text.Trim();

                if (double.TryParse(txt_ApplicationFees.Text.Trim(), out double fees))
                {
                    _applicationTypeDetails.ApplicationTypeInfo.ApplicationFees = fees;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for Application Fees.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            if (_applicationTypeDetails.Save())
            {
                MessageBox.Show("information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
