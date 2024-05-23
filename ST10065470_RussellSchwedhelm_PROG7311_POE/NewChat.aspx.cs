using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class NewChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCreateChat_Click(object sender, EventArgs e)
        {
            // Handle button click event to create a new chat
            string chatTitle = txtChatTitle.Text;
            string chatDescription = txtChatDescription.Text;

            // Process the data, for example, save to database or perform any other actions

            // Redirect to another page after creating the chat
            Response.Redirect("NewChatCreated.aspx");
        }
    }
}