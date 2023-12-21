using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            int[] arr = new int[3];

            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter the array element {0}",i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            //Array.Clear(arr, 0, arr.Length);

            //Array.Copy

            //Array.ConstrainedCopy

            //int []arr2 = (int[])Array.CreateInstance(typeof(int), arr.Length);
            
            //Array.Sort(arr);
            
            //Array.Reverse(arr);
            
            
            Console.ReadLine();
        }
        static void Main2(string[] args)
        {
            //Store marks for 5 students , 3 subjects marks
            int[,] arr = new int[3,2];

            //Console.WriteLine(arr.Length);              //15
            //Console.WriteLine(arr.GetLength(0));        //5
            //Console.WriteLine(arr.GetLength(1));        //3
            //Console.WriteLine(arr.Rank);                //2
            //Console.WriteLine(arr.GetUpperBound(0));    //4  upper index of 5 
            //Console.WriteLine(arr.GetLowerBound(0));    //0

           for(int i = 0;i < arr.GetLength(0);i++)
            {
                for(int j = 0;j < arr.GetLength(1); j++)
                {
                    Console.WriteLine("Enter the arr[{0},{1}]:", i, j);
                    arr[i,j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine("arr[{0},{1}] :{2}", i, j, arr[i,j]);
                }
            }
            Console.ReadLine();
        }
        static void Main3(string[] args)
        {
            //Jagged
            int[][] arr = new int[4][];
            arr[0] = new int[4];
            arr[1] = new int[3];
            arr[2] = new int[2];
            arr[3] = new int[3];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("Enter value for subscript [{0},{1}]:", i, j);
                    arr[i][j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine("value of subscript arr[{0},{1}] :{2}", i, j, arr[i][j]);
                }
            }
            Console.ReadLine();
        }
    }
}
