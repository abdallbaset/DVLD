using DVLD_DataAccess;
using DVLD_Model;
using System;
using System.ComponentModel;
using System.Data;
namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplications
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;
        private clsLocalDrivingLicenseApplicationsModel LocalDrivingLicenseApplicationInfo { get; set; }
        private clsApplications Application { get; set; }
        private clsLicenseClasses LicenseClasses { get; set; }
        public int ApplicantPersonID
        {
            get => Application.ApplicationInfo.ApplicantPersonID;
            set => Application.ApplicationInfo.ApplicantPersonID = value;
        }
        public DateTime ApplicationDate
        {
            get => Application.ApplicationInfo.ApplicationDate;
            set => Application.ApplicationInfo.ApplicationDate = value;
        }
        public clsApplicationTypesModel.enApplicationTypes ApplicationTypeID
        {
            get => Application.ApplicationInfo.ApplicationTypeID;
            set => Application.ApplicationInfo.ApplicationTypeID = value;
        }
        public double PaidFees
        {
            get => _GetApplictionsFeez();
            set => Application.ApplicationInfo.PaidFees = value;
        }

        public clsApplicationModel.enApplicationStatus ApplicationStatus
        {
            get => Application.ApplicationInfo.ApplicationStatus;
            set => Application.ApplicationInfo.ApplicationStatus = value;
        }

        public DateTime LastStatusDate
        {
            get => Application.ApplicationInfo.LastStatusDate;
            set => Application.ApplicationInfo.LastStatusDate = value;
        }

        public int CreatedByUserID
        {
            get => Application.ApplicationInfo.CreatedByUserID;
            set => Application.ApplicationInfo.CreatedByUserID = value;
        }

        public int LicenseClassID
        {
            get => (int)LocalDrivingLicenseApplicationInfo.LicenseClassID;
            set => LocalDrivingLicenseApplicationInfo.LicenseClassID = (clsLicenseClassesModel.enLicenseClass)value;
        }
         public int ApplicationID
        {
            get =>  Application.ApplicationInfo.ApplicationID;
        }
  
        public int LocalDrivingLicenseApplicationID
        {
            get => LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID;
        }
        public string ClassName
        {
            get => LicenseClasses.ClassName;
        }

        public string CreatedByUserName
        {
            get
            {
                if (Application == null || Application.ApplicationInfo == null)
                {
                    return "Unknown";
                }
                return Application.CreatedByUserName ;
            }
        }
        public string ApplicantFullName
        {
            get
            {
                if (Application == null || Application.ApplicationInfo == null)
                {
                    return "Unknown";
                }
                return Application.ApplicantName;
            }
        }
        private double _GetApplictionsFeez() 
        {
            if (Application == null || Application.ApplicationInfo == null)
            {
                return 0;
            }
            return clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.NewLocalDrivingLicenseService).ApplicationFees;
        }

        public clsLocalDrivingLicenseApplications()
        {
            LocalDrivingLicenseApplicationInfo = new clsLocalDrivingLicenseApplicationsModel();
            Application = new clsApplications();
            LicenseClasses = new clsLicenseClasses();
            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplications(clsLocalDrivingLicenseApplicationsModel info)
        {
            LocalDrivingLicenseApplicationInfo = info;
            Application = clsApplications.Find(LocalDrivingLicenseApplicationInfo.ApplicationID);
            LicenseClasses = clsLicenseClasses.Find((int)LocalDrivingLicenseApplicationInfo.LicenseClassID);
            _Mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplications FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplicationsModel LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplicationInfo != null)
            {
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationInfo);
            }

            return null;
        }

        public static clsLocalDrivingLicenseApplications FindByApplicationID(int ApplicationID)
        {
            clsLocalDrivingLicenseApplicationsModel LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationInfoByApplicationID(ApplicationID);

            if (LocalDrivingLicenseApplicationInfo != null)
            {
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationInfo);
            }

            return null;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
          
            LocalDrivingLicenseApplicationInfo.ApplicationID = ApplicationID;

            int LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicense(LocalDrivingLicenseApplicationInfo);
            LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            return LocalDrivingLicenseApplicationID != (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
        

            return clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicense(LocalDrivingLicenseApplicationInfo);
        }

       public int IssueLicenseForTheFirstTime(string Notes ,int UserID)
        {
            clsLicenses License = new clsLicenses();
            License.ApplicationID = ApplicationID;
            License.LicenseClassID = LicenseClassID;
            License.CreatedByUserID = UserID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(LicenseClasses.DefaultValidityLength);
            License.Notes = Notes;
            License.IsActive = true;
            License.PaidFees = PaidFees;
            License.IssueReason = clsLicenseModel.enIssueReason.FirstTime;

            if (License.Save())
            {
               return License.LicenseID;
            }
            else
                            {
                return (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
            }
        }

        public bool Save()
        {

            if (Application == null || Application.ApplicationInfo == null)
            {
                return false;
            }
            if (!Application.Save())
            {
                return false;
            }

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();

                default:
                    return false;
            }
        }


        static public DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplications();
        }

        static public bool DeleteLocalDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID)?.ApplicationID
                ?? (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

            if (ApplicationID == (int)clsEnumerationsModel.enIdentityStatus.NonExistent)
            {
                return false;
            }

            if (!clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicense(LocalDrivingLicenseApplicationID))
            {
                return false;
            }

            return clsApplications.DeleteApplication(ApplicationID);
        }
        static public bool CancelApplication(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID)?.ApplicationID
                ?? (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

            if (ApplicationID == (int)clsEnumerationsModel.enIdentityStatus.NonExistent)
            {
                return false;
            }
            clsApplications Applications = clsApplications.Find(ApplicationID);

           if (Applications == null || Applications.ApplicationInfo == null)
            {
                return false;
            }

            return Applications.CancelApplication();
        }

   
        static public bool IsExist(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsData.IsLocalDrivingLicenseExist(LocalDrivingLicenseApplicationID);
        }
        public int GetActiveLicensesID()
        {
            return clsLicensesData.GetActiveLicenseIDByPersonIDAndLicenseClassID(ApplicantPersonID,LicenseClassID);
        }
    }
}