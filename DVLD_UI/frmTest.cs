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

namespace DVLD_UI
{
    public partial class frmTest : Form
    {

        public frmTest()
        {
            InitializeComponent();
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {
       
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInfo(1031);
        }

        private void ctrlPersonCard1_Load_1(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCard1_Load_2(object sender, EventArgs e)
        {

        }
    }
}
