using ST10065470_RussellSchwedhelm_PROG7311_POE.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class GreenEnergyMarketplace : System.Web.UI.Page
    {
        DBController dBController = new DBController(); // Instance of the database controller
        //----------------------------------------------------------------------------------------------------------------------//
        // Method called when the page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (!(this.Master is SiteMaster master) || !master.LoggedOn)
            {
                // Redirect to the login page if not logged in
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                // Actions to be taken if the user is logged in
                if (!IsPostBack)
                {
                    // Actions to be taken if the page is not a postback (i.e., initial load)
                    if (master.Employee)
                    {
                        // Hide MyStore if the user is an employee
                        MyStore.Visible = false;
                    }
                    else
                    {
                        // Load user items for non-employees
                        LoadUserItems();
                    }

                    // Populate categories drop-down list
                    PopulateCategories();

                    // Load suppliers list
                    LoadSuppliers();

                    // Load all items
                    LoadAllItems();
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method called when the reset button is clicked
        protected void btnReset_Click(object sender, EventArgs e)
        {
            // Clear search text box
            txtSearch.Text = string.Empty;

            // Reset dp_fromDate
            dp_fromDate.Value = "";

            // Reset dp_toDate
            dp_toDate.Value = "";

            // Reload suppliers list
            LoadSuppliers();

            // Reload all items
            LoadAllItems();

            // Reset category drop-down list selection
            sel_category.SelectedIndex = 0;
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method called when the search button is clicked
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Get search term from the text box
            string searchTerm = txtSearch.Text.Trim();

            // Get the selected dates from the date pickers
            string fromDate = dp_fromDate.Value;
            string toDate = dp_toDate.Value;

            // Get the selected category
            string category = sel_category.Value;

            // Check if any search criteria are entered
            if (!string.IsNullOrEmpty(searchTerm) || !string.IsNullOrEmpty(fromDate) || !string.IsNullOrEmpty(toDate) || !string.IsNullOrEmpty(category))
            {
                // Retrieve suppliers and items data from the database
                DataTable dt_suppliers = dBController.GetAllSuppliers(Convert.ToInt32(Session["UserID"]), false);
                DataTable dt_items = dBController.GetAllItems(Convert.ToInt32(Session["UserID"]), false);

                // Filter items based on search criteria
                dt_suppliers = dBController.FilterItems(dt_suppliers, "supplier", searchTerm, fromDate, toDate, category);
                dt_items = dBController.FilterItems(dt_items, "items", searchTerm, fromDate, toDate, category);

                // Check if no items are found
                if (dt_suppliers.Rows.Count == 0 && dt_items.Rows.Count == 0)
                {
                    // Create empty tables with appropriate columns
                    dt_items = new DataTable();
                    dt_suppliers = new DataTable();

                    dt_items.Columns.Add("ProductName", typeof(string));
                    dt_items.Columns.Add("Category", typeof(string));
                    dt_items.Columns.Add("PDate", typeof(DateTime));
                    dt_items.Rows.Add("No Items", DBNull.Value, DBNull.Value);

                    dt_suppliers.Columns.Add("UserId", typeof(int));
                    dt_suppliers.Columns.Add("FirstName", typeof(string));
                    dt_suppliers.Columns.Add("Surname", typeof(string));
                    dt_suppliers.Rows.Add(0, "No", "Suppliers");
                }
                else if (dt_items != null)
                {
                    // Merge suppliers data for filtered items
                    foreach (DataRow row in dt_items.Rows)
                    {
                        dt_suppliers.Merge(dBController.GetAllSuppliers(Convert.ToInt32(dBController.GetIdFromItem(row["ProductName"].ToString())), true));
                    }
                }
                else
                {
                    // Create an empty table with appropriate columns if no items are found
                    dt_items = new DataTable();

                    dt_items.Columns.Add("ProductName", typeof(string));
                    dt_items.Columns.Add("Category", typeof(string));
                    dt_items.Columns.Add("PDate", typeof(DateTime));
                    dt_items.Rows.Add("No Items", DBNull.Value, DBNull.Value);
                }

                // Bind data to controls
                supplierList.DataSource = dt_suppliers;
                supplierList.DataBind();

                allItemList.DataSource = dt_items;
                allItemList.DataBind();
            }
            else
            {
                // Reload suppliers list
                LoadSuppliers();

                // Reload all items
                LoadAllItems();

                // Reset category drop-down list selection
                sel_category.SelectedIndex = 0;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method to load suppliers data
        private void LoadSuppliers()
        {
            // Get the logged-in user ID
            int loggedInUserId = Convert.ToInt32(Session["UserID"]);

            // Retrieve suppliers data from the database
            DataTable dt = dBController.GetAllSuppliers(loggedInUserId, false);

            // Check if suppliers data is null
            if (dt == null)
            {
                // Show error message if data retrieval fails
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occurred');", true);
            }
            else
            {
                // Bind suppliers data to the repeater control
                supplierList.DataSource = dt;
                supplierList.DataBind();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method to load items for the logged-in user
        private void LoadUserItems()
        {
            // Get the logged-in user ID
            int loggedInUserId = Convert.ToInt32(Session["UserID"]);

            // Retrieve items data for the logged-in user from the database
            DataTable dt = dBController.GetAllItems(loggedInUserId, true);

            // Check if items data is null
            if (dt == null)
            {
                // Show error message if data retrieval fails
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occurred');", true);
            }
            else
            {
                // Bind items data to the repeater control
                itemList.DataSource = dt;
                itemList.DataBind();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method to load all items
        private void LoadAllItems()
        {
            // Get the logged-in user ID
            int loggedInUserId = Convert.ToInt32(Session["UserID"]);

            // Retrieve all items data from the database
            DataTable dt = dBController.GetAllItems(loggedInUserId, false);

            // Check if items data is null
            if (dt == null)
            {
                // Show error message if data retrieval fails
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occurred');", true);
            }
            else
            {
                // Bind items data to the repeater control
                allItemList.DataSource = dt;
                allItemList.DataBind();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method called when an item command is triggered in the supplier list repeater control
        protected void SupplierList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // Get the supplier ID from the command argument
            int supplierId = Convert.ToInt32(e.CommandArgument);

            // Retrieve items data associated with the selected supplier from the database
            DataTable dt = dBController.GetAllItems(supplierId, true);

            // Bind items data to the allItemList repeater control
            allItemList.DataSource = dt;
            allItemList.DataBind();
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Method to populate categories drop-down list
        private void PopulateCategories()
        {
            // Retrieve categories from the database
            List<ListItem> categories = dBController.GetAllCategories();

            // Add a blank option at the beginning of the list
            categories.Insert(0, new ListItem("", ""));

            // Bind categories data to the selector drop-down box
            sel_category.DataSource = categories;
            sel_category.DataBind();
        }
    }
}
//-----------------------------------------------End Of Page-----------------------------------------------------------------------//