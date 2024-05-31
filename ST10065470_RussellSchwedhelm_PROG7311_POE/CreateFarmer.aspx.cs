using ST10065470_RussellSchwedhelm_PROG7311_POE.Classes;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class CreateFarmer : System.Web.UI.Page
    {
        DBController dbController; // Instance of the database controller
        //----------------------------------------------------------------------------------------------------------------------//
        // Event handler for the page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (!(this.Master is SiteMaster master) || !master.LoggedOn)
            {
                // Redirect the user to the login page if not logged in
                Response.Redirect("~/Login.aspx");
            }

            // Get the FarmerId from the query string
            string farmerId = Request.QueryString["FarmerId"];
            dbController = new DBController(); // Initialize database controller

            // If the page is not postback and FarmerId is not empty, load farmer details
            if (!IsPostBack && !string.IsNullOrEmpty(farmerId))
            {
                LoadFarmerDetails(farmerId);
            }
            else
            {
                // Call JavaScript function to set title
                string script = $@"<script>setTitle();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SetTitleScript", script);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method to load farmer details into the form
        private void LoadFarmerDetails(string farmerId)
        {
            // Retrieve farmer details from the database
            Dictionary<string, string> farmerDetails = dbController.GetFarmerDetails(farmerId);

            // If farmer details are found, populate the form fields
            if (farmerDetails != null)
            {
                txtFirstName.Text = farmerDetails["FirstName"];
                txtSurname.Text = farmerDetails["Surname"];
                txtEmail.Text = farmerDetails["Email"];
                txtStreetNumber.Text = farmerDetails["StreetNumber"];
                txtStreet.Text = farmerDetails["Street"];
                txtSuburb.Text = farmerDetails["Suburb"];
                txtCity.Text = farmerDetails["City"];
                txtProvince.Text = farmerDetails["Province"];
                txtCountry.Text = farmerDetails["Country"];
                txtPhone.Text = farmerDetails["Phone"];
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Event handler for continue button click
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            // Redirect to another page or take some action
            Response.Redirect("~/ModifyFarmers");
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Event handler for submit button click
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Retrieve form data
            string firstName = txtFirstName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string streetNumber = txtStreetNumber.Text.Trim();
            string street = txtStreet.Text.Trim();
            string suburb = txtSuburb.Text.Trim();
            string city = txtCity.Text.Trim();
            string province = txtProvince.Text.Trim();
            string country = txtCountry.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password;
            string farmerId = Request.QueryString["FarmerId"];
            string message;

            // Validate form data
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(streetNumber) || string.IsNullOrEmpty(street) ||
                string.IsNullOrEmpty(suburb) || string.IsNullOrEmpty(city) ||
                string.IsNullOrEmpty(province) || string.IsNullOrEmpty(country) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                // Display alert if any required field is empty
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('All Fields Are Required');", true);
                return;
            }

            // If FarmerId exists, update existing farmer
            if (!string.IsNullOrEmpty(farmerId))
            {
                if (dbController.UpdateUser(farmerId, firstName, surname, email, streetNumber, street,
                        suburb, city, province, country, phone, "0"))
                {
                    message = "Farmer Details Have Been Successfully Updated";
                }
                else
                {
                    message = "An Error Occurred And The Farmer Was Not Updated!";
                }
            }
            else
            {
                // If email does not exist, create new farmer
                if (!dbController.CheckForEmail(email))
                {
                    password = GeneratePassword();
                    string hashedPassword = HashPassword(password);

                    if (dbController.CreateUser(firstName, surname, email, hashedPassword, streetNumber, street,
                        suburb, city, province, country, phone, "0"))
                    {
                        message = "Farmer Details Have Been Successfully Saved! In The Release Version Of The Website, " +
                                  "An Email Will Be Sent To The Farmer With Their Information. Here Is The Temporary " +
                                  "Password: " + password;
                    }
                    else
                    {
                        message = "An Error Occurred And The Farmer Was Not Created!";
                    }
                }
                else
                {
                    message = "This Email Is Already Associated With An Account!";
                }
            }
            // Call JavaScript function to show message in a popup
            string script = $@"<script>showPopup('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "ShowPopupScript", script);
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method to generate a random password for new farmers
        private string GeneratePassword()
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Define valid characters for password
            StringBuilder passwordBuilder = new StringBuilder(); // StringBuilder to construct the password
            Random random = new Random(); // Random number generator

            // Generate a password of length 12
            while (passwordBuilder.Length < 12)
            {
                passwordBuilder.Append(validChars[random.Next(validChars.Length)]); // Append a random character from validChars
            }

            return passwordBuilder.ToString(); // Return generated password
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method to hash the password using SHA256 algorithm
        private string HashPassword(string password)
        {
            // Create an instance of SHA256 hashing algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); // Compute hash of password bytes
                StringBuilder builder = new StringBuilder(); // StringBuilder to store hashed password

                // Convert each byte of the hash to hexadecimal string representation
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Append hexadecimal representation of each byte
                }

                return builder.ToString(); // Return hashed password
            }
        }
    }
}
//-----------------------------------------------End Of Page-----------------------------------------------------------------------//