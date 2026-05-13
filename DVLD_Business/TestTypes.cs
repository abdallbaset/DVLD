using DVLD_DataAccess;
using DVLD_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business
{
    public class clsTestTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public clsTestTypesModel TestTypeInfo { get; set; }

        public double TestTypeFees
        {
            get  =>  TestTypeInfo.TestTypeFees; 
        }
        private clsTestTypes()
        {
            TestTypeInfo = new clsTestTypesModel();
            _Mode = enMode.AddNew;

        }
        private clsTestTypes(clsTestTypesModel TestTypeInfo)
        {
            this.TestTypeInfo = TestTypeInfo;
            _Mode = enMode.Update;
        }

        public static clsTestTypes Find(clsEnumerationsModel.enTestType TestTypeID)
        {
            clsTestTypesModel TestTypeInfo = clsTestTypesData.GetTestTypeInfoByID(TestTypeID);

            if (TestTypeInfo != null)
            {
                return new clsTestTypes(TestTypeInfo);
            }

            return null;
        }
        private bool _AddNewTestType()
        {
            TestTypeInfo.ID = (clsEnumerationsModel.enTestType)clsTestTypesData.AddNewTestType(TestTypeInfo);
            return (TestTypeInfo.ID != clsEnumerationsModel.enTestType.NotSpecified);
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
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }
    }
}
