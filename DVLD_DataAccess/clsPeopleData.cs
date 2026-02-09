using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_Model;
namespace DVLD_DataAccess
{
     public class clsPeopleData
    {
        static public bool GetPersonInfoByID(int ID, clsPeopleModel Person)
        {
            SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "select * From People where PersonID = @PersonID;";
            SqlCommand cmd = new SqlCommand(sql,Connection);
            cmd.Parameters.AddWithValue("@PersonID", ID);
            bool IsFound = false;
       
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Person.PersonID = Convert.ToInt32(reader["PersonID"]);
                    Person.NationalNo = reader["NationalNo"].ToString();
                    Person.FirstName = reader["FirstName"].ToString();
                    Person.SecondName = reader["SecondName"].ToString();
                    Person.ThirdName = (reader["ThirdName"] == DBNull.Value) ? "" : reader["ThirdName"].ToString();
                    Person.LastName = reader["LastName"].ToString();
                    Person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Person.Email = (reader["Email"] == DBNull.Value) ? "" : reader["Email"].ToString();
                    Person.phone = reader["phone"].ToString();
                    Person.Address = reader["Address"].ToString();
                    Person.Gendor = Convert.ToByte(reader["Gendor"]);
                    Person.NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    Person.ImagePath = (reader["ImagePath"] == DBNull.Value) ? "" : reader["ImagePath"].ToString();

                    IsFound = true;
                }
                

                reader.Close();


            }
            catch (Exception)
            {
                //Errors will be recorded in the LOG file later.
            }
            finally { Connection.Close(); }


