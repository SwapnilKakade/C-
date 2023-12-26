using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockThreads
{
    internal class Program
    {
        static object lockObject = new object();
        static int i = 0 ;
        static void Main1(string[] args)
        {


            Thread t1 = new Thread(new ThreadStart(FuncLock));
            Thread t2 = new Thread(new ThreadStart(FuncMonitor));
            Thread t3 = new Thread(new ThreadStart(FuncInterlocked));
            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine("Main finished");
        }

        private static void FuncLock()
        {
            lock (lockObject)
            {
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
                i++;
                Console.WriteLine("First Funclock " + i);
            }
        }
        private static void FuncMonitor()
        {
            Monitor.Enter(lockObject);
            {
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
            }
           Monitor.Exit(lockObject);
        }
        private static void FuncInterlocked()
        {
            Interlocked.Add(ref i, 10);                              // i+= 10
            Console.WriteLine("Third InterLocked "+i.ToString());

            Interlocked.Increment(ref i);                             //++i
            Console.WriteLine("Third InterLocked " + i.ToString());

            Interlocked.Decrement(ref i);                               //--i
            Console.WriteLine("Third InterLocked " + i.ToString());

            Interlocked.Exchange(ref i, 100);                            // i = 100
            Console.WriteLine("Third InterLocked " + i.ToString());
        }

    }
}
