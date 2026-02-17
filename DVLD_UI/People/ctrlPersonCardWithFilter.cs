using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        enum enFilterMode {  PersonID, NationalNO }
        enFilterMode _FilterMode;
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void mtxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void _FilterResult()
        {

            if (string.IsNullOrWhiteSpace(mtxt_Value.Text))
            {
                MessageBox.Show("Please enter a value to search.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxt_Value.Focus(); 
                return;
            }

            
            string filterValue = mtxt_Value.Text.Trim().Replace("'", "''");

            switch (_FilterMode)
            {
                case enFilterMode.PersonID:
                    int PersonID = Convert.ToInt32(filterValue);
                   ctrlPersonCard.LoadPersonInfo(PersonID);
                    break;

                case enFilterMode.NationalNO:


                    ctrlPersonCard.LoadPersonInfo(filterValue);
                    break;

                default:
                    MessageBox.Show("Invalid search mode selected.", "Technical Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); break;
            }

        }
        public void DisableFilter()
        {
            grb_Filter.Enabled = false;
        }
        private void cmb_AllFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterMode = (enFilterMode)cmb_AllFilter.SelectedIndex;

        }

        private void btn_Research_Click(object sender, EventArgs e)
        {
            _FilterResult();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cmb_AllFilter.SelectedIndex = 0;
        }

        private void btn_AddPerson_Click(object sender, EventArgs e)
        {
            frmAddAndEditPersonInfo frm = new frmAddAndEditPersonInfo(-1);
            frm.ShowDialog();
        }
    }
}
