using DVLD_Model;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsLicensesData
    {
        static public clsLicenseModel GetLicenseInfoByLicenseID(int LicenseID)
        {
            clsLicenseModel License = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From Licenses where LicenseID = @LicenseID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                License = new clsLicenseModel();

                                License.LicenseID = Convert.ToInt32(reader["LicenseID"]);
                                License.LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                                License.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                                License.DriverID = Convert.ToInt32(reader["DriverID"]);
                                License.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                                License.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                                License.IssueReason = (clsLicenseModel.enIssueReason)Convert.ToByte(reader["IssueReason"]);
                                License.PaidFees = Convert.ToDouble(reader["PaidFees"]);
                                License.IsActive = Convert.ToBoolean(reader["IsActive"]);
                                License.Notes = (reader["Notes"] == DBNull.Value) ? string.Empty : reader["Notes"].ToString();
                                License.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);


                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return License;
        }

        static public int AddNewLicense(clsLicenseModel License, int PersonID)
        {
            int LicenseID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"
                            DECLARE @ActualDriverID INT;

                            IF NOT EXISTS (SELECT 1 FROM Drivers WHERE PersonID = @PersonID)
                            BEGIN
                                INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                                VALUES (@PersonID, @CreatedByUserID, GETDATE());
                                
                                SELECT @ActualDriverID = SCOPE_IDENTITY();
                            END
                            ELSE
                            BEGIN
                                SELECT @ActualDriverID = DriverID FROM Drivers WHERE PersonID = @PersonID;
                            END
                            
                            INSERT INTO Licenses (LicenseClassID, ApplicationID, DriverID, IssueDate, 
                                                 ExpirationDate, IssueReason, PaidFees, IsActive, 
                                                 Notes, CreatedByUserID)
                            OUTPUT INSERTED.LicenseID
                            VALUES (@LicenseClassID, @ApplicationID, @ActualDriverID, @IssueDate, 
                                    @ExpirationDate, @IssueReason, @PaidFees, @IsActive, 
                                    @Notes, @CreatedByUserID);

                            UPDATE Applications 
                            SET ApplicationStatus = @ApplicationStatus 
                            WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@LicenseClassID", License.LicenseClassID);
                    cmd.Parameters.AddWithValue("@ApplicationID", License.ApplicationID);
                    cmd.Parameters.AddWithValue("@IssueDate", License.IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", License.ExpirationDate);
                    cmd.Parameters.AddWithValue("@IssueReason", (byte)License.IssueReason);
                    cmd.Parameters.AddWithValue("@PaidFees", License.PaidFees);
                    cmd.Parameters.AddWithValue("@IsActive", License.IsActive);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(License.Notes) ? (object)DBNull.Value : License.Notes);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", License.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@ApplicationStatus", clsApplicationModel.enApplicationStatus.Completed);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            LicenseID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return LicenseID;
        }

        static public bool UpdateLicense(clsLicenseModel License)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE Licenses SET LicenseClassID = @LicenseClassID, ApplicationID = @ApplicationID, DriverID = @DriverID, " +
                             "IssueDate = @IssueDate, ExpirationDate = @ExpirationDate, IssueReason = @IssueReason, PaidFees = @PaidFees, " +
                             "IsActive = @IsActive, Notes = @Notes, CreatedByUserID = @CreatedByUserID WHERE LicenseID = @LicenseID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseClassID", License.LicenseClassID);
                    cmd.Parameters.AddWithValue("@ApplicationID", License.ApplicationID);
                    cmd.Parameters.AddWithValue("@DriverID", License.DriverID);
                    cmd.Parameters.AddWithValue("@IssueDate", License.IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", License.ExpirationDate);
                    cmd.Parameters.AddWithValue("@IssueReason", (byte)License.IssueReason);
                    cmd.Parameters.AddWithValue("@PaidFees", License.PaidFees);
                    cmd.Parameters.AddWithValue("@IsActive", License.IsActive);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(License.Notes) ? (object)DBNull.Value : License.Notes);
                    cmd.Parameters.AddWithValue("@CreatedByUserID1", License.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@LicenseID", License.LicenseID);

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

        static public DataTable GetAllLicenses()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT LicenseID, LicenseClassID, ApplicationID, DriverID, IssueDate, ExpirationDate, IssueReason, PaidFees, IsActive, Notes, CreatedByUserID FROM Licenses;";
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

        static public DataTable GetAllLicensesByDriverID(int DriverID)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"SELECT L.LicenseID, L.ApplicationID,LC.ClassName, L.IssueDate, ExpirationDate, IsActive
                              FROM Licenses AS L
                              inner join LicenseClasses AS LC 
                              ON
                              L.LicenseClassID = LC.LicenseClassID
                              where L.DriverID = @DriverID;";
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

        static public bool IsLicenseExist(int ApplicationID, int LicenseClassID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"if Exists(select 1 From Licenses AS L
                               where ApplicationID = @ApplicationID AND LicenseClassID = @LicenseClassID) 
                               select 1 else select 0";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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


        public static int GetActiveLicenseIDByPersonIDAndLicenseClassID(int PersonID, int LicenseClassID)
        {
            int LicenseID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"SELECT LicenseID 
                         FROM Licenses AS L
						 inner Join Applications AS A ON A.ApplicationID = L.ApplicationID
                         WHERE A.ApplicantPersonID = @PersonID And L.LicenseClassID = @LicenseClassID And L.IsActive = 1";

                using (SqlCommand Command = new SqlCommand(sql, Connection))
                {
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                        {
                            LicenseID = insertedID;
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return LicenseID;
        }

        public static int RenewOrReplacementLicense(clsLicenseModel License, int PersonID, clsApplicationTypesModel.enApplicationTypes ApplicationTypes)
        {
            int NewLicenseID = (int)clsEnumerationsModel.enIdentityStatus.NonExistent;
            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"
                                Declare @ApplicationID int;

                               insert into Applications (ApplicantPersonID, ApplicationTypeID, ApplicationDate, CreatedByUserID, ApplicationStatus,LastStatusDate, PaidFees)
                               values (@PersonID, @ApplicationTypeID, GETDATE(), @CreatedByUserID, @ApplicationStatus, GETDATE(),
                               (select A.ApplicationFees from ApplicationTypes AS A
                                where ApplicationTypeID = @ApplicationTypeID ));

                                    SELECT @ApplicationID = SCOPE_IDENTITY();
 
                               INSERT INTO Licenses (LicenseClassID, ApplicationID, DriverID, IssueDate, 
                                                    ExpirationDate, IssueReason, PaidFees, IsActive, 
                                                    Notes, CreatedByUserID)
                               OUTPUT INSERTED.LicenseID
                               VALUES (@LicenseClassID, @ApplicationID, @DriverID, @IssueDate, 
                                    @ExpirationDate, @IssueReason, @PaidFees, @IsActive, 
                                    @Notes, @CreatedByUserID);

                              Update Licenses SET IsActive = 0 
                              WHERE LicenseID = @OldLicenseID";

                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypes);
                    cmd.Parameters.AddWithValue("@ApplicationStatus", clsApplicationModel.enApplicationStatus.Completed);
                    cmd.Parameters.AddWithValue("@LicenseClassID", License.LicenseClassID);
                    cmd.Parameters.AddWithValue("@DriverID", License.DriverID);
                    cmd.Parameters.AddWithValue("@IssueDate", License.IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", License.ExpirationDate);
                    cmd.Parameters.AddWithValue("@IssueReason", License.IssueReason);
                    cmd.Parameters.AddWithValue("@PaidFees", License.PaidFees);
                    cmd.Parameters.AddWithValue("@IsActive", License.IsActive);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(License.Notes) ? (object)DBNull.Value : License.Notes);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", License.CreatedByUserID);
                    cmd.Parameters.AddWithValue("@OldLicenseID", License.LicenseID);
                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            NewLicenseID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
                return NewLicenseID;
            }
        }
    
    

        }
}
        