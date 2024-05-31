using System;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class NewChat : System.Web.UI.Page
    {
        //----------------------------------------------------------------------------------------------------------------------//
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged on
            if (!(this.Master is SiteMaster master) || !master.LoggedOn)
            {
                // Redirect the user to the login page
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                // User is logged on, continue loading the page
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        //Method to redirect the user to the NewChatCreated page
        protected void btnCreateChat_Click(object sender, EventArgs e)
        {
            // Handle button click event to create a new chat
            string chatTitle = txtChatTitle.Text;
            string chatDescription = txtChatDescription.Text;

            // Process the data, for example, save to database or perform any other actions

            // Redirect to another page after creating the chat
            Response.Redirect("NewChatCreated.aspx");
        }
        //----------------------------------------------------------------------------------------------------------------------//
    }
}
//-----------------------------------------------End Of Page-----------------------------------------------------------------------//