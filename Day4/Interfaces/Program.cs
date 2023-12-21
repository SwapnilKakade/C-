using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class1 o = new Class1();
            //method 1
            o.Insert(); // interface method
            o.Display(); // non interface method

            //method 2
            IDbFunctions oIDb;
            oIDb = o;
            oIDb.Insert();

            //method 3
            ((IDbFunctions)o).Insert();

            //method 4
            (o as IDbFunctions).Insert();

            Console.ReadLine();

        }
    }
    
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();

    }

    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Delete");
        }

        public void Insert()
        {
          Console.WriteLine("Insert");
        }

        public void Update()
        {
            Console.WriteLine("Update");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }
    }
}

namespace Interfaces2
{
    internal class Program
    {
        static void Main2(string[] args)
        {
            Class1 o = new Class1();
            IFileFunctions oFile;
            oFile = o;
            o.Delete();
           


            (o as IFileFunctions).Delete();
            Console.ReadLine();

        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();

    }

    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Delete();

    }

    public class Class1 : IDbFunctions, IFileFunctions
    {
        public void Delete()
        {
            Console.WriteLine(" class1 IDb.Delete");

        }
        public void Insert()
        {
            Console.WriteLine("Insert");
        }

        public void Update()
        {
            Console.WriteLine("Update");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        void IFileFunctions.Open()
        {
            Console.WriteLine("class1 IFile.Open");
        }

        void IFileFunctions.Close()
        {
            Console.WriteLine("class1 IFile.lose");
        }

        void IFileFunctions.Delete()
        {
            Console.WriteLine(" class1 IFile.Delete");
        }
    }
}

namespace Interfaces3
{
    internal class Program
    {
        static void Main3()
        {
            Class1 o1 = new Class1();
            Class2 o2 = new Class2();

            IDbFunctions oIDb;
            oIDb = o1;
            o1.Insert();

            oIDb = o2;
            o2.Insert();

            (o1 as IDbFunctions).Insert();

            Console.ReadLine();

        }
     
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();

    }

    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine(" Class1 Delete");
        }

        public void Insert()
        {
            Console.WriteLine(" Class1 Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 Update");
        }

        public void Display()
        {
            Console.WriteLine(" Class1 Display");
        }
    }
    public class Class2 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine(" Class2 Delete");
        }

        public void Insert()
        {
            Console.WriteLine(" Class2 Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class2 Update");
        }

        public void Display()
        {
            Console.WriteLine(" Class2 Display");
        }
    }
}