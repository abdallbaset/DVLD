using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
namespace Infrastructure.Configuration
{
    /// <summary>
    /// Provides utility methods to read and manage configuration settings from the application's App.config file.
    /// </summary>
    [Description("Provides central access to application configuration settings stored in App.config.")]
    public static class AppConfigManager
    {
        /// <summary>
        /// Retrieves the primary database connection string configured in the App.config file.
        /// </summary>
        /// <returns>The database connection string associated with 'DVLDConnectionString'.</returns>
        [Description("Retrieves the connection string for the DVLD database from App.config.")]
        public static string GetDatabaseConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DVLDConnectionString"].ConnectionString;
        }
    }
}
