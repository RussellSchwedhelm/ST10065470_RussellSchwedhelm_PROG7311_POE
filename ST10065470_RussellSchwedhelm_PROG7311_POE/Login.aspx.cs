using ST10065470_RussellSchwedhelm_PROG7311_POE.Classes;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class Login : Page
    {
        DBController dbControler;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize session variables
            Session["IsLoggedOn"] = false; // Set IsLoggedOn to false by default
            Session["UserID"] = -1; // Set UserID to -1 by default
            dbControler = new DBController();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = this.email.Text;
            string password = this.password.Text;

            // Hash the password
            string hashedPassword = HashPassword(password);
            object result = dbControler.Login(email, hashedPassword);

            if (result != null)
            {
                int userId = Convert.ToInt32(result);

                // Set the UserID in the session
                Session["UserID"] = userId;

                // Set the Employee status in session
                Session["IsEmployee"] = dbControler.CheckIfEmployee(email);

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
