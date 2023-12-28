using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSetExample
{
    public partial class Form1 : Form
    {
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();                    //Step 1 :Connection
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";
            try
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand();            //Step 2 :SqlCommand
                cmdSelect.Connection = conn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * From Employees";

                SqlDataAdapter da = new SqlDataAdapter();           //Step 3 : SqlDataAdapter
                da.SelectCommand = cmdSelect;

                ds = new DataSet();
                da.Fill(ds, "Emps");        //Name of the table may not be same as database table name

                cmdSelect.CommandText = "Select * From Departments";
                da.Fill(ds, "Depts");

                // Primary Key constraint
                DataColumn[] arrCols = new DataColumn[1];
                arrCols[0] = ds.Tables["Emps"].Columns["EmpNo"];
                ds.Tables["Emps"].PrimaryKey = arrCols;


                // Add a Foreign Key Constraint             

                ds.Relations.Add(ds.Tables["Depts"].Columns["DeptNo"], ds.Tables["Emps"].Columns["DeptNo"]);



                //column  Level constraints

                ds.Tables["Depts"].Columns["DeptName"].Unique = true;


                //dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.DataSource = ds.Tables["Emps"];
                //dataGridView1.DataSource = ds.Tables["Depts"];

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Update the dataset changes to the database
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";

            try
            {
                conn.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = "UPDATE Employees SET Name = @Name, Basic = @Basic, DeptNo = @DeptNo WHERE EmpNo = @EmpNo";

                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

                SqlDataAdapter da = new SqlDataAdapter();
                da.UpdateCommand = cmdUpdate;


                da.Update(ds, "Emps");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Delete the dataset changes to the database

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";

            try
            {
                conn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.CommandText = "Delete From Employees where EmpNo = @EmpNo";

                cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

                SqlDataAdapter da = new SqlDataAdapter();
                da.DeleteCommand = cmdDelete;

                da.Update(ds, "Emps");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //Insert the dataset changes to the database

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Basic;Integrated Security=True";

            try
            {
                conn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "Insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
                cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
                cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
                cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });

                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = cmdInsert;

                da.Update(ds, "Emps");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
