using DVLD_DataAccess;
using DVLD_Model;
using System;
using System.Data;
using static DVLD_Model.clsApplicationModel;

namespace DVLD_Business
{
    public class clsApplications
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;
        public clsApplicationModel ApplicationInfo { get; set; }
        private clsPeople _Person;
        private clsApplicationType _appType;
        public int ApplicationID
        {
            get => ApplicationInfo.ApplicationID;
        }
        public int ApplicantPersonID
        {
            get => ApplicationInfo.ApplicantPersonID;
            set => ApplicationInfo.ApplicantPersonID = value;
        }
        public double PaidFees
        {
            get => ApplicationInfo.PaidFees;
            set => ApplicationInfo.PaidFees = value;
        }

        public string ApplicantName
        {
            get 
            {
                return (_Person != null) ? _Person.FullName : "???";
            }
        }

        public enApplicationStatus Status
        {
            get => ApplicationInfo.ApplicationStatus;

            set => ApplicationInfo.ApplicationStatus =  value;
        }

        public string ApplicationTypeName
        {
            get
            {
                return (_appType != null) ? _appType.ApplicationTypeInfo.ApplicationTypeTitle : "Unknown";
            }
        }
        public clsApplicationTypesModel.enApplicationTypes ApplicationTypeID
        {
            get => ApplicationInfo.ApplicationTypeID;
            set => ApplicationInfo.ApplicationTypeID = value;
               
        }

        public DateTime ApplicationDate
        {
            get => ApplicationInfo.ApplicationDate;
            set => ApplicationInfo.ApplicationDate = value;
        }

        public DateTime LastStatusDate
        {
            get => ApplicationInfo.LastStatusDate;
            set => ApplicationInfo.LastStatusDate = value;
        }

        public string CreatedByUserName
        {
            get
            {
                clsUser user = clsUser.FindByUserID(ApplicationInfo.CreatedByUserID);
                return (user != null) ? user.UserName : "Unknown";
            }
        }
        public int CreatedByUserID
        {
            get => ApplicationInfo.CreatedByUserID;
            set => ApplicationInfo.CreatedByUserID = value;
        }

        public clsApplications()
        {
            ApplicationInfo = new clsApplicationModel();
            _Mode = enMode.AddNew;
        }

        private clsApplications(clsApplicationModel application)
        {
            ApplicationInfo = application;
            _Person = clsPeople.Find(ApplicationInfo.ApplicantPersonID);
            _appType = clsApplicationType.Find(ApplicationInfo.ApplicationTypeID);
            _Mode = enMode.Update;
        }

        public static clsApplications Find(int ApplicationID)
        {
            clsApplicationModel appInfo = clsApplicationsData.GetApplicationInfoByID(ApplicationID);

            if (appInfo != null)
            {
                return new clsApplications(appInfo);
            }

            return null;
        }

        private bool _AddNewApplication()
        {
            ApplicationInfo.ApplicationID = clsApplicationsData.AddNewApplication(ApplicationInfo);
            return (ApplicationInfo.ApplicationID != (int)clsEnumerationsModel.enIdentityStatus.NonExistent);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplication(ApplicationInfo);
        }
        public bool CancelApplication( )
        {
            return clsApplicationsData.UpdateStatus(ApplicationID,enApplicationStatus.Cancelled);
        }
        public bool SetApplicationCompleted()
        {
            return clsApplicationsData.UpdateStatus(ApplicationID,enApplicationStatus.Completed);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateApplication();

                default:
                    return false;
            }
        }

        static public DataTable ListApplications()
        {
            return clsApplicationsData.GetAllApplications();
        }

        static public bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationsData.DeleteApplication(ApplicationID);
        }

        static public bool IsExist(int ApplicationID)
        {
            return clsApplicationsData.IsApplicationExist(ApplicationID);
        }
       static public int  GetActiveApplicationIDForLicenseClass(int PersonID, clsApplicationTypesModel.enApplicationTypes ApplicationTypes, int LicenseClassID)
        {
            return clsApplicationsData.GetActiveApplicationIDForLicenseClass(PersonID, ApplicationTypes, LicenseClassID);
        }


     

    }
}
