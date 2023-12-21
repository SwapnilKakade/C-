using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main1()
        {
            ArrayList o = new ArrayList();
            o.Add("Swapnil");
            o.Add(2); //BOXING
            int j = (int)o[1]; //UNBOXING

            o.Add(3.14);
            //o.AddRange(o2);
            o.Insert(3, "Kakade");
            o.Remove(2);
            o.RemoveAt(0);
            //o.BinarySearch(2);
            Console.WriteLine("index :" + o.IndexOf(2));
            Console.WriteLine("LastIndex :" + o.LastIndexOf(o));
            //o.RemoveRange(0, 2);
            //o.Clear();

            bool ans = o.Contains(2);
            Console.WriteLine("Contains 2nd element :" + ans);
            Console.WriteLine("GetRange: " + o.GetRange(0, 2));


            Console.WriteLine("Count " + o.Count);
            Console.WriteLine();

            Console.WriteLine(o.ToArray());

            Console.WriteLine();

            //o.Capacity = no of records
            int a = o.Capacity = 100;
            Console.WriteLine("k " + a);

            o.TrimToSize();

            foreach (object i in o)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
        static void Main2()
        {
            //Hashtable o = new Hashtable();
            SortedList o = new SortedList();
            o.Add(1, "A");
            o.Add(2, "B");
            o.Add(3, "C");
            o.Add(4, "D");
            o[5] = "E";
            o[1] = "F";

            //o.Remove(1);
            //o.RemoveAt(1);
            Console.WriteLine("Contains " + o.Contains(1));
            Console.WriteLine("Contains Key " + o.ContainsKey(3));

            Console.WriteLine("GetByIndex " + o.GetByIndex(0));
            Console.WriteLine("GetKey " + o.GetKey(0));
            Console.WriteLine("GetKeyList " + o.GetKeyList());

            //IList list = o.GetKeyList();
            //Console.WriteLine(list);


            //o.IndexOfValue("A");
            //o.GetValueList();
            //ArrayList o1 = (ArrayList) o.Keys;
            //ArrayList o2 = (ArrayList)o.Values;
           


            Console.WriteLine("Count :" + o.Count);
            foreach (DictionaryEntry i in o)
            {
                Console.Write(i.Key + ":");
                Console.WriteLine(i.Value);
            }
        }
        static void Main3()
        {
            Console.WriteLine("Stack");
            Stack s = new Stack();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            Console.WriteLine(s.Peek());
            Console.WriteLine(s.Pop());

            Console.WriteLine();
            Console.WriteLine("Queue");
            
            Queue q = new Queue();  
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            
            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Dequeue());
        }
        static void Main4()
        {
            List<int> o = new List<int>();
            o.Add(1);
            o.Add(2);
            o.Add(3);
            foreach(int i in o)
            {
                Console.WriteLine(i);
            }
        }
        static void Main5()
        {
            SortedList<int,string> o = new SortedList<int,string>();
            o.Add(1, "A");
            o.Add(2, "B");
            o.Add(3, "C");
            o[4] = "D";
            o[1] = "F";

            foreach(KeyValuePair<int,string> i in o)
            {
                Console.WriteLine(i.Key +" "+ i.Value);
            }

        }
        static void Main6()
        {
            Console.WriteLine("Stack");
            Stack<int>s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            Console.WriteLine(s.Peek());
            Console.WriteLine(s.Pop());

            Console.WriteLine();
            Console.WriteLine("Queue");

            Queue<int>q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Dequeue());
        }
        static void Main()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { Id = 1 , Name = "A"});
            list.Add(new Employee { Id = 2 , Name = "B"});
            list.Add(new Employee { Id = 3 , Name = "C"});
            list.Add(new Employee { Id = 4 , Name = "D"});

            foreach (Employee e in list)
            {
                Console.WriteLine(e.Id +" "+ e.Name);
            }
            Console.ReadLine();
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
