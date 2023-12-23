using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// call function synchronously using delegates
namespace AsyncCodeUsingDelegates1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Before Display");
            Action o1 = Display;
            //o1();       //Sync call
            o1.BeginInvoke(null, null);  //Async call
            Console.WriteLine("After Display");
            Console.ReadLine();
        }

        private static void Display()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Display Called");
        }
    }
    
}
// call function synchronously using delegates
// pass parameters to the fuction
namespace AsyncCodeUsingDelegates2
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Before Display");
            Action<string>o1 = Display;
            o1.BeginInvoke("Hello",null, null);  //Async call
            Console.WriteLine("After Display");
            Console.ReadLine();
        }

        private static void Display(string s)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Display Called " + s);
        }
    }

}
// call function Asynchronously using delegates
// call a function with a return value
//use a callback function
namespace AsyncCodeUsingDelegates3
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Before Display");
            Func<string ,string> o1 = Display;
            string retval;
            o1.BeginInvoke("Hello", CallbackFuction, null);  //Async call
            Console.WriteLine("After Display");
            Console.ReadLine();
        }

        private static string Display(string s)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Display Called " + s);
            return s.ToUpper();
        }
        private static void CallbackFuction(IAsyncResult ar)
        {
            // CallBack function that will be called after Display is over
            //the return value of Display will be read here
            Console.WriteLine("Callback fuction called");
        }
    }

}
// call function Asynchronously using delegates
// call a function with a return value
//use a callback function
// Move the delegate object to the class level so it can be accessed by the callback function
namespace AsyncCodeUsingDelegates4
{
    internal class Program
    {
        static Func<string, string> o1;
        static void Main1(string[] args)
        {
            Console.WriteLine("Before Display");
            o1 = Display;
             
            IAsyncResult ar =  o1.BeginInvoke("Hello", CallbackFuction, null);  //Async call
    
            Console.WriteLine("After Display");
            Console.ReadLine();
        }

        private static string Display(string s)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Display Called " + s);
            return s.ToUpper();
        }
        private static void CallbackFuction(IAsyncResult ar)
        {
            // CallBack function that will be called after Display is over
            //the return value of Display will be read here
            Console.WriteLine("Callback fuction called");
            string retval;
            retval = o1.EndInvoke(ar);
            Console.WriteLine(retval );
        }
    }

}
// call function Asynchronously using delegates
// call a function with a return value
//use a callback function
// use an anonymous method (callback method) to access delegate object decleare in Main()
namespace AsyncCodeUsingDelegates5
{
    internal class Program
    {
        static Func<string, string> o1;
        static void Main1(string[] args)
        {
            Console.WriteLine("Before Display");
            Func<string, string> o1 = Display;

             o1.BeginInvoke("Hello", delegate(IAsyncResult ar)
            {
                Console.WriteLine("Callback fuction called");
                string retval;
                retval = o1.EndInvoke(ar);
                Console.WriteLine("return value "+ retval );
            },null);  

            Console.WriteLine("After Display");
            Console.ReadLine();
        }

        private static string Display(string s)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Display Called " + s);
            return s.ToUpper();
        }
       
    }

}
// call function Asynchronously using delegates
// call a function with a return value
//use a callback function
// pass the delegate object(o1) as the last parameter in o1.BeginInvoke(..)
// use ar.AsyncState in the callback fuction to access the last parameter passed
namespace AsyncCodeUsingDelegates6
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Before Display");
            Func<string, string> o1 = Display;
            //o1.BeginInvoke("Hello", CallbackFuction, null);
            //o1.BeginInvoke("Hello", CallbackFuction, "Extra Info");
            o1.BeginInvoke("Hello", CallbackFuction, o1);
            Console.WriteLine("After Display");
            Console.ReadLine();
        }

        private static string Display(string s)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Display Called " + s);
            return s.ToUpper();
        }
        private static void CallbackFuction(IAsyncResult ar)
        {
            // CallBack function that will be called after Display is over
            //the return value of Display will be read here
            Console.WriteLine("Callback fuction called");

            // ar.AsyncState is the last parameter from o1.BeginInvoke(..)
            //string lastPrameter = ar.AsyncState.ToString();
            //Console.WriteLine(lastPrameter);
            Func<string, string> o1 = (Func<string, string>) ar.AsyncState;
            string retval;
            retval = o1.EndInvoke(ar);
            Console.WriteLine("return value " + retval);
        }
    }

}

namespace AsyncCodeUsingDelegates7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before Display");
            Func<string, string> o1 = Display;
            IAsyncResult asyncResult = o1.BeginInvoke("Hello", CallbackFunction, null);
            Console.WriteLine("After Display");
            Console.ReadLine();
        }

        private static string Display(string s)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Display Called " + s);
            return s.ToUpper();
        }

        private static void CallbackFunction(IAsyncResult ar)
        {
            Console.WriteLine("Callback function called");
            AsyncResult asyncResult = (AsyncResult)ar;
            Func<string, string> o1 = (Func<string, string>)asyncResult.AsyncDelegate;
            string retval;
            retval = o1.EndInvoke(ar);
            Console.WriteLine("Return value: " + retval);
        }
    }
}