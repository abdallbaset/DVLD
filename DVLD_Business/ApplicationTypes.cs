using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using DVLD_Model;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public clsApplicationTypesModel ApplicationTypeInfo { get; set; }

        public double ApplicationFees
        {
            get => ApplicationTypeInfo.ApplicationFees;
        }
        private clsApplicationType()
        {
            ApplicationTypeInfo = new clsApplicationTypesModel();
            _Mode = enMode.AddNew;
        }
        private clsApplicationType(clsApplicationTypesModel ApplicationTypeInfo)
        {
            this.ApplicationTypeInfo = ApplicationTypeInfo;
            _Mode = enMode.Update;

        }

        
        public static clsApplicationType Find(clsApplicationTypesModel.enApplicationTypes ApplicationTypeID)
        {
            clsApplicationTypesModel ApplicationTypeInfo = clsApplicationTypesData.GetApplicationTypeInfoByID(ApplicationTypeID);

            if (ApplicationTypeInfo != null)
            {
                return new clsApplicationType(ApplicationTypeInfo);
            }

            return null;
        }

        static public DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }
        private bool _AddNewApplicationType()
        {
            ApplicationTypeInfo.ApplicationTypeID = (clsApplicationTypesModel.enApplicationTypes)clsApplicationTypesData.AddNewApplicationType(ApplicationTypeInfo);
            return (ApplicationTypeInfo.ApplicationTypeID != clsApplicationTypesModel.enApplicationTypes.NotSpecified);
        }
        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType(ApplicationTypeInfo);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateApplicationType();

                default:
                    return false;
            }
        }
    }
}
