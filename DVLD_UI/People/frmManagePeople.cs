using DVLD_Business;
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

namespace DVLD_UI
{
    public partial class frmManagePeople : Form
    {

        enum enFilterMode { None , PersonID , NationalNO, FirstName, SecondName , ThirdName , LastName , Nationality , Gendor , Phone , Email }
        enFilterMode _FilterMode;
        public frmManagePeople()
        {
            InitializeComponent();
        }
        private DataView _ListPeople; 
        
        private void _GetNumberOfRecords()
        {
            lbl_NumberOfRecords.Text = _ListPeople.Count.ToString();
        }
        private void _RefreshPeopleList()
        {
            DataTable dtPeople = clsPeople.ListPeople();
            _ListPeople = new DataView(dtPeople);
            dgv_ListPeople.DataSource = _ListPeople;
           _GetNumberOfRecords();
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            cmb_AllFilter.SelectedIndex = cmb_AllFilter.FindString("None");
        }


        private void _FilterResult()
        {
            if (string.IsNullOrWhiteSpace(mtxt_Value.Text))
            {
                _ListPeople.RowFilter = "";
                return;
            }

            string FilterValue = mtxt_Value.Text.Trim();

            switch (_FilterMode)
            {
                case enFilterMode.PersonID:
                
                        _ListPeople.RowFilter = $"PersonID = {FilterValue}";
                  
                    break;

                case enFilterMode.NationalNO:
                    _ListPeople.RowFilter = $"NationalNO  LIKE '%{FilterValue}%'";
                    break;

                case enFilterMode.FirstName:
                    _ListPeople.RowFilter = $"FirstName LIKE '%{FilterValue}%'";
                    break;

                case enFilterMode.SecondName:
                    _ListPeople.RowFilter = $"SecondName LIKE '%{FilterValue}%'";
                    break;

                case enFilterMode.ThirdName:
                    _ListPeople.RowFilter = $"ThirdName LIKE '%{FilterValue}%'";
                    break;

                case enFilterMode.LastName:
                    _ListPeople.RowFilter = $"LastName LIKE '%{FilterValue}%'";
                    break;

                case enFilterMode.Nationality:
                    _ListPeople.RowFilter = $"Nationality LIKE '%{FilterValue}%'";
                    break;

                case enFilterMode.Gendor:
                    _ListPeople.RowFilter = $"Gendor LIKE '%{FilterValue}%'";
                    break;

                case enFilterMode.Phone:
                    _ListPeople.RowFilter = $"Phone LIKE '%{FilterValue}%'";
                    break;

                case enFilterMode.Email:
                    _ListPeople.RowFilter = $"Email LIKE '%{FilterValue}%'";
                    break;

                default:
                    _ListPeople.RowFilter = "";
                    break;
            }
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

        private void cmb_AllFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterMode = (enFilterMode)cmb_AllFilter.SelectedIndex;
          

            if (_FilterMode == enFilterMode.None)
            {
                _RefreshPeopleList();
                mtxt_Value.Visible = false;
            }
          else
            {
                mtxt_Value.Visible = true;
            }
        }

       private void _ShowFormAddNewPerson()
        {
            frmAddAndEditPersonInfo frm = new frmAddAndEditPersonInfo(-1);
            frm.ShowDialog();
            _RefreshPeopleList();
        }
       private void _ShowFormEditPerson()
        {
            if (dgv_ListPeople.Rows.Count > 0 && dgv_ListPeople.CurrentRow != null)
            {
                int PersonID = Convert.ToInt32(dgv_ListPeople.CurrentRow.Cells["PersonID"].Value);

                frmAddAndEditPersonInfo frmPersonDetails = new frmAddAndEditPersonInfo(PersonID);
                frmPersonDetails.ShowDialog();
                _RefreshPeopleList();
            }
            else
            {
                MessageBox.Show("Please select a person first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btn_AddPerson_Click(object sender, EventArgs e)
        {
            _ShowFormAddNewPerson();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListPeople.Rows.Count > 0 && dgv_ListPeople.CurrentRow != null)
            {
                int PersonID = Convert.ToInt32(dgv_ListPeople.CurrentRow.Cells["PersonID"].Value);

                frmPersonDetails frmPersonDetails = new frmPersonDetails(PersonID);
                frmPersonDetails.ShowDialog();
                _RefreshPeopleList();
                mtxt_Value.Clear();

            }
            else
            {
                MessageBox.Show("Please select a person first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        private void mtxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterMode == enFilterMode.PersonID)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListPeople.Rows.Count > 0 && dgv_ListPeople.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this person?", "Confirm Delete",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    int PersonID = Convert.ToInt32(dgv_ListPeople.CurrentRow.Cells["PersonID"].Value);
                    string ImageDeletingPath = clsPeople.Find(PersonID).PersonInfo.ImagePath;

                    if (clsPeople.IsExist(PersonID))
                    {
                        if (clsPeople.DeletePerson(PersonID))
                        {
                            MessageBox.Show("Person Deleted Successfully.", "Deleted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clsGlobal.DeletePersonImageOnDisk(ImageDeletingPath);

                            _RefreshPeopleList();
                        }
                        else
                        {
                            MessageBox.Show("Person was not deleted because he/she has data linked to other records.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Person with ID [" + PersonID + "] exists in the system.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select a person first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowFormAddNewPerson();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowFormEditPerson();
        }


        private void _NotifyNotImplemented()
        {
            MessageBox.Show("This feature has not been implemented yet. It will be available in the next update.",
                          "Information",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NotifyNotImplemented();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NotifyNotImplemented();
        }
    }
}
