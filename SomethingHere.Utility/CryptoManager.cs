using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingHere.Utility
{
   public class CryptoManager
    {
        private static int cryptoNumericKey = 61;
        public static string Encrypt(string cleanText)
        {
            string encryptText = string.Empty;
            foreach(char item in cleanText)
            {
                int ascii = Convert.ToInt32(item);
                ascii += cryptoNumericKey;
                char newChar = Convert.ToChar(ascii);
                encryptText += newChar;
            }
            return encryptText;
        }
        public static string Decrypt(string encryptText)
        {
            string decryptKey = string.Empty;
            foreach (char item in encryptText)
            {
                int ascii = Convert.ToInt32(item);
                ascii -= cryptoNumericKey;
                char newChar = Convert.ToChar(ascii);
                decryptKey += newChar;
            }
            return decryptKey;
        }
    }
}
