using ST10065470_RussellSchwedhelm_PROG7311_POE.Classes;
using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class ModifyFarmers : System.Web.UI.Page
    {
        DBController dbController; // Declaring an instance of DBController class
        //----------------------------------------------------------------------------------------------------------------------//
        // Event handler for loading the page
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking if the current page's Master page is of type SiteMaster and the user is logged on
            if (!(this.Master is SiteMaster master) || !master.LoggedOn)
            {
                // Redirecting to login page if not logged on
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                // Redirecting to home page if not an employee
                if (!master.Employee)
                {
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    // Creating an instance of DBController class
                    dbController = new DBController();
                    // Calling method to load farmers
                    LoadFarmers();
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method for loading farmers from database
        private void LoadFarmers()
        {
            // Getting SqlDataReader object containing all farmers from database
            SqlDataReader reader = dbController.GetAllFarmers();

            if (reader != null) // Checking if reader is not null
            {
                try
                {
                    // Setting the data source for itemList control
                    itemList.DataSource = reader;
                    // Binding the data to itemList control
                    itemList.DataBind();
                }
                finally
                {
                    // Closing the SqlDataReader
                    reader.Close();
                }
            }
            else
            {
                // Handling exception if reader is null
                Response.Write("An Error Occurred!");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Event handler for creating a new farmer
        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            // Redirecting to CreateFarmer.aspx page
            Response.Redirect("CreateFarmer.aspx");
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Event handler for modifying a farmer
        protected void btnModify_Click(object sender, EventArgs e)
        {
            // Casting the sender object to Button
            Button button = (Button)sender;
            // Getting the CommandArgument which holds the farmer's ID
            string farmerId = button.CommandArgument;
            // Redirecting to CreateFarmer.aspx page with farmerId in query string
            Response.Redirect($"CreateFarmer.aspx?FarmerId={farmerId}");
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Event handler for confirming farmer deletion
        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            // Getting the farmer ID from hidden field
            string farmerId = hiddenFarmerId.Value;
            // Deleting the farmer from database
            DeleteFarmer(farmerId);
            // Reloading the farmers list
            LoadFarmers();
            // Showing the remove popup
            showRemovePopup();
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method for deleting a farmer
        private void DeleteFarmer(string farmerId)
        {
            // Deleting the farmer and getting the response
            string response = dbController.DeleteFarmer(farmerId);
            if (response != null) // Checking if response is not null
            {
                // Displaying error message if response is not null
                Response.Write("An error occurred: " + response);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Event handler for continuing farmer removal
        protected void btnContinueRemove_Click(object sender, EventArgs e)
        {
            // Hiding the remove popup
            hideRemovePopup();
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method for showing the remove popup
        private void showRemovePopup()
        {
            // Registering script to show the remove popup
            ScriptManager.RegisterStartupScript(this, GetType(), "showRemovePopup", "showRemovePopup();", true);
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method for hiding the remove popup
        private void hideRemovePopup()
        {
            // Registering script to hide the remove popup
            ScriptManager.RegisterStartupScript(this, GetType(), "hideRemovePopup", "hideRemovePopup();", true);
        }
        //----------------------------------------------------------------------------------------------------------------------//
    }
}
//-----------------------------------------------End Of Page-----------------------------------------------------------------------//