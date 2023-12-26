using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkingWithTasks1
{
    internal class Program
    {
        // calling a method with void return type using taskobj.Start
        static void Main1(string[] args)
        {
            //Task t1 = new Task(Func1);
            //Task t2 = new Task(Func2);

            Action objAction1 = Func1;
            Task t1 = new Task(objAction1);

            Action objAction2 = Func2;
            Task t2 = new Task(objAction2);
         

            t1.Start();
            t2.Start();

            Console.ReadLine();
        }

        static void Func1()
        { 
            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine("First function called from {0} ,{1} " , Thread.CurrentThread.ManagedThreadId,i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second function called from {0} ,{1} ", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}

namespace WorkingWithTasks2
{
    internal class Program
    {
        // calling a method with void return type using taskobj.Start
        static void Main1(string[] args)
        {
            
            //Action objAction1 = Func1;
            //Task t1 = Task.Run(objAction1);

            Task t1 = Task.Run(Func1);

            //Action objAction2 = Func2;
            //Task t2 = new Task(objAction2);

            Task t2 = Task.Factory.StartNew(Func2);

            Console.ReadLine();
        }

        static void Func1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("First function called from {0} ,{1} ", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second function called from {0} ,{1} ", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}

namespace WorkingWithTasks3
{
    internal class Program
    {
        // calling a method with void return type using taskobj.Start
        static void Main1(string[] args)
        {

            Action<object> objAction1 = Func1;         // 1
            Task t1a = new Task(objAction1, " abc");
            t1a.Start();

            //Action <object> objAction2 = Func2;
            //Task t2 = new Task(objAction2 , "efg");

            //t2.Start();


            //Task t1 = new Task(Func1," abc");            // 2
            //t1.Start ();

            //Task.Run - cannot be used with parameters.
            //use anonymous methods instead to access variables declared in calling code

            //string s = "ABC";
            //Task.Run(delegate () { Console.WriteLine(s); });
            //Task t2 = Task.Factory.StartNew(Func2, "bbb");
            //t2.Start();

            Console.ReadLine();
        }

        static void Func1(object s)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("First function called from {0} ,{1} ", i + s.ToString());
            }
        }
        static void Func2(object s)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second function called from {0} ,{1} ", i + s.ToString());
            }
        }
    }
}

namespace WorkingWithTasks4
{
    internal class Program
    {
        // calling a method having return type
        static void Main1(string[] args)
        {

            //Task<int> t = new Task<int>(Func1);
            //t.Start();

            Task<int> t1 = new Task<int>(new Func<int>(Func1));
            t1.Start();

            //Func<object,int> objFunc2 = Func2;
            //Task<int> t2 = new Task<int>(objFunc2, "bbb");

            Task<int> t2 = new Task<int>(Func2, "bbb");
            t2.Start();

            // to do 
            // try calling func with return value with Task.Run and Task.Factory.StartNew

            if (!t1.IsCompleted)
            {
                t1.Wait();
                Console.WriteLine(t1.Result);
            }
            if (!t2.IsCompleted)
            {
                t2.Wait();
                Console.WriteLine(t2.Result);
            }

            Console.ReadLine();
        }

        static int Func1()
        {
            int i;
            for (i = 0; i < 100; i++)
            {
                Console.WriteLine("First function called from {0} ", i);
            }
            Thread.Sleep(3000);
            return i;
        }
        static int Func2(object s)
        {
            int i;
            for (i = 0; i < 100; i++)
            {
                Console.WriteLine("Second function called from {0} ,{1} ", i ,s.ToString());
            }
            Thread.Sleep(3000);
            return i;
        }
    }
}
