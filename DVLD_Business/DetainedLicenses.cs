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
            set => _DetainedInfo.DetainID = value;
        }

        public int PersonID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

        public int LicenseID
        {
            get => _DetainedInfo.LicenseID;
            set => _DetainedInfo.LicenseID = value;
        }

        public int ReleasedByUserID
        {
            get => _DetainedInfo.ReleasedByUserID;
            set => _DetainedInfo.ReleasedByUserID = value;
        }

        public int ReleaseApplicationID
        {
            get => _DetainedInfo.ReleaseApplicationID;
            set => _DetainedInfo.ReleaseApplicationID = value;
        }
        public int CreatedByUserID
        {
            get => _DetainedInfo.CreatedByUserID;
            set => _DetainedInfo.CreatedByUserID = value;
        }

        public bool IsReleased
        {
            get => _DetainedInfo.IsReleased;
            set => _DetainedInfo.IsReleased = value;
        }

        public DateTime DetainDate
        {
            get => _DetainedInfo.DetainDate;
            set => _DetainedInfo.DetainDate = value;
        }

        public DateTime ReleaseDate
        {
            get => _DetainedInfo.ReleaseDate;
            set => _DetainedInfo.ReleaseDate = value;
        }

        public double FineFees
        {
            get => _DetainedInfo.FineFees;
            set => _DetainedInfo.FineFees = value;
        }
        public string CreatedByUserName
        {
            get => (_DetainedInfo != null) ? clsUser.FindByUserID(CreatedByUserID).UserName : "unknown";
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

        static public clsDetainedLicense FindByDetainID(int DetainID)
        {
            clsDetainedLicenseModel DetainedLicenseInfo = clsDetainedLicensesData.GetDetainedLicenseInfoByID(DetainID);

            if (DetainedLicenseInfo != null)
            {
                return new clsDetainedLicense(DetainedLicenseInfo);
            }

            return null;
        }
        static public clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            clsDetainedLicenseModel DetainedLicenseInfo = clsDetainedLicensesData.GetDetainedLicenseInfoByLicenseID(LicenseID);

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
            if(_DetainedInfo == null)
            {
                return false;
            }

            return clsDetainedLicensesData.ReleaseDetainedLicense(this.DetainID,this.ReleasedByUserID,this.PersonID);
        }
    }
}