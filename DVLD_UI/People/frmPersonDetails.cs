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
    public partial class frmPersonDetails : Form
    {
        private int _PersonID;
        public frmPersonDetails(int PersonID)
        {
            _PersonID = PersonID;
            InitializeComponent();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInfo(_PersonID);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
