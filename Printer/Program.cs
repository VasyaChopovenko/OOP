using System;
using System.Collections.Generic;
using System.Text;

namespace Printer
{
    public enum Priority
    {
        High = 3,
        Middle = 2,
        Low = 1
    }

    class Client
    {
        public string Name { get; set; }
        public Priority priority { get; set; }

        public static readonly int Counter;

        public Client()
        {

        }

        static Client()
        {
            Counter++;
        }

        public Client(string name)
        {
            Name = name;
            AddPriority();
        }

        private void AddPriority()
        {
            Random random = new Random();
            priority = (Priority)random.Next(1, 4);
        }
    }

    class Program
    {
        static Queue<Client> lowPriority = new Queue<Client>();
        static Queue<Client> middlePriority = new Queue<Client>();
        static Queue<Client> highPriority = new Queue<Client>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int choice = 0;

            do
            {
                try
                {
                    Console.WriteLine("Виберіть операцію: \n1.Додати користувача \n2.Показати статистику");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Action[] actions = new Action[] { null, AddClient, ShowStatistic };

                    if (actions[choice] != null)
                    {
                        actions[choice].Invoke();
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("\n------Вибрана неправильна операція. Повторіть спробу------\n");
                }


            }
            while (choice != 2);
        }

        public static void AddClient()
        {
            Console.WriteLine("Введіть ім'я користувача: ");
            string name = Console.ReadLine();

            Client client = new Client(name);
            switch (client.priority)
            {
                case Priority.Low:
                    lowPriority.Enqueue(client);
                    break;
                case Priority.Middle:
                    middlePriority.Enqueue(client);
                    break;
                case Priority.High:
                    highPriority.Enqueue(client);
                    break;
            }
        }

        public static void ShowStatistic()
        {
            Client client;

            if (lowPriority.Count != 0)
            {
                for (int i = 0; i < lowPriority.Count; i++)
                {
                    client = lowPriority.Dequeue();
                    Console.WriteLine("Принтер зайняв " + client.Name + " " + DateTime.Now);
                    System.Threading.Thread.Sleep(1000);
                }
            }


            if (middlePriority.Count != 0)
            {
                for (int i = 0; i < middlePriority.Count; i++)
                {
                    client = middlePriority.Dequeue();
                    Console.WriteLine("Принтер зайняв " + client.Name + " " + DateTime.Now);
                    System.Threading.Thread.Sleep(1000);
                }
            }


            if (highPriority.Count != 0)
            {
                for (int i = 0; i < highPriority.Count; i++)
                {
                    client = highPriority.Dequeue();
                    Console.WriteLine("Принтер зайняв " + client.Name + " " + DateTime.Now);
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
