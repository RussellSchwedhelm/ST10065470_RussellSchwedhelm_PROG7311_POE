using ST10065470_RussellSchwedhelm_PROG7311_POE.Classes;
using System;
using System.Globalization;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class CreateItem : System.Web.UI.Page
    {
        DBController dbController = new DBController();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged on
            if (!(this.Master is SiteMaster master) || !master.LoggedOn)
            {
                // Redirect the user to the login page if not logged in
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                // Check if the user is an employee
                if (master.Employee)
                {
                    // Redirect employees to the home page
                    Response.Redirect("~/Home.aspx");
                }

                // Populate categories dropdown list if the page is not a postback
                if (!IsPostBack)
                {
                    PopulateCategories();
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Event handler for creating a new item
        protected void btnCreateItem_Click(object sender, EventArgs e)
        {
            // Get values from the form
            string itemName = inp_itemName.Value;
            string category = this.sel_category.Value;

            // Check if the category list contains the name of the selected category
            bool categoryExists = CategoryExists(category);

            if (category != "")
            {
                // Check if the category already exists
                if (categoryExists)
                {
                    // Use the existing category ID
                    dbController.CreateNewItem(itemName, dbController.GetCategoryId(category), DateTime.Parse(this.inp_dateOfProduction.Value), this.inp_description.Value, (int)Session["UserID"]);
                }
                else
                {
                    // Create the new category and get its ID
                    int newCategoryId = dbController.CreateNewCategory(category);
                    dbController.CreateNewItem(itemName, newCategoryId, DateTime.Parse(this.inp_dateOfProduction.Value), this.inp_description.Value, (int)Session["UserID"]);
                }

                // Redirect to a page confirming the item creation
                Response.Redirect("~/GreenEnergyMarketplace.aspx");
            }
            else if (inp_newCategory.Value != "")
            {
                // If the user selected to create a new category, use the value from the newCategory input
                category = this.inp_newCategory.Value;
                category = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(category.ToLower());

                // Check if the category already exists
                if (categoryExists)
                {
                    // Use the existing category ID
                    dbController.CreateNewItem(itemName, dbController.GetCategoryId(category), DateTime.Parse(this.inp_dateOfProduction.Value), this.inp_description.Value, (int)Session["UserID"]);
                }
                else
                {
                    // Create the new category and get its ID
                    int newCategoryId = dbController.CreateNewCategory(category);
                    dbController.CreateNewItem(itemName, newCategoryId, DateTime.Parse(this.inp_dateOfProduction.Value), this.inp_description.Value, (int)Session["UserID"]);
                }

                // Redirect to a page confirming the item creation
                Response.Redirect("~/GreenEnergyMarketplace.aspx");
            }
            else
            {
                // Display popup error on the webpage
                string errorMessage = "Please select a category or enter a new category.";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorPopup", $"alert('{errorMessage}');", true);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------//
        // Check if the category exists in the dropdown list
        private bool CategoryExists(string category)
        {
            foreach (ListItem item in sel_category.Items)
            {
                if (item.Text == category)
                {
                    return true;
                }
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Event handler for adding a new category
        protected void btnNewCat_Click(object sender, EventArgs e)
        {
            if (inp_newCategory.Visible == true)
            {
                // hide the input field for new category
                inp_newCategory.Visible = false;
                sel_category.SelectedIndex = 0;
                sel_category.Disabled = false;
            }
            else
            {
                // Show the input field for new category
                inp_newCategory.Visible = true;
                sel_category.SelectedIndex = -1;
                sel_category.Value = "";
                sel_category.Disabled = true;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Populate categories dropdown list
        private void PopulateCategories()
        {
            sel_category.DataSource = dbController.GetAllCategories();
            sel_category.DataBind();
        }
    }
}
//-----------------------------------------------End Of Page-----------------------------------------------------------------------//