using System;
using System.Data;
using DVLD_DataAccess;
using DVLD_Model;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        public enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;

        private clsDetainedLicenseModel _DetainedInfo { get; set; }

        public int DetainID
        {
            get => _DetainedInfo.DetainID; 
        }

        public int LicenseID
        {
            get => _DetainedInfo.LicenseID;
        }

        public int ReleasedByUserID
        {
            get => _DetainedInfo.ReleasedByUserID;
        }

        public int ReleaseApplicationID
        {
            get => _DetainedInfo.ReleaseApplicationID;
        }
        public int CreatedByUserID
        {
            get => _DetainedInfo.CreatedByUserID;
        }

        public bool IsReleased
        {
            get => _DetainedInfo.IsReleased;
        }

        public DateTime DetainDate
        {
            get => _DetainedInfo.DetainDate;
        }

        public DateTime ReleaseDate
        {
            get => _DetainedInfo.ReleaseDate;
        }

        public double FineFees
        {
            get => _DetainedInfo.FineFees;
        }


        public clsDetainedLicense()
        {
            _DetainedInfo = new clsDetainedLicenseModel();
            _Mode = enMode.AddNew;
        }

        private clsDetainedLicense(clsDetainedLicenseModel DetainedLicenseInfo)
        {
            _DetainedInfo = DetainedLicenseInfo;
            _Mode = enMode.Update;
        }

        static public clsDetainedLicense Find(int DetainID)
        {
            clsDetainedLicenseModel DetainedLicenseInfo = clsDetainedLicensesData.GetDetainedLicenseInfoByID(DetainID);

            if (DetainedLicenseInfo != null)
            {
                return new clsDetainedLicense(DetainedLicenseInfo);
            }

            return null;
        }

        static public bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicensesData.IsLicenseDetained(LicenseID);
        }

        static public DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesData.GetAllDetainedLicenses();
        }

        private bool _AddNewDetainedLicense()
        {
            int id = clsDetainedLicensesData.AddNewDetainedLicense(_DetainedInfo);
            _DetainedInfo.DetainID = id;
            return id != (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesData.UpdateDetainedLicense(_DetainedInfo);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDetainedLicense();

                default:
                    return false;
            }
        }

        public bool ReleaseDetainedLicense()
        {
            if (_DetainedInfo == null || _DetainedInfo.DetainID == (int)clsEnumerationsModel.enIdentityStatus.NonExistent)
            {
                return false;
            }

            _DetainedInfo.IsReleased = true;
            _DetainedInfo.ReleaseDate = DateTime.Now;
            _DetainedInfo.ReleasedByUserID = ReleasedByUserID;
            _DetainedInfo.ReleaseApplicationID = ReleaseApplicationID;

            return Save();
        }
    }
}