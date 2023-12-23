using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class1 obj = new Class1();
            obj = null;
            int x = Convert.ToInt32(Console.ReadLine());
            obj.p1 = 100 / x;
            Console.WriteLine(obj.p1);

            Console.ReadLine();
        }
        static void Main2()
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                Console.WriteLine("Enter the value of x ");
                int x = Convert.ToInt32(Console.ReadLine());
                obj.p1 = 100 / x;
                Console.WriteLine(obj.p1);
                Console.WriteLine("No Exceptions");

            }
            catch
            {
                Console.WriteLine("Exception occurred");
            }
        } //Simple try catch block
        static void Main3()
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                Console.WriteLine("Enter the value of x ");
                int x = Convert.ToInt32(Console.ReadLine());
                obj.p1 = 100 / x;
                Console.WriteLine(obj.p1);
                Console.WriteLine("No Exceptions");

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("DBException occurred");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (FormatException e)
            {
                Console.WriteLine("FormatException occurred");
            }
            finally
            {
                Console.WriteLine("Finally block excuted");
            }
            Console.ReadLine();

        } // try multiple catch block and finally 
        static void Main4()
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                Console.WriteLine("Enter the value of x ");
                int x = Convert.ToInt32(Console.ReadLine());
                obj.p1 = 100 / x;
                Console.WriteLine(obj.p1);
                Console.WriteLine("No Exceptions");

            }
            catch (FormatException e)
            {
                try
                {
                    Console.WriteLine("FormatException occurred. Enter only numbers");
                    int x = Convert.ToInt32(Console.ReadLine());
                    obj.p1 = 100 / x;
                    Console.WriteLine(obj.p1);
                }
                catch
                {
                    Console.WriteLine("Nested try catch block");
                }
                finally
                {
                    Console.WriteLine("Nested Finally block excuted");
                }
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("DBException occurred");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("NRException occurred");
            }

            finally
            {
                Console.WriteLine("Finally block excuted");
            }
            Console.ReadLine();

        } // nested try catch finally

        public class Class1
        {
            public int p1;
        }
    }
}

namespace ExceptionHandling2
{
    internal class Program
    {
        static void Main()
        {
            Class1 obj = new Class1();
            try
            {
                //Console.WriteLine("Enter the value of s ");
                //string s = Convert.ToString(Console.ReadLine());
                //Console.WriteLine(s);

                Console.WriteLine("Enter the value of x ");
                int x = Convert.ToInt32(Console.ReadLine());  
                obj.P1 = x;
                Console.WriteLine(obj.P1);
                //Console.WriteLine("No Exceptions");

            }
            catch (FormatException e)
            {  
                    Console.WriteLine("FormatException occurred");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (InvalidP1Exception e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SystemException e)           // all exceptions thrown by .net base classes
            {
                Console.WriteLine(e.Message);
            }
            catch (ApplicationException e)    // all user defined exceptions
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)             // All other exceptions
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();

        }

        public class Class1
        {
            private int p1;
            public int P1
            {
                get
                {
                    return p1;
                }
                set
                {
                    if (value < 100)
                    {
                        p1 = value;
                    }
                    else
                    {
                        //Console.WriteLine("Invalid p1");  //Dont ever do this
                        //Exception e = new Exception();
                        //throw e;

                        //Exception e = new Exception("Invalid P1");
                        //throw e;

                        //throw new Exception("Invalid P1");
                        throw new InvalidP1Exception("Invalid P1");
                    }
                }
            }
        }
        public class InvalidP1Exception : Exception
        {
            public InvalidP1Exception(string message) : base(message) 
            {

            }
        }
    }
}