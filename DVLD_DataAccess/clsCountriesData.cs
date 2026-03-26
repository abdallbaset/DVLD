using DVLD_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsCountriesData
    {
        static public string GetCountryNameByCountryID(int CountryID)
        {
            string CountryName = "";

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select C.CountryName from Countries AS C Where C.CountryID = @CountryID";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@CountryID", CountryID);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            CountryName = Result.ToString();
                        }
                    }
                    catch (Exception)
                    {
                        // Errors will be recorded in the LOG file later.
                    }
                }
            }
            return CountryName;
        }

        static public int GetCountryIDByCountryName(string CountryName)
        {
            int CountryID = -1;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select C.CountryID from Countries AS C Where C.CountryName = @CountryName";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@CountryName", CountryName);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            CountryID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {
                        // Errors will be recorded in the LOG file later.
                    }
                }
            }
            return CountryID;
        }

        static public DataTable GetAllCountry()
        {
            DataTable CountryTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * from Countries";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                CountryTable.Load(reader);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Errors will be recorded in the LOG file later.
                    }
                }
            }
            return CountryTable;
        }
    }
}