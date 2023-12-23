using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class1 objCls1 = new Class1();
            //pass the event handling fuction to the delegate object(event) in the class
            //Or call the event handler if the event happens
            objCls1.InvalidP1 += objCls1_InvalidP1;

            objCls1.P1 = 101;
            Console.ReadLine();
        }
        static void objCls1_InvalidP1()
        {
            Console.WriteLine("Event code called");
        }
    }
    //Step  1 :Create a delegate class having the same signature as the event handler
    public delegate void InvalidP1EventHandler();
    public class Class1
    {
        // Step 2 declare the event as an object of the delegates class
        public event InvalidP1EventHandler InvalidP1;

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                {
                    p1 = value;
                }
                else
                {
                    // Step 3 :Raise the event the required
                    InvalidP1();
                }
               
            }
        }
    }
}
namespace EventHandling2
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class1 objCls1 = new Class1();

            objCls1.InvalidP1 += ObjCls1_InvalidP1;
            objCls1.InvalidP1 += Handler2;
            objCls1.P1 = 200;
            Console.ReadLine();
        }

        private static void ObjCls1_InvalidP1()
        {
            Console.WriteLine("Event handle called");
        }
        private static void Handler2()
        {
            Console.WriteLine("Handler2 called");
        }
    }
    public delegate void InvalidP1EventHandler();
    public class Class1
    {
        public event InvalidP1EventHandler InvalidP1;

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                {
                    p1 = value;
                }
                else
                {
                    InvalidP1();
                }

            }
        }
    }
}
namespace EventHandling3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 objCls1 = new Class1();
            objCls1.InvalidP1 += ObjCls1_InvalidP1;
            objCls1.P1 = 300;
            Console.ReadLine();
        }

        private static void ObjCls1_InvalidP1(int InvalidValue)
        {
          Console.WriteLine("Event raised value is "+ InvalidValue);
        }
    }
    public delegate void InvalidP1EventHandler(int InvalidValue);
    public class Class1
    {
        public event InvalidP1EventHandler InvalidP1;

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                {
                    p1 = value;
                }
                else
                {
                    if(InvalidP1 != null)
                    InvalidP1(value);
                }

            }
        }
    }
}

