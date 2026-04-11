using DVLD_Model;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentsData
    {
        static public clsTestAppointmentModel GetTestAppointmentInfoByID(int TestAppointmentID)
        {
            clsTestAppointmentModel AppointmentInfo = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From TestAppointments where TestAppointmentID = @TestAppointmentID;";
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
                                AppointmentInfo = new clsTestAppointmentModel();

                                AppointmentInfo.TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                                AppointmentInfo.LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                                AppointmentInfo.TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                                AppointmentInfo.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                                AppointmentInfo.PaidFees = Convert.ToDouble(reader["PaidFees"]);
                                AppointmentInfo.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                AppointmentInfo.IsLocked = Convert.ToBoolean(reader["IsLocked"]);
                                AppointmentInfo.RetakeTestApplicationID = (reader["RetakeTestApplicationID"] == DBNull.Value) ? (int)clsEnumerationsModel.enIdentityStatus.NonExistent : Convert.ToInt32(reader["RetakeTestApplicationID"]);

                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return AppointmentInfo;
        }

        static public int AddNewTestAppointment(clsTestAppointmentModel Appointment)
        {
            int TestAppointmentID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID) " +
                             "OUTPUT INSERTED.TestAppointmentID " +
                             "VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@TestTypeID", Appointment.TestTypeID);
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", Appointment.LocalDrivingLicenseApplicationID);
                    cmd.Parameters.AddWithValue("@AppointmentDate", Appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@PaidFees", Appointment.PaidFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", Appointment.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@IsLocked", Appointment.IsLocked);
                    cmd.Parameters.AddWithValue("@RetakeTestApplicationID", Appointment.RetakeTestApplicationID == (int)clsEnumerationsModel.enIdentityStatus.NonExistent ?
                        (object)DBNull.Value : Appointment.RetakeTestApplicationID);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            TestAppointmentID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return TestAppointmentID;
        }

        static public bool UpdateTestAppointment(clsTestAppointmentModel Appointment)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"UPDATE TestAppointments SET 
                               AppointmentDate = @AppointmentDate,
                               WHERE TestAppointmentID = @TestAppointmentID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@AppointmentDate", Appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@TestAppointmentID", Appointment.TestAppointmentID);

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

        static public DataTable GetAllTestAppointments()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID FROM TestAppointments;";
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

        static public DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked " +
                             "FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = @TestTypeID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        static public bool HasActiveAppointment(int LocalDrivingLicenseApplicationID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"if Exists(select 1 From TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                AND IsLocked = 0) select 1 else select 0";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            IsExist = Convert.ToBoolean(Result);
                        }
                    }
                    catch (Exception)
                    {                        //Errors will be recorded in the LOG file later
                    }
                }
            }
            return IsExist;
        }
    }

}