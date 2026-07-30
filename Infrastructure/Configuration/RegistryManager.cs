using Infrastructure.Logging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class RegistryManager
    {
      
        static readonly string   subKeyPath = @"SOFTWARE\ABDULBASIT\DVLD_System";

        /// <summary>
        /// Writes or updates a string value in the Windows Registry under the specified subKeyPath.
        /// </summary>
        /// <param name="valueName">The name of the value/entry to write (e.g., "Username" or "Password").</param>
        /// <param name="valueData">The string data/content to store.</param>
        /// <returns>True if the value was successfully saved; otherwise, false.</returns>
        static public bool WriteToRegistry(string valueName, string valueData)
        {
            if (string.IsNullOrWhiteSpace(valueName))
                return false;

            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(subKeyPath))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName, valueData ?? string.Empty);
                        return true;
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                EventViewerLogger.LogError($"Permission Error: Insufficient rights to write '{valueName}' to Registry.", ex);
            }
            catch (Exception ex)
            {
                EventViewerLogger.LogError($"Unexpected error occurred while writing '{valueName}' to Registry.", ex);
            }

            return false;
        }

        /// <summary>
        /// Reads a string value from the Windows Registry for a given value name.
        /// </summary>
        /// <param name="valueName">The name of the value to read.</param>
        /// <param name="defaultValue">The default value to return if the key or value does not exist.</param>
        /// <returns>The stored string value, or default value if reading fails/not found.</returns>
        static public string ReadFromRegistry(string valueName, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(valueName))
                return defaultValue;

            try
            {

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKeyPath, false))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(valueName);
                        if (value != null)
                        {
                            return value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.LogError($"An error occurred while reading '{valueName}' from Registry.", ex);
            }

            return defaultValue;
        }

        /// <summary>
        /// Deletes a specific value entry from the Registry path.
        /// </summary>
        /// <param name="valueName">The name of the value to delete.</param>
        /// <returns>True if successfully deleted or already absent; otherwise, false.</returns>
        static public bool DeleteFromRegistry(string valueName)
        {
            if (string.IsNullOrWhiteSpace(valueName))
                return false;

            try
            {

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKeyPath, true))
                {
                    if (key != null)
                    {
                        key.DeleteValue(valueName, false);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.LogError($"Error deleting registry value '{valueName}'.", ex);
            }

            return false;
        }
    }
}
