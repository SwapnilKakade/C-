using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    internal class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();

            o.i = 1;
            o.s = "sss";
            o.Setj(1000); // Call the Setj method to set the value of j
            Console.WriteLine(o.Getj());

        }
        static void Main()
        {   
            Class2 o = new Class2();
            o.I = 100;
            Console.WriteLine(o.I);
            o.S = "swapnil";
            Console.WriteLine(o.S);
            Console.ReadLine();
        }
        static void Main3()
        {
            Class3 o = new Class3();
            Console.WriteLine("Additon :"+o.Add(12));
        }


    }
    public class Class1
    {
        public int i;
        public String s;

        private int j;

        public int Getj()
        {
            return j;
        }

        public void Setj(int value)
        {
            if (value < 100)
            {
                j = value;
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
    public class Class2
    {
        public int i;
        public int I
        {
            get {
                return i;
            } 
            set { 
                if(value > 0)
                {
                    i = value;
                }
            }
        }

        public string S { get; set; }
    }
    public class Class3
    {
        public int Add(int a , int b = 22)
        {
            return a + b;
        }
    }

    
}
