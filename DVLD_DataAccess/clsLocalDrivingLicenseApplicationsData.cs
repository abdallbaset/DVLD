using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Model;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationsData
    {
        static public clsLocalDrivingLicenseApplicationsModel GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplicationsModel LocalDrivingLicenseApplicationInfo = null;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "select * From LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LocalDrivingLicenseApplicationInfo = new clsLocalDrivingLicenseApplicationsModel();
                                LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                                LocalDrivingLicenseApplicationInfo.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                                LocalDrivingLicenseApplicationInfo.LicenseClassID = (clsLicenseClassesModel.enLicenseClass)reader["LicenseClassID"];
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return LocalDrivingLicenseApplicationInfo;
        }

        static public int AddNewLocalDrivingLicense(clsLocalDrivingLicenseApplicationsModel LocalDrivingLicenseApplicationInfo)
        {
            int LocalDrivingLicenseID = (int)clsSettingsModel.enIdentityStatus.NonExistent;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) OUTPUT INSERTED.LocalDrivingLicenseApplicationID " +
                             "VALUES (@ApplicationID, @LicenseClassID);";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", LocalDrivingLicenseApplicationInfo.ApplicationID);
                    cmd.Parameters.AddWithValue("@LicenseClassID",LocalDrivingLicenseApplicationInfo.LicenseClassID);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            LocalDrivingLicenseID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return LocalDrivingLicenseID;
        }

        static public bool UpdateLocalDrivingLicense(clsLocalDrivingLicenseApplicationsModel LocalDrivingLicenseApplicationInfo)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE LocalDrivingLicenseApplications SET ApplicationID = @ApplicationID, LicenseClassID = @LicenseClassID " +
                             "WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", LocalDrivingLicenseApplicationInfo.ApplicationID);
                    cmd.Parameters.AddWithValue("@LicenseClassID",LocalDrivingLicenseApplicationInfo.LicenseClassID);
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID);

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

        static public bool DeleteLocalDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            bool IsDeleted = false;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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

        static public bool IsLocalDrivingLicenseExist(int LocalDrivingLicenseApplicationID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "if Exists(select 1 From LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  select 1 else select 0 ;";
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
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return IsExist;
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int LicenseClassID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = $@"if Exists (SELECT 1 
                         FROM LocalDrivingLicenseFullApplications_View 
                         WHERE ApplicantPersonID = @PersonID 
                         AND LicenseClassID = @LicenseClassID 
                         AND ApplicationStatus = {(int)clsApplicationModel.enApplicationStatus.New}) select 1 else select 0 ;";

                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null) 
                         IsExist =Convert.ToBoolean(Result);
                        
                    }
                    catch (Exception ex)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return IsExist;
        }
        static public DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "SELECT * FROM LocalDrivingLicenseApplications_View;";
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