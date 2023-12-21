using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExamples1
{
    //    public - available anywhere
    //    private - available within same class
    //    protected - available same class,derived class
    //    internal - same class ,same assembly(same project)
    //    protected internal - same class ,derived class , same assembly(same project)
    //    private protected - same class , derived class which is the same assembly

    internal class Program
    {
        static void Main1(string[] args)
        {
            int i;
            string s;
            s = Console.ReadLine();
            i = int.Parse(Console.ReadLine());
            //BaseClass o = new BaseClass();
            //TestAccessSpecifiers.BaseClass o = new TestAccessSpecifiers.BaseClass();
        }
    }

    public class BaseClass
    {
        public int PUBLIC;
        private int PRIVATE;
        private int PROTECTED;
        internal int INTERNAL;
        protected internal int PROTECTED_INTERNAL;
        private protected int PRIVATE_PROTECTED;
    }
    public class DerivedClass : TestAccessSpecifiers.BaseClass
    {

    }

}
namespace InheritanceExamples2
{

    internal class Program
    {
        static void Main1(string[] args)
        {
            DerivedClass d = new DerivedClass();
            d.Display1();
            d.Display1("Hello");
            Console.WriteLine();

            d.Display2();
            Console.WriteLine();

            d.Display3();
            Console.ReadLine();
        }

        // diff between virtual(late bound) and non virtual(early bound) methods
        static void Main2(string[] args)
        {
            BaseClass o;
            o = new BaseClass();
            o.Display2();
            o.Display3();
            Console.WriteLine();

            o = new DerivedClass();
            o.Display2();
            o.Display3();

            Console.ReadLine();
        }

        static void Main3(string[] args)
        {
            BaseClass o;
            o = new BaseClass();
            o.Display3();
            Console.WriteLine();

            o = new DerivedClass();
            o.Display3();
            Console.WriteLine();

            o = new SubDerivedClass();
            o.Display3();
            Console.WriteLine();

            o = new SubSubDerivedClass();
            o.Display3();
            Console.WriteLine();

            Console.ReadLine();
        }
    }

    public class BaseClass
    {
        public void Display1()
        {
            Console.WriteLine("Base Class Display1");
        }
        public void Display2()
        {
            Console.WriteLine("Base Class Display2");
        }

        public virtual void Display3()
        {
            Console.WriteLine("Base Class Display3");
        }

    }
    public class DerivedClass : BaseClass
    {
        //Overloading a base class method same function name,diff parameters
        //both class methods are available from an object of derived class
        public void Display1(String s)
        {
            Console.WriteLine("Derived class Display1 " + s);
        }

        //hinding of base class method same function name,same parameters
        //only derived class method is available from an object of derived class
        public new void Display2()
        {
            Console.WriteLine("Derived Class Display2");
        }

        // Overriding a base class method same function name,same parameters
        // only derived class method is available from an object of derived class
        // only a virtual method can be overriden
        public override void Display3()
        {
            Console.WriteLine("Derived class Display3");
        }
    }
    public class SubDerivedClass : DerivedClass
    {
        //override a base class method
        public sealed override void Display3()
        {
            Console.WriteLine("SubDerived class Display3");
        }
    }
    public class SubSubDerivedClass : SubDerivedClass
    {
        //override a base class method
        //public override void display3() --- error -> sealed method cannot be overriden
        public new void Display3()
        {
            Console.WriteLine("SubSubDerived class Display3");
        }
    }
}
namespace InheritanceExamples3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DerivedClass1 d1 = new DerivedClass1();
            d1.Display(); // Output: "Base Class1 Display"
            d1.DerivedMethod(); // Output: "Derived Method1"

            Console.WriteLine();

            DerivedClass2 d2 = new DerivedClass2();
            d2.Display(); // Output: "Derived Class2 Display"
            d2.Show();    // Output: "Derived Class2 Show"
            Console.ReadLine();
        }
    }

    // Abstract class without any abstract members
    public abstract class BaseClass1
    {
        public void Display()
        {
            Console.WriteLine("Base Class1 Display");
        }
    }

    public class DerivedClass1 : BaseClass1
    {
        public void DerivedMethod()
        {
            Console.WriteLine("Derived Method1");
        }
    }

    public abstract class BaseClass2
    {
        public abstract void Display(); // Abstract method - no implementation
        public abstract void Show();    // Abstract method - no implementation
    }

    public class DerivedClass2 : BaseClass2
    {
        public override void Display()
        {
            Console.WriteLine("Derived Class2 Display");
        }

        public override void Show()
        {
            Console.WriteLine("Derived Class2 Show");
        }
    }
}

