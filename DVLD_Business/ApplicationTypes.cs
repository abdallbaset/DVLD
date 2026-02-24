using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using DVLD_Model;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public clsApplicationTypesModel ApplicationTypeInfo { get; set; }

        private clsApplicationType(clsApplicationTypesModel ApplicationTypeInfo)
        {
            this.ApplicationTypeInfo = ApplicationTypeInfo;
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            clsApplicationTypesModel ApplicationTypeInfo = clsApplicationTypesData.GetApplicationTypeInfoByID(ApplicationTypeID);

            if (ApplicationTypeInfo != null)
            {
                return new clsApplicationType(ApplicationTypeInfo);
            }

            return null;
        }

        static public DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType(ApplicationTypeInfo);
        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }
    }
}
