using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DVLD_DataAccess;
using DVLD_Model;
using System.IO;
namespace DVLD_Business
{
    public class clsPeople
    {
        enum enMode { AddNew = 1 , Update = 2 }
        private enMode _Mode;
        public clsPeopleModel PersonInfo { get; set; } 

        public clsPeople() 
        { 
            PersonInfo = new clsPeopleModel();
           _Mode = enMode.AddNew;
        }
        public clsPeople(clsPeopleModel Personn) 
        {
            PersonInfo = Personn;
           _Mode = enMode.Update;
        }

        public int PersonID
        {
            get => PersonInfo.PersonID;
        }

        public string NationalNo
        {
            get => PersonInfo.NationalNo;
            set => PersonInfo.NationalNo = value;
        }

        public string FirstName
        {
            get => PersonInfo.FirstName;
            set => PersonInfo.FirstName = value;
        }

        public string SecondName
        {
            get => PersonInfo.SecondName;
            set => PersonInfo.SecondName = value;
        }

        public string ThirdName
        {
            get => PersonInfo.ThirdName;
            set => PersonInfo.ThirdName = value;
        }

        public string LastName
        {
            get => PersonInfo.LastName;
            set => PersonInfo.LastName = value;
        }

        public string FullName
        {
            get => PersonInfo.FullName;
        }

        public DateTime DateOfBirth
        {
            get => PersonInfo.DateOfBirth;
            set => PersonInfo.DateOfBirth = value;
        }

        public byte Gendor
        {
            get => PersonInfo.Gendor;
            set => PersonInfo.Gendor = value;
        }

        public string Address
        {
            get => PersonInfo.Address;
            set => PersonInfo.Address = value;
        }

        public string Phone
        {
            get => PersonInfo.Phone;
            set => PersonInfo.Phone = value;
        }

        public string Email
        {
            get => PersonInfo.Email;
            set => PersonInfo.Email = value;
        }

        public int NationalityCountryID
        {
            get => PersonInfo.NationalityCountryID;
            set => PersonInfo.NationalityCountryID = value;
        }

        public string ImagePath
        {
            get => PersonInfo.ImagePath;
            set => PersonInfo.ImagePath = value;
        }


        public static clsPeople Find(int PersonId)
        {
            clsPeopleModel PersonInfo = clsPeopleData.GetPersonInfoByID(PersonId);

            if (PersonInfo != null)
            {
                return new clsPeople(PersonInfo);
            }

            return null;
        }
        public static clsPeople Find(string NationalNo)
        {
            clsPeopleModel PersonInfo = clsPeopleData.GetPersonInfoByNationalNo(NationalNo);

            if (PersonInfo != null)
            {
                return new clsPeople(PersonInfo);
            }

            return null;
        }


        private bool _AddNewPerson()
        {
            PersonInfo.PersonID = clsPeopleData.AddNewPerson(PersonInfo);
            return (PersonID != (int)clsSettingsModel.enIdentityStatus.NonExistent);
        }
        private bool _UpdatePerson()
        {
            
            return clsPeopleData.UpdatePerson(PersonInfo);
        }

        static public DataTable ListPeople()
        {
            return clsPeopleData.GetAllPeopl();
        }

        static public bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);
        }
        static public bool IsExist(int PersonID)
        {
            return clsPeopleData.IsPersonExist(PersonID);
        }
        static public bool IsExist(string NationalNo)
        {
            return clsPeopleData.IsPersonExist(NationalNo);
        }

        public bool Save()
        {
            switch (_Mode)
            { 
              case enMode.AddNew:
                    if(_AddNewPerson())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {  return false;}
            
            case enMode.Update:

                    return _UpdatePerson();

                    default:
                    return false;
            
            }

        }


       
        




    }
}
