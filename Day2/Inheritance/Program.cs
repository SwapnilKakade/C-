using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BaseClass o1 = new BaseClass();
            DerivedClass o = new DerivedClass();
            Console.WriteLine(o.a);
            Console.WriteLine(o.b);
            Console.ReadLine();
        }
    }

    public class BaseClass
    {
        public int a;
        public BaseClass()
        {
            Console.WriteLine("BaseClass no parameter constructor");
            a = 10;
        }
        public BaseClass(int a)
        {
            Console.WriteLine("BaseClass Int parameter constructor");
            this.a = a;
        }
    }

    public class DerivedClass : BaseClass
    {
        public int b;

        public DerivedClass()
        {
            Console.WriteLine("DerivedClass no parameter constructor");
            //a = 10;
            b = 20;
        }
        public DerivedClass(int a , int b) :base(a)
        {
            Console.WriteLine("DerivedClass Int parameter constructor");
            //this.a = a;
            this.b = b;
        }
    }
}
