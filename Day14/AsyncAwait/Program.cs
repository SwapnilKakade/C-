using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {
        static  async Task Main1(string[] args)
        {
            Console.WriteLine("Before");
            string message = await DoWorkAsync();
            Console.WriteLine(message);
            Console.WriteLine("After");
            Console.ReadLine();
        }

        static async Task Main2(string[] args)
        {
            Console.WriteLine("Before");

            Task<Task<string>> t1 = new Task<Task<string>>(DoWorkAsync);
            t1.Start();
            Console.WriteLine("After");

            string message = await t1.Result;
            Console.WriteLine(message);
          
            Console.ReadLine();
        }

        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "Done with work !";
            });
        }
    }
}
