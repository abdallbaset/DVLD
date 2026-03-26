using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DVLD_Model;

namespace DVLD_DataAccess
{
    public class clsPeopleData
    {
        static public clsPeopleModel GetPersonInfoByID(int PersonID)
        {
            clsPeopleModel Person = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From People where PersonID = @PersonID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Person = new clsPeopleModel();

                                Person.PersonID = Convert.ToInt32(reader["PersonID"]);
                                Person.NationalNo = reader["NationalNo"].ToString();
                                Person.FirstName = reader["FirstName"].ToString();
                                Person.SecondName = reader["SecondName"].ToString();
                                Person.ThirdName = (reader["ThirdName"] == DBNull.Value) ? "" : reader["ThirdName"].ToString();
                                Person.LastName = reader["LastName"].ToString();
                                Person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                Person.Email = (reader["Email"] == DBNull.Value) ? "" : reader["Email"].ToString();
                                Person.Phone = reader["phone"].ToString();
                                Person.Address = reader["Address"].ToString();
                                Person.Gendor = Convert.ToByte(reader["Gendor"]);
                                Person.NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                                Person.ImagePath = (reader["ImagePath"] == DBNull.Value) ? "" : reader["ImagePath"].ToString();
                            }
                        }
                    }
                    catch (Exception)
                    {                        //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return Person;
        }

        static public clsPeopleModel GetPersonInfoByNationalNo(string NationalNo)
        {
            clsPeopleModel Person = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From People where NationalNo = @NationalNo;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@NationalNo", NationalNo);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Person = new clsPeopleModel();
                                Person.PersonID = Convert.ToInt32(reader["PersonID"]);
                                Person.NationalNo = reader["NationalNo"].ToString();
                                Person.FirstName = reader["FirstName"].ToString();
                                Person.SecondName = reader["SecondName"].ToString();
                                Person.ThirdName = (reader["ThirdName"] == DBNull.Value) ? "" : reader["ThirdName"].ToString();
                                Person.LastName = reader["LastName"].ToString();
                                Person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                Person.Email = (reader["Email"] == DBNull.Value) ? "" : reader["Email"].ToString();
                                Person.Phone = reader["phone"].ToString();
                                Person.Address = reader["Address"].ToString();
                                Person.Gendor = Convert.ToByte(reader["Gendor"]);
                                Person.NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                                Person.ImagePath = (reader["ImagePath"] == DBNull.Value) ? "" : reader["ImagePath"].ToString();
                            }
                        }
                    }
                    catch (Exception)
                    {                        //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return Person;
        }

        static public int AddNewPerson(clsPeopleModel Person)
        {
            int PersonID = -1;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName,DateOfBirth, Gendor, Address, Phone," +
                               " Email,NationalityCountryID,ImagePath) OUTPUT INSERTED.PersonID" +
                               " VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName,@DateOfBirth, @Gendor, @Address, @Phone, @Email,@NationalityCountryID," +
                               " @ImagePath);";

                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@NationalNo", Person.NationalNo);
                    cmd.Parameters.AddWithValue("@FirstName", Person.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", Person.SecondName);
                    cmd.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(Person.ThirdName) ? (object)DBNull.Value : Person.ThirdName);
                    cmd.Parameters.AddWithValue("@LastName", Person.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", Person.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gendor", Person.Gendor);
                    cmd.Parameters.AddWithValue("@Address", Person.Address);
                    cmd.Parameters.AddWithValue("@Phone", Person.Phone);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Person.Email) ? (object)DBNull.Value : Person.Email);
                    cmd.Parameters.AddWithValue("@NationalityCountryID", Person.NationalityCountryID);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(Person.ImagePath) ? (object)DBNull.Value : Person.ImagePath);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            PersonID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception) {
                        //Errors will be recorded in the LOG file later
                    }
                }
            }
            return PersonID;
        }

        static public bool UpdatePerson(clsPeopleModel Person)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE People SET NationalNo = @NationalNo, FirstName = @FirstName, SecondName = @SecondName, " +
                             "ThirdName = @ThirdName, LastName = @LastName, DateOfBirth = @DateOfBirth, Gendor = @Gendor, " +
                             "Address = @Address, Phone = @Phone, Email = @Email, NationalityCountryID = @NationalityCountryID, " +
                             "ImagePath = @ImagePath WHERE PersonID = @PersonID;";

                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@NationalNo", Person.NationalNo);
                    cmd.Parameters.AddWithValue("@FirstName", Person.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", Person.SecondName);
                    cmd.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(Person.ThirdName) ? (object)DBNull.Value : Person.ThirdName);
                    cmd.Parameters.AddWithValue("@LastName", Person.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", Person.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gendor", Person.Gendor);
                    cmd.Parameters.AddWithValue("@Address", Person.Address);
                    cmd.Parameters.AddWithValue("@Phone", Person.Phone);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Person.Email) ? (object)DBNull.Value : Person.Email);
                    cmd.Parameters.AddWithValue("@NationalityCountryID", Person.NationalityCountryID);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(Person.ImagePath) ? (object)DBNull.Value : Person.ImagePath);
                    cmd.Parameters.AddWithValue("@PersonID", Person.PersonID);

                    try
                    {
                        Connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        IsUpdated = rows > 0;
                    }
                    catch (Exception)
                    {                         //Errors will be recorded in the LOG file later
                    }
                }
            }
            return IsUpdated;
        }

        static public DataTable GetAllPeopl()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select P.PersonID,P.NationalNo,P.FirstName,P.SecondName,P.ThirdName,P.LastName,P.DateOfBirth," +
                             "(Case When P.Gendor = 0 Then 'Male' else 'Female'  end) AS Gendor,P.Phone,P.Email,C.CountryName AS Nationality from People As P " +
                             "inner join Countries AS C on P.NationalityCountryID =C.CountryID ";

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
                    {                         //Errors will be recorded in the LOG file later
                    }
                }
            }
            return dataTable;
        }

        static public bool DeletePerson(int PersonID)
        {
            bool IsDeleted = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "DELETE FROM People WHERE PersonID = @PersonID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        Connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        IsDeleted = rows > 0;
                    }
                    catch (Exception)
                    {                         //Errors will be recorded in the LOG file later
                    }
                }
            }
            return IsDeleted;
        }

        static public bool IsPersonExist(int PersonID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "if Exists(select 1 From People where PersonID =@PersonID) select 1 else select 0";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
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
                    {                         //Errors will be recorded in the LOG file later
                    }
                }
            }
            return IsExist;
        }

        static public bool IsPersonExist(string NationalNo)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "if Exists(select 1 From People where NationalNo =@NationalNo) select 1 else select 0";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
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
                    {                        //Errors will be recorded in the LOG file later
                    }
                }
            }
            return IsExist;
        }
    }
}