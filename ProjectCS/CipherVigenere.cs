using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCS
{
    public class CipherVigenere
    {
        static Random random = new Random();
        private static string alphabet = "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя" +
            "ABCDEFGHIJKLMNOPQRSTUVWXYZАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ" +
            "0123456789\"!#$%&'()*+,-./:;<=>?[\\]^_`{|}\n ";
        public static string Encrypt(string text, string key)
        {
            string cipherText = string.Empty;
            for (int i = 0, j = 0; i < text.Length; i++, j++)
            {
                if (j >= key.Length)
                    j = 0;
                char letter = key[j];
                int sum = (alphabet.IndexOf(text[i]) + alphabet.IndexOf(letter)) % alphabet.Length;
                cipherText += alphabet[sum];
            }
            return cipherText;
        }
        public static string Decrypt(string cipherText, string key)
        {
            string line = String.Empty;
            for (int i = 0, j = 0; i < cipherText.Length; i++, j++)
            {
                if (j >= key.Length)
                    j = 0;
                char letter = key[j];
                int sum;
                if (alphabet.IndexOf(cipherText[i]) < alphabet.IndexOf(letter))
                {
                    sum = alphabet.Length + alphabet.IndexOf(cipherText[i]) - alphabet.IndexOf(letter);
                    line += alphabet[sum];
                    continue;
                }
                sum = alphabet.IndexOf(cipherText[i]) - alphabet.IndexOf(letter);
                line += alphabet[sum];
            }
            return line;
        }
    }
}
