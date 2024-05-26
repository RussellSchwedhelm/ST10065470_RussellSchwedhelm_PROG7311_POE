using System;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class Home : System.Web.UI.Page
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
                // Check if the user is an employee
                if (master.Employee)
                {
                    
                }
            }
        }

        protected void btnLearnMore_Click(object sender, EventArgs e)
        {
            // Handle button click event
        }
    }
}
