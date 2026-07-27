using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Model;
using Infrastructure.Logging;

namespace DVLD_DataAccess
{
    public class clsApplicationTypesData
    {
        static public clsApplicationTypesModel GetApplicationTypeInfoByID(clsApplicationTypesModel.enApplicationTypes ApplicationTypeID)
        {
            clsApplicationTypesModel ApplicationType = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From ApplicationTypes where ApplicationTypeID = @ApplicationTypeID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationType = new clsApplicationTypesModel();

                                ApplicationType.ApplicationTypeID = ApplicationTypeID;
                                ApplicationType.ApplicationTypeTitle = reader["ApplicationTypeTitle"].ToString();
                                ApplicationType.ApplicationFees = Convert.ToDouble(reader["ApplicationFees"]);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventViewerLogger.LogError($"Database Error in GetApplicationTypeInfoByID for ApplicationTypeID: {ApplicationTypeID}", ex);
                    }
                }
            }

            return ApplicationType;
        }

        static public int AddNewApplicationType(clsApplicationTypesModel ApplicationType)
        {
            int ApplicationTypeID = (int)clsApplicationTypesModel.enApplicationTypes.NotSpecified;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO ApplicationTypes (ApplicationTypeTitle, ApplicationFees) OUTPUT INSERTED.ApplicationTypeID " +
                             "VALUES (@Title, @Fees);";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@Title", ApplicationType.ApplicationTypeTitle);
                    cmd.Parameters.AddWithValue("@Fees", ApplicationType.ApplicationFees);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            ApplicationTypeID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception ex)
                    {
                        EventViewerLogger.LogError("Database Error in AddNewApplicationType", ex);
                    }
                }
            }

            return ApplicationTypeID;
        }

        static public bool UpdateApplicationType(clsApplicationTypesModel ApplicationType)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE ApplicationTypes SET ApplicationTypeTitle = @Title, ApplicationFees = @Fees WHERE ApplicationTypeID = @ApplicationTypeID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@Title", ApplicationType.ApplicationTypeTitle);
                    cmd.Parameters.AddWithValue("@Fees", ApplicationType.ApplicationFees);
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationType.ApplicationTypeID);

                    try
                    {
                        Connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        IsUpdated = rows > 0;
                    }
                    catch (Exception ex)
                    {
                        EventViewerLogger.LogError($"Database Error in UpdateApplicationType for ApplicationTypeID: {ApplicationType.ApplicationTypeID}", ex);
                    }
                }
            }

            return IsUpdated;
        }

        static public DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT ApplicationTypeID ,ApplicationTypeTitle  ,ApplicationFees FROM ApplicationTypes;";
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
                        EventViewerLogger.LogError("Database Error in GetAllApplicationTypes", ex);
                    }
                }
            }

            return dataTable;
        }
    }
}