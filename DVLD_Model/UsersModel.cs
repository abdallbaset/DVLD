using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsUsersModel
    {
        public int UserID { get; set; } = (int)clsSettingsModel.enIdentityStatus.NonExistent;
        public int PersonID { get; set; } = (int)clsSettingsModel.enIdentityStatus.NonExistent;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
