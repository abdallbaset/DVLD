using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsCountriesModel
    {
        public int CountryID {  get; set; } = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        public string CountryName { get; set; } = string.Empty;
    }
}
