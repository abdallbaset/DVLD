using System;
using System.Data;
using DVLD_DataAccess;
using DVLD_Model;

namespace DVLD_Business
{
    public class clsUser
    {
        enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode;
        public clsUsersModel UserInfo { get; set; }
        public clsPeople PersonInfo { get; set; }
        public clsUser()
        {
            UserInfo = new clsUsersModel();
            _Mode = enMode.AddNew;
        }

        private clsUser(clsUsersModel user)
        {
            UserInfo = user;
            PersonInfo = clsPeople.Find(UserInfo.PersonID);
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
            clsUsersModel UserInfo = clsUsersData.GetUserInfoByUsernameAndPassword(UserName, Password);

            if (UserInfo != null)
            {
                return new clsUser(UserInfo);
            }

            return null;
        }

        private bool _AddNewUser()
        {
            UserInfo.UserID = clsUsersData.AddNewUser(UserInfo);
            return (UserInfo.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(UserInfo);
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
