using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;

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
        /// <exception cref="InvalidOperationException">Thrown when the connection string 'DVLDConnectionString' is missing or empty in App.config.</exception>
        /// <exception cref="FormatException">Thrown when the connection string format is invalid or missing required properties (Server, Database, Auth).</exception>
        /// <exception cref="Exception">Thrown when the App.config file itself contains syntax or structural errors.</exception>
        [Description("Retrieves the connection string for the DVLD database from App.config.")]
        public static string GetDatabaseConnectionString()
        {
            string connectionString;

            try
            {
                var connectionSetting = ConfigurationManager.ConnectionStrings["DVLDConnectionString"];

                if (connectionSetting == null || string.IsNullOrWhiteSpace(connectionSetting.ConnectionString))
                {
                    throw new InvalidOperationException("Connection string 'DVLDConnectionString' was not found or is empty in App.config.");
                }

                connectionString = connectionSetting.ConnectionString;

                var builder = new SqlConnectionStringBuilder(connectionString);

                if (string.IsNullOrWhiteSpace(builder.DataSource))
                {
                    throw new FormatException("Connection string is missing the 'Server' or 'Data Source' property.");
                }

                if (string.IsNullOrWhiteSpace(builder.InitialCatalog))
                {
                    throw new FormatException("Connection string is missing the 'Database' or 'Initial Catalog' property.");
                }

                if (!builder.IntegratedSecurity && string.IsNullOrWhiteSpace(builder.UserID))
                {
                    throw new FormatException("Connection string must either use 'Integrated Security=True' or provide a valid 'User ID'.");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new InvalidOperationException("The App.config file is malformed or contains syntax errors.", ex);
            }
            catch (ArgumentException ex)
            {
                throw new FormatException("The ConnectionString 'DVLDConnectionString' has an invalid syntax format.", ex);
            }

            return connectionString;
        }
    }
}