            return IsFound;
        }
        static public bool GetPersonInfoByNationalNo(string NationalNo,clsPeopleModel Person)
        {
            SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "select * From People where NationalNo = @NationalNo;";
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddWithValue("NationalNo", NationalNo);
            bool IsFound = false;
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Person.PersonID = Convert.ToInt32(reader["PersonID"]);
                    Person.NationalNo = reader["NationalNo"].ToString();
                    Person.FirstName = reader["FirstName"].ToString();
                    Person.SecondName = reader["SecondName"].ToString();
                    Person.ThirdName = (reader["ThirdName"] == DBNull.Value) ? "" : reader["ThirdName"].ToString();
                    Person.LastName = reader["LastName"].ToString();
                    Person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Person.Email = (reader["Email"] == DBNull.Value) ? "" : reader["Email"].ToString();
                    Person.phone = reader["phone"].ToString();
                    Person.Address = reader["Address"].ToString();
                    Person.Gendor = Convert.ToByte(reader["Gendor"]);
                    Person.NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    Person.ImagePath = (reader["ImagePath"] == DBNull.Value) ? "" : reader["ImagePath"].ToString();

                    IsFound = true;
                }


                reader.Close();


            }
            catch (Exception)
            {
                //Errors will be recorded in the LOG file later.
            }
            finally { Connection.Close(); }


            return IsFound;
        }


      

        static public int AddNewPerson(clsPeopleModel Person)
        {
            SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName,DateOfBirth, Gendor, Address, Phone," +
               " Email,NationalityCountryID,ImagePath) OUTPUT INSERTED.PersonID" +
               " VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName,@DateOfBirth, @Gendor, @Address, @Phone, @Email,@NationalityCountryID," +
               " @ImagePath);";
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@NationalNo", Person.NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", Person.FirstName);
            cmd.Parameters.AddWithValue("@SecondName", Person.SecondName);
                 if(Person.ThirdName != "")
                cmd.Parameters.AddWithValue("@ThirdName", Person.ThirdName);
                 else
                cmd.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            cmd.Parameters.AddWithValue("@LastName", Person.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", Person.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Person.Gendor);
            cmd.Parameters.AddWithValue("@Address", Person.Address);
            cmd.Parameters.AddWithValue("@Phone", Person.phone);

                 if(Person.Email != "")
                     cmd.Parameters.AddWithValue("@Email", Person.Email);
                else
                     cmd.Parameters.AddWithValue("@Email", DBNull.Value);

            cmd.Parameters.AddWithValue("@NationalityCountryID", Person.NationalityCountryID);

                 if(Person.ImagePath != "")
                 cmd.Parameters.AddWithValue("@ImagePath", Person.ImagePath);
                else
                 cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);


            int PersonID = -1;


            try
            {
                Connection.Open();
                object Result  = cmd.ExecuteScalar() ;
                 if(Result != null)
                {
                    PersonID = Convert.ToInt32(Result);
                }
            }
            catch (Exception)
            {
                //Errors will be recorded in the LOG file later.
            }
            finally { Connection.Close(); }


            return PersonID;
        }
        static public bool UpdatePerson(clsPeopleModel Person)
        {
            SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "UPDATE People SET " +
                         "NationalNo = @NationalNo, " +
                         "FirstName = @FirstName, " +
                         "SecondName = @SecondName, " +
                         "ThirdName = @ThirdName, " +
                         "LastName = @LastName, " +
                         "DateOfBirth = @DateOfBirth, " +
                         "Gendor = @Gendor, " +
                         "Address = @Address, " +
                         "Phone = @Phone, " +
                         "Email = @Email, " +
                         "NationalityCountryID = @NationalityCountryID, " +
                         "ImagePath = @ImagePath " +
                         "WHERE PersonID = @PersonID;";

            SqlCommand cmd = new SqlCommand(sql, Connection);

            cmd.Parameters.AddWithValue("@NationalNo", Person.NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", Person.FirstName);
            cmd.Parameters.AddWithValue("@SecondName", Person.SecondName);

            if (!string.IsNullOrEmpty(Person.ThirdName))
                cmd.Parameters.AddWithValue("@ThirdName", Person.ThirdName);
            else
                cmd.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            cmd.Parameters.AddWithValue("@LastName", Person.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", Person.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Person.Gendor);
            cmd.Parameters.AddWithValue("@Address", Person.Address);
            cmd.Parameters.AddWithValue("@Phone", Person.phone);

            if (!string.IsNullOrEmpty(Person.Email))
                cmd.Parameters.AddWithValue("@Email", Person.Email);
            else
                cmd.Parameters.AddWithValue("@Email", DBNull.Value);

            cmd.Parameters.AddWithValue("@NationalityCountryID", Person.NationalityCountryID);

            if (!string.IsNullOrEmpty(Person.ImagePath))
                cmd.Parameters.AddWithValue("@ImagePath", Person.ImagePath);
            else
                cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            cmd.Parameters.AddWithValue("@PersonID", Person.PersonID);

            bool IsUpdated = false;
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
            finally
            {
                Connection.Close();
            }

            return IsUpdated;
        }
        static public DataTable GetAllPeopl()
        {
            DataTable dataTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "select P.PersonID,P.NationalNo,P.FirstName,P.SecondName,P.ThirdName,P.LastName,P.DateOfBirth," +
                "(Case When P.Gendor = 0 Then 'Male' else 'Female'  end) AS Gendor,P.Phone,P.Email,C.CountryName AS Nationality from People As P " +
                "inner join Countries AS C on P.NationalityCountryID =C.CountryID ";
            SqlCommand cmd = new SqlCommand(sql, Connection);
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }


                reader.Close();


            }
            catch (Exception)
            {
                //Errors will be recorded in the LOG file later.
            }
            finally { Connection.Close(); }


            return dataTable;
        }
        static public bool DeletePerson(int PersonID)
        {
            SqlConnection Connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "DELETE FROM People WHERE PersonID = @PersonID;";
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            bool IsDeleted = false;
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
            finally
            {
                Connection.Close();
            }

            return IsDeleted;
        }
        static public bool IsPersonExist(int PersonID)
        {
            SqlConnection Con = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "if Exists(select 1 From People where PersonID =@PersonID)  select 1 else select 0 ";


            SqlCommand cmd = new SqlCommand(sql, Con);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            bool IsExist = false;
            try
            {
                Con.Open();
                object Result = cmd.ExecuteScalar();
                if (Result != null)
                {
                    IsExist = Convert.ToBoolean(Result);
                }



            }
            catch (Exception ex)
            {
                //Errors will be recorded in the LOG file later.
            }
            finally
            {
                Con.Close();
            }

            return IsExist;
        }
        static public bool IsPersonExist(string NationalNo)
        {
            SqlConnection Con = new SqlConnection(DataAccessSetting.ConnectionString);
            string sql = "if Exists(select 1 From People where NationalNo =@NationalNo)  select 1 else select 0 ";


            SqlCommand cmd = new SqlCommand(sql, Con);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);

            bool IsExist = false;
            try
            {
                Con.Open();
                object Result = cmd.ExecuteScalar();
                if (Result != null)
                {
                    IsExist = Convert.ToBoolean(Result);
                }



            }
            catch (Exception ex)
            {
                //Errors will be recorded in the LOG file later.
            }
            finally
            {
                Con.Close();
            }

            return IsExist;
        }






    }
}
