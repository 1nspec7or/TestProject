using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _181701с_ГалецкийАС
{
    class Access
    {
        public static bool CheckAdminAccess(string login, string password)
        {
            login = Encryptor.Encrypt(login);
            password = Encryptor.Encrypt(password);
            bool check = false;
            string logintmp;
            string passwordtmp;
            using (StreamReader sr = new StreamReader(Path.GetPathAccess(Admin.GetAccess()), Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    logintmp = sr.ReadLine();
                    passwordtmp = sr.ReadLine();
                    if (login == logintmp && password == passwordtmp)
                    {
                        check = true;
                    }
                }
            }
            return check;
        }

        public static bool CheckUserAccess(string login, string password)
        {
            login = Encryptor.Encrypt(login);
            password = Encryptor.Encrypt(password);
            bool check = false;
            string logintmp;
            string passwordtmp;
            using (StreamReader sr = new StreamReader(Path.GetPathAccess(User.GetAccess()), Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    logintmp = sr.ReadLine();
                    passwordtmp = sr.ReadLine();
                    if (login == logintmp && password == passwordtmp)
                    {
                        check = true;
                    }
                }
            }
            return check;
        }
    }
}