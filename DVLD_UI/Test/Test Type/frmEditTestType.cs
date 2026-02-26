using DVLD_Business;
using DVLD_UI.GlobalClasses;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD_UI.Test.Test_Type
{
    public partial class frmEditTestType : Form
    {
        private int _TestTypeID;
        private clsTestTypes _testTypeDetails = null;

        public frmEditTestType(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void _LoadTestTypeDetails()
        {
            _testTypeDetails = clsTestTypes.Find(_TestTypeID);
            if (_testTypeDetails != null)
            {
                lbl_TestTypeID.Text = _testTypeDetails.TestTypeInfo.TestTypeID.ToString();
                txt_Title.Text = _testTypeDetails.TestTypeInfo.TestTypeTitle;
                txt_Description.Text = _testTypeDetails.TestTypeInfo.TestTypeDescription;
                txt_Fees.Text = _testTypeDetails.TestTypeInfo.TestTypeFees.ToString();
            }
            else
            {
                MessageBox.Show("No Test Type with ID = " + _TestTypeID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _LoadTestTypeDetails();
        }

        private void _HandleFocusOnValidation()
        {
            if (string.IsNullOrWhiteSpace(txt_Title.Text))
                txt_Title.Focus();
            else if (string.IsNullOrWhiteSpace(txt_Description.Text))
                txt_Description.Focus();
            else if (string.IsNullOrWhiteSpace(txt_Fees.Text))
                txt_Fees.Focus();
            else
                txt_Title.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid. Put the mouse over the red icon(s) to see the error.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                _HandleFocusOnValidation();

                return;
            }

            _testTypeDetails.TestTypeInfo.TestTypeTitle = txt_Title.Text.Trim();
            _testTypeDetails.TestTypeInfo.TestTypeDescription = txt_Description.Text.Trim();
            _testTypeDetails.TestTypeInfo.TestTypeFees = Convert.ToDouble(txt_Fees.Text.Trim());

            if (_testTypeDetails.Save())
            {
                MessageBox.Show("Information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txt_Title_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Title.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_Title, $"{txt_Title.Tag} is required");
            }
            else
            {
                errorProvider1.SetError(txt_Title, "");
            }
        }

        private void txt_Fees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Fees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_Fees, $"{txt_Fees.Tag} is required");
                return;
            }

            if (!clsValidatoin.IsNumber(txt_Fees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_Fees, $"{txt_Fees.Tag} must be a valid number");
            }
            else
            {
                errorProvider1.SetError(txt_Fees, "");
            }
        }

        private void txt_Fees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txt_Description_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Description.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_Description, $"{txt_Description.Tag} is required");
            }
            else
            {
                errorProvider1.SetError(txt_Description, "");
            }
        }
    }
}
