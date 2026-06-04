using DVLD_DataAccess;
using DVLD_Model;
using System;
using System.ComponentModel;
using System.Data;
using static DVLD_Model.clsApplicationModel;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{
    public class clsInternationalLicense
    {
        private enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;
        private clsApplicationModel _ApplicationsInfo { get; set; }
        private clsInternationalLicenseModel _InternationalLicenseInfo { get; set; }
        private clsLicenses _Licenses { get; set; }
        public int InternationalLicenseID
        {
            get => _InternationalLicenseInfo.InternationalLicenseID;
            set => _InternationalLicenseInfo.InternationalLicenseID = value;
        }

        public int ApplicationID
        {
            get => _InternationalLicenseInfo.ApplicationID;
            set => _InternationalLicenseInfo.ApplicationID = value;
        }

        public int DriverID
        {
            get => _InternationalLicenseInfo.DriverID;
            set => _InternationalLicenseInfo.DriverID = value;
        }

        public int IssuedUsingLocalLicenseID
        {
            get => _InternationalLicenseInfo.IssuedUsingLocalLicenseID;
            set => _InternationalLicenseInfo.IssuedUsingLocalLicenseID = value;
        }

        public DateTime IssueDate
        {
            get => _InternationalLicenseInfo.IssueDate;
            set => _InternationalLicenseInfo.IssueDate = value;
        }

        public DateTime ExpirationDate
        {
            get => _InternationalLicenseInfo.ExpirationDate;
            set => _InternationalLicenseInfo.ExpirationDate = value;
        }

        public bool IsActive
        {
            get => _InternationalLicenseInfo.IsActive;
            set => _InternationalLicenseInfo.IsActive = value;
        }

        public int CreatedByUserID
        {
            get => _InternationalLicenseInfo.CreatedByUserID;
            set => _InternationalLicenseInfo.CreatedByUserID = value;
        }
        public int PersonID
        {
            get => _Licenses.PersonID;
        }
        public DateTime DateOfBirth
        {
            get => _Licenses.DateOfBirth;
        }
        public string FullName
        {
            get => _Licenses.PersonName;
        }
        public string NationalNo
        {
            get => _Licenses.NationalNo;
        }
        public byte Gendor
        {
            get => _Licenses.Gendor;
        }
        public string PersonalPhoto
        {
            get => _Licenses.PersonalPhoto;
        }


        public clsInternationalLicense()
        {
            _InternationalLicenseInfo = new clsInternationalLicenseModel();
            _Licenses = new clsLicenses();
            _ApplicationsInfo = new clsApplicationModel();
            _Mode = enMode.AddNew;
        }

        private clsInternationalLicense(clsInternationalLicenseModel InternationalLicenseInfo)
        {
            _InternationalLicenseInfo = InternationalLicenseInfo;
            _Licenses = clsLicenses.Find(_InternationalLicenseInfo.IssuedUsingLocalLicenseID);
            _Mode = enMode.Update;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            clsInternationalLicenseModel InternationalLicenseInfo = clsInternationalLicenseData.GetInternationalLicenseInfoByID(InternationalLicenseID);
            if (InternationalLicenseInfo != null)
            {
                return new clsInternationalLicense(InternationalLicenseInfo);
            }

            return null;
        }

        static public DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }

        static public DataTable GetAllInternationalLicensesByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetAllInternationalLicensesByDriverID(DriverID);
        }

        static public bool IsInternationalLicenseExist(int LicenseID)
        {
            return clsInternationalLicenseData.IsInternationalLicenseExist(LicenseID);
        }
        private void _SetApplicationInfo()
        {
            _ApplicationsInfo.ApplicantPersonID = clsLicenses.Find(_InternationalLicenseInfo.IssuedUsingLocalLicenseID)?.PersonID ?? (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
            _ApplicationsInfo.ApplicationDate = DateTime.Now;
            _ApplicationsInfo.LastStatusDate = DateTime.Now;
            _ApplicationsInfo.ApplicationTypeID = clsApplicationTypesModel.enApplicationTypes.NewInternationalLicense;
            _ApplicationsInfo.ApplicationStatus = clsApplicationModel.enApplicationStatus.Completed;
            _ApplicationsInfo.PaidFees = clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.NewInternationalLicense).ApplicationFees;
        }
        private bool _AddNewInternationalLicense()
        {
            _SetApplicationInfo();
            int id = clsInternationalLicenseData.AddNewInternationalLicense(_InternationalLicenseInfo, _ApplicationsInfo);
            _InternationalLicenseInfo.InternationalLicenseID = id;
            return id != (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(_InternationalLicenseInfo);
        }
        static public int GetActiveInternationalLicense(int LicenseID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicense(LicenseID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateInternationalLicense();

                default:
                    return false;
            }
        }
    }
}