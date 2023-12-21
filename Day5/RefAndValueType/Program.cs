using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefAndValueType
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class1 o = new Class1();
            o.i = 100;
            //DoSomething1(o); 200
            //DoSomething2(o); 100
            //DoSomething3(ref o); //200
              BoxingUnboxing();
            Console.WriteLine(o.i);
            Console.ReadLine();
        }

        private static void DoSomething1(Class1 obj)
        {
            // changes made in func (Changing value of properties ) is reflected in calling code O
            obj.i = 200;
        }
        private static void DoSomething2(Class1 obj)
        {
            // changes made in func (obj pointing to some other block) is NOT reflected in calling code o
            obj = new Class1();
            obj.i = 200;
        }
        private static void DoSomething3(ref Class1 obj)
        {
            // changes made in func (obj pointing to some other block) is reflected in calling code o initlization of the object is complsuary
            obj = new Class1();
            obj.i = 200;
        }

         static void BoxingUnboxing()
        {
            object o; 
            int i = 200;
            o = i; // Store a value type into  a reference type - Boxing

            Console.WriteLine(o);

            int j;
            j = (int)o; // get the BOXED value type from the reference type - UNBOXING
            Console.WriteLine(j);
        }
    }
    public class Class1
    {
        public int i;
    }
}
