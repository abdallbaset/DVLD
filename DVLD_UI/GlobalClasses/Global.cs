using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DVLD_UI.GlobalClasses
{
    static class clsGlobal
    {
       static public void DeletePersonImageOnDisk(string FilePath)
        {

            try
            {
                if (!string.IsNullOrEmpty(FilePath) && File.Exists(FilePath))
                    File.Delete(FilePath);
            }
            catch (Exception ex)
            {
                //Errors will be recorded in the LOG file later.
            }

        }

 
    }
}
