using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorAndObjectInitilizers
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 o1 = new Class1();
            Console.WriteLine(o1.P1);
            Console.WriteLine(o1.P2);
            Console.WriteLine();

            Class1 o2 = new Class1(12,"Kakade");
            Console.WriteLine(o2.P1);
            Console.WriteLine(o2.P2);


            o1 = null;
            o2 = null;
           
            GC.Collect();
            Console.ReadLine();
        }
    }
    public class Class1
    {
        public int P1 { get; set; }     
        public String P2 { get; set; }
        public Class1()
        {
            P1 = 1;
            P2 = "Swapnil";
            Console.WriteLine("No parameter constructor called");
        }
        public Class1(int P1 = 0, String P2 = "no value")
        {
            this.P1 = P1;
            this.P2 = P2;
        }

        ~Class1()
        {
            Console.WriteLine();
            Console.WriteLine("Destructor called");
        }
    }
}
