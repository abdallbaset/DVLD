using DVLD_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_UI.GlobalClasses
{
    public class clsGlobal
    {
      static public clsUser CurrentUser { get; set; }

      static public string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\ABDULBASIT\DVLD_System";

        private static readonly string _EncryptionKey = "1234567890123456";

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
                return "Error: " + ex.Message;

            }
        }

 
       

    }
}
