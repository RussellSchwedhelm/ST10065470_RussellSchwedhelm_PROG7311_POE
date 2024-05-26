using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize session variables
            Session["IsLoggedOn"] = false; // Set IsLoggedOn to false by default
            Session["UserID"] = -1; // Set UserID to -1 by default
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = this.email.Text;
            string password = this.password.Text;

            // Hash the password
            string hashedPassword = HashPassword(password);

            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Connect to the database and validate the credentials
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id FROM Users WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", hashedPassword);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        int userId = Convert.ToInt32(result);

                        // Set the UserID in the session
                        Session["UserID"] = userId;

                        // Set the Employee status in session
                        Session["IsEmployee"] = CheckIfEmployee(email);

                        // Set the LoggedOn status in session
                        Session["IsLoggedOn"] = true;

                        // Credentials are correct, redirect to home page
                        Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        // Credentials are incorrect, display error message using JavaScript
                        string script = "alert('Invalid Email Or Password.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "LoginFailure", script, true);
                    }
                }
                catch (Exception ex)
                {
                    // Handle database connection or query errors
                    // Log the exception or show an error message
                    // For example:
                    Response.Write("An error occurred: " + ex.Message);
                }
            }
        }

        // Method to check if the user is an employee
        private bool CheckIfEmployee(string email)
        {
            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Connect to the database and check if the user is an employee
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Employee FROM Users WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    // If Employee column is 1, user is an employee; otherwise, not an employee
                    return Convert.ToInt32(result) == 1;
                }
            }

            // If no employee status is found or if an error occurs, return false
            return false;
        }

        // Method to hash the password using SHA-256 algorithm
        private string HashPassword(string password)
        {
            // Create SHA-256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute hash from password bytes
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert bytes to hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                // Return the hashed password
                return builder.ToString();
            }
        }
    }
}
