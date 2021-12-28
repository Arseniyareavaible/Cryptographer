using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCS
{
    public class CipherVigenere
    {
          public static string Encrypt(string encryptedText, string key)
          {
               var decryptedText = new StringBuilder();

               for (int i = 0, j = 0; i < encryptedText.Length; i++, j++)
               {
                    if (j == key.Length)
                         j = 0;

                    decryptedText.Append((char)(encryptedText[i] + key[j]));
               }

               return decryptedText.ToString();
          }

          public static string Decrypt(string decryptedText, string key)
          {
               var encryptedText = new StringBuilder();

               for (int i = 0, j = 0; i < decryptedText.Length; i++, j++)
               {
                    if (j == key.Length)
                         j = 0;

                    encryptedText.Append((char)(decryptedText[i] - key[j]));
               }

               return encryptedText.ToString();
          }
     }
}
