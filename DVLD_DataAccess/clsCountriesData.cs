using DVLD_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace DVLD_DataAccess
{
    public class clsCountriesData
    {
        static public string GetCountryNameByCountryID(int CountryID)
        {
            SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "select C.CountryName from Countries AS C Where C.CountryID = @CountryID";
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            string CountryName = "";
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
                //Errors will be recorded in the LOG file later.
            }
            finally { Connection.Close(); }


            return CountryName;
        }
        static public int GetCountryIDByCountryName(string CountryName)
        {
            SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "select C.CountryID from Countries AS C Where C.CountryName = @CountryName";
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@CountryName", CountryName);
            int CountryID = -1;
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
                //Errors will be recorded in the LOG file later.
            }
            finally { Connection.Close(); }


            return CountryID;
        }
        static public DataTable GetAllCountry()
        {
            SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "select CountryName from Countries ";
            SqlCommand cmd = new SqlCommand(sql, Connection);
            DataTable CountryTable = new DataTable();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    CountryTable.Load(reader);
                }
            }
            catch (Exception)
            {
                //Errors will be recorded in the LOG file later.
            }
            finally { Connection.Close(); }


            return CountryTable;
        }

    }
}
