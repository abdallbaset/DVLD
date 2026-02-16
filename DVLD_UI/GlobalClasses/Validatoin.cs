using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD_UI.GlobalClasses
{
    static public  class clsValidatoin
    {
        static public bool ValidateEmail(string EmailAddress)
        {
            if (string.IsNullOrWhiteSpace(EmailAddress))
                return false;


            string pattern = @"^[a-zA-Z][a-zA-Z0-9._-]*@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(EmailAddress, pattern);
        }
    }
}
