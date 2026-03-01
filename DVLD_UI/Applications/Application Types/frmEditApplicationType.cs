using DVLD_Business;
using DVLD_Model;
using DVLD_UI.Controls;
using DVLD_UI.GlobalClasses;
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
        private clsApplicationTypesModel.enApplicationTypes _ApplictionTypeID = clsApplicationTypesModel.enApplicationTypes.NotSpecified;
        private clsApplicationType _applicationType = null;
        public frmEditApplicationType(clsApplicationTypesModel.enApplicationTypes ApplictionTypeID)
        {
            InitializeComponent();
            _ApplictionTypeID = ApplictionTypeID;
        }


       private void _LoadApplicationTypeDetails()
        {
             _applicationType = clsApplicationType.Find(_ApplictionTypeID);
            if (_applicationType != null)
            {
                lbl_ApplicationID.Text    = ((int)_applicationType.ApplicationTypeInfo.ApplicationTypeID).ToString();
                txt_ApplicationTitle.Text = _applicationType.ApplicationTypeInfo.ApplicationTypeTitle;
                txt_ApplicationFees.Text  = _applicationType.ApplicationTypeInfo.ApplicationFees.ToString();
            }
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypeDetails();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                   "Validation Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);

                if (string.IsNullOrWhiteSpace(txt_ApplicationTitle.Text))
                { 
                    txt_ApplicationTitle.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txt_ApplicationFees.Text))
                {
                    txt_ApplicationFees.Focus();
                }
                else
                    txt_ApplicationTitle.Focus();


                return;
            }

            _applicationType.ApplicationTypeInfo.ApplicationTypeTitle = txt_ApplicationTitle.Text.Trim();
            _applicationType.ApplicationTypeInfo.ApplicationFees =Convert.ToDouble( txt_ApplicationFees.Text);

            if (_applicationType.Save())
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

        private void txt_ApplicationTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ApplicationTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_ApplicationTitle, $"{txt_ApplicationTitle.Tag} is required");
            }
            else
            {
                errorProvider1.SetError(txt_ApplicationTitle, "");
            }
        }

        private void txt_ApplicationFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ApplicationFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_ApplicationFees, $"{txt_ApplicationFees.Tag} is required");
                return;
            }

            if (!clsValidatoin.IsNumber(txt_ApplicationFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_ApplicationFees, $"{txt_ApplicationFees.Tag} must be a valid number");
            }
            else
            {
                errorProvider1.SetError(txt_ApplicationFees, "");
            }
        }

        private void txt_ApplicationFees_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

        }
    }
}
