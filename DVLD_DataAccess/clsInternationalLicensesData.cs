using DVLD_Model;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsInternationalLicenseData
    {
        static public clsInternationalLicenseModel GetInternationalLicenseInfoByID(int InternationalLicenseID)
        {
            clsInternationalLicenseModel InternationalLicense = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID From InternationalLicenses where InternationalLicenseID = @InternationalLicenseID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                InternationalLicense = new clsInternationalLicenseModel();

                                InternationalLicense.InternationalLicenseID = Convert.ToInt32(reader["InternationalLicenseID"]);
                                InternationalLicense.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                                InternationalLicense.DriverID = Convert.ToInt32(reader["DriverID"]);
                                InternationalLicense.IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                                InternationalLicense.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                                InternationalLicense.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                                InternationalLicense.IsActive = Convert.ToBoolean(reader["IsActive"]);
                                InternationalLicense.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return InternationalLicense;
        }

        static public int AddNewInternationalLicense(clsInternationalLicenseModel InternationalLicenseInfo, clsApplicationModel ApplicationInfo)
        {
            int InternationalLicenseID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"
            DECLARE @NewApplicationID INT;
             

            INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
            VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
            
            SELECT @NewApplicationID = SCOPE_IDENTITY();

             Update InternationalLicenses set IsActive = 0 where DriverID = @DriverID and IsActive = 1;

            INSERT INTO InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID) 
            VALUES (@NewApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);

            SELECT @NewApplicationID AS NewApplicationID, SCOPE_IDENTITY() AS NewInternationalLicenseID;";

                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicationInfo.ApplicantPersonID);
                    cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationInfo.ApplicationDate);
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationInfo.ApplicationTypeID);
                    cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationInfo.ApplicationStatus);
                    cmd.Parameters.AddWithValue("@LastStatusDate", ApplicationInfo.LastStatusDate);
                    cmd.Parameters.AddWithValue("@PaidFees", ApplicationInfo.PaidFees);

                    cmd.Parameters.AddWithValue("@DriverID", InternationalLicenseInfo.DriverID);
                    cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", InternationalLicenseInfo.IssuedUsingLocalLicenseID);
                    cmd.Parameters.AddWithValue("@IssueDate", InternationalLicenseInfo.IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", InternationalLicenseInfo.ExpirationDate);
                    cmd.Parameters.AddWithValue("@IsActive", InternationalLicenseInfo.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", InternationalLicenseInfo.CreatedByUserID);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                InternationalLicenseInfo.ApplicationID = Convert.ToInt32(reader["NewApplicationID"]);

                                InternationalLicenseID = Convert.ToInt32(reader["NewInternationalLicenseID"]);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Errors will be recorded in the LOG file later.
                    }
                }
            }

            return InternationalLicenseID;
        }

        static public bool UpdateInternationalLicense(clsInternationalLicenseModel InternationalLicense)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE InternationalLicenses SET ApplicationID = @ApplicationID, DriverID = @DriverID, IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID, " +
                             "IssueDate = @IssueDate, ExpirationDate = @ExpirationDate, IsActive = @IsActive, CreatedByUserID = @CreatedByUserID WHERE InternationalLicenseID = @InternationalLicenseID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", InternationalLicense.ApplicationID);
                    cmd.Parameters.AddWithValue("@DriverID", InternationalLicense.DriverID);
                    cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", InternationalLicense.IssuedUsingLocalLicenseID);
                    cmd.Parameters.AddWithValue("@IssueDate", InternationalLicense.IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", InternationalLicense.ExpirationDate);
                    cmd.Parameters.AddWithValue("@IsActive", InternationalLicense.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", InternationalLicense.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicense.InternationalLicenseID);

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

        static public DataTable GetAllInternationalLicenses()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT InternationalLicenseID,ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive FROM InternationalLicenses;";
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

        static public DataTable GetAllInternationalLicensesByDriverID(int DriverID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive 
                               FROM InternationalLicenses
                               WHERE DriverID = @DriverID";

                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);

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


        static public bool IsInternationalLicenseExist(int LicenseID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"if Exists(select 1 From InternationalLicenses 
                               where  IssuedUsingLocalLicenseID = @LicenseID) 
                               select 1 else select 0";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
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
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return IsExist;
        }

        static public int GetActiveInternationalLicense(int LicenseID)
        {
            int InternationalLicenseID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"SELECT InternationalLicenseID FROM InternationalLicenses 
                               WHERE IssuedUsingLocalLicenseID = @LicenseID AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            InternationalLicenseID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return InternationalLicenseID;
        }

        }
}