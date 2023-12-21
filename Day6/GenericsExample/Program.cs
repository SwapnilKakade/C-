using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            IntegerStack o1 = new IntegerStack(3);
            o1.Push(1);
            o1.Push(2); 
            o1.Push(3);
            //o1.Push(4);
            Console.WriteLine(o1.Pop());
            Console.WriteLine(o1.Pop());
            Console.WriteLine(o1.Pop());

        }

        static void Main2()
        {
            StringStack o2 = new StringStack(3);
            o2.Push("A");
            o2.Push("B");
            o2.Push("C");

            Console.WriteLine(o2.Pop());
            Console.WriteLine(o2.Pop());
            Console.WriteLine(o2.Pop());

        }

        static void Main()
        {
            MyStack<String> o2 = new MyStack<String>(3);
            o2.Push("A");
            o2.Push("B");
            o2.Push("C");

            Console.WriteLine(o2.Pop());
            Console.WriteLine(o2.Pop());
            Console.WriteLine(o2.Pop());

        }
    }
    class IntegerStack<T> 
        //where T : class       // T must be a reference type
        //where T : struct      //T must be a value type
        //where T : className   //T must be the class or its derived class
        //where T : interfaceName // T must be a class that implements the inteface
        //where T : new()           // T must have a no parameter consturctor
        //where T : className,interfaceName,new()
       
    {
        int[] arr;
        int Pos = -1;

        public IntegerStack(int size)
        {
            arr = new int[size];
        }

        public void Push(int i)
        {
            if (Pos == (arr.Length - 1))
            {
                throw new Exception("Stack full");
            }

            arr[++Pos] = i;
        }

        public int Pop()
        {
            if (Pos == -1)
            {
                throw new Exception("Stack Empty");
            }

            return arr[Pos--];
        }
    }

    class StringStack
    {
        String[] arr;
        int Pos = -1;

        public StringStack(int size)
        {
            arr = new String[size];
        }

        public void Push(String i)
        {
            if (Pos == (arr.Length - 1))
            {
                throw new Exception("Stack full");
            }

            arr[++Pos] = i;
        }

        public String Pop()
        {
            if (Pos == -1)
            {
                throw new Exception("Stack Empty");
            }

            return arr[Pos--];
        }
    }

    class MyStack<T>
    {
        T[] arr;
        int Pos = -1;

        public MyStack(int size)
        {
            arr = new T[size];
        }

        public void Push(T i)
        {
            if (Pos == (arr.Length - 1))
            {
                throw new Exception("Stack full");
            }

            arr[++Pos] = i;
        }

        public T Pop()
        {
            if (Pos == -1)
            {
                throw new Exception("Stack Empty");
            }

            return arr[Pos--];
        }
    }


}

