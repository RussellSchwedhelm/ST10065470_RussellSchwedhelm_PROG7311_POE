using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class CreateFarmer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged on
            if (!(this.Master is SiteMaster master) || !master.LoggedOn)
            {
                // Redirect the user to the login page
                Response.Redirect("~/Login.aspx");
            }

            // Get the FarmerId from the query string
            string farmerId = Request.QueryString["FarmerId"];

            // If the FarmerId is not null or empty, load the farmer details
            if (!IsPostBack && !string.IsNullOrEmpty(farmerId))
            {
                LoadFarmerDetails(farmerId);
            }
        }

        private void LoadFarmerDetails(string farmerId)
        {
            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Query to retrieve farmer details
            string selectQuery = "SELECT FirstName, Surname, Email, StreetNumber, Street, Suburb, City, Province, Country, Phone FROM Users WHERE Id = @FarmerId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@FarmerId", farmerId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Populate form fields with the farmer's details
                    txtFirstName.Text = reader["FirstName"].ToString();
                    txtSurname.Text = reader["Surname"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtStreetNumber.Text = reader["StreetNumber"].ToString();
                    txtStreet.Text = reader["Street"].ToString();
                    txtSuburb.Text = reader["Suburb"].ToString();
                    txtCity.Text = reader["City"].ToString();
                    txtProvince.Text = reader["Province"].ToString();
                    txtCountry.Text = reader["Country"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                }
                connection.Close();
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModifyFarmers");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Retrieve the form data
            string firstName = txtFirstName.Text.Trim(); // Extract first name from the text box
            string surname = txtSurname.Text.Trim(); // Extract surname from the text box
            string streetNumber = txtStreetNumber.Text.Trim(); // Extract street number from the text box
            string street = txtStreet.Text.Trim(); // Extract street name from the text box
            string suburb = txtSuburb.Text.Trim(); // Extract suburb from the text box
            string city = txtCity.Text.Trim(); // Extract city from the text box
            string province = txtProvince.Text.Trim(); // Extract province from the text box
            string country = txtCountry.Text.Trim(); // Extract country from the text box
            string email = txtEmail.Text.Trim(); // Extract email from the text box
            string phone = txtPhone.Text.Trim(); // Extract phone number from the text box
            string password = string.Empty; // Initialize password variable
            string farmerId = Request.QueryString["FarmerId"]; // Get FarmerId from query string

            // Validate the form data
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(streetNumber) || string.IsNullOrEmpty(street) ||
                string.IsNullOrEmpty(suburb) || string.IsNullOrEmpty(city) ||
                string.IsNullOrEmpty(province) || string.IsNullOrEmpty(country) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                // If any of the required fields are empty, display an alert
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('All Fields Are Required');", true);
                return;
            }

            // Get the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query;
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                // If FarmerId is present, update the farmer's details
                if (!string.IsNullOrEmpty(farmerId))
                {
                    query = "UPDATE Users SET FirstName = @FirstName, Surname = @Surname, Email = @Email, " +
                        "StreetNumber = @StreetNumber, " +
                            "Street = @Street, Suburb = @Suburb, City = @City, Province = @Province, Country = " +
                            "@Country, Phone = @Phone WHERE Id = @FarmerId";
                    command.Parameters.AddWithValue("@FarmerId", farmerId);
                }
                // If FarmerId is not present, insert a new farmer
                else
                {
                    password = GeneratePassword(); // Generate password for new farmer
                    string hashedPassword = HashPassword(password); // Hash the password

                    query = "INSERT INTO Users (FirstName, Surname, Email, Password, StreetNumber, Street, Suburb, " +
                        "City, Province, Country, Phone, Employee) " +
                            "VALUES (@FirstName, @Surname, @Email, @Password, @StreetNumber, @Street, @Suburb, @City, " +
                            "@Province, @Country, @Phone, 0)";
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                }

                command.CommandText = query;
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@StreetNumber", streetNumber);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@Suburb", suburb);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Province", province);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@Phone", phone);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); // Execute the SQL command and get the number of rows affected
                connection.Close();

                if (rowsAffected > 0)
                {
                    // Clear the form
                    ClearForm(); // Clear the form fields


                    string message;

                    if (string.IsNullOrEmpty(farmerId))
                    {
                        message = "Farmer Details Have Been Successfully Saved!\n\nIn The Release Version Of The Website, " +
                            "An Email Will Be Sent To The Farmer With Their Information.\nHere Is This Farmer's Temporary " +
                            "Password: " + password;
                    }
                    else
                    {
                        message = "Farmer Details Have Been Successfully Updated";
                    }

                    // Register the script to show the popup
                    string script = $@"<script>showPopup('{message}');</script>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowPopupScript", script, false);

                }   
            }
        }

        // Clear all form fields
        private void ClearForm()
        {
            txtFirstName.Text = "";
            txtSurname.Text = "";
            txtStreetNumber.Text = "";
            txtStreet.Text = "";
            txtSuburb.Text = "";
            txtCity.Text = "";
            txtProvince.Text = "";
            txtCountry.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        // Generate a random password for new farmers
        private string GeneratePassword()
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Define the characters allowed in the password
            StringBuilder passwordBuilder = new StringBuilder(); // StringBuilder to construct the password
            Random random = new Random(); // Random number generator

            // Generate a password of length 12
            while (passwordBuilder.Length < 12)
            {
                passwordBuilder.Append(validChars[random.Next(validChars.Length)]); // Append a random character from validChars
            }

            return passwordBuilder.ToString(); // Return the generated password
        }

        // Hash the password using SHA256 algorithm
        private string HashPassword(string password)
        {
            // Create an instance of SHA256 hashing algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); // Compute the hash of the password bytes
                StringBuilder builder = new StringBuilder(); // StringBuilder to store the hashed password

                // Convert each byte of the hash to hexadecimal string representation
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Append the hexadecimal representation of each byte
                }

                return builder.ToString(); // Return the hashed password
            }
        }

    }
}
