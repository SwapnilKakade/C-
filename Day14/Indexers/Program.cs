using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    internal class Program
    {
        static void Main1(string[] args)
        {

            //ArrayList o2 = new ArrayList();
            //o2[10] = "Swapnil";
            //o2.this[20] = "adc";


            Class1 o = new Class1();
            o[0] = 10;
            o[1] = 20;
            o[2] = 30;
            //o.X = 40;

           // Console.WriteLine(o.X);
            Console.WriteLine(o[0]);
            Console.WriteLine(o[1]);
            Console.WriteLine(o[2]);

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            YearlyCollections o1 = new YearlyCollections(5,2020);
            o1[2020] = 10;
            o1[2021] = 20;
            o1[2022] = 30;
            o1[2023] = 40;
            o1[2024] = 50;

            Console.WriteLine(o1[2024]);
        }

    }

    public class Class1
    {
        private int []arr = new int[3];
        public int this[int index]     //indexer
        {
            set
            {
                arr[index] = value;
            }
            get 
            { 
                return arr[index];
            }
        }

        private int x;
        public int X 
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
    }

    public class YearlyCollections
    {
        private int[] arr;
        private int offset;

        public YearlyCollections(int size ,int offset)
        {
            arr = new int[size];
            this.offset = offset;
        }
         public int this[int index]     //indexer
        {
            set
            {
                arr[index - offset] = value;
            }
            get 
            { 
                return arr[index - offset];
            }
        }
    }
    
}
