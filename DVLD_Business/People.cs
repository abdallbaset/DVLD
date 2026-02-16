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
            return (PersonInfo.PersonID != -1);
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
