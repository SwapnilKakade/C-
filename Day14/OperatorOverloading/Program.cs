using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            int i = 10;

            Class1 o1 = new Class1 { i = 20 };
            Class1 o2 = new Class1 { i = 30 };

            // Using overloaded + operator with an integer
            Class1 result1 = o1 + i;
            Console.WriteLine("Result 1: " + result1.i); // Output: 30 (20 + 10)

            // Using overloaded + operator with two Class1 objects
            Class1 result2 = o1 + o2;
            Console.WriteLine("Result 2: " + result2.i); // Output: 50 (20 + 30)

       
            Console.ReadLine();
        }
    }

    public class Class1
    {
        public int i;

        public static Class1 operator+(Class1 o , int i)
        {
            Class1 retval = new Class1();       
            retval.i = o.i + i;
            return retval;
        }

        public static Class1 operator +(Class1 o1, Class1 o2)
        {
            Class1 retval = new Class1();
            retval.i = o1.i + o2.i;
            return retval;
        }
    }
}
