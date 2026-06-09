using DVLD_DataAccess;
using DVLD_Model;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using static DVLD_Model.clsLicenseModel;

namespace DVLD_Business
{
    public class clsLicenses
    {
        public enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;

        private clsLicenseModel _LicenseInfo { get; set; }
        private clsPeople _PersonInfo = null;
        private clsLicenseClasses _LicenseClasses = null;
        public clsDetainedLicense DetainedInfo { get; set; }
        public int LicenseID
        {
            get => _LicenseInfo.LicenseID;
            set => _LicenseInfo.LicenseID = value;
        }

        public int LicenseClassID
        {
            get => _LicenseInfo.LicenseClassID;
            set => _LicenseInfo.LicenseClassID = value;
        }

        public int ApplicationID
        {
            get => _LicenseInfo.ApplicationID;
            set => _LicenseInfo.ApplicationID = value;
        }

        public int DriverID
        {
            get => _LicenseInfo.DriverID;
            set => _LicenseInfo.DriverID = value;
        }

        public DateTime IssueDate
        {
            get => _LicenseInfo.IssueDate;
            set => _LicenseInfo.IssueDate = value;
        }

        public DateTime ExpirationDate
        {
            get => _LicenseInfo.ExpirationDate;
            set => _LicenseInfo.ExpirationDate = value;
        }

        public enIssueReason IssueReason
        {
            get => _LicenseInfo.IssueReason;
            set => _LicenseInfo.IssueReason = value;
        }

        public double PaidFees
        {
            get => _LicenseInfo.PaidFees;
            set => _LicenseInfo.PaidFees = value;
        }

        public bool IsActive
        {
            get => _LicenseInfo.IsActive;
            set => _LicenseInfo.IsActive = value;
        }

        public string Notes
        {
            get => _LicenseInfo.Notes;
            set => _LicenseInfo.Notes = value;
        }

        public int CreatedByUserID
        {
            get => _LicenseInfo.CreatedByUserID;
            set => _LicenseInfo.CreatedByUserID = value;
        }

        private clsPeople PersonInfo
        {
            get
            {
                if (_PersonInfo == null && _LicenseInfo != null)
                {
                    int personID = clsApplications.Find(_LicenseInfo.ApplicationID)?.ApplicantPersonID
                                   ?? (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
                    _PersonInfo = clsPeople.Find(personID);
                }
                return _PersonInfo;
            }
        }

        public string ClassName
        {
            get
            {
                if (_LicenseClasses == null && _LicenseInfo != null)
                {
                    _LicenseClasses = clsLicenseClasses.Find(_LicenseInfo.LicenseClassID);
                }

                return _LicenseClasses?.ClassName ?? "???";
            }

        }
        public double LicenseFees
        {
            get
            {
                if (_LicenseClasses == null && _LicenseInfo != null)
                {
                    _LicenseClasses = clsLicenseClasses.Find(_LicenseInfo.LicenseClassID);
                }

                return _LicenseClasses?.ClassFees ?? 0;
            }

        }
        public byte DefaultValidityLength
        {
            get
            {
                if (_LicenseClasses == null && _LicenseInfo != null)
                {
                    _LicenseClasses = clsLicenseClasses.Find(_LicenseInfo.LicenseClassID);
                }

                return _LicenseClasses?.DefaultValidityLength ?? 0;
            }

        }
        public int PersonID
        {
            get => PersonInfo.PersonID;
        }
        public string NationalNo
        {
            get => PersonInfo?.NationalNo ?? "???";

        }

        public DateTime DateOfBirth
        {
            get => PersonInfo?.DateOfBirth ?? DateTime.MinValue;
        }
        public string IssueReasonTitle
        {
            get
            {
                switch (_LicenseInfo.IssueReason)
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
            _LicenseInfo = new clsLicenseModel();
            _Mode = enMode.AddNew;
        }
        private clsLicenses(clsLicenseModel model)
        {
            _LicenseInfo = model;
            _PersonInfo = clsPeople.Find(PersonID);
            _LicenseClasses = clsLicenseClasses.Find(_LicenseInfo.LicenseClassID);
             DetainedInfo = clsDetainedLicense.FindByLicenseID(LicenseID);
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
        static public DataTable GetAllLicensesByDriverID(int DriverID)
        {
            return clsLicensesData.GetAllLicensesByDriverID(DriverID);
        }

        private bool _AddNewLicense()
        {
            int id = clsLicensesData.AddNewLicense(_LicenseInfo, PersonID);
            _LicenseInfo.LicenseID = id;
            return id != (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        }

        private bool _UpdateLicense()
        {
            return clsLicensesData.UpdateLicense(_LicenseInfo);
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

        public clsLicenses RenewLicense(string Notes, int UserID)
        {
            clsLicenseModel newLicense = new clsLicenseModel
            {
                LicenseID = this.LicenseID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength),
                IssueReason = enIssueReason.Renew,
                PaidFees = this.LicenseFees,
                IsActive = true,
                Notes = Notes,
                CreatedByUserID = UserID
            };

            int newLicenseID = clsLicensesData.RenewOrReplacementLicense(newLicense, this.PersonID, clsApplicationTypesModel.enApplicationTypes.RenewDrivingLicenseService);

            if (newLicenseID != (int)clsEnumerationsModel.enIdentityStatus.NonExistent)
            {
                return Find(newLicenseID);
            }
            else
                return null;
        }
        public clsLicenses Replacement(clsLicenseModel.enIssueReason IssueReason, int UserID)
        {
            clsLicenseModel newLicense = new clsLicenseModel
            {
                LicenseID = this.LicenseID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                IssueReason = IssueReason,
                PaidFees = this.LicenseFees,
                IsActive = true,
                Notes = this.Notes,
                CreatedByUserID = UserID
            };

            clsApplicationTypesModel.enApplicationTypes ApplicationTypeID = clsApplicationTypesModel.enApplicationTypes.NotSpecified;

            if (IssueReason == enIssueReason.ReplacementForDamaged)
            {
                ApplicationTypeID = clsApplicationTypesModel.enApplicationTypes.ReplacementForDamagedDrivingLicense;
            }
            else
            {
                ApplicationTypeID = clsApplicationTypesModel.enApplicationTypes.ReplacementForLostDrivingLicense;
            }


            int newLicenseID = clsLicensesData.RenewOrReplacementLicense(newLicense, this.PersonID, ApplicationTypeID);

            if (newLicenseID != (int)clsEnumerationsModel.enIdentityStatus.NonExistent)
            {
                return Find(newLicenseID);
            }
            else
                return null;
        }

        public bool IsLicenseExpired()
        {
            return ExpirationDate < DateTime.Now;
        }
        public int Detain(double FineFees, int UserID)
        {
            clsDetainedLicense DetainedInfo = new clsDetainedLicense();
            DetainedInfo.LicenseID = this.LicenseID;
            DetainedInfo.FineFees = FineFees;
            DetainedInfo.DetainDate = DateTime.Now;
            DetainedInfo.CreatedByUserID = UserID;
            DetainedInfo.IsReleased = false;

            if (!DetainedInfo.Save())
            {
                return (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
            }

            return DetainedInfo.DetainID;
        }

        public bool ReleaseDetainedLicense(int UserID)
        {

            DetainedInfo.ReleasedByUserID = UserID;
            DetainedInfo.PersonID = this.PersonID;

            return DetainedInfo.ReleaseDetainedLicense();
        }
    }
}