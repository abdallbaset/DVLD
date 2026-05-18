using DVLD_DataAccess;
using DVLD_Model;
using System;
using System.Data;
using static DVLD_Model.clsLicenseClassesModel;

namespace DVLD_Business
{
    public class clsLicenseClasses
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;
        public clsLicenseClassesModel _LicenseClassInfo { get; set; }

        public clsLicenseClasses()
        {
            _LicenseClassInfo = new clsLicenseClassesModel();
            _Mode = enMode.AddNew;
        }

        private clsLicenseClasses(clsLicenseClassesModel LicenseClassInfo)
        {
           this._LicenseClassInfo = LicenseClassInfo;
            _Mode = enMode.Update;
        }

        public enLicenseClass LicenseClassID
        {
            get => _LicenseClassInfo != null ? _LicenseClassInfo.LicenseClassID : enLicenseClass.NotSpecified;
            set
            {
                if (_LicenseClassInfo != null)
                    _LicenseClassInfo.LicenseClassID = value;
            }
        }

        public string ClassName
        {
            get => _LicenseClassInfo?.ClassName ?? string.Empty;
            set
            {
                if (_LicenseClassInfo != null)
                    _LicenseClassInfo.ClassName = value;
            }
        }

        public string ClassDescription
        {
            get => _LicenseClassInfo?.ClassDescription ?? string.Empty;
            set
            {
                if (_LicenseClassInfo != null)
                    _LicenseClassInfo.ClassDescription = value;
            }
        }

        public byte MinimumAllowedAge
        {
            get => _LicenseClassInfo != null ? _LicenseClassInfo.MinimumAllowedAge : (byte)18;
            set
            {
                if (_LicenseClassInfo != null)
                    _LicenseClassInfo.MinimumAllowedAge = value;
            }
        }

        public byte DefaultValidityLength
        {
            get => _LicenseClassInfo != null ? _LicenseClassInfo.DefaultValidityLength : (byte)10;
            set
            {
                if (_LicenseClassInfo != null)
                    _LicenseClassInfo.DefaultValidityLength = value;
            }
        }

        public double ClassFees
        {
            get => _LicenseClassInfo != null ? _LicenseClassInfo.ClassFees : 10.0;
            set
            {
                if (_LicenseClassInfo != null)
                    _LicenseClassInfo.ClassFees = value;
            }
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
            _LicenseClassInfo.LicenseClassID = (clsLicenseClassesModel.enLicenseClass)clsLicenseClassesData.AddNewLicenseClass(_LicenseClassInfo);
           
            return _LicenseClassInfo.LicenseClassID != clsLicenseClassesModel.enLicenseClass.NotSpecified;
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassesData.UpdateLicenseClass(_LicenseClassInfo);
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
