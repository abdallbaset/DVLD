using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Model;

namespace DVLD_DataAccess
{
    public class clsDetainedLicensesData
    {
        static public clsDetainedLicenseModel GetDetainedLicenseInfoByID(int DetainID)
        {
            clsDetainedLicenseModel DetainedLicense = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From DetainedLicenses where DetainID = @DetainID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@DetainID", DetainID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DetainedLicense = new clsDetainedLicenseModel();

                                DetainedLicense.DetainID = Convert.ToInt32(reader["DetainID"]);
                                DetainedLicense.LicenseID = Convert.ToInt32(reader["LicenseID"]);
                                DetainedLicense.DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                                DetainedLicense.FineFees = Convert.ToDouble(reader["FineFees"]);
                                DetainedLicense.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                DetainedLicense.IsReleased = Convert.ToBoolean(reader["IsReleased"]);
                                DetainedLicense.ReleaseDate = (reader["ReleaseDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ReleaseDate"]);
                                DetainedLicense.ReleasedByUserID = (reader["ReleasedByUserID"] == DBNull.Value) ? (int)clsEnumerationsModel.enIdentityStatus.NonExistent : Convert.ToInt32(reader["ReleasedByUserID"]);
                                DetainedLicense.ReleaseApplicationID = (reader["ReleaseApplicationID"] == DBNull.Value) ? (int)clsEnumerationsModel.enIdentityStatus.NonExistent : Convert.ToInt32(reader["ReleaseApplicationID"]);

                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return DetainedLicense;
        }

        static public int AddNewDetainedLicense(clsDetainedLicenseModel DetainedLicense)
        {
            int DetainID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID) " +
                             "OUTPUT INSERTED.DetainID " +
                             "VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", DetainedLicense.LicenseID);
                    cmd.Parameters.AddWithValue("@DetainDate", DetainedLicense.DetainDate);
                    cmd.Parameters.AddWithValue("@FineFees", DetainedLicense.FineFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", DetainedLicense.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@IsReleased", DetainedLicense.IsReleased);
                    cmd.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReleaseApplicationID",  DBNull.Value);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            DetainID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return DetainID;
        }

        static public bool UpdateDetainedLicense(clsDetainedLicenseModel DetainedLicense)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE DetainedLicenses SET LicenseID = @LicenseID, DetainDate = @DetainDate, FineFees = @FineFees, " +
                             "CreatedByUserID = @CreatedByUserID, IsReleased = @IsReleased, ReleaseDate = @ReleaseDate, ReleasedByUserID = @ReleasedByUserID, " +
                             "ReleaseApplicationID = @ReleaseApplicationID WHERE DetainID = @DetainID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", DetainedLicense.LicenseID);
                    cmd.Parameters.AddWithValue("@DetainDate", DetainedLicense.DetainDate);
                    cmd.Parameters.AddWithValue("@FineFees", DetainedLicense.FineFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", DetainedLicense.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@IsReleased", DetainedLicense.IsReleased);
                    cmd.Parameters.AddWithValue("@ReleaseDate", DetainedLicense.ReleaseDate == DateTime.MinValue ? (object)DBNull.Value : DetainedLicense.ReleaseDate);
                    cmd.Parameters.AddWithValue("@ReleasedByUserID", DetainedLicense.ReleasedByUserID);
                    cmd.Parameters.AddWithValue("@ReleaseApplicationID", DetainedLicense.ReleaseApplicationID);
                    cmd.Parameters.AddWithValue("@DetainID", DetainedLicense.DetainID);

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

        static public bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "if Exists(select 1 From DetainedLicenses where LicenseID = @LicenseID AND IsReleased = 0) select 1 else select 0 ;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            IsDetained = Convert.ToBoolean(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return IsDetained;
        }

        static public DataTable GetAllDetainedLicenses()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID FROM DetainedLicenses;";
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
    }
}