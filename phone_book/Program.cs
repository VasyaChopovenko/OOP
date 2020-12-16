using System;
using System.Collections.Generic;
using System.Text;

namespace phone_book
{
    class PhoneBook
    {
        public int Count { get; set; } = 0;

        private List<Subscriber> subscribers;

        public PhoneBook()
        {
            subscribers = new List<Subscriber>();
        }

        public void AddNewSubscriber(Subscriber subscriber)
        {
            subscribers.Add(subscriber);
            Count++;
        }

        public void DeleteSubscriber(int x)
        {
            if (x - 1 < subscribers.Count)
            {
                subscribers.RemoveAt(x - 1);
                Console.WriteLine("\nКонтакт успішно видалений\n");
            }
            else
                Console.WriteLine("\nНе існує конакта з таким індексом\n");
        }

        public void ShowAll()
        {
            if (subscribers.Count != 0)
            {
                for (int i = 0; i < subscribers.Count; i++)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine($"\n{i + 1}.");
                    Console.WriteLine($"{subscribers[i].Surname} ");
                    Console.WriteLine($"{subscribers[i].Name}");
                    Console.WriteLine($"{subscribers[i].Patronymic }");
                    Console.WriteLine($"{subscribers[i].Number } ");
                    Console.WriteLine($"{subscribers[i].Info}\n");
                    Console.WriteLine("-------------------------");
                }
            }
            else
            {
                Console.WriteLine("\nТелефонна книга порожня\n");
            }
        }
    }

    class Subscriber
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Number { get; set; }
        public string Info { get; set; }

        public Subscriber(string name, string surname, string patronymic, string number, string info)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Number = number;
            Info = info;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            PhoneBook phoneBook = new PhoneBook();
            phoneBook.Count = phoneBook.Count;

            int choose;

            do
            {
                Console.WriteLine("Виберіть операцію:\n1.Переглянути всі контакти\n2.Додати новий контакт\n3.Видалити контакт\n4.Вийти");
                choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        phoneBook.ShowAll();
                        break;
                    case 2:
                        Console.WriteLine("Введіть прізвище: ");
                        string surname = Console.ReadLine();

                        Console.WriteLine("Введіть ім'я: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Введіть по-батькові: ");
                        string patronymic = Console.ReadLine();

                        Console.WriteLine("Введіть номер: ");
                        string number = Console.ReadLine();

                        Console.WriteLine("Введіть додаткову інформацію: ");
                        string info = Console.ReadLine();
                        Console.WriteLine();

                        Subscriber subscriber = new Subscriber(surname, name, patronymic, number, info);
                        phoneBook.AddNewSubscriber(subscriber);
                        break;
                    case 3:
                        Console.WriteLine("Введіть номер конатка, який ви хочете видалити");
                        int x = Convert.ToInt32(Console.ReadLine());
                        phoneBook.DeleteSubscriber(x);
                        break;
                }
            } while (choose != 4);
        }
    }
}
