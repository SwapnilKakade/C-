using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageFeatures
{
    internal class Program
    {
        static void Main1(string[] args)
        {
        }
    }
}
namespace ImplicitVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int a = 100;
            var a = 100; // implicit variable
            var b = "Swapnil";
            Console.WriteLine(a.GetType());
            Console.WriteLine(a);
            Console.WriteLine(b.GetType());
            Console.WriteLine(b);
            Console.ReadLine();
        }
    }
}
