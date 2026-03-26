using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    static class clsDataAccessSetting
    {
        static public string ConnectionString
        {
            get
            {
                return @"Server=DESKTOP-POD3TM1\SQLEXPRESS;Database=DVLD;Integrated Security=True;";
            }
        }
    }
}
