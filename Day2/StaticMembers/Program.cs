using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1  o = new Class1();
            o.i = 1;
            Class1.j = 2;
            Console.WriteLine(Class1.j);
            o.display();
            Class1.staticDisplay();
        }
    }

    public class Class1
    {
        public int i;
        public static int j;

        public void display()
        {
            Console.WriteLine(i);
            Console.WriteLine("Display");
        }

        public static void staticDisplay()
        {
            Console.WriteLine("Static display");
        }
    }
}
