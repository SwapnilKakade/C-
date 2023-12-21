using System;

namespace InterfaceWithCore
{
    internal class Program
    {
        static void Main1()
        {
            Class1 o1 = new Class1();
            o1.Insert();
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
    }
}
