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
    public partial class frmAddNewAndEditUser : Form
    {
        public frmAddNewAndEditUser()
        {
            InitializeComponent();
        }
        int _ID = -1;
        private void tp_PersonInfo_Click(object sender, EventArgs e)
        {

        }

        private void frmAddNewAndEditUser_Load(object sender, EventArgs e)
        {
            btn_Next.Enabled = false;
            btn_Save.Enabled = false;
        }

    

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex != 0 && _ID == -1)
            {
                e.Cancel = true;

                MessageBox.Show("Please select a person first before moving to the next step.",
                                "Selection Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {

        }
    }
}
