using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsEnumerationsModel
    {
        public enum enIdentityStatus { NonExistent = -1 }
        public enum enPassedTestCount
        {
            None = 0,
            VisionTestPassed = 1,
            WrittenTestPassed = 2,
            StreetTestPassed = 3
        };
    }
}
