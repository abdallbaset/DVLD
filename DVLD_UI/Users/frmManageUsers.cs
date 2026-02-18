using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Users
{
    public partial class frmManageUsers : Form
    {
        enum enFilterMode { None, UserID, PersonID, UserName, FullName, IsActive}

        private enFilterMode _FilterMode;
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private DataView _ListUsers;

        private void _GetNumberOfRecords()
        {
            lbl_NumberOfRecords.Text = _ListUsers.Count.ToString();
        }
        private void _RefreshUsersList()
        {
            DataTable dtUsers = clsUser.ListUsers();
            _ListUsers = new DataView(dtUsers);
            dgv_ListUsers.DataSource = _ListUsers;
            _GetNumberOfRecords();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
            cmb_AllFilter.SelectedIndex = cmb_AllFilter.FindString("None");
            cmb_IsActive.Visible = false;
        }


        private void _FilterResult()
        {
            string filterExpression = "";

            if (string.IsNullOrWhiteSpace(mtxt_Value.Text) && mtxt_Value.Visible)
            {
                _ListUsers.RowFilter = "";
                return;
            }

            string filterValue = mtxt_Value.Text.Trim().Replace("'", "''");

            switch (_FilterMode)
            {
                case enFilterMode.PersonID:
                case enFilterMode.UserID:

                        filterExpression = $"{_FilterMode} = {filterValue}";
                    break;

                case enFilterMode.UserName:
                case enFilterMode.FullName:
                    filterExpression = $"{_FilterMode} LIKE '%{filterValue}%'";
                    break;

                case enFilterMode.IsActive:
                    if (cmb_IsActive.Text != "All")
                    {
                        bool bitValue = (cmb_IsActive.Text == "Yes") ? true :false;
                        filterExpression = $"IsActive = {bitValue}";
                    }
                    break;

                default:
                    filterExpression = "";
                    break;
            }

            _ListUsers.RowFilter = filterExpression;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mtxt_Value_TextChanged(object sender, EventArgs e)
        {
            _FilterResult();
            _GetNumberOfRecords();
        }

    

        private void cmb_AllFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _FilterMode = (enFilterMode)cmb_AllFilter.SelectedIndex;


            if (_FilterMode == enFilterMode.None)
            {
                _RefreshUsersList();
                mtxt_Value.Visible = false;
                cmb_IsActive.Visible = false;
            }
            else if(_FilterMode  == enFilterMode.IsActive)
            {
                _RefreshUsersList();
                mtxt_Value.Visible = false;
                cmb_IsActive.Visible = true;
                cmb_IsActive.SelectedIndex = cmb_IsActive.FindString("All");
            }
            else
            {
                cmb_IsActive.Visible = false;
                mtxt_Value.Visible = true;
            }
        }

        private void mtxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterMode == enFilterMode.PersonID || _FilterMode == enFilterMode.UserID)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
        }

        private void cmb_IsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            _FilterResult();
            _GetNumberOfRecords();

        }

        private void btn_AddNewUser_Click(object sender, EventArgs e)
        {
            frmAddNewAndEditUser frm = new frmAddNewAndEditUser();  
            frm.ShowDialog();
            _RefreshUsersList();

        }

        private void _ShowDetailsPerson()
        {
            if (dgv_ListUsers.Rows.Count > 0 && dgv_ListUsers.CurrentRow != null)
            {
                int UserID = Convert.ToInt32(dgv_ListUsers.CurrentRow.Cells["UserID"].Value);
                frmUserInfo frmUserDetails = new frmUserInfo(UserID);

                frmUserDetails.ShowDialog();
                _RefreshUsersList();
                mtxt_Value.Clear();

            }
            else
            {
                MessageBox.Show("Please select a person first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowDetailsPerson();
        }

        private void dgv_ListUsers_DoubleClick(object sender, EventArgs e)
        {
            _ShowDetailsPerson();
        }
    }
}
