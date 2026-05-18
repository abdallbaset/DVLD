using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsDriverModel
    {

        public int DriverID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public int PersonID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public int CreatedByUserID { get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public DateTime CreatedDate { get; set; } = DateTime.MinValue;
    }
}
