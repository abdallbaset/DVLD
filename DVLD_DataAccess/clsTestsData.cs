using DVLD_Model;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsTestsData
    {
        static public clsTestModel GetTestInfoByID(int TestID)
        {
            clsTestModel Test = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From Tests where TestID = @TestID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@TestID", TestID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Test = new clsTestModel();

                                Test.TestID = Convert.ToInt32(reader["TestID"]);
                                Test.TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                                Test.TestResult = Convert.ToBoolean(reader["TestResult"]);
                                Test.Notes = ( reader["Notes"] == DBNull.Value) ? string.Empty : reader["Notes"].ToString();
                                Test.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return Test;
        }
        static public clsTestModel GetTestInfoByTestAppointmentID(int TestAppointmentID)
        {
            clsTestModel Test = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From Tests where TestAppointmentID = @TestAppointmentID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Test = new clsTestModel();

                                Test.TestID = Convert.ToInt32(reader["TestID"]);
                                Test.TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                                Test.TestResult = Convert.ToBoolean( reader["TestResult"]);
                                Test.Notes = ( reader["Notes"] == DBNull.Value) ? string.Empty : reader["Notes"].ToString();
                                Test.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return Test;
        }

        static public int AddNewTest(clsTestModel Test)
        {
            int TestID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID) " +
                             "OUTPUT INSERTED.TestID " +
                             "VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);" +
                             "UPDATE TestAppointments SET  IsLocked = @IsLocked "
                                + "WHERE TestAppointmentID = @TestAppointmentID;";

                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@TestAppointmentID", Test.TestAppointmentID);
                    cmd.Parameters.AddWithValue("@TestResult", Test.TestResult);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Test.Notes) ? (object)DBNull.Value : Test.Notes);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", Test.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@IsLocked", clsEnumerationsModel.enAppointmentStatus.Completed);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            TestID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return TestID;
        }

        static public bool UpdateTest(clsTestModel Test)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE Tests SET  TestAppointmentID = @TestAppointmentID,TestResult = @TestResult, Notes = @Notes, CreatedByUserID = @CreatedByUserID " +
                             "WHERE TestID = @TestID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@TestAppointmentID", Test.TestAppointmentID);
                    cmd.Parameters.AddWithValue("@TestResult", Test.TestResult);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Test.Notes) ? (object)DBNull.Value : Test.Notes);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", Test.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@TestID", Test.TestID);

                    try
                    {
                        Connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        IsUpdated = rows > 0;
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return IsUpdated;
        }

        static public DataTable GetAllTests()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID FROM Tests;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return dataTable;
        }

        static public byte GetTestPassedCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"SELECT Count(TestID) AS PasswdTestAcount
                         FROM Tests 
                         INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                         WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
						 AND Tests.TestResult = 1";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null && byte.TryParse(Result.ToString(), out byte count))
                        {
                            PassedTestCount = count;
                        }
                        
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return PassedTestCount;
        }
        static public byte GetTotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsEnumerationsModel.enTestType TestTypeID)
        {
            byte TotalTrials = 0;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"SELECT Count(*) 
                              FROM Tests 
                              INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                              WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                               AND TestAppointments.TestTypeID = @TestTypeID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null && byte.TryParse(Result.ToString(), out byte count))
                        {
                            TotalTrials = count;
                        }
                        
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return TotalTrials;
        }
    }
}