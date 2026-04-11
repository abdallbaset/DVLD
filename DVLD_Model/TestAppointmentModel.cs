using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsTestAppointmentModel
    {
        public int  TestAppointmentID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public  int LocalDrivingLicenseApplicationID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public int TestTypeID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public DateTime AppointmentDate { get; set; } = DateTime.MinValue;
        public double PaidFees { get; set; } = 0;
        public int CreatedByUserID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public bool IsLocked { get; set; } = false;
        public int RetakeTestApplicationID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
    }
}
