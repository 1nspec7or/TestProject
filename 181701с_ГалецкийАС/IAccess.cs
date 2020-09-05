using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _181701с_ГалецкийАС
{
    interface IAccess
    {
        void SetLogin(string login);
        string GetLogin();
        void SetPassword(string password);
        string GetPassword();
    }
}
