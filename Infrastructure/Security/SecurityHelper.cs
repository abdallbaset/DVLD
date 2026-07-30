using Infrastructure.Logging;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Security
{
    /// <summary>
    /// Provides cryptographic operations such as Encryption and Decryption using the AES algorithm.
    /// </summary>
    public class SecurityHelper
    {
        private static readonly string _EncryptionKey = "1234567890123456";

        /// <summary>
        /// Encrypts a plain text string into a Base64 cipher text using AES.
        /// </summary>
        /// <param name="plainText">The raw string to be encrypted (e.g., a password).</param>
        /// <returns>A Base64 encoded string representing the encrypted data, or null if encryption fails.</returns>
        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return "";

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(_EncryptionKey);

                    aes.IV = new byte[16];

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(plainText);
                            }
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                EventViewerLogger.LogError("Error occurred during text encryption.", ex);

                return null;
            }
        }

        /// <summary>
        /// Decrypts a Base64 encrypted string back to its original plain text using AES.
        /// </summary>
        /// <param name="cipherText">The Base64 encrypted string.</param>
        /// <returns>The decrypted plain text, or null if decryption fails.</returns>
        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return "";

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(_EncryptionKey);
                    aes.IV = new byte[16];

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                EventViewerLogger.LogError("Invalid Base64 format during decryption.", ex);
                return null;
            }
            catch (CryptographicException ex)
            {
                EventViewerLogger.LogError("Cryptographic error occurred during decryption. Key or data might be invalid.", ex);
                return null;
            }
            catch (Exception ex)
            {
                EventViewerLogger.LogError("Unexpected error occurred during text decryption.", ex);
                return null;
            }
        }
    }
}