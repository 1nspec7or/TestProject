using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _181701с_ГалецкийАС
{
    class MainMenu
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("1. Вход под администратором\n2. Вход под пользователем\n3. Запасной вход (через бинарный файл)\n0. Выход\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0: Environment.Exit(0); break;
                    case 1: AdminMenu.Menu(); break;
                    case 2: UserMenu.Menu(); break;
                    case 3: Binary.CopyAccessToBinary(); break; 
                }
            }
        }
    }
}
