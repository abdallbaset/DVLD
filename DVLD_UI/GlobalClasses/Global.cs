using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DVLD_Business;
namespace DVLD_UI.GlobalClasses
{
    public class clsGlobal
    {
      static public clsUser CurrentUser { get; set; }

      static public string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\ABDULBASIT\DVLD_System";

    }
}
