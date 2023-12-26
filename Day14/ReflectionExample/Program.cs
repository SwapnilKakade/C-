using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string assemblyPath = @"D:\C#\Day2\Properties\bin\Debug\Properties.exe";
            Assembly asm = Assembly.LoadFile(assemblyPath);
            //Console.WriteLine(asm.FullName);         //Get full name
            Console.WriteLine(asm.GetName().Name);

            Type[] arrTypes = asm.GetTypes();     //Array of types 

            foreach (Type t in arrTypes)
            {
                Console.WriteLine("     "+t.Name);
               
                MethodInfo [] arrMethods = t.GetMethods();
                foreach (MethodInfo m in arrMethods)
                {
                    Console.WriteLine("         "+m.Name);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
