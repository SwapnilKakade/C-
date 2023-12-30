using LoginRegistrationApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System;
using System.Data;

namespace LoginRegistrationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Registration")]
        public string Registration(Registration registration)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("TonyCon")))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Registration (UserName, Password, Email, IsActive) VALUES (@UserName, @Password, @Email, @IsActive)", conn);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                {
                    return "Data Inserted";
                }
                else
                {
                    return "Error";
                }
            }
        }
        [HttpPost]
        [Route("Login")]
        public string Login(Registration registration)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("TonyCon")))
            {
                conn.Open();

                // Use parameters in the query to avoid SQL injection
                string query = "SELECT * FROM Registration WHERE Email = registration.Email AND Password = registration.Password AND IsActive = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                // Bind parameters with values from the registration object
                da.SelectCommand.Parameters.AddWithValue("@Email", registration.Email);
                da.SelectCommand.Parameters.AddWithValue("@Password", registration.Password);

                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Close(); // Close the connection when done

                if (dt.Rows.Count > 0)
                {
                    return "Data found"; // User exists
                }
                else
                {
                    return "Invalid User"; // User not found or credentials incorrect
                }
            }
        }

    }
}