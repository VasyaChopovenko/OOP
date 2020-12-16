using System;

namespace Fraction
{
    class Fraction
    {
        public int numerator { get; set; }
        public int denominator { get; set; }

        public Fraction(int n, int d)
        {
            numerator = n;
            denominator = d;
        }

        public void printFraction()
        {
            Console.WriteLine($"{numerator}\n-\n{denominator}");
        }

        public void sum(Fraction fraction)
        {
            if (denominator == fraction.denominator)
            {
                numerator += fraction.numerator;
            }
            else
            {
                numerator = (numerator * fraction.denominator) + (denominator * fraction.numerator);
                denominator = denominator * fraction.denominator;
            }
        }

        public void sum(int numerator, int denominator)
        {
            if (this.denominator == denominator)
            {
                this.numerator += numerator;
            }
            else
            {
                this.numerator = (this.numerator * denominator) + (this.denominator * numerator);
                this.denominator = this.denominator * denominator;
            }
        }

        public void subtract(Fraction fraction)
        {
            if (denominator == fraction.denominator)
            {
                numerator -= fraction.numerator;
            }
            else
            {
                numerator = (numerator * fraction.denominator) - (denominator * fraction.numerator);
                denominator = denominator * fraction.denominator;
            }
        }

        public void subtract(int numerator, int denominator)
        {
            if (this.denominator == denominator)
            {
                this.numerator -= numerator;
            }
            else
            {
                this.numerator = (this.numerator * denominator) - (this.denominator * numerator);
                this.denominator = this.denominator * denominator;
            }
        }

        public void multiply(Fraction fraction)
        {
            numerator *= fraction.numerator;
            denominator *= fraction.denominator;
        }

        public void multiply(int numerator, int denominator)
        {
            this.numerator *= numerator;
            this.denominator *= denominator;
        }

        public void divide(Fraction fraction)
        {
            numerator *= fraction.denominator;
            denominator *= fraction.numerator;
        }

        public void divide(int numerator, int denominator)
        {
            this.numerator *= denominator;
            this.denominator *= numerator;
        }

        public static Fraction operator++ (Fraction fraction)
        {
            fraction.numerator += fraction.denominator;
            return fraction;
        }
        
        public static Fraction operator-- (Fraction fraction)
        {
            fraction.numerator -= fraction.denominator;
            return fraction;
        }
    };

    class Program
    {

        static void Main(string[] args)
        {
            int x1;
            int y1;

            int x2;
            int y2;

            char ch;
            string choose;

            do
            {
                Console.WriteLine("Введіть перший дріб: ");

                x1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-");
                y1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введіть другий дріб: ");

                x2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-");
                y2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Виберіть операцію: \n+\n-\n*\n/\n++\n--");

                choose = Convert.ToString(Console.ReadLine());

                Fraction f1 = new Fraction(x1, y1);
                Fraction f2 = new Fraction(x2, y2);

                switch (choose)
                {
                    case "+":
                        f1.sum(f2);
                        Console.WriteLine("Сума: ");
                        break;
                    case "-":
                        f1.subtract(f2);
                        Console.WriteLine("Різниця: ");
                        break;
                    case "*":
                        f1.multiply(f2);
                        Console.WriteLine("Добуток: ");
                        break;
                    case "/":
                        f1.divide(f2);
                        Console.WriteLine("Частка: ");
                        break;
                    case "++":
                        f1++;
                        Console.WriteLine("Інкремент: ");
                        break;
                    case "--":
                        f1--;
                        Console.WriteLine("Декремент: ");
                        break;
                }

                f1.printFraction();

                Console.WriteLine("Натисніть:\n1 - Продовжити\n0 - Вийти");
                ch = Convert.ToChar(Console.ReadLine());
            } while (ch == '1');
        }
    }
}
