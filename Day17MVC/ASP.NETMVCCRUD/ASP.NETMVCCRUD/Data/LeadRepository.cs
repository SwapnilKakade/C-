
using ASP.NETMVCCRUD.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ASP.NETMVCCRUD.Data
{
    public class LeadRepository
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MvcDemoDb;Integrated Security=True;";
        public List<LeadsEntity> GetAllLeads()
        {
            List<LeadsEntity> leadListEntity = new List<LeadsEntity>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("GetAllLeads", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                leadListEntity.Add(new LeadsEntity
                                {
                                    Id = Convert.ToInt32(dr["id"]),
                                    LeadDate = Convert.ToDateTime(dr["LeadDate"]),
                                    Name = dr["Name"].ToString(),
                                    EmailAddress = dr["EmailAddress"].ToString(),
                                    Mobile = dr["Mobile"].ToString(),
                                    LeadSource = dr["LeadSource"].ToString(),
                                    LeadStatus = dr["LeadStatus"].ToString(),
                                    NextFollowUpDate = Convert.ToDateTime(dr["NextFollowUpDate"])
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, display an error message, etc.)
                    Console.WriteLine($"Error in GetAllLeads: {ex.Message}");
                }
            }

            return leadListEntity;
        }
        public bool AddLead(LeadsEntity lead)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddLeadDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LeadDate", lead.LeadDate);
                cmd.Parameters.AddWithValue("@Name", lead.Name);
                cmd.Parameters.AddWithValue("@EmailAddress", lead.EmailAddress);
                cmd.Parameters.AddWithValue("@Mobile", lead.Mobile);
                cmd.Parameters.AddWithValue("@LeadSource", lead.LeadSource);
                cmd.Parameters.AddWithValue("@LeadStatus", lead.LeadStatus);
                cmd.Parameters.AddWithValue("@NextFollowUpDate", lead.NextFollowUpDate);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                return i >= 1;
            }
        }
        public LeadsEntity GetLeadById(int Id)
        {
            LeadsEntity leadListEntity = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetLeadDetailsById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                leadListEntity = new LeadsEntity
                                {
                                    Id = Convert.ToInt32(dr["id"]),
                                    LeadDate = Convert.ToDateTime(dr["LeadDate"]),
                                    Name = dr["Name"].ToString(),
                                    EmailAddress = dr["EmailAddress"].ToString(),
                                    Mobile = dr["Mobile"].ToString(),
                                    LeadSource = dr["LeadSource"].ToString(),
                                    LeadStatus = dr["LeadStatus"].ToString(),
                                    NextFollowUpDate = Convert.ToDateTime(dr["NextFollowUpDate"])
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    Console.WriteLine($"Error in GetLeadById: {ex.Message}");
                }
            }

            return leadListEntity;
        }
        public bool EditLeadDetails(int Id, LeadsEntity lead)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EditLeadDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", lead.Id);
                    cmd.Parameters.AddWithValue("@LeadDate", lead.LeadDate);
                    cmd.Parameters.AddWithValue("@Name", lead.Name);
                    cmd.Parameters.AddWithValue("@EmailAddress", lead.EmailAddress);
                    cmd.Parameters.AddWithValue("@Mobile", lead.Mobile);
                    cmd.Parameters.AddWithValue("@LeadSource", lead.LeadSource);
                    cmd.Parameters.AddWithValue("@LeadStatus", lead.LeadStatus);
                    cmd.Parameters.AddWithValue("@NextFollowUpDate", lead.NextFollowUpDate);

                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    return i >= 1;
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    Console.WriteLine($"Error in EditLeadDetails: {ex.Message}");
                    return false;
                }
            }
        }
        public bool DeleteLeadDetails(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string deleteQuery = "DELETE FROM Leads WHERE ID = @ID";

                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", Id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    return rowsAffected >= 1;
                }
                catch (Exception ex)
                {
                    // Log or handle the exception appropriately
                    Console.WriteLine($"Error in DeleteLeadDetails: {ex.Message}");
                    return false;
                }
            }
        }

    }
}