using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Model;
using Infrastructure.Logging;

namespace DVLD_DataAccess
{
    public class clsDriversData
    {
        static public clsDriverModel GetDriverInfoByDriverID(int DriverID)
        {
            clsDriverModel Driver = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select DriverID, PersonID, CreatedByUserID, CreatedDate From Drivers where DriverID = @DriverID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Driver = new clsDriverModel();

                                Driver.DriverID = Convert.ToInt32(reader["DriverID"]);
                                Driver.PersonID = Convert.ToInt32(reader["PersonID"]);
                                Driver.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                Driver.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventViewerLogger.LogError($"Database Error in GetDriverInfoByDriverID for DriverID: {DriverID}", ex);
                    }
                }
            }

            return Driver;
        }

        static public clsDriverModel GetDriverInfoByPersonID(int PersonID)
        {
            clsDriverModel Driver = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select DriverID, PersonID, CreatedByUserID, CreatedDate From Drivers where PersonID = @PersonID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Driver = new clsDriverModel();

                                Driver.DriverID = Convert.ToInt32(reader["DriverID"]);
                                Driver.PersonID = Convert.ToInt32(reader["PersonID"]);
                                Driver.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                Driver.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventViewerLogger.LogError($"Database Error in GetDriverInfoByPersonID for PersonID: {PersonID}", ex);
                    }
                }
            }

            return Driver;
        }

        static public int AddNewDriver(clsDriverModel Driver)
        {
            int DriverID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate) " +
                             "OUTPUT INSERTED.DriverID " +
                             "VALUES (@PersonID, @CreatedByUserID, @CreatedDate);";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", Driver.PersonID);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", Driver.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@CreatedDate", Driver.CreatedDate);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            DriverID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception ex)
                    {
                        EventViewerLogger.LogError("Database Error in AddNewDriver", ex);
                    }
                }
            }

            return DriverID;
        }

        static public bool UpdateDriver(clsDriverModel Driver)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE Drivers SET PersonID = @PersonID, CreatedByUserID = @CreatedByUserID, CreatedDate = @CreatedDate WHERE DriverID = @DriverID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", Driver.PersonID);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", Driver.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@CreatedDate", Driver.CreatedDate);
                    cmd.Parameters.AddWithValue("@DriverID", Driver.DriverID);

                    try
                    {
                        Connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        IsUpdated = rows > 0;
                    }
                    catch (Exception ex)
                    {
                        EventViewerLogger.LogError($"Database Error in UpdateDriver for DriverID: {Driver.DriverID}", ex);
                    }
                }
            }

            return IsUpdated;
        }

        static public DataTable GetAllDrivers()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT * FROM Drivers_View;";
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
                    catch (Exception ex)
                    {
                        EventViewerLogger.LogError("Database Error in GetAllDrivers", ex);
                    }
                }
            }

            return dataTable;
        }

        static public bool IsDriverExistByPersonID(int PersonID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"if Exists(select 1 From Drivers AS D
                               where PersonID = @PersonID) 
                               select 1 else select 0";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            IsExist = Convert.ToBoolean(Result);
                        }
                    }
                    catch (Exception ex)
                    {
                        EventViewerLogger.LogError($"Database Error in IsDriverExistByPersonID for PersonID: {PersonID}", ex);
                    }
                }
            }

            return IsExist;
        }

        static public bool IsDriverExistByDriverID(int DriverID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"if Exists(select 1 From Drivers AS D
                               where DriverID = @DriverID) 
                               select 1 else select 0";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            IsExist = Convert.ToBoolean(Result);
                        }
                    }
                    catch (Exception ex)
                    {
                        EventViewerLogger.LogError($"Database Error in IsDriverExistByDriverID for DriverID: {DriverID}", ex);
                    }
                }
            }

            return IsExist;
        }
    }
}