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
using Infrastructure.Configuration;
using Infrastructure.Logging;
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

            try
            {
                _ = AppConfigManager.GetDatabaseConnectionString();
            }
            catch (Exception ex)
            {
                EventViewerLogger.LogError("Critical failure during application startup: App.config is missing or invalid.", ex);
     
                MessageBox.Show($"System initialization failed due to a settings issue.:\n{ex.Message}",
                                "critical error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return; 
            }

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
