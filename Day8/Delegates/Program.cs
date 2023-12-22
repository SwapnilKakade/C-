using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    // Step 1 : Create a delegates class having the same singnature as the function to be called
    //Object
    //Delegate
    //MultiCastDelegate
    //Dell

    public delegate void Del1();

    public delegate int DelCal(int a, int b);
    internal class Program
    {
        static void Main1(string[] args)
        {
            //Display();
            // Step 2 :Create an object of the delegate class and pass it function name as parameter
            Del1 objDel = new Del1(Display);
            // Step 3 : call the function with the delegate object
            objDel();
            Console.ReadLine();

        }
        static void Main2(string[] args)
        {

            Del1 objDel = Display;
            objDel();
            Console.ReadLine();

        }
        static void Main3(string[] args)
        {

            Del1 objDel = Display;
            objDel();
            Console.WriteLine();

            objDel += Show;
            objDel();
            Console.WriteLine();

            objDel += Display;
            objDel();
            Console.WriteLine();

            objDel -= Display;
            objDel();
            Console.WriteLine();

            Console.ReadLine();

        }

        static void Main4()
        {

            Console.WriteLine("Addition :" + CalMathOperation(Add, 12, 5));
            Console.WriteLine();


            Console.WriteLine("Substration :" + CalMathOperation(Sub, 122, 5));
            Console.WriteLine();

            Console.WriteLine("Multiplication :" + CalMathOperation(Multi, 2, 5));
            Console.WriteLine();


            Console.WriteLine("division :" + CalMathOperation(Div, 2, 5));
            Console.WriteLine();

            Console.ReadLine();
        }
        static void Main5()
        {
            Del1 objDel = Class1.Show;
            objDel();

            Class1 oCls1 = new Class1();
            objDel = oCls1.Display;
            objDel();

            Console.ReadLine();
        }
        static void Display()
        {
            Console.WriteLine("Display called");
        }

        static void Show()
        {
            Console.WriteLine("Show called ");
        }

        static int CalMathOperation(DelCal objDel, int i, int j)
        {
            return objDel(i, j);
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Sub(int a, int b)
        {
            return a - b;
        }
        static int Multi(int a, int b)
        {
            return a * b;
        }
        static int Div(int a, int b)
        {
            return a / b;
        }
    }

    public class Class1
    {
        public void Display()
        {
            Console.WriteLine("Display called");
        }

        public static void Show()
        {
            Console.WriteLine("Show called ");
        }
    }
}
