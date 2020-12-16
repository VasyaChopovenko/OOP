using System;
using System.Collections.Generic;
using System.Text;

namespace Building
{
    class Building
    {
        public readonly uint Floors;

        public Flat[] flats;

        public Building(uint countOfFloors, uint countOfFlats)
        {
            Floors = countOfFloors;
            flats = new Flat[countOfFlats];

            for (int i = 0; i < flats.Length; i++)
            {
                flats[i] = new Flat(2);
            }
        }
    }

    class Flat
    {
        public List<Human> humans;
        public Room[] rooms;

        public Flat(uint countOfRoom)
        {
            humans = new List<Human>();
            rooms = new Room[countOfRoom];

            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = new Room(2, 3, 3);
            }
        }

        public void AddHuman(Human human)
        {
            humans.Add(human);
            Console.WriteLine($"{human.Name} заселився в квартиру");
        }

        public void Evict(string name)
        {
            for (int i = 0; i < humans.Count; i++)
            {
                if (humans[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    humans.RemoveAt(i);
                    Console.WriteLine($"{humans[i].Name} покинув квартиру");
                }
                else
                {
                    Console.WriteLine("В цій квартирі немає жителя з таким іменем");
                }
            }
        }

        public void ShowAllInhabitant()
        {
            for (int i = 0; i < humans.Count; i++)
            {
                Console.WriteLine($"{humans[i].Name}\n");
            }
        }
    }

    class Room
    {
        public readonly uint Length;
        public readonly uint Height;
        public readonly uint Width;

        public Room(uint length, uint height, uint width)
        {
            Length = length;
            Height = height;
            Width = width;
        }

        public uint GetArea()
        {
            return Length * Height * Width;
        }
    }

    class Human
    {
        public string Name { get; set; }
        public uint Age { get; set; }
        public string Gender { get; set; }

        public Human(string name, uint age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Ім'я: {Name}\nВік: {Age}\nСтать: {Gender}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Building building = new Building(9, 27);
            Console.WriteLine(building.flats[0].rooms[0].Height);

        }
    }
}
