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

namespace DVLD_UI.Applications.Application_Types
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
        private DataView _ListApplication;
     
        private void _FormatDataGridViewColumn()
        {
            if (dgv_ListApplication.Rows.Count > 0)
            {
                clsUtil.ConfigureColumn(dgv_ListApplication.Columns["ApplicationTypeID"], "ID", 110);
                clsUtil.ConfigureColumn(dgv_ListApplication.Columns["ApplicationTypeTitle"], "Title", 400);
                clsUtil.ConfigureColumn(dgv_ListApplication.Columns["ApplicationFees"], "Fees", 140);
            }
        }

        private void _RefreshApplicationList()
        {
            _ListApplication = new DataView(clsApplicationType.GetAllApplicationTypes());
            dgv_ListApplication.DataSource = _ListApplication;
            _FormatDataGridViewColumn();
            clsUtil.UpdateRecordCount(lbl_NumberOfRecords, _ListApplication);

        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationList();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplictionsTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplicationTypesModel.enApplicationTypes ApplicationTypeID = (clsApplicationTypesModel.enApplicationTypes)dgv_ListApplication.CurrentRow.Cells["ApplicationTypeID"].Value;
            frmEditApplicationType editForm = new frmEditApplicationType(ApplicationTypeID);
            editForm.ShowDialog();
            _RefreshApplicationList();
            
        }
    }
}
