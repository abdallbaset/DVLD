using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Model;

namespace DVLD_DataAccess
{
    public class clsLicenseClassesData
    {
        static public clsLicenseClassesModel GetLicenseClassInfoByID(int LicenseClassID)
        {
            clsLicenseClassesModel LicenseClassInfo = null;
            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From LicenseClasses where LicenseClassID = @LicenseClassID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LicenseClassInfo = new clsLicenseClassesModel();
                                LicenseClassInfo.LicenseClassID = (clsLicenseClassesModel.enLicenseClass)reader["LicenseClassID"];
                                LicenseClassInfo.ClassName = reader["ClassName"].ToString();
                                LicenseClassInfo.ClassDescription = reader["ClassDescription"].ToString();
                                LicenseClassInfo.MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]);
                                LicenseClassInfo.DefaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]);
                                LicenseClassInfo.ClassFees = Convert.ToDouble(reader["ClassFees"]);

                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return LicenseClassInfo;
        }

        static public int AddNewLicenseClass(clsLicenseClassesModel LicenseClassInfo)
        {
            int LicenseClassID = (int)clsLicenseClassesModel.enLicenseClass.NotSpecified;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO LicenseClasses (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees) " +
                             "OUTPUT INSERTED.LicenseClassID " +
                             "VALUES (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees);";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ClassName", LicenseClassInfo.ClassName);
                    cmd.Parameters.AddWithValue("@ClassDescription", LicenseClassInfo.ClassDescription);                 
                    cmd.Parameters.AddWithValue("@MinimumAllowedAge", LicenseClassInfo.MinimumAllowedAge);
                    cmd.Parameters.AddWithValue("@DefaultValidityLength", LicenseClassInfo.DefaultValidityLength);
                    cmd.Parameters.AddWithValue("@ClassFees", LicenseClassInfo.ClassFees);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            LicenseClassID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return LicenseClassID;
        }

        static public bool UpdateLicenseClass(clsLicenseClassesModel LicenseClassInfo)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE LicenseClasses SET ClassName = @ClassName, ClassDescription = @ClassDescription, " +
                             "MinimumAllowedAge = @MinimumAllowedAge, DefaultValidityLength = @DefaultValidityLength, ClassFees = @ClassFees " +
                             "WHERE LicenseClassID = @LicenseClassID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ClassName", LicenseClassInfo.ClassName);
                    cmd.Parameters.AddWithValue("@ClassDescription", LicenseClassInfo.ClassDescription);
                    cmd.Parameters.AddWithValue("@MinimumAllowedAge", LicenseClassInfo.MinimumAllowedAge);
                    cmd.Parameters.AddWithValue("@DefaultValidityLength", LicenseClassInfo.DefaultValidityLength);
                    cmd.Parameters.AddWithValue("@ClassFees", LicenseClassInfo.ClassFees);
                    cmd.Parameters.AddWithValue("@LicenseClassID",LicenseClassInfo.LicenseClassID);

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

        static public bool DeleteLicenseClass(int LicenseClassID)
        {
            bool IsDeleted = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "DELETE FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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

        static public bool IsLicenseClassExist(int LicenseClassID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "if Exists(select 1 From LicenseClasses where LicenseClassID = @LicenseClassID) select 1 else select 0;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
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
        static public bool IsLicenseClassExist(string ClassName)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "if Exists(select 1 From LicenseClasses where ClassName = @ClassName) select 1 else select 0;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@ClassName", ClassName);
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

        static public DataTable GetAllLicenseClasses()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees FROM LicenseClasses;";
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