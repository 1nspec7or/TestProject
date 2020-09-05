using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _181701с_ГалецкийАС
{
    class Input
    {
        public static void Menu()
        {
            Console.WriteLine("Что хотите добавить?\n1. Автомобиль\n2. Клиента\n3. Выданный автомобиль\n0. Назад");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: InputCar(); break;
                case 2: InputCustomer(); break;
                case 3: InputGivenCars(); break;
                case 0: Console.Clear(); return;
            }
            Console.Clear();
            Console.WriteLine("Добавление прошло успешно!\n");
        }
        private static void InputCar()
        {
            Car cars = new Car();
            Console.WriteLine("Введите номер авто:");
            cars.AutoCode = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите модель авто:");
            cars.AutoModel = Console.ReadLine();
            Console.WriteLine("Введите стоимость авто:");
            cars.AutoPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите стоимость аренды:");
            cars.AutoRentalCost = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите тип авто:");
            cars.AutoType = Console.ReadLine();
            InputFile(cars);
        }
        private static void InputCustomer()
        {
            Customer customers = new Customer();
            Console.WriteLine("Введите код клиента:");
            customers.CustomerCode = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите фамилию:");
            customers.CustomerSurname = Console.ReadLine();
            Console.WriteLine("Введите имя:");
            customers.CustomerName = Console.ReadLine();
            Console.WriteLine("Введите отчество:");
            customers.CustomerPatronymic = Console.ReadLine();
            Console.WriteLine("Введите адрес:");
            customers.CustomerAdress = Console.ReadLine();
            Console.WriteLine("Введите телефон:");
            customers.CustomerPhoneNumber = int.Parse(Console.ReadLine());
            InputFile(customers);
        }
        public static void InputGivenCars()
        {
            GivenCars givens = new GivenCars();
            Console.WriteLine("Введите номер автомобиля:");
            givens.AutoCode = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите код клиента:");
            givens.CustomerCode = int.Parse(Console.ReadLine());
            givens.RentTime = Time.SetTime(0);
            Console.WriteLine("Введите количество часов аренды: ");
            givens.ReturnTime = Time.SetTime(double.Parse(Console.ReadLine()));
            InputFile(givens);
        }
        public static void InputFile(object something)
        {
            using (StreamWriter sw = new StreamWriter(Path.GetPathSomething(something), true, Encoding.UTF8))
            {
                switch (something.GetType().ToString())
                {
                    case "_181701с_ГалецкийАС.Car":
                        {
                            sw.WriteLine(((Car)something).AutoCode);
                            sw.WriteLine(((Car)something).AutoModel);
                            sw.WriteLine(((Car)something).AutoPrice);
                            sw.WriteLine(((Car)something).AutoRentalCost);
                            sw.WriteLine(((Car)something).AutoType + "\n");
                            break;
                        }
                    case "_181701с_ГалецкийАС.Customer":
                        {
                            sw.WriteLine(((Customer)something).CustomerCode);
                            sw.WriteLine(((Customer)something).CustomerSurname);
                            sw.WriteLine(((Customer)something).CustomerName);
                            sw.WriteLine(((Customer)something).CustomerPatronymic);
                            sw.WriteLine(((Customer)something).CustomerAdress);
                            sw.WriteLine(((Customer)something).CustomerPhoneNumber + "\n");
                            break;
                        }
                    case "_181701с_ГалецкийАС.GivenCars":
                        {
                            sw.WriteLine(((GivenCars)something).AutoCode);
                            sw.WriteLine(((GivenCars)something).CustomerCode);
                            sw.WriteLine(((GivenCars)something).RentTime);
                            sw.WriteLine(((GivenCars)something).ReturnTime + "\n");
                            break;
                        }
                }
            }
        }
        public static void InputListFile(List<object> list, object something)
        {
            using (StreamWriter sw = new StreamWriter(Path.GetPathSomething(something), false, Encoding.Default))
            {
                switch (something.GetType().ToString())
                {
                    case "_181701с_ГалецкийАС.Car":
                        {
                            int index = 0;
                            while (index != list.Count)
                            {
                                sw.WriteLine(((Car)list[index]).AutoCode);
                                sw.WriteLine(((Car)list[index]).AutoModel);
                                sw.WriteLine(((Car)list[index]).AutoPrice);
                                sw.WriteLine(((Car)list[index]).AutoRentalCost);
                                sw.WriteLine(((Car)list[index]).AutoType + "\n");
                                index++;
                            }
                            break;
                        }
                    case "_181701с_ГалецкийАС.Customer":
                        {
                            int index = 0;
                            while (index != list.Count)
                            {
                                sw.WriteLine(((Customer)list[index]).CustomerCode);
                                sw.WriteLine(((Customer)list[index]).CustomerSurname);
                                sw.WriteLine(((Customer)list[index]).CustomerName);
                                sw.WriteLine(((Customer)list[index]).CustomerPatronymic);
                                sw.WriteLine(((Customer)list[index]).CustomerAdress);
                                sw.WriteLine(((Customer)list[index]).CustomerPhoneNumber + "\n");
                                index++;
                            }
                            break;
                        }
                    case "_181701с_ГалецкийАС.GivenCars":
                        {
                            int index = 0;
                            while (index != list.Count)
                            {
                                sw.WriteLine(((GivenCars)list[index]).AutoCode);
                                sw.WriteLine(((GivenCars)list[index]).CustomerCode);
                                sw.WriteLine(((GivenCars)list[index]).RentTime);
                                sw.WriteLine(((GivenCars)list[index]).ReturnTime + "\n");
                                index++;
                            }
                            break;
                        }
                }
            }
        }
    }
}
