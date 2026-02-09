using DVLD_Business;
using DVLD_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UI
{
    public partial class ctrlPersonCard : UserControl
    {
        enum enGendor :byte {Male = 0 , Female =1 };
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
       private int _PersonID = -1;
      public void LoadPersonInfo(int PersonID)
        {
            clsPeople Person = clsPeople.Find(PersonID);
            if (Person == null)
            {
                MessageBox.Show($"No Person with ID [{PersonID}] was found in the system.",
                                    "Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                return;
            }
            _PersonID = PersonID;
            lbl_PersonID.Text = PersonID.ToString();
            lbl_FullName.Text = Person.PersonInfo.FullName;
            lbl_NotionalNumber.Text = Person.PersonInfo.NationalNo;
            lbl_Phone.Text = Person.PersonInfo.phone;
            lbl_Address.Text = Person.PersonInfo.Address;
            lbl_Email.Text = Person.PersonInfo.Email;
            lbl_Gendor.Text =(Person.PersonInfo.Gendor == (byte)enGendor.Male)? "Male" :"Female" ;
            lbl_Country.Text = clsCountries.GetCountryNameByCountryID(Person.PersonInfo.NationalityCountryID);
            lbl_DateOfBirth.Text = Person.PersonInfo.DateOfBirth.ToString("dd-MM-yyyy");
            
            ptb_Gendor.Image = (Person.PersonInfo.Gendor == (byte)enGendor.Male) ? Properties.Resources.male_svgrepo_com : Properties.Resources.female_svgrepo_com;

            ptb_PersonalPhoto.ImageLocation = (Person.PersonInfo.ImagePath != "") ? Person.PersonInfo.ImagePath : null ;
            
          }

     

        frmAddAndEditPersonInfo frm;
        private void btn_EditPerson_Click(object sender, EventArgs e)
        {
            if(_PersonID == -1)
            {
                MessageBox.Show($"No Person was found in the system.",
                                   "Not Found",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation);
                return;
            }

            frm = new frmAddAndEditPersonInfo(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}
