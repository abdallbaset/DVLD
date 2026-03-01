using DVLD_Business;
using DVLD_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Test.Test_Type
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private DataView _ListTestTypes;

        private void _GetNumberOfRecords()
        {
            lbl_NumberOfRecords.Text = _ListTestTypes.Count.ToString();
        }

        private void _FormatDataGridView()
        {
            if (dgv_ListTestTypes.Rows.Count > 0)
            {
                if (dgv_ListTestTypes.Columns.Contains("TestTypeID"))
                {
                    dgv_ListTestTypes.Columns["TestTypeID"].HeaderText = "ID";
                    dgv_ListTestTypes.Columns["TestTypeID"].Width = 100;
                }

                if (dgv_ListTestTypes.Columns.Contains("TestTypeTitle"))
                {
                    dgv_ListTestTypes.Columns["TestTypeTitle"].HeaderText = "Title";
                    dgv_ListTestTypes.Columns["TestTypeTitle"].Width = 180;
                }

                if (dgv_ListTestTypes.Columns.Contains("TestTypeDescription"))
                {
                    dgv_ListTestTypes.Columns["TestTypeDescription"].HeaderText = "Description";
                    dgv_ListTestTypes.Columns["TestTypeDescription"].Width = 600;
                }

                if (dgv_ListTestTypes.Columns.Contains("TestTypeFees"))
                {
                    dgv_ListTestTypes.Columns["TestTypeFees"].HeaderText = "Fees";
                    dgv_ListTestTypes.Columns["TestTypeFees"].Width = 100;
                }
            }
        }

        private void _RefreshTestTypesList()
        {
            _ListTestTypes = new DataView(clsTestTypes.GetAllTestTypes());
            dgv_ListTestTypes.DataSource = _ListTestTypes;
            _FormatDataGridView();
            _GetNumberOfRecords();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesList();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplictionsTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListTestTypes.Rows.Count > 0 && dgv_ListTestTypes.CurrentRow != null)
            {
                clsTestTypesModel.enTestType TestTypeID = (clsTestTypesModel.enTestType)(dgv_ListTestTypes.CurrentRow.Cells["TestTypeID"].Value);
                frmEditTestType editForm = new frmEditTestType(TestTypeID);
                editForm.ShowDialog();
                _RefreshTestTypesList();
            }
            else
            {
                MessageBox.Show("Please select a test type first!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
