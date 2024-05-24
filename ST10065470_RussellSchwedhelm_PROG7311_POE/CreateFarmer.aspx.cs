using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class CreateFarmer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Retrieve the form data
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

            // Validate the form data
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(streetNumber) || string.IsNullOrEmpty(street) ||
                string.IsNullOrEmpty(suburb) || string.IsNullOrEmpty(city) ||
                string.IsNullOrEmpty(province) || string.IsNullOrEmpty(country) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                lblMessage.Text = "All fields are required.";
                return;
            }

            // Implement the logic to save the farmer's details
            // For example, you can save the data to a database
            // SaveFarmerDetails(firstName, surname, streetNumber, street, suburb, city, province, country, email, phone);

            // Clear the form and display a success message
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
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Farmer details have been successfully saved.";
        }

        // This is a placeholder for the actual save logic
        // private void SaveFarmerDetails(string firstName, string surname, string streetNumber, string street, string suburb, string city, string province, string country, string email, string phone)
        // {
        //     // Implement the actual logic to save the farmer's details to the data source
        // }
    }
}