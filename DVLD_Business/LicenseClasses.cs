using System;
using System.Data;
using DVLD_DataAccess;
using DVLD_Model;

namespace DVLD_Business
{
    public class clsLicenseClasses
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;
        public clsLicenseClassesModel LicenseClassInfo { get; set; }
        public double ClassFees
        {
            get => LicenseClassInfo.ClassFees;
        }
        public clsLicenseClasses()
        {
            LicenseClassInfo = new clsLicenseClassesModel();
            _Mode = enMode.AddNew;
        }

        private clsLicenseClasses(clsLicenseClassesModel LicenseClassInfo)
        {
           this.LicenseClassInfo = LicenseClassInfo;
            _Mode = enMode.Update;
        }

     

        public static clsLicenseClasses Find(int LicenseClassID)
        {
            clsLicenseClassesModel LicenseClassInfo = clsLicenseClassesData.GetLicenseClassInfoByID(LicenseClassID);
            if (LicenseClassInfo != null)
            {
                return new clsLicenseClasses(LicenseClassInfo);
            }

            return null;
        }

        private bool _AddNewLicenseClass()
        {
            LicenseClassInfo.LicenseClassID = (clsLicenseClassesModel.enLicenseClass)clsLicenseClassesData.AddNewLicenseClass(LicenseClassInfo);
           
            return LicenseClassInfo.LicenseClassID != clsLicenseClassesModel.enLicenseClass.NotSpecified;
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassesData.UpdateLicenseClass(LicenseClassInfo);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLicenseClass();

                default:
                    return false;
            }
        }

        static public DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }

        static public bool DeleteLicenseClass(int LicenseClassID)
        {
            return clsLicenseClassesData.DeleteLicenseClass(LicenseClassID);
        }

        static public bool IsExist(int LicenseClassID)
        {
            return clsLicenseClassesData.IsLicenseClassExist(LicenseClassID);
        }
        static public bool IsExist(string LicenseClassName)
        {
            return clsLicenseClassesData.IsLicenseClassExist(LicenseClassName);
        }
    }
}
