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
        private void _RefreshApplicationList()
        {
            _ListApplication = new DataView(clsApplicationType.GetAllApplicationTypes());
            dgv_ListApplication.DataSource = _ListApplication;
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
            int ApplicationTypeID = Convert.ToInt32(dgv_ListApplication.CurrentRow.Cells["ID"].Value);
            frmEditApplicationType editForm = new frmEditApplicationType(ApplicationTypeID);
            editForm.ShowDialog();
            _RefreshApplicationList();
            
        }
    }
}
