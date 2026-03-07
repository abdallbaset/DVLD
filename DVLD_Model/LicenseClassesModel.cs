using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsLicenseClassesModel
    {
        public enum enLicenseClass
        {
            NotSpecified = -1,
            SmallMotorcyclee = 1,
            HeavyMotorcycleLicense = 2,
            OrdinaryDrivingLicense = 3,
            Commercial = 4,
            Agricultural = 5,
            SmallAndMediumBus = 6,
            TruckAndHeavyVehicle = 7
        }
        public enLicenseClass LicenseClassID { get; set; } = enLicenseClass.NotSpecified;
        public string ClassName { get; set; } = string.Empty;
        public string ClassDescription { get; set; } = string.Empty;
        public byte MinimumAllowedAge { get; set; } = 18;
        public byte DefaultValidityLength { get; set; } = 10;
        public double ClassFees { get; set; } = 10;
    }
}
