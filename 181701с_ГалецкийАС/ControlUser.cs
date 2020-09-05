using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace _181701с_ГалецкийАС
{
    class ControlUser
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Добавить пользователя\n2. Обновить учётную запись пользователя\n3. Удалить пользователя\n0. Назад\n");
            switch (int.Parse(Console.ReadLine()))
            {
                case 0: Console.Clear(); return;
                case 1: Console.Clear(); AddUser(); break;
                case 2: Console.Clear(); EditUser(); break;
                case 3: Console.Clear(); DeleteUser(); break;
            }
        }

        public static void AddUser()
        {
            using (StreamWriter sw = new StreamWriter(Path.GetPathAccess(User.GetAccess()), true, Encoding.Default))
            {
                Console.WriteLine("Введите логин нового пользователя: ");
                sw.WriteLine(Encryptor.Encrypt(Console.ReadLine()));
                Console.WriteLine("Введите пароль нового пользователя: ");
                sw.WriteLine(Encryptor.Encrypt(Console.ReadLine()));
                Console.WriteLine("\n\nПользователь добавлен успешно!");
                Thread.Sleep(1000);
            }
        }

        public static void DeleteUser()
        {
            Console.WriteLine("Введите логин пользователя, которого надо удалить: ");
            string deletelogin = Encryptor.Encrypt(Console.ReadLine());
            int deleteindex = -2;
            string[] newfile = File.ReadAllLines(Path.GetPathAccess(User.GetAccess()));
            using (StreamWriter sw = new StreamWriter(Path.GetPathAccess(User.GetAccess()), false, Encoding.Default))
            {
                for (int i = 0; i < newfile.Length; i += 2)
                {
                    if (newfile[i] == deletelogin)
                    {
                        deleteindex = i;
                    }
                }
                for (int i = 0; i < newfile.Length; i++)
                {
                    if (i != deleteindex && i != (deleteindex+1))
                    {
                        sw.WriteLine(newfile[i]);
                    }
                }
            }
            if (deleteindex == -2)
            {
                Console.WriteLine("Пользователя с таким логином не существует!\n");
                Console.WriteLine("\n\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n\nПользователь удалён успешно!");
                Thread.Sleep(1000);
            }
        }

        public static void EditUser()
        {
            Console.WriteLine("Введите логин пользователя, учетную запись которого нужно изменить: ");
            string editlogin = Console.ReadLine();
            int editindex = -2;
            string[] newfile = File.ReadAllLines(Path.GetPathAccess(User.GetAccess()));
            using (StreamWriter sw = new StreamWriter(Path.GetPathAccess(User.GetAccess()), false, Encoding.Default))
            {
                for (int i = 0; i < newfile.Length; i += 2)
                {
                    newfile[i] = Encryptor.Decrypt(newfile[i]);
                    newfile[i+1] = Encryptor.Decrypt(newfile[i + 1]);
                    if (newfile[i] == editlogin)
                    {
                        Console.WriteLine("Введите новый логин: ");
                        newfile[i] = Console.ReadLine();
                        Console.WriteLine("Введите новый пароль: ");
                        newfile[i + 1] = Console.ReadLine();
                        editindex = i;
                    }
                }
                for (int i = 0; i < newfile.Length; i++)
                {
                        sw.WriteLine(Encryptor.Encrypt(newfile[i]));
                }
            }
            if (editindex == -2)
            {
                Console.WriteLine("Пользователя с таким логином не существует!\n");
                Console.WriteLine("\n\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n\nПользователь изменён успешно!");
                Thread.Sleep(1000);
            }
        }
    }
}
