using ST10065470_RussellSchwedhelm_PROG7311_POE.Classes;
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        // Declare an instance of DBController class
        DBController dbController;
        //----------------------------------------------------------------------------------------------------------------------//
        // Method called when the page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize session variables
            Session["IsLoggedOn"] = false; // Set IsLoggedOn to false by default
            Session["UserID"] = -1; // Set UserID to -1 by default

            // Initialize the DBController instance
            dbController = new DBController();
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method called when the reset password button is clicked
        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            // Retrieve form field values
            string email = inp_email.Text.Trim();
            string newPassword = inp_newPassword.Text;
            string oldPassword = inp_oldPassword.Text;

            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Check if the email exists in the database
            if (dbController.CheckForEmail(email))
            {
                // If email exists, compare old password with the stored password
                if (dbController.ComparePasswords(email, HashPassword(oldPassword)))
                {
                    // If old password matches, update the password
                    if (dbController.UpdatePassword(email, HashPassword(newPassword)))
                    {
                        // Password updated successfully
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Password Reset Successfully');", true);
                        Response.Redirect("~/Login.aspx");
                    }
                    else
                    {
                        // Handle database connection errors
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occured');", true);
                    }
                }
                else
                {
                    // Display error message if old password is incorrect
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Old Password Invalid');", true);
                }
            }
            else
            {
                // Display error message if email not found in the database
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Email Not Found');", true);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method to hash the password using SHA-256 encryption
        private string HashPassword(string password)
        {
            // Using SHA256 hashing algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute hash from password bytes
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                // Convert bytes to hexadecimal string
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
    }
}
//-----------------------------------------------End Of Page-----------------------------------------------------------------------//