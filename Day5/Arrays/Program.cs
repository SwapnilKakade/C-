using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            int[] arr = new int[5];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter the array element {0} :", i);
                arr[i] = int.Parse(Console.ReadLine());

            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("arr[{0}] : {1}", i, arr[i]);
            }

            Console.WriteLine();
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            int[] arr = new int[3];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter the array element {0} :", i);
                arr[i] = int.Parse(Console.ReadLine());

            }

            //int index = Array.IndexOf(arr, 30);
            //int index = Array.LastIndexOf(arr, 30);
            int index = Array.BinarySearch(arr, 30);
            if(index == -1)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine("Found at {0}",index);
            }
     
            Console.ReadLine();
        }
    }
}
