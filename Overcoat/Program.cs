using Microsoft.VisualBasic.CompilerServices;
using System;

namespace Overcoat
{
    enum Size
    {
        S, M, L, XL, XXL
    }

    class Overcoat
    {
        public uint price { get; set; }
        public string color { get; set; }
        public Size size { get; set; }

        public Overcoat(uint price, string color, Size size)
        {
            this.price = price;
            this.color = color;
            this.size = size;
        }

        public override bool Equals(object obj)
        {
            bool eq = false;
            if(obj is Overcoat overcoat)
            {
                if(color.Equals(overcoat.color) && price.Equals(overcoat.price) && size.Equals(overcoat.size))
                {
                    eq = true;
                }
            }
            return eq;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator> (Overcoat overcoat1, Overcoat overcoat2)
        {
            bool eq = false;
            if(overcoat1.price > overcoat2.price)
            {
                eq = true;
            }
            return eq;
        }

        public static bool operator< (Overcoat overcoat1, Overcoat overcoat2)
        {
            bool eq = false;
            if(overcoat1.price < overcoat2.price)
            {
                eq = true;
            }
            return eq;
        }
        
        public static bool operator<= (Overcoat overcoat1, Overcoat overcoat2)
        {
            bool eq = false;
            if(overcoat1.price <= overcoat2.price)
            {
                eq = true;
            }
            return eq;
        }

        public static bool operator>= (Overcoat overcoat1, Overcoat overcoat2)
        {
            bool eq = false;
            if(overcoat1.price >= overcoat2.price)
            {
               eq = true;
            }
            return eq;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Overcoat overcoat = new Overcoat(12, "Green", Size.S);
            Overcoat overcoat1 = new Overcoat(12, "Green", Size.S);
            Console.WriteLine(overcoat > overcoat1);
        }
    }
}
