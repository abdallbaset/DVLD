using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsLocalDrivingLicenseApplicationsModel
    {

        public int LocalDrivingLicenseApplicationID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public int ApplicationID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public clsLicenseClassesModel.enLicenseClass LicenseClassID { get; set; } = clsLicenseClassesModel.enLicenseClass.NotSpecified;
    }
}
