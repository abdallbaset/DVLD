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

namespace DVLD_UI.Applications.Application_Types
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
        private DataView _ListApplication;
        private void _GetNumberOfRecords()
        {
            lbl_NumberOfRecords.Text = _ListApplication.Count.ToString();
        }
        private void _FormatDataGridView()
        {
            if (dgv_ListApplication.Rows.Count > 0)
            {
                if(dgv_ListApplication.Columns.Contains("ApplicationTypeID"))
                {
                    dgv_ListApplication.Columns["ApplicationTypeID"].HeaderText = "ID";
                    dgv_ListApplication.Columns["ApplicationTypeID"].Width = 110;
                }

                if(dgv_ListApplication.Columns.Contains("ApplicationTypeTitle"))
                {

                    dgv_ListApplication.Columns["ApplicationTypeTitle"].HeaderText = "Title";
                    dgv_ListApplication.Columns["ApplicationTypeTitle"].Width = 400;
                }

                if(dgv_ListApplication.Columns.Contains("ApplicationFees"))
                {

                    dgv_ListApplication.Columns["ApplicationFees"].HeaderText = "Fees";
                    dgv_ListApplication.Columns["ApplicationFees"].Width = 140;
                }
            }
        }

        private void _RefreshApplicationList()
        {
            _ListApplication = new DataView(clsApplicationType.GetAllApplicationTypes());
            dgv_ListApplication.DataSource = _ListApplication;
            _FormatDataGridView();
            _GetNumberOfRecords();
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
