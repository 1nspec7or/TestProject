using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _181701с_ГалецкийАС
{
    class Admin : IAccess
    {
        private string login;
        public void SetLogin(string login)
        {
            this.login = login;
        }
        public string GetLogin()
        {
            return login;
        }

        private string password;
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public string GetPassword()
        {
            return password;
        }

        //private static Admin admin;
        public static string GetAccess()
        {
            return "admin";
        }
        public static string GetBinaryAccess()
        {
            return "adminbin";
        }
    }
}
