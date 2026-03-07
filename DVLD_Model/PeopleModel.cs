using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsPeopleModel
    {
        public enum enIdentityStatus { NonExistent = -1 }

        public int PersonID { get; set; } = (int)enIdentityStatus.NonExistent;
        public string NationalNo { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; }  = string.Empty;
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }

        } 
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public byte Gendor { get; set; } = 0;

        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int NationalityCountryID { get; set; } = (int)enIdentityStatus.NonExistent;
        public string ImagePath { get; set; } = string.Empty;
    }
}
