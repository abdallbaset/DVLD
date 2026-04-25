using DVLD_Business;
using DVLD_Model;
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

namespace DVLD_UI.Test.Test_Type
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private DataView _ListTestTypes;

     
        private void _FormatDataGridViewColumn()
        {
            if (dgv_ListTestTypes.Rows.Count > 0)
            {
                 clsUtil.ConfigureColumn(dgv_ListTestTypes.Columns["TestTypeID"], "ID", 100);
                 clsUtil.ConfigureColumn(dgv_ListTestTypes.Columns["TestTypeTitle"], "Title", 180);
                 clsUtil.ConfigureColumn(dgv_ListTestTypes.Columns["TestTypeDescription"], "Description", 600);
                 clsUtil.ConfigureColumn(dgv_ListTestTypes.Columns["TestTypeFees"], "Fees", 100);
            }
        }

        private void _RefreshTestTypesList()
        {
            _ListTestTypes = new DataView(clsTestTypes.GetAllTestTypes());
            dgv_ListTestTypes.DataSource = _ListTestTypes;
            _FormatDataGridViewColumn();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, _ListTestTypes);
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
