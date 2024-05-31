using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class Forum : System.Web.UI.Page
    {
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
        protected void NewChat_Click(object sender, EventArgs e)
        {
            // Redirect to the new chat creation page
            Response.Redirect("~/NewChat.aspx");
        }

        protected void ExpandChat_Click(object sender, EventArgs e)
        {
            // Get the chat number from the CommandArgument
            var button = (Button)sender;
            string chatNumber = button.CommandArgument;

            // Redirect to the expanded chat page
            Response.Redirect($"~/ExpandedChat.aspx");
        }
    }
}