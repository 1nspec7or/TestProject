using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _181701с_ГалецкийАС
{
    class AdminMenu
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Войти\n0. Назад\n");
            switch (int.Parse(Console.ReadLine()))
            {
                case 0: Console.Clear(); return;
                case 1: SignIn(); break;
            }
        }
        
        public static void SignIn()
        {
            Console.WriteLine("Введите логин: ");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            string password = Console.ReadLine();
            if (Access.CheckAdminAccess(login, password))
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t-------Вход успешен!--------");
                Console.WriteLine("\t-----Добро пожаловать!-----");
                Thread.Sleep(3000);
                Console.Clear();
                MainMenu();
            }
            else
            {
                Console.WriteLine("Неправильный логин или пароль!");
                Console.WriteLine("1. Попробовать ещё раз\n0.Назад\n");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1: Console.Clear(); SignIn(); break;
                    case 0: Console.Clear(); return;
                }
                Menu();
            }
            Console.Clear();
        }

        public static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("1. Добавление записи\n2. Редактирование записи\n3. Удаление записи\n" +
                "4. Просмотр всех данных в табличной форме\n5. Поиск и фильтрация данных\n6. Управление пользователями\n0. Назад\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0: Console.Clear(); return;
                    case 1: Console.Clear(); Input.Menu(); break;
                    case 2: Console.Clear(); Edit.Menu(); break;
                    case 3: Console.Clear(); Delete.Menu(); break;
                    case 4: Console.Clear(); Output.Menu(); break;
                    case 5: Console.Clear(); Search.Menu(); break;
                    case 6: Console.Clear(); ControlUser.Menu(); break;
                }
            }
        }
    }
}
