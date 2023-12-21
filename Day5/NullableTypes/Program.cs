using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            // Class1 0 = null;
            int j = 0;
            int? i = 100;
            i = null;

            if (i != null)
            {
                j = (int)i;
            }
            else
            {
                j = 0;
            }

            if (i.HasValue) {
                j = i.Value;
            } else
            {
                j = 0;
            }

            j = i .GetValueOrDefault();
            j = i.GetValueOrDefault(10);

            j = i ?? 0; // null coalscing operator

            Console.WriteLine(j);
            Console.ReadLine();
        }
    }
    class Class1
    {

    }
}
