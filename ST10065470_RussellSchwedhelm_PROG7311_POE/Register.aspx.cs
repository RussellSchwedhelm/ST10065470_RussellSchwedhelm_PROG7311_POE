using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            // Logic to handle user registration
            // This method will be called when the registration form is submitted
            // You can access form fields using Request.Form collection or using controls directly
            string fullName = Request.Form["fullName"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string confirmPassword = Request.Form["confirmPassword"];

            // Perform validation, database operations, etc.
            // Redirect user to another page after successful registration
            Response.Redirect("Login.aspx");
        }
    }
}