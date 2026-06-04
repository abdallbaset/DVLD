using System;
using System.Data;
using DVLD_DataAccess;
using DVLD_Model;

namespace DVLD_Business
{
    public class clsDrivers
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;
        private clsDriverModel _DriverInfo { get; set; }
        public int DriverID { get => _DriverInfo.DriverID; }
        public int PersonID {  get => _DriverInfo.PersonID; }
        public int CreatedByUserID { get => _DriverInfo.CreatedByUserID; }
        public DateTime CreatedDate {  get => _DriverInfo.CreatedDate; }

        public clsDrivers()
        {
            _DriverInfo = new clsDriverModel();
            _Mode = enMode.AddNew;
        }

        private clsDrivers(clsDriverModel DriverInfo)
        {
            _DriverInfo = DriverInfo;
            _Mode = enMode.Update;
        }

        public static clsDrivers Find(int DriverID)
        {
            clsDriverModel DriverInfo = clsDriversData.GetDriverInfoByDriverID(DriverID);
            if (DriverInfo != null)
            {
                return new clsDrivers(DriverInfo);
            }

            return null;
        }

        public static clsDrivers FindByPersonID(int PersonID)
        {
            clsDriverModel DriverInfo = clsDriversData.GetDriverInfoByPersonID(PersonID);
            if (DriverInfo != null)
            {
                return new clsDrivers(DriverInfo);
            }

            return null;
        }

        private bool _AddNewDriver()
        {
            _DriverInfo.DriverID = clsDriversData.AddNewDriver(_DriverInfo);
            return _DriverInfo.DriverID != (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        }

        private bool _UpdateDriver()
        {
            return clsDriversData.UpdateDriver(_DriverInfo);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDriver();

                default:
                    return false;
            }
        }

        static public DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();
        }

        static public bool IsExistByPersonID(int PersonID)
        {
            return clsDriversData.IsDriverExistByPersonID(PersonID);
        }
        static public bool IsExistByDriverID(int DriverID)
        {
            return clsDriversData.IsDriverExistByDriverID(DriverID);
        }
    }
}