using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample1  
{
    // Language integrated query
    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();

        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "Sales" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "HR" });


            lstEmp.Add(new Employee { EmpNo = 1, Name = "A", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "B", Basic = 3000, DeptNo = 30, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "C", Basic = 50000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "D", Basic = 20000, DeptNo = 10, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "E", Basic = 30000, DeptNo = 30, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "C", Basic = 40000, DeptNo = 20, Gender = "M" }); ;
        }
        static void Main1(string[] args)
        {
            AddRecs();
            // Form single object in collection select something
            var emps = from emp in lstEmp select emp;
            //IEnumerable<Employee> Emps = from emp in lstEmp select emp;
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }
            Console.ReadLine();
        }
        static void Main2(string[] args)
        {
            AddRecs();
            var emps = from emp in lstEmp select emp;  // emps datatype =IEnumerable string
            foreach (var item in emps)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void Main3(string[] args)
        {
            AddRecs();
            var emps = from emp in lstEmp select new { emp.EmpNo, emp.Name };
            foreach (var item in emps)
            {
                Console.WriteLine($"EmpNo: {item.EmpNo}, Name: {item.Name}");
            }
            Console.ReadLine();
        }
        static void Main4(string[] args)
        {
            AddRecs();
            //var emps = from emp in lstEmp where emp.Basic > 10000 select emp;

            //var emps = from emp in lstEmp where emp.Basic > 10000 && emp.Basic < 50000 select emp;

            var emps = from emp in lstEmp where emp.Name.StartsWith("C") select emp;

            foreach (var item in emps)
            {
                Console.WriteLine($"Name: {item.Name}");
            }
            Console.ReadLine();
        }
        static void Main5(string[] args)
        {
            AddRecs();

            //var emps = from emp in lstEmp orderby emp.Name descending select emp;  

            var emps = from emp in lstEmp orderby emp.Name ,emp.DeptNo descending select emp;

            foreach (var item in emps)
            {
                Console.WriteLine($"Name: {item.Name}");
            }
            Console.ReadLine();
        }
        static void Main6(string[] args)
        {
            AddRecs();

            var emps1 = from emp in lstEmp join dept in lstDept on  emp.DeptNo equals dept.DeptNo select new { dept.DeptName ,emp.Name};

            var emps2 = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select emp;

            var emps3 = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select dept;

            var emps4 = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select new {emp , dept };

            foreach (var item in emps1)    // get department name and employee name
            {
                Console.WriteLine(item);
            }
               
            Console.WriteLine();

            foreach (var item in emps2)   // get Employee details
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (var item in emps3)   // get Department details
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (var item in emps4)   // // get department and employee
            {
                Console.WriteLine(item);
            }
        }
        static void Main7(string[] args)
        {
            AddRecs();

          

            var emps = from emp in lstEmp group emp by emp.DeptNo ;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Key);
                foreach(var e in emp)
                {
                    Console.WriteLine(e.Name);  
                }
            }
            Console.ReadLine();
        }
        static void Main8(string[] args)
        {
            AddRecs();



            var emps = from emp in lstEmp group emp by emp.DeptNo into group1 
                       select new {group1 ,Count = group1.Count() , Max = group1.Max(x => x.Basic) ,
                           Min = group1.Min(x => x.Basic)
                       };

            foreach (var emp in emps)
            {
                Console.WriteLine("DeptNo :" + emp.group1.Key);
                Console.WriteLine("Count :"+emp.Count);
                Console.WriteLine("Max :"+emp.Max);
                Console.WriteLine("Min :"+emp.Min);

                foreach (var e in emp.group1)
                {
                    Console.WriteLine(e.Name);
                }
                Console.WriteLine() ;
            }
            Console.ReadLine();
        }
    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public override string ToString()
        {
            return $"DeptNo: {DeptNo}, DeptName: {DeptName}";
        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }

        //public override string ToString()
        //{
        //    return $"{Name},{EmpNo},{Basic},{DeptNo},{Gender}";
        //}

        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString() + "," + Gender.ToString();
            return s;
        }
    }
}

namespace LinqExample2
{
    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();

        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "Sales" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "HR" });


            lstEmp.Add(new Employee { EmpNo = 1, Name = "A", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "B", Basic = 3000, DeptNo = 30, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "C", Basic = 50000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "D", Basic = 20000, DeptNo = 10, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "E", Basic = 30000, DeptNo = 30, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "C", Basic = 40000, DeptNo = 20, Gender = "M" }); ;
        }

        static Employee GetEmployees(Employee o)
        {
            return o;
        }

        static string GetEmployees2(Employee o)
        {
            return o.Name;
        }
        static void Main1(string[] args)
        {
            AddRecs();
            //var emps1 = from emp in lstEmp select emp;
            var emps = lstEmp.Select(GetEmployees);

            // var emps1 = from emp in lstEmp select emp.name;

            var emps2 = lstEmp.Select(GetEmployees2);

            var emps2a = lstEmp.Select(delegate (Employee o)
            {
                return o.Name;
            });

            var emps2b = lstEmp.Select(e => e);
            var emps2c = lstEmp.Select(e => e.Name);

            var emps2d = lstEmp.Select(e => new { e.EmpNo ,e.Name});


            foreach (var item in emps2b)
            {
                Console.WriteLine(item.Name); // Assuming item here is a string
            }

            Console.ReadLine();
        }
        static void Main2(string[] args)
        {
            AddRecs();

            //var emps = from emp in lstEmp where emp.EmpNo >= 4 select emp;

            var emps1 = lstEmp.Where(e => e.EmpNo >= 4);
            var emps2 = lstEmp.Where(e => e.EmpNo >= 4).Select(e => e);
            var emps3 = lstEmp.Select(e => e).Where(e => e.EmpNo >= 4);

            var emps4 = lstEmp.Where(e => e.EmpNo >= 4).Select(e => e.Name);      //Get list of employee then check name
            //var emps5= lstEmp.Select(e => e.Name).Where(e => e.EmpNo >= 4);     //Not Working     syntex error   Order important


            foreach (var item in emps4)
            {
                Console.WriteLine(item); // Assuming item here is a string
            }

            Console.ReadLine();
        }

        static void Main3(string[] args)
        {
            AddRecs();

            var emps1 = lstEmp.OrderBy(e => e.Name);

            var emps2 = lstEmp.OrderByDescending(e => e.Name);

            var emps3 = lstEmp.OrderBy(e => e.DeptNo).ThenBy(e => e.Name);

            var emps4 = lstEmp.OrderBy(e => e.DeptNo).ThenByDescending(e => e.Name);

            foreach (var item in emps2)
            {
                Console.WriteLine(item); // Assuming item here is a string
            }

            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            AddRecs();

            var emps1 = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo ,(emp ,dept) => emp);
            var emps2 = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept);
            var emps3 = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp.DeptNo);
            var emps4 = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp.DeptNo);
            var emps5 = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new {dept.DeptName ,emp.Name });



            foreach (var item in lstDept)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }

        public override string ToString()
        {
            return $"DeptNo: {DeptNo}, DeptName: {DeptName}";
        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"{Name},{EmpNo},{Basic},{DeptNo},{Gender}";
        }


    }
}
