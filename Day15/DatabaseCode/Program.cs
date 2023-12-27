using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseCode1
{
    internal class Program
    {
        static void Main()
        {
            //ConnectToDb();

            Employee obj = new Employee()
            {
                EmpNo = 30,
                Name = "Samira",
                Basic = 2000,
                DeptNo = 20
            };

            //ConnectToDb();
            //Insert(obj);
            //InsertWithParameters(obj);
            //InsertWithstoredProcedure(obj);
            //QueryReturningSingleValue();
            //QueryReturningMultipleValue();
            //GetSingleRecordUsingSqlReader(obj.EmpNo);
            //SqlReaderNextResult();
            CallFuctionReturningSqlDataReader();

            Console.ReadLine();
        }

        static void ConnectToDb()
        {
            SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Basic;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            //conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;User Id = xxx;Password=pwd";
            try
            {
                conn.Open();
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }
        static void Insert(Employee obj)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
                cmdInsert.CommandType = CommandType.Text;
                //cmdInsert.CommandText = "insert into Employees values(7,'Sk',1000,30)";
                cmdInsert.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.Name}',{obj.Basic},{obj.DeptNo})";

                Console.WriteLine(cmdInsert.CommandText);
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Record inserted");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void InsertWithParameters(Employee obj)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = $"insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";
                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("Record inserted");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void InsertWithstoredProcedure(Employee obj)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertEmployee";
                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("Record inserted");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void QueryReturningSingleValue()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = conn;
                cmdSelect.CommandType = CommandType.Text;
                //cmdSelect.CommandText = "Select count(*) from Employees";
                cmdSelect.CommandText = "Select * from Employees";

                object retval = cmdSelect.ExecuteScalar();
                Console.WriteLine(retval);

                Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void QueryReturningMultipleValue()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = conn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employees";

                SqlDataReader DR = cmdSelect.ExecuteReader();
                while (DR.Read())
                {
                    //Console.WriteLine(DR[0]);
                    Console.WriteLine(DR["Name"]);
                }
                Console.WriteLine();
                DR.Close();
                Console.WriteLine("Retrive All Records");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void GetSingleRecordUsingSqlReader(int EmpNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = conn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employees Where EmpNo = @EmpNo";
                cmdSelect.Parameters.AddWithValue("@EmpNo", EmpNo);
                SqlDataReader DR = cmdSelect.ExecuteReader();
                if (DR.Read())
                {
                    Console.WriteLine(DR["Name"]);
                }
                else
                {
                    Console.WriteLine("Record Not found");
                }
                Console.WriteLine();
                DR.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void SqlReaderNextResult()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = conn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employees; Select * from Departments";
                SqlDataReader DR = cmdSelect.ExecuteReader();
                Console.WriteLine("Employees List :");
                while (DR.Read())
                {
                    Console.WriteLine(DR["Name"]);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Departments List :");
                DR.NextResult();
                while (DR.Read())
                {
                    Console.WriteLine(DR["DeptName"]);
                }
                DR.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        static void CallFuctionReturningSqlDataReader()
        {
            SqlDataReader DR = GetDataReader();
            while (DR.Read())
            {
                Console.WriteLine(DR[1]);
            }
            DR.Close() ;
            //Console.WriteLine(conn.State);           //Connnection Open
           
        }
        //static SqlConnection conn = new SqlConnection();
        static SqlDataReader GetDataReader()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";

            conn.Open();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = conn;
            cmdSelect.CommandType = CommandType.Text;
            cmdSelect.CommandText = "Select * from Employees"; 
            //SqlDataReader DR = cmdSelect.ExecuteReader();
            SqlDataReader DR = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

            //conn.Close();
            return DR;

        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public int Basic { get; set; }
        public int DeptNo { get; set; }
    }
}
namespace DatabaseCode2
{
    internal class Program
    {
        static void Main1()
        {

            Employee obj = new Employee()
            {
                EmpNo = 1,
                Name = "sk",
                Basic = 120,
                DeptNo = 40
            };

            //Delete(obj.EmpNo);
            //DeleteWithstoredProcedure(obj.EmpNo);
            //Update(obj.EmpNo, obj.Name, obj.Basic, obj.DeptNo);
            UpdateWithStoredProcedure(obj.EmpNo, obj.Name, obj.Basic, obj.DeptNo);

            Console.ReadLine();
        }

        static void Delete(int EmpNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.CommandText = "Delete from Employees where EmpNo = @EmpNo";
                cmdDelete.Parameters.AddWithValue("@EmpNo", EmpNo);
                int rowsAffected = cmdDelete.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record deleted successfully");
                }
                else
                {
                    Console.WriteLine("No record found with the specified ID");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void DeleteWithstoredProcedure(int EmpNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdDelete = new SqlCommand("DeleteEmployee", conn);
                cmdDelete.CommandType = CommandType.StoredProcedure;

                cmdDelete.Parameters.AddWithValue("@EmpNo", EmpNo);

                int rowsAffected = cmdDelete.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record deleted successfully");
                }
                else
                {
                    Console.WriteLine("No record found with the specified ID");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void Update(int EmpNo, String Name, int Basic, int DeptNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = "Update Employees set Name = @Name ,Basic = @Basic , DeptNo = @DeptNo where EmpNo = @EmpNo";
                cmdUpdate.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmdUpdate.Parameters.AddWithValue("@Name", Name);
                cmdUpdate.Parameters.AddWithValue("@Basic", Basic);
                cmdUpdate.Parameters.AddWithValue("@DeptNo", DeptNo);

                int rowsAffected = cmdUpdate.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record updated successfully");
                }
                else
                {
                    Console.WriteLine("No record found with the specified ID");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void UpdateWithStoredProcedure(int EmpNo, String Name, int Basic, int DeptNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdUpdate = new SqlCommand("UpdateEmployee", conn);
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                cmdUpdate.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmdUpdate.Parameters.AddWithValue("@Name", Name);
                cmdUpdate.Parameters.AddWithValue("@Basic", Basic);
                cmdUpdate.Parameters.AddWithValue("@DeptNo", DeptNo);

                int rowsAffected = cmdUpdate.ExecuteNonQuery();


                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record deleted successfully");
                }
                else
                {
                    Console.WriteLine("No record found with the specified ID");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public int Basic { get; set; }
        public int DeptNo { get; set; }
    }
}
