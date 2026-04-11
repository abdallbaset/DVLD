using System;
using System.Data;
using DVLD_DataAccess;
using DVLD_Model;

namespace DVLD_Business
{
    public class clsLicenses
    {
        public enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;

        public clsLicenseModel LicenseInfo { get; set; }
       // private clsDrivers _DriverInfo; لاحقا
        private clsPeople _PersonInfo = null;

        public clsPeople PersonInfo
        {
            get
            {
                if (_PersonInfo == null) 
                {
                    int personID = clsApplications.Find(LicenseInfo.ApplicationID)?.ApplicantPersonID
                                   ?? (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
                    _PersonInfo = clsPeople.Find(personID);
                }
                return _PersonInfo;
            }
        }
        public string ClassName
        {
            get => clsLicenseClasses.Find(LicenseInfo.LicenseClassID)?.ClassName ?? "???" ;
        }

        public int LicenseID
        {
            get => LicenseInfo.LicenseID;
        }

        public string NationalNo
        {
            get => PersonInfo?.NationalNo ?? "???";

        }
        public DateTime IssueDate
        {
            get => LicenseInfo?.IssueDate ?? DateTime.MinValue;
        }
        public DateTime ExpirationDate
        {
            get => LicenseInfo?.ExpirationDate ?? DateTime.MinValue; 
        }
        public string Notes
        { 
            get => (LicenseInfo.Notes == string.Empty)? "No Notes" : LicenseInfo.Notes;
        }
        public bool IsActived
        {
            get => (LicenseInfo.IsActive);
        }

        public DateTime DateOfBirth
        {
            get => PersonInfo?.DateOfBirth ?? DateTime.MinValue;
        }

        public string IssueReason
        {
            get
            {
                    switch (LicenseInfo.IssueReason)
                    {
                        case clsLicenseModel.enIssueReason.FirstTime:
                            return "First Time";
                        case clsLicenseModel.enIssueReason.Renew:
                            return "Renew";
                        case clsLicenseModel.enIssueReason.ReplacementForLost:
                            return "Replacement For Lost";
                        case clsLicenseModel.enIssueReason.ReplacementForDamaged:
                            return "Replacement For Damaged";
                        default:
                            return "Unknown";
                    }
                
            }
      }
        public byte Gendor
        {
          get => PersonInfo?.Gendor ?? 0;
        }
        public int DriverID
        {
            get => LicenseInfo.DriverID;
        }

        public string PersonName
        {
            get => PersonInfo?.PersonInfo.FullName ?? "???";
        }
        public string PersonalPhoto
        {
           get => PersonInfo?.ImagePath ?? "Non";
        }
        public bool IsDitained 
        {
            get => clsDetainedLicense.IsLicenseDetained(LicenseID);
        }

        public clsLicenses()
        {
             LicenseInfo = new clsLicenseModel();
            _Mode = enMode.AddNew; 
        }

        private clsLicenses(clsLicenseModel model)
        {
             LicenseInfo = model;
            _Mode = enMode.Update;
        }

        public static clsLicenses Find(int LicenseID)
        {
            clsLicenseModel LicenseInfo = clsLicensesData.GetLicenseInfoByLicenseID(LicenseID);
          
            if (LicenseInfo != null)
            {
                return new clsLicenses(LicenseInfo);
            }

            return null;
        }

        static public bool IsLicenseExist(int PersonID, int LicenseClassID)
        {
            return clsLicensesData.IsLicenseExist(PersonID, LicenseClassID);
        }

        static public int GetActiveLicenseIDByPersonIDAndLicenseClassID(int PersonID, int LicenseClassID)
        {
            return clsLicensesData.GetActiveLicenseIDByPersonIDAndLicenseClassID(PersonID, LicenseClassID);
        }
      

        static public DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicenses();
        }

        private bool _AddNewLicense()
        {
            int id = clsLicensesData.AddNewLicense(LicenseInfo);
            LicenseInfo.LicenseID = id;
            // مزال هنا مفروض نتأكد من هدا الشخص هل أول مرة يتم إصدار له رخصة او لا في حال كان لديه رخصه من قبل فإن لا نضيف في جدول السائقين 
            //وإذا كان أول مرة يتم إصدار له رخصة فإن نضيف في جدول السائقين
            return id != (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        }

        private bool _UpdateLicense()
        {
            return clsLicensesData.UpdateLicense(LicenseInfo);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLicense();

                default:
                    return false;
            }
        }
    }
}