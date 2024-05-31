using ST10065470_RussellSchwedhelm_PROG7311_POE.Classes;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class Register : System.Web.UI.Page
    {
        // Declare an instance of DBController class
        DBController dbController;
        //----------------------------------------------------------------------------------------------------------------------//
        // Method called when the page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize session variable for login status if it's null
            if (Session["IsLoggedOn"] == null)
            {
                Session["IsLoggedOn"] = false;
            }

            // Initialize the DBController instance
            dbController = new DBController();
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method called when the register button is clicked
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Retrieve user input from form fields
            string firstName = inp_firstName.Text;
            string surname = inp_surname.Text;
            string email = inp_email.Text;
            string password = inp_password.Text;
            string streetNum = txtStreetNumber.Text;
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string suburb = txtSuburb.Text;
            string country = txtCountry.Text;
            string province = txtProvince.Text;
            string phone = txtPhone.Text;
            string employee = "0";
            bool isEmployee = employeeCheck.Checked;

            // Hash the password using SHA-256 encryption
            string hashedPassword = HashPassword(password);

            // Check if the email already exists in the database
            if (dbController.CheckForEmail(email))
            {
                // If the email already exists, display an error message to the user
                string script = "alert('Email Already Registered');";
                ScriptManager.RegisterStartupScript(this, GetType(), "InvalidEmail", script, true);
                return;
            }

            // If the user is an employee, validate the employee code
            if (isEmployee)
            {
                string employeeCode = inp_employeeCode.Text;
                if (!dbController.CheckEmployeeCodes(employeeCode))
                {
                    // If the employee code doesn't exist, display an error message to the user
                    string script = "alert('Employee Code Invalid');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "InvalidCode", script, true);
                    return;
                }
                else
                {
                    employee = "1";
                }
            }

            // Attempt to create a new user in the database
            if (dbController.CreateUser(firstName, surname, email, hashedPassword, streetNum, street, suburb, city, province, country, phone, employee))
            {
                // User registration successful, redirect to login page
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                // Handle database connection errors
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occured');", true);
                return;
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