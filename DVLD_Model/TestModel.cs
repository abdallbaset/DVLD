using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsTestModel
    {
        public enum enTestResult { Failed = 0, Passed = 1 }

        public int TestID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public int TestAppointmentID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public enTestResult TestResult { get; set; } = enTestResult.Failed;
        public string Notes { get; set; } = string.Empty;
        public int CreatedByUserID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

    }
}
