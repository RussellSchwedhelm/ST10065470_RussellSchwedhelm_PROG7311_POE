using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize session variables
            Session["IsLoggedOn"] = false; // Set IsLoggedOn to false by default
            Session["UserID"] = -1; // Set UserID to -1 by default
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            // Retrieve form field values
            string email = inp_email.Text.Trim();
            string newPassword = inp_newPassword.Text;
            string oldPassword = inp_oldPassword.Text;

            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Check if the email exists in the database
            if (EmailExists(email, connectionString))
            {
                // Hash the new password
                string hashedNewPassword = HashPassword(newPassword);

                // Retrieve the old hashed password from the database
                string hashedOldPasswordFromDB = GetHashedPasswordFromDB(email, connectionString);

                // Hash the old password provided by the user
                string hashedOldPasswordEntered = HashPassword(oldPassword);

                // Verify if the old password provided matches the one stored in the database
                if (hashedOldPasswordFromDB == hashedOldPasswordEntered)
                {
                    // Update the password in the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Users SET Password = @Password WHERE Email = @Email";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Password", hashedNewPassword);
                        command.Parameters.AddWithValue("@Email", email);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // Password updated successfully
                                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Password Reset Successfully');", true);
                                Response.Redirect("~/Login.aspx");
                            }
                            else
                            {
                                // Email not found in the database
                                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Email Not Found');", true);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle database connection or query errors
                            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occurred: " + ex.Message + "');", true);
                        }
                    }
                }
                else
                {
                    // Old password provided by the user does not match the one stored in the database
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Old Password Invalid');", true);
                }
            }
            else
            {
                // Email not found in the database
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Email Not Found');", true);
            }
        }

        // Method to check if the email exists in the database
        private bool EmailExists(string email, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    // Handle database connection or query errors
                    Response.Write("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }


        // Method to retrieve the hashed password from the database based on the email
        private string GetHashedPasswordFromDB(string email, string connectionString)
        {
            string hashedPassword = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Password FROM Users WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        hashedPassword = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Handle database connection or query errors
                    Response.Write("An error occurred: " + ex.Message);
                }
            }

            return hashedPassword;
        }


        // Method to hash the password using SHA-256 encryption
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}