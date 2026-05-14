using System;
using System.Data;
using DVLD_DataAccess;
using DVLD_Model;

namespace DVLD_Business
{
    public class clsTestAppointments
    {
        public enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;

        private clsTestAppointmentModel _AppointmentInfo { get; set; }
        private clsLocalDrivingLicenseApplications _LocalApp { get; set; }
        public int TestAppointmentID { get => _AppointmentInfo.TestAppointmentID; }
        public int LocalDrivingLicenseApplicationID {
            get => _AppointmentInfo.LocalDrivingLicenseApplicationID;
            set => _AppointmentInfo.LocalDrivingLicenseApplicationID = value;
        }
        public int TestTypeID {
            get => _AppointmentInfo.TestTypeID;
            set => _AppointmentInfo.TestTypeID = value;
        }
        public DateTime AppointmentDate {
            get => _AppointmentInfo.AppointmentDate;
            set => _AppointmentInfo.AppointmentDate = value;
        }
        public double PaidFees {
            get => _AppointmentInfo.PaidFees;
            set => _AppointmentInfo.PaidFees = value;
        }
        public int CreatedByUserID {
            get => _AppointmentInfo.CreatedByUserID;
            set => _AppointmentInfo.CreatedByUserID = value;
        }
        public bool IsLocked {
            get => _AppointmentInfo.IsLocked;
            set => _AppointmentInfo.IsLocked = value;
        }
        public int RetakeTestApplicationID {
            get => _AppointmentInfo.RetakeTestApplicationID;
            set => _AppointmentInfo.RetakeTestApplicationID = value;
        }
        public string className { get => _LocalApp.ClassName; }
        public string ApplicantFullName { get => _LocalApp.ApplicantFullName; }

        public clsTestAppointments()
        {
            _AppointmentInfo = new clsTestAppointmentModel();
            _Mode = enMode.AddNew;
        }

        private clsTestAppointments(clsTestAppointmentModel AppointmentInfo)
        {
            _AppointmentInfo = AppointmentInfo;
            _LocalApp = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_AppointmentInfo.LocalDrivingLicenseApplicationID);
            _Mode = enMode.Update;
        }

        static public clsTestAppointments Find(int TestAppointmentID)
        {
            clsTestAppointmentModel TestAppointmentInfo = clsTestAppointmentsData.GetTestAppointmentInfoByID(TestAppointmentID);

            if (TestAppointmentInfo != null)
            {
                return new clsTestAppointments(TestAppointmentInfo);
            }

            return null;
        }
        static public bool HasActiveAppointment(int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentsData.HasActiveAppointment(LocalDrivingLicenseApplicationID);
        }
        static public DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentsData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        static public DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentsData.GetAllTestAppointments();
        }

        private bool _AddNewTestAppointment()
        {
            int TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointment(_AppointmentInfo);
            _AppointmentInfo.TestAppointmentID = TestAppointmentID;
            return TestAppointmentID != (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsData.UpdateTestAppointment(_AppointmentInfo);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateTestAppointment();

                default:
                    return false;
            }
        }
    }
}