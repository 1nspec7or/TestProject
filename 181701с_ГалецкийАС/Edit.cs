using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _181701с_ГалецкийАС
{
    class Edit
    {
        public static void Menu()
        {
            Console.WriteLine("Выберите какой файл хотите заменить:\n1. Автомобили\n2. Клиенты\n3. Выданные автомобили\n0. Назад");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0: Console.Clear(); return;
                case 1: EditSomething(Output.OutputListFile(new Car()), choice); break;
                case 2: EditSomething(Output.OutputListFile(new Customer()), choice); break;
                case 3: EditSomething(Output.OutputListFile(new GivenCars()), choice); break;
            }

        }
        private static void EditSomething(List<object> list, int choice)
        {
            if (list.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Файл пуст!\n");
                return;
            }
            Console.WriteLine("Выберите какой номер хотите заменить: ");
            int num = int.Parse(Console.ReadLine());
            if (num > list.Count || num <= -1 || num == 0)
            {
                Console.Clear();
                Console.WriteLine("Указан не верный номер!\n");
                return;
            }
            num--;
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Введите номер авто:");
                        ((Car)list[num]).AutoCode = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите модель авто:");
                        ((Car)list[num]).AutoModel = Console.ReadLine();
                        Console.WriteLine("Введите стоимость авто:");
                        ((Car)list[num]).AutoPrice = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите стоимость аренды:");
                        ((Car)list[num]).AutoRentalCost = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите тип авто:");
                        ((Car)list[num]).AutoType = Console.ReadLine();
                        Input.InputListFile(list, new Car());
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Введите код клиента:");
                        ((Customer)list[num]).CustomerCode = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите фамилию:");
                        ((Customer)list[num]).CustomerSurname = Console.ReadLine();
                        Console.WriteLine("Введите имя:");
                        ((Customer)list[num]).CustomerName = Console.ReadLine();
                        Console.WriteLine("Введите отчество:");
                        ((Customer)list[num]).CustomerPatronymic = Console.ReadLine();
                        Console.WriteLine("Введите адрес:");
                        ((Customer)list[num]).CustomerAdress = Console.ReadLine();
                        Console.WriteLine("Введите телефон:");
                        ((Customer)list[num]).CustomerPhoneNumber = int.Parse(Console.ReadLine());
                        Input.InputListFile(list, new Customer());
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Введите номер авто:");
                        ((GivenCars)list[num]).AutoCode = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите код клиента:");
                        ((GivenCars)list[num]).CustomerCode = int.Parse(Console.ReadLine());
                        ((GivenCars)list[num]).RentTime = Time.SetTime(0);
                        Console.WriteLine("Введите количество часов аренды: ");
                        ((GivenCars)list[num]).ReturnTime = Time.SetTime(double.Parse(Console.ReadLine()));
                        Input.InputListFile(list, new GivenCars());
                        break;
                    }
                case 0: Console.Clear(); return;
            }
            Console.Clear();
            Console.WriteLine("Замена прошла успешна!\n");
            Thread.Sleep(1000);
        }
    }
}
