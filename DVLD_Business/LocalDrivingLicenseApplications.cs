using DVLD_DataAccess;
using DVLD_Model;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplications
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;
        public clsLocalDrivingLicenseApplicationsModel LocalDrivingLicenseApplicationInfo { get; set; }
        static public clsApplications Application { get; set; }

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
        static public int ApplicationID
        {
            get => Application.ApplicationInfo.ApplicationID;
        }
        public int LocalDrivingLicenseApplicationID
        {
            get => LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID;
        }

        public string CreatedByUserName
        {
            get => _GetCreatedByUserName();
        }

        private double _GetApplictionsFeez()
        {
            if (Application == null || Application.ApplicationInfo == null)
            {
                return 0;
            }
            return clsApplicationType.Find(clsApplicationTypesModel.enApplicationTypes.NewLocalDrivingLicenseService).ApplicationFees;
        }
        private string _GetCreatedByUserName()
        {
            if (Application == null || Application.ApplicationInfo == null)
            {
                return "Unknown";
            }
            clsUser User = clsUser.FindByUserID(Application.ApplicationInfo.CreatedByUserID);
            return (User != null) ? User.UserInfo.UserName : "[Unknown]";

        }
        public clsLocalDrivingLicenseApplications()
        {
            LocalDrivingLicenseApplicationInfo = new clsLocalDrivingLicenseApplicationsModel();
            Application = new clsApplications();
            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplications(clsLocalDrivingLicenseApplicationsModel info)
        {
            LocalDrivingLicenseApplicationInfo = info;
            Application = clsApplications.Find(LocalDrivingLicenseApplicationInfo.ApplicationID);
            _Mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplications FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplicationsModel info = clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID);

            if (info != null)
            {
                return new clsLocalDrivingLicenseApplications(info);
            }

            return null;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            if (Application == null || Application.ApplicationInfo == null)
            {
                return false;
            }
            if (!Application.Save())
            {
                return false;
            }

            LocalDrivingLicenseApplicationInfo.ApplicationID = ApplicationID;

            int LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicense(LocalDrivingLicenseApplicationInfo);
            LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            return LocalDrivingLicenseApplicationID != (int)clsLocalDrivingLicenseApplicationsModel.enIdentityStatus.NonExistent;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            if(Application == null || Application.ApplicationInfo == null)
            {
                return false;
            }
            if (!Application.Save())
            {
                return false;
            }

            LocalDrivingLicenseApplicationInfo.ApplicationID = ApplicationID; 

            return clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicense(LocalDrivingLicenseApplicationInfo);
        }

        public bool Save()
        {
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


        static public DataTable GetAllLocalDrivingLicenses()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenses();
        }

        static public bool DeleteLocalDrivingLicense(int LocalDrivingLicenseApplicationID)
        {

          
             if(!clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicense(LocalDrivingLicenseApplicationID))
             {
                return false;
             }

            if (Application == null || Application.ApplicationInfo == null)
            {
                return false;
            }

            return clsApplicationsData.DeleteApplication(ApplicationID);
        }

        static public bool IsExist(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsData.IsLocalDrivingLicenseExist(LocalDrivingLicenseApplicationID);
        }
    }
}