using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsLicenseModel
    {
        public enum enIssueReason : byte
        {
            FirstTime = 1,
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4
        }

        public int LicenseID { get; set; } = (int)clsSettingsModel.enIdentityStatus.NonExistent;
        public int LicenseClassID { get; set; } = (int)clsSettingsModel.enIdentityStatus.NonExistent;
        public int ApplicationID { get; set; } = (int)clsSettingsModel.enIdentityStatus.NonExistent;
        public int DriverID { get; set; } = (int)clsSettingsModel.enIdentityStatus.NonExistent;
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; } = DateTime.Now;
        public enIssueReason IssueReason { get; set; } = enIssueReason.FirstTime;
        public double PaidFees { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public string Notes { get; set; } = string.Empty;
        public int CreatedByUserID { get; set; } = (int)clsSettingsModel.enIdentityStatus.NonExistent;





}
}
