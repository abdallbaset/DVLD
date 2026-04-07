using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsDetainedLicenseModel
    {
        public int DetainID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public int LicenseID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public DateTime DetainDate { get; set; } = DateTime.MinValue;
        public double FineFees { get; set; } = 0;
        public int CreatedByUserID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public bool IsReleased { get; set; } = false;
        public DateTime ReleaseDate {  get; set; } = DateTime.MinValue;
        public int ReleasedByUserID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public int ReleaseApplicationID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

    }
}
