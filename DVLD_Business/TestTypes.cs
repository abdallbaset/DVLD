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
    public class clsTestTypes
    {
        public clsTestTypesModel TestTypeInfo { get; set; }

        private clsTestTypes(clsTestTypesModel TestTypeInfo)
        {
            this.TestTypeInfo = TestTypeInfo;
        }

        public static clsTestTypes Find(int TestTypeID)
        {
            clsTestTypesModel TestTypeInfo = clsTestTypesData.GetTestTypeInfoByID(TestTypeID);

            if (TestTypeInfo != null)
            {
                return new clsTestTypes(TestTypeInfo);
            }

            return null;
        }

        static public DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        private bool _UpdateTestType()
        {
            return clsTestTypesData.UpdateTestType(TestTypeInfo);
        }

        public bool Save()
        {
            return _UpdateTestType();
        }
    }
}
