using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _181701с_ГалецкийАС
{
    class Encryptor
    {
        public static string Encrypt(string EncryptString)
        {
            string tmpstr = "";
            foreach (char symbol in EncryptString)
            {
                int tmp = symbol + 7;
                tmpstr = tmpstr + (char)tmp;
            }
            return tmpstr;
        }
        public static string Decrypt(string DecryptString)
        {
            string tmpstr = "";
            foreach (char symbol in DecryptString)
            {
                int tmp = symbol - 7;
                tmpstr = tmpstr + (char)tmp;
            }
            return tmpstr;
        }
    }
}
