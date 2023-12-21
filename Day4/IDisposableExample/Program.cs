using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableExample1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class1 o1 = new Class1();
            o1.Display();
            o1.Dispose();
            Console.ReadLine();
        }
        static void Main2(string[] args)
        {
            using (Class1 o = new Class1())
            {
                o.Display();
            }
            Console.ReadLine();
        }
    }
    public class Class1 : IDisposable
    {
        public Class1()
        {
            Console.WriteLine("Cons code called");
        }
        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose code Called");
        }
    }
}
namespace IDisposableExample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 o1 = new Class1();
            o1.Display();
            o1.Dispose();
            Console.ReadLine();
        }
       
    }
    public class Class1 : IDisposable
    {
        public Class1()
        {
            Console.WriteLine("Cons code called");
        }
        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose code Called");
        }
    }
}
