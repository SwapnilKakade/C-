using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
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
            //Employee emp = lstEmp.Single(e => e.EmpNo == 1);                      // works
            //Employee emp = lstEmp.Single(e =>  e.EmpNo == 15);                    //Not found exception
            //Employee emp = lstEmp.Single(e => e.Basic > 10000);                   //Multiple exception
            //Employee emp = lstEmp.SingleOrDefault(e => e.Basic > 10000);          //Multiple exception
            //Employee emp = lstEmp.SingleOrDefault(e => e.EmpNo == 1);                      // works
            Employee emp = lstEmp.SingleOrDefault(e =>  e.EmpNo == 15);                    //Not found
            if(emp != null)
            {
                Console.WriteLine(emp);
            }
            else
            {
                Console.WriteLine("Not found");
            }

            Console.ReadLine();
        }

        static void Main2()
        {
            AddRecs();

            var emps = from emp in lstEmp select emp;

            emps = emps.ToList();  //.ToArray .ToDictionary

            Console.WriteLine();

            lstEmp.RemoveAt(0);
            foreach(var  emp in emps)
            {
                Console.WriteLine(emp);
            }
            
            Console.WriteLine();

            lstEmp.Add(new Employee { EmpNo = 15,Name = "New" , Basic = 2550 , DeptNo = 20,Gender = "M" });
            foreach (var emp in emps)
            {
                Console.WriteLine(emp);
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