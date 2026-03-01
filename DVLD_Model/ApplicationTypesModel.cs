using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsApplicationTypesModel
    {
        public enum enApplicationTypes
        {
            NotSpecified = 0,
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService = 2,
            ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        }
        public enApplicationTypes ApplicationTypeID { get; set; } = enApplicationTypes.NotSpecified;
        public string ApplicationTypeTitle { get; set; } = string.Empty;
        public double ApplicationFees { get; set; } = 0;

    }
}
