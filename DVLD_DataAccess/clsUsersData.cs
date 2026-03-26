using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Model;

namespace DVLD_DataAccess
{
    public class clsUsersData
    {
        static public clsUsersModel GetUserInfoByUserID(int UserID)
        {
            clsUsersModel User = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From Users where UserID = @UserID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User = new clsUsersModel();
                                User.UserID = Convert.ToInt32(reader["UserID"]);
                                User.PersonID = Convert.ToInt32(reader["PersonID"]);
                                User.UserName = reader["UserName"].ToString();
                                User.Password = reader["Password"].ToString();
                                User.IsActive = Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return User;
        }

        static public clsUsersModel GetUserInfoByPersonID(int PersonID)
        {
            clsUsersModel User = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "select * From Users where PersonID = @PersonID;";
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
                                User = new clsUsersModel();
                                User.UserID = Convert.ToInt32(reader["UserID"]);
                                User.PersonID = Convert.ToInt32(reader["PersonID"]);
                                User.UserName = reader["UserName"].ToString();
                                User.Password = reader["Password"].ToString();
                                User.IsActive = Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return User;
        }
        static public clsUsersModel GetUserInfoByUsernameAndPassword(string UserName, string Password)
        {
            clsUsersModel User = null;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password;";

                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User = new clsUsersModel
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    PersonID = Convert.ToInt32(reader["PersonID"]),
                                    UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Errors will be recorded in the LOG file later.
                    }
                }
            }

            return User;
        }

        static public int AddNewUser(clsUsersModel User)
        {
            int UserID = -1;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "INSERT INTO Users (PersonID, UserName, Password, IsActive) OUTPUT INSERTED.UserID " +
                             "VALUES (@PersonID, @UserName, @Password, @IsActive);";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", User.PersonID);
                    cmd.Parameters.AddWithValue("@UserName", User.UserName);
                    cmd.Parameters.AddWithValue("@Password", User.Password);
                    cmd.Parameters.AddWithValue("@IsActive", User.IsActive);

                    try
                    {
                        Connection.Open();
                        object Result = cmd.ExecuteScalar();
                        if (Result != null)
                        {
                            UserID = Convert.ToInt32(Result);
                        }
                    }
                    catch (Exception)
                    {                //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return UserID;
        }

        static public bool UpdateUser(clsUsersModel User)
        {
            bool IsUpdated = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "UPDATE Users SET PersonID = @PersonID, UserName = @UserName, " +
                             "Password = @Password, IsActive = @IsActive WHERE UserID = @UserID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", User.PersonID);
                    cmd.Parameters.AddWithValue("@UserName", User.UserName);
                    cmd.Parameters.AddWithValue("@Password", User.Password);
                    cmd.Parameters.AddWithValue("@IsActive", User.IsActive);
                    cmd.Parameters.AddWithValue("@UserID", User.UserID);

                    try
                    {
                        Connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        IsUpdated = rows > 0;
                    }
                    catch (Exception)
                    {                 //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return IsUpdated;
        }

        static public DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "SELECT U.UserID, U.PersonID, (P.FirstName + ' ' + P.SecondName + ISNULL(' ' + P.ThirdName, '') + ' ' + P.LastName) AS FullName, " +
                             "U.UserName, U.IsActive FROM Users AS U INNER JOIN People AS P ON U.PersonID = P.PersonID;";
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
                    {                 //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return dataTable;
        }

        static public bool DeleteUser(int UserID)
        {
            bool IsDeleted = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "DELETE FROM Users WHERE UserID = @UserID;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        Connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        IsDeleted = rows > 0;
                    }
                    catch (Exception)
                    {                //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return IsDeleted;
        }

        static public bool IsUserExist(int UserID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "if Exists(select 1 From Users where UserID = @UserID)  select 1 else select 0 ;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserID);
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
                    {                //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return IsExist;
        }
        static public bool isUserExistForPersonID(int PersonID)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "if Exists(select 1 From Users where PersonID = @PersonID)  select 1 else select 0 ;";
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
                    {                //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return IsExist;
        }
        static public bool IsUserExist(string UserName)
        {
            bool IsExist = false;

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string sql = "if Exists(select 1 From Users where UserName = @UserName)  select 1 else select 0 ;";
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
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
                    {                //Errors will be recorded in the LOG file later.
                    }
                }
            }
            return IsExist;
        }

    }
}