using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
 /*   internal class Program1
    {
        static void Main1(string[] args)
        {
            //var n = 5;
            //for(var i = 0; i < n ;  i++)
            //{
            //    Console.WriteLine(i);
            //}

            //char[] chars = { 'a', 'b', 'c', 'd' };

            //String str = new string(chars);

            //Console.WriteLine(str);
            //foreach(char c in str)
            //{
            //    Console.WriteLine(c);
            //}
            //Console.WriteLine();    


            Coordinate point = new Coordinate(12,6);
            //point.x = 1;
            //point.y = 2;
            Console.WriteLine(point.x);
            Console.WriteLine(point.y);

            

        }
       
           struct Coordinate
           {
                public int x;
                public int y;

                public Coordinate(int x ,int y)
                {
                this.x = x; 
                this.y = y;
                }
           }
    }*/
 /*   internal class Program2
    {
        public static void Main2(string[] args)
        {
            Ifile file1 = new FileInfo();
            //FileInfo file2 = new FileInfo();
            file1.ReadFile();
            file1.WriteFile("content");
        }
    }

    interface Ifile
    {
        void ReadFile();
        void WriteFile(String text);
    }

    internal class FileInfo : Ifile
    {
        public void ReadFile()
        {
            Console.WriteLine("Reading file");
        }

        public void WriteFile(String text)
        {
            Console.WriteLine(text);
        }
    } */

    internal class Program
    {
        public static void Main(string[] args)
        {
            int x = 5 + 5;
            int y = x + 5;
            Console.WriteLine(x + " " + y);
        }
    }

}
