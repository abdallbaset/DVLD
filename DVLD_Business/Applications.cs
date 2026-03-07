using DVLD_DataAccess;
using DVLD_Model;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{
    public class clsApplications
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;
        public clsApplicationModel ApplicationInfo { get; set; }

        public double ApplicationFees
        {
            get => _GetApplictionsFeez();
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

        private double _GetApplictionsFeez() 
        {
            clsApplicationType appType = clsApplicationType.Find(ApplicationInfo.ApplicationTypeID);
            return (appType != null) ? Convert.ToDouble(appType.ApplicationTypeInfo.ApplicationFees) : 0;
        }

       static public int  GetActiveApplicationIDForLicenseClass(int PersonID, clsApplicationTypesModel.enApplicationTypes ApplicationTypes, int LicenseClassID)
        {
            return clsApplicationsData.GetActiveApplicationIDForLicenseClass(PersonID, ApplicationTypes, LicenseClassID);
        }
    }
}
