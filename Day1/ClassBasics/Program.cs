using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBasics
{
    class Program
    {
        static void Main()
        {
            //System.Console.WriteLine("HelloWorld");
            //Console.WriteLine("Hello");
            //Console.ReadLine();
            Class1 c = new Class1();
            c.Display();
            c.Display("Swapnil");
            Console.ReadLine() ;
        }
    }

    public class Class1
    {
        int i = 10;
        public void Display()
        {
            Console.WriteLine("Display called " + i);
        }
        //Method overloading 
        public void Display(String s)
        {
            Console.WriteLine("Display called " + s);
        }
    }
}
