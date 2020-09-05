using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace _181701с_ГалецкийАС
{
    class Binary
    {
        public static void CopyAccessToBinary()
        {
            string logintmp;
            string passwordtmp;
            using (StreamReader sr = new StreamReader(Path.GetPathAccess(Admin.GetAccess()), Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    logintmp = sr.ReadLine();
                    passwordtmp = sr.ReadLine();
                    using (BinaryWriter br = new BinaryWriter(File.Open(Path.GetPathBinaryAccess(Admin.GetBinaryAccess()), FileMode.OpenOrCreate)))
                    {
                        br.Write(logintmp);
                        br.Write(passwordtmp);
                    }
                }
            }
            using (StreamReader sr = new StreamReader(Path.GetPathAccess(User.GetAccess()), Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    logintmp = sr.ReadLine();
                    passwordtmp = sr.ReadLine();
                    using (BinaryWriter br = new BinaryWriter(File.Open(Path.GetPathBinaryAccess(User.GetBinaryAccess()), FileMode.OpenOrCreate)))
                    {
                        br.Write(logintmp);
                        br.Write(passwordtmp);
                    }
                }
            }

            Console.Clear();
            Console.Write("1. Вход под администратором\n2. Вход под пользователем\n3. Выход\n0. Назад\n");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0: Console.Clear(); return;
                case 1: AdminSignIn(); break;
                case 2: UserSignIn(); break;
                case 3: Environment.Exit(0); break;
            }
        }

        public static bool AdminEmergencyEnter(string login, string password)
        {
            login = Encryptor.Encrypt(login);
            password = Encryptor.Encrypt(password);
            bool check = false;
            string logintmp;
            string passwordtmp;
            using (BinaryReader br = new BinaryReader(File.Open(Path.GetPathBinaryAccess(Admin.GetBinaryAccess()), FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    logintmp = br.ReadString();
                    passwordtmp = br.ReadString();
                    if (login == logintmp && password == passwordtmp)
                    {
                        check = true;
                    }
                }
            }
            return check;
        }

        public static bool UserEmergencyEnter(string login, string password)
        {
            login = Encryptor.Encrypt(login);
            password = Encryptor.Encrypt(password);
            bool check = false;
            string logintmp;
            string passwordtmp;
            using (BinaryReader br = new BinaryReader(File.Open(Path.GetPathBinaryAccess(User.GetBinaryAccess()), FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    logintmp = br.ReadString();
                    passwordtmp = br.ReadString();
                    if (login == logintmp && password == passwordtmp)
                    {
                        check = true;
                    }
                }
            }
            return check;
        }

        public static void AdminSignIn()
        {
            Console.WriteLine("Введите логин: ");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            string password = Console.ReadLine();
            if (AdminEmergencyEnter(login, password))
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t-------Вход успешен!--------");
                Console.WriteLine("\t-----Добро пожаловать!-----");
                Thread.Sleep(3000);
                Console.Clear();
                AdminMenu.MainMenu();
            }
            else
            {
                Console.WriteLine("Неправильный логин или пароль!");
                Console.WriteLine("1. Попробовать ещё раз\n0.Назад\n");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1: Console.Clear(); AdminSignIn(); break;
                    case 0: Console.Clear(); return;
                }
            }
            Console.Clear();
        }

        public static void UserSignIn()
        {
            Console.WriteLine("Введите логин: ");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            string password = Console.ReadLine();
            if (UserEmergencyEnter(login, password))
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t-------Вход успешен!--------");
                Console.WriteLine("\t-----Добро пожаловать!-----");
                Thread.Sleep(3000);
                Console.Clear();
                UserMenu.MainMenu();
            }
            else
            {
                Console.WriteLine("Неправильный логин или пароль!");
                Console.WriteLine("1. Попробовать ещё раз\n0.Назад\n");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1: Console.Clear(); UserSignIn(); break;
                    case 0: Console.Clear(); return;
                }
            }
            Console.Clear();
        }
    }
}
