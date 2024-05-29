using ST10065470_RussellSchwedhelm_PROG7311_POE.Classes;
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
        DBController dbController;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize session variables
            Session["IsLoggedOn"] = false; // Set IsLoggedOn to false by default
            Session["UserID"] = -1; // Set UserID to -1 by default
            dbController = new DBController();
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
            if (dbController.CheckForEmail(email))
            {
                if (dbController.ComparePasswords(email, HashPassword(oldPassword)))
                {
                    if (dbController.UpdatePassword(email, HashPassword(newPassword)))
                    {
                        // Password updated successfully
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Password Reset Successfully');", true);
                        Response.Redirect("~/Login.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occured');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Old Password Invalid');", true);
                }
            }
            else
            {
                // Email not found in the database
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Email Not Found');", true);
            }
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