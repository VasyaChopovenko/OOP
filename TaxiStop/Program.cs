using System;
using System.Text;
using System.Collections.Generic;

namespace TaxiStop
{
    class Person
    {
        public int TimeEnterQueue { get; set; }
        public int TimeLeaveQueue { get; set; }

        public Person(int timeEnterQueue)
        {
            TimeEnterQueue = timeEnterQueue;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Random random = new Random();

            Queue<Person> peopleOnStop = new Queue<Person>();
            List<Person> passengers = new List<Person>();
            int numberOfFreeSits;

            Console.WriteLine("Введіть середній час(в секундах) появи пасажирів на зупинці вдень: "); //за день вважаємо час від 7 до 19
            int dayTimeArrivalPassengers = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введіть середній час(в секундах) появи пасажирів на зупинці в темну пору доби: "); // за темну пору доби вважаємо час від 19 до 24
            int nightTimeArrivalPassengers = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введіть середній час(в секундах) появи автобусів на зупинці вдень: "); //за день вважаємо час від 7 до 19
            int dayTimeArrivalBuses = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введіть середній час появи(в секундах) автобусів на зупинці в темну пору доби: "); // за темну пору доби вважаємо час від 19 до 24
            int nightTimeArrivalBuses = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 17 * 60 * 60; i++) // автобуси починають рух в 7 годин і закінчують в 12, тому розрахунок буде для 17 годин
            {
                if (i < 12 * 60 * 60)
                {
                    if (i % dayTimeArrivalPassengers == 0)
                    {
                        peopleOnStop.Enqueue(new Person(i));
                    }

                    if (i % dayTimeArrivalBuses == 0)
                    {
                        numberOfFreeSits = random.Next(0, 28);
                        Console.WriteLine("Bus with sits: " + numberOfFreeSits);

                        while (numberOfFreeSits != 0 && peopleOnStop.Count != 0)
                        {
                            Person person = peopleOnStop.Dequeue();
                            person.TimeLeaveQueue = i;
                            passengers.Add(person);
                            numberOfFreeSits--;
                        }

                    }
                }

                else
                {
                    if (i % nightTimeArrivalPassengers == 0)
                    {
                        peopleOnStop.Enqueue(new Person(i));
                    }

                    if (i % nightTimeArrivalBuses == 0)
                    {
                        numberOfFreeSits = random.Next(0, 28);
                        Console.WriteLine("Bus with sits: " + numberOfFreeSits);

                        while (numberOfFreeSits != 0 && peopleOnStop.Count != 0)
                        {
                            Person person = peopleOnStop.Dequeue();
                            person.TimeLeaveQueue = i;
                            passengers.Add(person);
                            numberOfFreeSits--;
                        }
                    }
                }

                Console.WriteLine("Count of people on stop: " + peopleOnStop.Count);
            }

            int timeOnStop = 0;

            foreach(Person passenger in passengers)
            {
                timeOnStop += passenger.TimeLeaveQueue - passenger.TimeEnterQueue;
            }

            Console.WriteLine("Середній час перебування на зупинці: " + timeOnStop/passengers.Count);
        }
    }
}
