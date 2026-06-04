using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Model.clsLicenseModel;

namespace DVLD_Model
{
    public class clsInternationalLicenseModel
    {
        public int InternationalLicenseID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public int ApplicationID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public int DriverID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public int IssuedUsingLocalLicenseID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public DateTime IssueDate { get; set; } = DateTime.MinValue;
        public DateTime ExpirationDate { get; set; } = DateTime.MinValue;
        public bool IsActive { get; set; } = true;
        public int CreatedByUserID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
    }
}
