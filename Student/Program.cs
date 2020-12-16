using System;
using System.Text;
using System.IO;

namespace Student
{
    [Serializable()]
    class Student
    {
        private string name;
        private string surname;
        private uint age;
        private string gender;
        private string number;

        public Student(string name, string surname, uint age, string gender, string number)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.gender = gender;
            this.number = number;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

        public uint Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public void Save()
        {
            string info = $"Студент: {name} {surname}\nВік: {age}\nСтать: {gender}\nНомер телефона: {number}";
            byte[] array = System.Text.Encoding.Default.GetBytes(info);

            using (FileStream fstream = new FileStream(@"D:\Student.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                fstream.Write(array, 0, array.Length);
            }
        }

        public void Read()
        {
            using (FileStream fstream = File.OpenRead(@"D:\Student.txt"))
            {
                byte[] array = new byte[fstream.Length];

                fstream.Read(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст з файла: {textFromFile}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Student student = new Student("John", "Smith", 18, "Male", "0968651598");
            student.Save();
            student.Read();
        }
    }
}
