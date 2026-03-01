using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Model;

namespace DVLD_DataAccess
{
    public class clsTestTypesData
    {
        static public clsTestTypesModel GetTestTypeInfoByID(clsTestTypesModel.enTestType TestTypeID)
        {
            clsTestTypesModel TestType = null;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "select * From TestTypes where TestTypeID = @TestTypeID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestType = new clsTestTypesModel();

                                TestType.ID = TestTypeID;
                                TestType.TestTypeTitle = reader["TestTypeTitle"].ToString();
                                TestType.TestTypeDescription = reader["TestTypeDescription"].ToString();
                                TestType.TestTypeFees = Convert.ToDouble(reader["TestTypeFees"]);

                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return TestType;
        }
        static public int AddNewTestType(clsTestTypesModel TestType)
        {
            int TestTypeID =(int) clsTestTypesModel.enTestType.NotSpecified;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO TestTypes (TestTypeTitle, TestTypeDescription, TestTypeFees) OUTPUT INSERTED.TestTypeID " +
                             "VALUES (@Title, @Description, @Fees);";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@Title", TestType.TestTypeTitle);
                    cmd.Parameters.AddWithValue("@Description", TestType.TestTypeDescription);
                    cmd.Parameters.AddWithValue("@Fees", TestType.TestTypeFees);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            TestTypeID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return TestTypeID;
        }

        static public bool UpdateTestType(clsTestTypesModel TestType)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE TestTypes SET TestTypeTitle = @Title, TestTypeDescription = @Description, TestTypeFees = @Fees WHERE TestTypeID = @TestTypeID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@Title", TestType.TestTypeTitle);
                    cmd.Parameters.AddWithValue("@Description", TestType.TestTypeDescription);
                    cmd.Parameters.AddWithValue("@Fees", TestType.TestTypeFees);
                    cmd.Parameters.AddWithValue("@TestTypeID", TestType.ID);

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

        static public DataTable GetAllTestTypes()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString))
            {
                string sql = "SELECT TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees FROM TestTypes;";
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
