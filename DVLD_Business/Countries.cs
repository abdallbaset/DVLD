using DVLD_DataAccess;
using DVLD_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_Business
{
    public class clsCountries
    {
        public static string GetCountryNameByCountryID(int CountryID)
        {
            return clsCountriesData.GetCountryNameByCountryID(CountryID);
        }
        static public DataTable GetAllCountry()
        {
            return clsCountriesData.GetAllCountry();
        }
        static public int GetCountryIDByCountryName(string CountryName)
        {
            return clsCountriesData.GetCountryIDByCountryName(CountryName);
        }
    }
}
