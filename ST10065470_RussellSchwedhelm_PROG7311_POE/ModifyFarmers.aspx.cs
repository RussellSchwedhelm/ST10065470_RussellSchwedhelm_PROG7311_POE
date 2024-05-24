using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class ModifyFarmers : System.Web.UI.Page
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
                // Add your page load logic here
            }
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            // Redirect to a create new farmer page
            Response.Redirect("CreateNewFarmer.aspx");
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            // Get the button that triggered the event
            var button = (Button)sender;

            // Determine the farmer based on the button ID
            string farmerName = string.Empty;

            switch (button.ID)
            {
                case "btnModifyJohn":
                    farmerName = "John Doe";
                    break;
                case "btnModifyJane":
                    farmerName = "Jane Smith";
                    break;
                case "btnModifyMark":
                    farmerName = "Mark Johnson";
                    break;
                    // Add more cases as needed
            }

            // Redirect to a modify page with the farmer name as a query parameter
            Response.Redirect("CreateNewFarmer.aspx");
        }
        protected void btnContinueRemove_Click(object sender, EventArgs e)
        {

        }
        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
        }

        // This is a placeholder for the actual delete logic
        // private void DeleteFarmer(string farmerName)
        // {
        //     // Implement the actual logic to delete the farmer from the data source
        // }
    }
}