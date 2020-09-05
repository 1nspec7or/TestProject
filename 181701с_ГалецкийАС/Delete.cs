using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _181701с_ГалецкийАС
{
    class Delete
    {
        public static void Menu()
        {
            Console.WriteLine("Выберите из какого файла хотите удалить:\n1. Автомобиль\n2. Клиент\n3. Выданный автомобиль\n0. Назад");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0: Console.Clear(); return;
                case 1: DeleteSomething(Output.OutputListFile(new Car()), choice); break;
                case 2: DeleteSomething(Output.OutputListFile(new Customer()), choice); break;
                case 3: DeleteSomething(Output.OutputListFile(new GivenCars()), choice); break;
            }

        }
        private static void DeleteSomething(List<object> list, int choice)
        {
            if (list.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Файл пуст!\n");
                return;
            }
            Console.WriteLine("Выберите номер объекта, который хотите удалить: ");
            int num = int.Parse(Console.ReadLine());
            if (num > list.Count || num <= -1 || num == 0)
            {
                Console.Clear();
                Console.WriteLine("Указан неверный номер!\n");
                Thread.Sleep(1000);
                return;
            }
            num--;
            switch (choice)
            {
                case 0: Console.Clear(); return;
                case 1: list.RemoveAt(num); Input.InputListFile(list, new Car()); break;
                case 2: list.RemoveAt(num); Input.InputListFile(list, new Customer()); break;
                case 3: list.RemoveAt(num); Input.InputListFile(list, new GivenCars()); break;
            }
            Console.Clear();
            Console.WriteLine("\n\nУдаление прошло успешно!");
            Thread.Sleep(1000);
        }
    }
}
