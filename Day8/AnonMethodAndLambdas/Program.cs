using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Fuct ,Action and Predicate

namespace AnonMethodAndLambdas1
{
    
    internal class Program
    {
        static void Main1(string[] args)
        {
            Action o1 = Display;
            o1();

            Action<string> o2 = Display;
            o2("Hello");

            Action<string, int> o3 = Display;
            o3("A", 2);
        }
        static void Main2(string[] args)
        {
            Func<int, int ,int > o1 = Add;
            Console.WriteLine("Addition : "+ o1(10,20));

            //Func<string, int, decimal ,string> o2 = DoSomething;
            //Console.WriteLine("DoSomething : " + o2("abc", 20 ,212.4M));

            Func<int, bool> o3 = IsEven;
            Console.WriteLine("Even Or Not : " + o3(20));

            Predicate<int> o4 = IsEven;
            Console.WriteLine("Even Or Not : " + o4(201));
            Console.ReadLine();
        }
        static void Display()
        {
            Console.WriteLine("Display called");
        }
        static void Display(string s)
        {
            Console.WriteLine("Display called " + s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("Display called " + s + " " + i);
        }
        static int Add(int i, int j)
        {
            return i + j;
        }

        //static string DoSomething(string a ,int b, decimal c)
        //{
        //    return a.Substring(b);
        //}
        static bool IsEven(int a)
        {
            if(a %  2 == 0)
                return true;
            else
                return false;
        }

    }
}

//Anonymous Methods
namespace AnonMethodAndLambdas2
{
   
    internal class Program
    {
        static void Main1(string[] args)
        {
            int x = 10;
            Action o1 = delegate()
            {
                Console.WriteLine("X :"+x);
                Console.WriteLine("Anonmous method called");
            };
            o1();

            Action<string> o2 = delegate (string s) {
                Console.WriteLine("Display called " + s);
            };
            o2("Swapnil");

            Func<int, int, int> o3 = delegate (int i, int j)
            {
                return i + j;
            };

            Console.WriteLine("Addition :"+o3(15, 4));
        }
       
        static void Display()
        {
            Console.WriteLine("Display called");
        }
        static void Display(string s)
        {
            Console.WriteLine("Display called " + s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("Display called " + s + " " + i);
        }
        static int Add(int i, int j)
        {
            return i + j;
        }
        static bool IsEven(int a)
        {
            if (a % 2 == 0)
                return true;
            else
                return false;
        }

    }
}

//Lamndas
namespace AnonMethodAndLambdas3
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> o1 = delegate (int a)
            {
                return a * 3;
            };

            // Lambda
             
            Func<int ,int > o2 = a => a * 2;
            Console.WriteLine("A :" + o2(3));


            Func<int , int , int> o3 = (a, b) => a + b;
            Console.WriteLine("Add : " + o3(55, 51));


            Predicate<int> o4 = a => a % 2 == 0;
            Console.WriteLine("Even or Not " + o4(63));
            Console.ReadLine();
        }

    
        static int MakeDouble(int a)
        {
            return a * 2;
        }
        static int Add(int i, int j)
        {
            return i + j;
        }
        static bool IsEven(int a)
        {
            if (a % 2 == 0)
                return true;
            else
                return false;
        }

    }
}