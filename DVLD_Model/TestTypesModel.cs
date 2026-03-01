using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Model
{
    public class clsTestTypesModel
    {
        public enum enTestType { NotSpecified  = 0, VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public enTestType ID { get; set; } = enTestType.NotSpecified;
       public string TestTypeTitle { get; set; } = string.Empty;
       public string TestTypeDescription { get; set;} = string.Empty;
       public double TestTypeFees { get; set;} = 0;

     

    }
}
