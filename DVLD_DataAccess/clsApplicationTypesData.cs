using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Model;

namespace DVLD_DataAccess
{
    public class clsApplicationTypesData
    {
        static public clsApplicationTypesModel GetApplicationTypeInfoByID(int ApplicationTypeID)
        {
            clsApplicationTypesModel ApplicationType = null;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
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

                                ApplicationType.ApplicationTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                                ApplicationType.ApplicationTypeTitle = reader["ApplicationTypeTitle"].ToString();
                                ApplicationType.ApplicationFees = Convert.ToDouble(reader["ApplicationFees"]);

                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return ApplicationType;
        }

        static public bool UpdateApplicationType(clsApplicationTypesModel ApplicationType)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
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
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return IsUpdated;
        }

        static public DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "SELECT ApplicationTypeID AS ID,ApplicationTypeTitle AS Title ,ApplicationFees AS Fees   FROM ApplicationTypes;";
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
