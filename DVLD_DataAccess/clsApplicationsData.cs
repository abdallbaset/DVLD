using DVLD_Model;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsApplicationsData
    {
        static public clsApplicationModel GetApplicationInfoByID(int ApplicationID)
        {
          
            clsApplicationModel ApplicationInfo = null;
            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From Applications where ApplicationID = @ApplicationID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationInfo = new clsApplicationModel();

                                ApplicationInfo.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                                ApplicationInfo.ApplicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                                ApplicationInfo.ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                                ApplicationInfo.ApplicationTypeID = (clsApplicationTypesModel.enApplicationTypes)reader["ApplicationTypeID"];
                                ApplicationInfo.ApplicationStatus = (clsApplicationModel.enApplicationStatus)(reader["ApplicationStatus"]);
                                ApplicationInfo.LastStatusDate =Convert.ToDateTime( reader["LastStatusDate"])  ;
                                ApplicationInfo.PaidFees = Convert.ToDouble(reader["PaidFees"]);
                                ApplicationInfo.CreatedByUserID = Convert.ToInt32((reader["CreatedByUserID"])); 

                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return ApplicationInfo;
        }
        static public int AddNewApplication(clsApplicationModel ApplicationInfo)
        {
            int ApplicationID = (int)clsSettingsModel.enIdentityStatus.NonExistent;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID) " +
                             "OUTPUT INSERTED.ApplicationID " +
                             "VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);";                             ;
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicationInfo.ApplicantPersonID);
                    cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationInfo.ApplicationDate);
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationInfo.ApplicationTypeID);
                    cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationInfo.ApplicationStatus);
                    cmd.Parameters.AddWithValue("@LastStatusDate", ApplicationInfo.LastStatusDate);                 
                    cmd.Parameters.AddWithValue("@PaidFees", ApplicationInfo.PaidFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", ApplicationInfo.CreatedByUserID);
              

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            ApplicationID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return ApplicationID;
        }

        static public bool UpdateApplication(clsApplicationModel ApplicationInfo)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"UPDATE Applications SET  
                             ApplicationStatus = @ApplicationStatus,
                             LastStatusDate = @LastStatusDate,
                             WHERE ApplicationID = @ApplicationID;";
                           
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationInfo.ApplicationStatus);
                    cmd.Parameters.AddWithValue("@LastStatusDate", ApplicationInfo.LastStatusDate);
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationInfo.ApplicationID);

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

        static public bool DeleteApplication(int ApplicationID)
        {
            bool IsDeleted = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    try
                    {
                        Connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        IsDeleted = rows > 0;
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return IsDeleted;
        }

        static public bool IsApplicationExist(int ApplicationID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "if Exists(select 1 From Applications where ApplicationID = @ApplicationID)  select 1 else select 0 ;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
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

        static public DataTable GetAllApplications()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID FROM Applications;";
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

        static public int GetActiveApplicationIDForLicenseClass(int PersonID , clsApplicationTypesModel.enApplicationTypes ApplicationTypes , int LicenseClassID)
        {
            int ActiveApplicationID = (int)clsSettingsModel.enIdentityStatus.NonExistent;
            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = @"SELECT ApplicationID FROM LocalDrivingLicenseFullApplications_View  
                             WHERE ApplicantPersonID = @PersonID AND ApplicationTypeID = @ApplicationTypeID AND LicenseClassID = @LicenseClassID AND ApplicationStatus = @NewStatus;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypes);
                    cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    cmd.Parameters.AddWithValue("@NewStatus", clsApplicationModel.enApplicationStatus.New);
                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            ActiveApplicationID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return ActiveApplicationID;
        }
        

        
    }
}