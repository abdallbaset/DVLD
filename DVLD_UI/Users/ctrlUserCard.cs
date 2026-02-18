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

namespace DVLD_UI.Users
{
    public partial class ctrlUserCard : UserControl
    {
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
        public void LoadUserInfo(int UserID)
        {
            clsUser User = clsUser.FindByUserID(UserID);
            if (User == null)
            {
                _LoadDefaultData();
                MessageBox.Show($"No User with ID [{UserID}] was found in the system.",
                                     "Not Found",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);
                return;
            }

            ctrlPersonCard1.LoadPersonInfo(User.UserInfo.PersonID);

            lbl_UserID.Text = User.UserInfo.UserID.ToString();
            lbl_UserName.Text = User.UserInfo.UserName;
            lbl_IsActive.Text = (User.UserInfo.IsActive) ? "Yes" : "No";
        }
    }
}
