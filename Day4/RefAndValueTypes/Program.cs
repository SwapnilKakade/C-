using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefAndValueTypes
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class1 o1 = new Class1();
            Class1 o2 = new Class1();
            o1.i = 100;
            o2.i = 200;
            o1 = o2;
            o2.i = 300;
            Console.WriteLine(o1.i); //300
            Console.WriteLine(o2.i); //300
            Console.ReadLine();
        }
        // All class and thier varition are examples of reference types --
        // Classses,intefaces,delegates,arrays,object class and string class are examples of referece types
        static void Main2(string[] args)
        {
            int o1, o2;
            o1 = 100;
            o2 = 200;
            o1 = o2;
            o2 = 300;
            Console.WriteLine(o1); //200
            Console.WriteLine(o2); //300
            Console.ReadLine();
        }
        static void Main3(string[] args)
        {
            String o1, o2; //Create new block ,string is immutable
            o1 = "100";
            o2 = "200";
            o1 = o2;
            o2 = "300";
            Console.WriteLine(o1); //200
            Console.WriteLine(o2); //300
            Console.ReadLine();
        }

        static void Main()
        {
            int i = 123;
            int j = 456;
            //Swap(ref i, ref j);
            Init(out i, out j);
            //DoSomething(i ,j);
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.ReadLine();
        }

        static void Swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
        static void Init(out int i, out int j)
        {
            i = 100;
            j = 200;
        }
        static void DoSomething(in int i, in int j)
        {
            Console.WriteLine(i + " " + j);
        }
    }
    public class Class1
    {
        public int i;
    }
}
