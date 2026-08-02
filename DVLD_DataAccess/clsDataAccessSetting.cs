using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Infrastructure.Configuration;
namespace DVLD_DataAccess
{
    static class clsDataAccessSetting
    {
        static public string ConnectionString
        {
            get
            {
                return AppConfigManager.GetDatabaseConnectionString();
            }
        }
    }
}
