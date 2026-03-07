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

        enum enFilterMode { None, PersonID, NationalNO, FirstName, SecondName, ThirdName, LastName, Nationality, Gendor, Phone, Email }
        enFilterMode _FilterMode;
        public frmManagePeople()
        {
            InitializeComponent();
        }
        private DataView _ListPeople;
        private void _FormatDataGridView()
        {
            if (dgv_ListPeople.Rows.Count > 0)
            {
                if (dgv_ListPeople.Columns.Contains("PersonID"))
                {
                    dgv_ListPeople.Columns["PersonID"].HeaderText = "ID";
                    dgv_ListPeople.Columns["PersonID"].Width = 90;
                }

                if (dgv_ListPeople.Columns.Contains("NationalNo"))
                {
                    dgv_ListPeople.Columns["NationalNo"].HeaderText = "National No";
                    dgv_ListPeople.Columns["NationalNo"].Width = 130;
                }

                if (dgv_ListPeople.Columns.Contains("FirstName"))
                {
                    dgv_ListPeople.Columns["FirstName"].HeaderText = "First Name";
                    dgv_ListPeople.Columns["FirstName"].Width = 140;
                }
                if (dgv_ListPeople.Columns.Contains("SecondName"))
                {
                    dgv_ListPeople.Columns["SecondName"].HeaderText = "Second Name";
                    dgv_ListPeople.Columns["SecondName"].Width = 140;
                }
                if (dgv_ListPeople.Columns.Contains("ThirdName"))
                {
                    dgv_ListPeople.Columns["ThirdName"].HeaderText = "Third Name";
                    dgv_ListPeople.Columns["ThirdName"].Width = 120;
                }
                if (dgv_ListPeople.Columns.Contains("LastName"))
                {
                    dgv_ListPeople.Columns["LastName"].HeaderText = "Last Name";
                    dgv_ListPeople.Columns["LastName"].Width = 140;
                }

                if (dgv_ListPeople.Columns.Contains("DateOfBirth"))
                {
                    dgv_ListPeople.Columns["DateOfBirth"].HeaderText = "Date of Birth";
                    dgv_ListPeople.Columns["DateOfBirth"].Width = 110;
                }

                if (dgv_ListPeople.Columns.Contains("Gendor"))
                {
                    dgv_ListPeople.Columns["Gendor"].HeaderText = "Gender";
                    dgv_ListPeople.Columns["Gendor"].Width = 90;
                }

                if (dgv_ListPeople.Columns.Contains("Phone"))
                {
                    dgv_ListPeople.Columns["Phone"].HeaderText = "Phone";
                    dgv_ListPeople.Columns["Phone"].Width = 120;
                }
                if (dgv_ListPeople.Columns.Contains("Email"))
                {
                    dgv_ListPeople.Columns["Email"].HeaderText = "Email";
                    dgv_ListPeople.Columns["Email"].Width = 200;
                }

                if (dgv_ListPeople.Columns.Contains("Nationality"))
                {
                    dgv_ListPeople.Columns["Nationality"].HeaderText = "Nationality";
                    dgv_ListPeople.Columns["Nationality"].Width = 150;
                }
            }
        }
        private void _GetNumberOfRecords()
        {
            lbl_NumberOfRecords.Text = _ListPeople.Count.ToString();
        }
        private void _RefreshPeopleList()
        {
            DataTable dtPeople = clsPeople.ListPeople();
            _ListPeople = new DataView(dtPeople);
            dgv_ListPeople.DataSource = _ListPeople;
            _FormatDataGridView();
            _GetNumberOfRecords();
        }
      
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            cmb_AllFilter.SelectedIndex = cmb_AllFilter.FindString("None");

        }


        private void _FilterResult()
        {
            string filterExpression = "";

            if (string.IsNullOrWhiteSpace(mtxt_Value.Text))
            {
                _ListPeople.RowFilter = "";
                return;
            }

            string filterValue = mtxt_Value.Text.Trim().Replace("'", "''");

            switch (_FilterMode)
            {
                case enFilterMode.PersonID:
                    filterExpression = $"PersonID = {filterValue}";
                    break;

                case enFilterMode.NationalNO:
                case enFilterMode.FirstName:
                case enFilterMode.SecondName:
                case enFilterMode.ThirdName:
                case enFilterMode.LastName:
                case enFilterMode.Nationality:
                case enFilterMode.Gendor:
                case enFilterMode.Phone:
                case enFilterMode.Email:

                    filterExpression = $"{_FilterMode} LIKE '%{filterValue}%'";
                    break;

                default:
                    filterExpression = "";
                    break;
            }

            _ListPeople.RowFilter = filterExpression;
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
                mtxt_Value.Clear();
                mtxt_Value.Focus();
            }
        }


        private void _ShowFormAddAndEditPerson(int PersonID = (int)clsGlobal.enIdentityStatus.NonExistent)
        {
            frmAddAndEditPersonInfo frm;
            if (PersonID == (int)clsGlobal.enIdentityStatus.NonExistent)
            {
                frm = new frmAddAndEditPersonInfo(PersonID);
                frm.ShowDialog();
                _RefreshPeopleList();
                return;
            }




            frm = new frmAddAndEditPersonInfo(PersonID);
            frm.ShowDialog();
            _RefreshPeopleList();

        }

        private void _ShowDetailsPerson()
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

        private void btn_AddPerson_Click(object sender, EventArgs e)
        {
            _ShowFormAddAndEditPerson();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _ShowDetailsPerson();

        }

        private void mtxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterMode == enFilterMode.PersonID || _FilterMode == enFilterMode.NationalNO || _FilterMode == enFilterMode.Phone)
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
                int PersonID = Convert.ToInt32(dgv_ListPeople.CurrentRow.Cells["PersonID"].Value);

                if (MessageBox.Show($"Are you sure you want to delete this Person ID [{PersonID}] ?", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                  

                    if (clsPeople.IsExist(PersonID))
                    {
                        string ImageDeletingPath = clsPeople.Find(PersonID).ImagePath;
                        if (clsPeople.DeletePerson(PersonID))
                        {
                            MessageBox.Show("Person Deleted Successfully.", "Deleted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clsUtil.DeletePersonImageOnDisk(ImageDeletingPath);

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
            _ShowFormAddAndEditPerson();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgv_ListPeople.Rows.Count > 0 && dgv_ListPeople.CurrentRow != null)
            {
                int PersonID = Convert.ToInt32(dgv_ListPeople.CurrentRow.Cells["PersonID"].Value);
                _ShowFormAddAndEditPerson(PersonID);
            }
            else
            {
                MessageBox.Show("Please select a person first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void dgv_ListPeople_DoubleClick(object sender, EventArgs e)
        {
            _ShowDetailsPerson();
        }
    }
    }
