using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures1
{
    internal class Program
    {
        //AnonmousTypes
        static void Main1(string[] args)
        {
            var obj1 = new { a = 1, b = "Swapnil", c = true };
            var obj2 = new { a = 2, b = "Kakade", c = true };
            Console.WriteLine(obj1.c);
            Console.WriteLine(obj2.GetType());
            Console.ReadLine();
        }
    }
}

namespace LanguageFeatures2
{
    // Partial Classes
    // partial classes must be in the same assembly
    // partial classes must be in the same namespace
    // partial classes must have the same name
    internal class Program
    {
        static void Main1()
        {
            class1 o = new class1();
        }
    }
    public partial class class1
    {
        public int i;
    }
    public partial class class1
    {
        public int j;
    }

}

namespace LanguageFeatures2
{
    public partial class class1
    {
        public int k;
    }

}

namespace LanguageFeatures3
{
    // Partial Methods
    // partial methods must return void
    // Partial methods can be static or instance level
    // Partial methods cannot have out params
    // partial methods are always implicitly private
    internal class Program
    {

        static void Main1()
        {
            class1 o = new class1();
            Console.WriteLine(o.Check());
        }
    }
    public partial class class1
    {
        private bool isValid = true;
        partial void Validate();
        public bool Check()
        {
            Validate();
            return isValid;
        }
    }
    public partial class class1
    {
        partial void Validate()
        {
            isValid = false;
        }

    }

}

namespace ExtensionMethods1
{

    internal class Program
    {

        static void Main1()
        {
            int a = 100;
            a.Display();
            a = a.Add(100, 100);
            Console.WriteLine(a);

            string s = "ABC";
            s.Show();
            Console.ReadLine();
        }
        static void Main2()
        {
            int a = 100;
            MyExtMethodsClass.Display(a);

            string s = "Abc";
            MyExtMethodsClass.Show(s);

            MyExtMethodsClass.Add(a, 200, 100);
            Console.WriteLine(a);

            //MyExtMethodsClass.ExtMethodsForBaseClass(a);
            Console.ReadLine();
        }
    }
    // 1 . Create static class
    public static class MyExtMethodsClass
    {
        // 2. Create a static method in static  class.
        // first parameter of this method should be the tpye for which you 
        // are writing the extesion method .precede it with the 'this; keyword

        public static void Display(this int i)
        {
            Console.WriteLine(i);
        }

        public static int Add(this int i, int j, int k)
        {
            return i + j + k;
        }

        public static void Show(this string s)
        {
            Console.WriteLine(s);
        }

        public static void ExtMethodsForBaseClass(this object s)
        {
            Console.WriteLine(s);
        }
    }


}

namespace ExtensionMethods2
{

    internal class Program
    {
        static void Main()
        {
            ClassMaths o = new ClassMaths();
            Console.WriteLine(o.SubStract(20, 10)); // Using the SubStract extension method
        }
    }

    public static class MyExtMethodsClass
    {
        public static int SubStract(this IMathOperations i, int a, int b)
        {
            return a - b;
        }
    }

    public interface IMathOperations
    {
        int Add(int a, int b);
        int Multiply(int a, int b);
    }

    public class ClassMaths : IMathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}