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

namespace DVLD_UI.Users
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;
        private int _UserID = (int)clsGlobal.enIdentityStatus.NonExistent;
        public int UserID {
            get => _UserID; 
        }
        public ctrlUserCard()
        {
            InitializeComponent();

        }
        private void _LoadDefaultData()
        {
            lbl_UserID.Text = "???";
            lbl_UserName.Text = "???";
            lbl_IsActive.Text = "???";
            ctrlPersonCard1.LoadDefaultData();
        }


        private void _FillUserInfo()
        {

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);

            lbl_UserID.Text = _User.UserID.ToString();
            lbl_UserName.Text = _User.UserName;
            lbl_IsActive.Text = (_User.IsActive) ? "Yes" : "No";
        }
        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User = clsUser.FindByUserID(UserID);
            if (_User == null)
            {
                _LoadDefaultData();
                MessageBox.Show($"No User with ID [{UserID}] was found in the system.",
                                     "Not Found",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);
                return;
            }

            _FillUserInfo();

        }
    }
}
