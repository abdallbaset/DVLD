using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public class SymmetricCryptoHelper
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

        /// <summary>
        /// Decrypts a Base64 encrypted string back to its original plain text using AES.
        /// </summary>
        /// <param name="cipherText">The Base64 encrypted string.</param>
        /// <returns>The decrypted plain text, or null if decryption fails.</returns>
        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return "";


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
    }
}
