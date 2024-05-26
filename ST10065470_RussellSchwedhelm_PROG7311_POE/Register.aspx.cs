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
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize session variable for login status
            if (Session["IsLoggedOn"] == null)
            {
                Session["IsLoggedOn"] = false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Retrieve user input from form fields
            string firstName = inp_firstName.Text;
            string surname = inp_surname.Text;
            string email = inp_email.Text;
            string password = inp_password.Text;
            int streetNum = int.Parse(txtStreetNumber.Text);
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string suburb = txtSuburb.Text;
            string country = txtCountry.Text;
            string province = txtProvince.Text;
            string phone = txtPhone.Text;
            bool isEmployee = employeeCheck.Checked;

            // Hash the password using SHA-256 encryption
            string hashedPassword = HashPassword(password);

            // Retrieve the connection string from Web.config file
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Check if the user with the provided email already exists in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        // If the email already exists, display an error message to the user
                        string script = "alert('Email Already Registered');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "InvalidEmail", script, true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    // Handle database connection errors
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occured: " + ex.Message + "');", true);
                    return;
                }
            }

            // If the user is an employee, validate the employee code
            if (isEmployee)
            {
                string employeeCode = inp_employeeCode.Text;

                // Check if the provided employee code exists in the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM EmployeeCodes WHERE Codes = @EmployeeCode";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeCode", employeeCode);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        if (count == 0)
                        {
                            // If the employee code doesn't exist, display an error message to the user
                            string script = "alert('Employee Code Invalid');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "InvalidCode", script, true);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle database connection errors
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occured: " + ex.Message + "');", true);
                        return;
                    }
                }
            }

            // Insert the user data into the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (FirstName, Surname, Email, Password, Employee, " +
                    "StreetNumber, Street, Suburb, City, Province, Country, Phone) VALUES (@FirstName, " +
                    "@Surname, @Email, @Password, @Employee, @StreetNumber, @Street, @Suburb, @City, @Province, @Country, @Phone)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", hashedPassword);
                command.Parameters.AddWithValue("@Employee", isEmployee ? 1 : 0);
                command.Parameters.AddWithValue("@StreetNumber", streetNum);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@Suburb", suburb);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Province", province);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@Phone", phone);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle database connection errors
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occured: " + ex.Message + "');", true);
                    return;
                }
            }

            // User registration successful, redirect to login page
            Response.Redirect("~/Login.aspx");
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
