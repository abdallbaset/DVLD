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

        public int ApplicationID
        {
            get => ApplicationInfo.ApplicationID;
        }
        public int ApplicantPersonID
        {
            get => ApplicationInfo.ApplicantPersonID;
        }
        public double PaidFees
        {
            get => ApplicationInfo.PaidFees;
        }

        public string ApplicantName
        {
            get 
            {
                clsPeople Person = clsPeople.Find(ApplicationInfo.ApplicantPersonID);
                return (Person != null) ? Person.FullName : "???";
            }
        }

        public string Status
        {
            get
            {
                switch (ApplicationInfo.ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return enApplicationStatus.New.ToString();
                    case enApplicationStatus.Cancelled:
                        return enApplicationStatus.Cancelled.ToString();
                    case enApplicationStatus.Completed:
                        return enApplicationStatus.Completed.ToString();
                    default:
                        return "Unknown";
                }

            }
        }

        public string ApplicationType
        {
            get
            {
                clsApplicationType appType = clsApplicationType.Find(ApplicationInfo.ApplicationTypeID);
                return (appType != null) ? appType.ApplicationTypeInfo.ApplicationTypeTitle : "Unknown";
            }
        }

        public DateTime ApplicationDate
        {
            get => ApplicationInfo.ApplicationDate;
        }

        public DateTime LastStatusDate
        {
            get => ApplicationInfo.LastStatusDate;
        }

        public string CreatedByUser
        {
            get
            {
                clsUser user = clsUser.FindByUserID(ApplicationInfo.CreatedByUserID);
                return (user != null) ? user.UserName : "Unknown";
            }
        }
        public clsApplications()
        {
            ApplicationInfo = new clsApplicationModel();
            _Mode = enMode.AddNew;
        }

        private clsApplications(clsApplicationModel application)
        {
            ApplicationInfo = application;
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
            return (ApplicationInfo.ApplicationID != (int)clsApplicationModel.enIdentityStatus.NonExistent);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplication(ApplicationInfo);
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
