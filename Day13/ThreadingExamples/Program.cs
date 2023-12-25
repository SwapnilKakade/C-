using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingExamples1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            //Thread t = new Thread(new ThreadStart(Func1));
            Thread t1 = new Thread(Func1);
            Thread t2 = new Thread(Func2);
            //t1.Priority = ThreadPriority.Highest;
            //t1.IsBackground = true;
            t1.Start();
            t2.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main " + i);
                //if(i == 50)
                //{
                //    t1.Abort();
                //}
            }
            //t1.Suspend();
            //t1.Resume();


            t1.Join();            // This code should run only after func1 is over
            Console.WriteLine("This code should run only after fuc1 is over");

            //Console.WriteLine( t1.ThreadState);

           // if(t1.ThreadState == ThreadState.) ;
        }
        static void Func1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("First "+i);
                Thread.Sleep(1000);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second " + i);
            }
        }
    }
}

namespace ThreadingExamples2
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            Thread t2 = new Thread(Func2);
         
            t1.Start(" o1");
            t2.Start(" o2");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main " + i.ToString());
                //if(i == 50)
                //{
                //    t1.Abort();
                //}
            }
           
        }
        static void Func1(object o)
        {
             
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First " + i.ToString() + o.ToString());
                Thread.Sleep(1000);
            }
        }
        static void Func2(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second " + i.ToString() + o.ToString());
            }
        }
    }
}

namespace ThreadingExamples3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc1), " aaa");
            ThreadPool.QueueUserWorkItem(PoolFunc1, " aa");
            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc1));
            ThreadPool.QueueUserWorkItem(PoolFunc2);


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main " + i.ToString());
            }
            int workerthreads, iothreads;
            ThreadPool.GetAvailableThreads(out workerthreads, out iothreads);

            //ThreadPool.SetMinThreads;
            //ThreadPool.SetMaxThreads;
            //ThreadPool.GetMinThreads;

            Console.WriteLine(workerthreads);
            Console.WriteLine(iothreads);

        }
        static void PoolFunc1(object o)
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First " + i.ToString() + o.ToString());
              
            }
        }
        static void PoolFunc2(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second " + i.ToString() + o.ToString());
            }
        }
    }
}
