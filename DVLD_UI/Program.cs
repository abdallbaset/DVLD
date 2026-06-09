using DVLD_UI.Applications.Application_Types;
using DVLD_UI.Applications.International_License;
using DVLD_UI.Applications.Local_Driving_License;
using DVLD_UI.Applications.Renew_Local_License;
using DVLD_UI.Applications.Rlease_Detained_License;
using DVLD_UI.Drivers;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses;
using DVLD_UI.Licenses.Detain_License;
using DVLD_UI.Licenses.International_Licenses;
using DVLD_UI.Licenses.Local_Licenses;
using DVLD_UI.Login;
using DVLD_UI.Test;
using DVLD_UI.Test.Test_Type;
using DVLD_UI.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          
            while (true)
            {
                frmLogin loginForm = new frmLogin();

                if (loginForm.ShowDialog() == DialogResult.OK)
                {

                    Application.Run(new frmMain());

                    if (clsGlobal.CurrentUser != null)
                    {
                        break;
                    }

                }
                else
                {
                    break;
                }
            }


        }
    }
}
