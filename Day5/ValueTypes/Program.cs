using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Struct
namespace ValueTypes1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            // int i = 0;
            int i = new int();
            Console.WriteLine(i);
        }
        static void Main2(string[] args)
        {
            MyPoint p = new MyPoint();
            Console.WriteLine(p.A);
            Console.WriteLine(p.X);
            Console.WriteLine(p.Y);
        }
        static void Main3(string[] args)
        {
            MyPoint p = new MyPoint();
            p.A = 10;
            p.X = 20;
            p.Y = 30;
            Console.WriteLine(p.A);
            Console.WriteLine(p.X);
            Console.WriteLine(p.Y);
        }
        static void Main4(string[] args)
        {
            MyPoint p = new MyPoint(10, 20, 30);
            Console.WriteLine(p.A);
            Console.WriteLine(p.X);
            Console.WriteLine(p.Y);
        }
    }
    public struct MyPoint
    {
        // structs are value Types - stored on stack. Faster than heap operations
        // No Inheritance allowed in stucts
        // Parameterless constuctor not allowed in structs
        public int A { get; set; }
        public int X, Y;
        public MyPoint(int X = 0, int Y = 0, int A = 0)
        {
            Console.WriteLine("Constructor called");
            this.X = X;
            this.Y = Y;
            this.A = A;
        }
    }
}

namespace ValueTypes2
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            //Display1(0);
            Display(TimeOfDay.Morning);
            Console.ReadLine();
        }

        private static void Display1(int t)
        {
            if (t == 0)
                Console.WriteLine("Good Morning");
            else if (t == 1)
                Console.WriteLine("Good Afternoon");
            else if (t == 2)
                Console.WriteLine("Good Evening");
            else if (t == 3)
                Console.WriteLine("Good Night");
        }
        static void Display(TimeOfDay t)
        {
            if (t == TimeOfDay.Morning)
                Console.WriteLine("Good Morning");
            else if (t == TimeOfDay.Afternoon)
                Console.WriteLine("Good Afternoon");
            else if (t == TimeOfDay.Evening)
                Console.WriteLine("Good Evening");
            else if (t == TimeOfDay.Night)
                 Console.WriteLine("Good Night");
        }
    }
    public enum TimeOfDay
    {
        Morning,
        Afternoon,
        Evening,
        Night
    }
}
