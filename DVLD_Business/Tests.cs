using System;
using System.Data;
using DVLD_DataAccess;
using DVLD_Model;

namespace DVLD_Business
{
    public class clsTests
    {
        public enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;
        public clsTestModel TestInfo { get; set; }
        
        public int TestID
        {
            get => TestInfo.TestID;
        }

        public int TestAppointmentID
        {
            get => TestInfo.TestAppointmentID;
            set => TestInfo.TestAppointmentID = value;
        }

        public int TestResult
        {
            get => (int)TestInfo.TestResult;
            set => TestInfo.TestResult =(clsTestModel.enTestResult)value;
        }
        public string Notes
        {
            get => TestInfo.Notes;
            set => TestInfo.Notes = value;
        }
        public int CreatedByUserID
        {
            get => TestInfo.CreatedByUserID;
            set => TestInfo.CreatedByUserID = value;
        }

        public clsTests()
        {
            TestInfo = new clsTestModel();
            _Mode = enMode.AddNew;
        }

        private clsTests(clsTestModel model)
        {
            TestInfo = model;
            _Mode = enMode.Update;
        }

        static public clsTests Find(int TestID)
        {
            clsTestModel testInfo = clsTestsData.GetTestInfoByID(TestID);

            if (testInfo != null)
            {
                return new clsTests(testInfo);
            }

            return null;
        }
        static public clsTests FindByTestAppointmentID(int TestAppointmentID)
        {
            clsTestModel testInfo = clsTestsData.GetTestInfoByTestAppointmentID(TestAppointmentID);

            if (testInfo != null)
            {
                return new clsTests(testInfo);
            }

            return null;
        }

        static public int GetTestPassedCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetTestPassedCount(LocalDrivingLicenseApplicationID);
        }
        static public int GetTotalTrialsPerTest(int LocalDrivingLicenseApplicationID , int TestTypeID)
        {
            return clsTestsData.GetTotalTrialsPerTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }


        static public bool IsAllTestsPassed(int LocalDrivingLicenseApplicationID)
        {
            return GetTestPassedCount(LocalDrivingLicenseApplicationID) == 3;
        }

        static public DataTable GetAllTests()
        {
            return clsTestsData.GetAllTests();
        }

        private bool _AddNewTest()
        {
            TestInfo.TestID = clsTestsData.AddNewTest(TestInfo);
            return TestID != (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
        }

        private bool _UpdateTest()
        {
            return clsTestsData.UpdateTest(TestInfo);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateTest();

                default:
                    return false;
            }
        }
    }
}