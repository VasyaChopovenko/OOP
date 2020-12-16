using System;
using System.Collections.Generic;

namespace String
{
    class MyString
    {
        private List<char> array;

        public int Length
        {
            get
            {
                return array.Count; 
            }
        }

        public MyString() 
        {
            array = new List<char>();
        }

        public MyString(char[] arr) : this()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                array.Add(arr[i]);
            }
        }

        public MyString(string s) : this()
        {  
            for (int i = 0; i < s.Length; i++)
            {
                array.Add(s[i]);
            }
        }

        public MyString(MyString myString) : this()
        {
            array = myString.array;
        }

        public char this[int index]
        { 
            get { return array[index]; }
            set { array[index] = value; }
        }

        public void Print()
        {
            for (int i = 0; i < array.Count; i++)
            {
                Console.Write(array[i]);
            }
        }

        public bool Equals(MyString myString)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if(array[i] != myString.array[i] || array.Count != myString.array.Count)
                {
                    return false;
                }
            }
            return true;
        }

        public static MyString operator+ (MyString myString, MyString myString1)
        {
            MyString result = new MyString();

            for (int i = 0; i < myString.array.Count; i++)
            {
                result.array.Add(myString.array[i]); 
            }

            for (int j = 0; j < myString1.array.Count; j++)
            {
                result.array.Add(myString1.array[j]);
            }

            return result;
        }

        public int IndexOf(char ch)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == ch)
                    return i;
            }

            return -1;
        }

        public override string ToString()
        {
            string finalString = "";
            foreach (var chr in array)
            {
                finalString += chr;
            }
            return finalString;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyString myString = new MyString("sadfgrews");
            myString[0] = 'w';
            Console.WriteLine(myString);
        }
    }
}
