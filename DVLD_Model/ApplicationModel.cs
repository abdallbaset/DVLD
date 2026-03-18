using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsApplicationModel
    {
        public enum  enApplicationStatus :byte
        {
            New = 1,
            Cancelled = 2,
            Completed = 3,
        }
        public enum enIdentityStatus { NonExistent = -1 }

        public int ApplicationID { get; set; } = (int)enIdentityStatus.NonExistent;
        public int ApplicantPersonID { get; set; } = (int)enIdentityStatus.NonExistent;
        public clsApplicationTypesModel.enApplicationTypes ApplicationTypeID { get; set; } = clsApplicationTypesModel.enApplicationTypes.NotSpecified;
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public enApplicationStatus ApplicationStatus { get; set; } = enApplicationStatus.New;
        public DateTime LastStatusDate { get; set; } = DateTime.Now;
        public double PaidFees { get; set; } = 0;
        public int CreatedByUserID { get; set; } = (int)enIdentityStatus.NonExistent;

    }
}
