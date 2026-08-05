using DVLD_DataAccess;
using DVLD_Model;
using Infrastructure.Security;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsUser
    {
        enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode;
        public clsUsersModel UserInfo { get; set; }
        public clsPeople Person { get; set; }
        public clsUser()
        {
            UserInfo = new clsUsersModel();
            _Mode = enMode.AddNew;
        }
        public string UserName
        {
            get  =>  UserInfo.UserName;
            set => UserInfo.UserName = value;
        }
        public int UserID
        {
            get  =>  UserInfo.UserID; 
        }

        public string Password
        {
            get => UserInfo.Password;
            set => UserInfo.Password = value;
        }

        public bool IsActive
        {
            get => UserInfo.IsActive;
            set => UserInfo.IsActive = value;
        }

        public int PersonID
        {
            get => UserInfo.PersonID;    
            set => UserInfo.PersonID = value;
            
        }


        private clsUser(clsUsersModel user)
        {
            UserInfo = user;
            Person = clsPeople.Find(UserInfo.PersonID);
            _Mode = enMode.Update;
        }

        public static clsUser FindByUserID(int UserID)
        {
            clsUsersModel UserInfo = clsUsersData.GetUserInfoByUserID(UserID);

            if (UserInfo != null)
            {
                return new clsUser(UserInfo);
            }

            return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            clsUsersModel UserInfo = clsUsersData.GetUserInfoByPersonID(PersonID);

            if (UserInfo != null)
            {
                return new clsUser(UserInfo);
            }

            return null;
        }

        public static clsUser FindByUserameAndPassword(string UserName, string Password)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
                return null;

            string hashedPassword = HashingHelper.GenerateSHA256Hash(Password);

            clsUsersModel UserInfo = clsUsersData.GetUserInfoByUsernameAndPassword(UserName, hashedPassword);

            if (UserInfo != null)
            {
                return new clsUser(UserInfo);
            }

            return null;
        }

        private bool _AddNewUser()
        {
           UserInfo.Password = HashingHelper.GenerateSHA256Hash(UserInfo.Password);
            UserInfo.UserID = clsUsersData.AddNewUser(UserInfo);
            return (UserInfo.UserID != -1);
        }

        private bool _UpdateUser()
        {
            UserInfo.Password = HashingHelper.GenerateSHA256Hash(UserInfo.Password);
            return clsUsersData.UpdateUser(UserInfo);
        }

        public bool VerifyPassword(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                return false;

            string hashedInput = HashingHelper.GenerateSHA256Hash(plainPassword);

            return this.UserInfo.Password == hashedInput;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();

                default:
                    return false;
            }
        }

        static public DataTable ListUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        static public bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        static public bool IsUserExist(int UserID)
        {
            return clsUsersData.IsUserExist(UserID);
        }

        static public bool IsUserExist(string UserName)
        {
            return clsUsersData.IsUserExist(UserName);
        }

        static public bool isUserExistForPersonID(int PersonID)
        {
            return clsUsersData.isUserExistForPersonID(PersonID);
        }

    }
}
