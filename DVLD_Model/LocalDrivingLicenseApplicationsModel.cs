using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsLocalDrivingLicenseApplicationsModel
    {
        public enum enIdentityStatus { NonExistent = -1 }

        public int LocalDrivingLicenseApplicationID { get; set; } = (int)enIdentityStatus.NonExistent;
        public int ApplicationID { get; set; } = (int)enIdentityStatus.NonExistent;
        public clsLicenseClassesModel.enLicenseClass LicenseClassID { get; set; } = clsLicenseClassesModel.enLicenseClass.NotSpecified;
    }
}
