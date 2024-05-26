using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class CreateItem : System.Web.UI.Page
    {
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
                    Response.Redirect("~/Home.aspx");
                }

                if (!IsPostBack)
                {
                    // Populate the categories dropdown list
                    PopulateCategories();
                }
            }
        }

        // Event handler for creating a new item
        protected void btnCreateItem_Click(object sender, EventArgs e)
        {
            // Get values from the form
            string itemName = inp_itemName.Value;
            string category = this.sel_category.Value;

            if (category == "new")
            {
                // If the user selected to create a new category, use the value from the newCategory input
                category = this.inp_newCategory.Value;
                category = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(category.ToLower());

                // Check if the category already exists
                int existingCategoryId = GetCategoryIdByName(category);

                if (existingCategoryId > 0)
                {
                    // Use the existing category ID
                    CreateNewItem(itemName, existingCategoryId, DateTime.Parse(this.inp_dateOfProduction.Value), this.inp_description.Value, (int)Session["UserID"]);
                }
                else
                {
                    // Create the new category and get its ID
                    int newCategoryId = CreateNewCategory(category);
                    CreateNewItem(itemName, newCategoryId, DateTime.Parse(this.inp_dateOfProduction.Value), this.inp_description.Value, (int)Session["UserID"]);
                }
            }
            else
            {
                // Use the selected category ID
                int categoryId = int.Parse(category);
                CreateNewItem(itemName, categoryId, DateTime.Parse(this.inp_dateOfProduction.Value), this.inp_description.Value, (int)Session["UserID"]);
            }

            // Redirect to a page confirming the item creation
            Response.Redirect("~/GreenEnergyMarketplace.aspx");
        }

        // Event handler for adding a new category
        protected void btnNewCat_Click(object sender, EventArgs e)
        {
            // Show the input field for new category
            inp_newCategory.Visible = true;
        }

        // Populate categories dropdown list
        private void PopulateCategories()
        {
            // Retrieve connection string from configuration
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // SQL query to retrieve categories from the database
            string query = "SELECT Id, Category FROM Categories ORDER BY Category";

            // Establish connection and execute the query
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear existing items in the dropdown list
                    sel_category.Items.Clear();

                    // Add categories retrieved from the database to the dropdown list
                    while (reader.Read())
                    {
                        sel_category.Items.Add(new ListItem(reader["Category"].ToString(), reader["Id"].ToString()));
                    }

                    // Add an option to create a new category
                    sel_category.Items.Add(new ListItem("New Category", "new"));
                }
            }
        }

        // Retrieve category ID by name
        private int GetCategoryIdByName(string category)
        {
            // Retrieve connection string from configuration
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // SQL query to retrieve category ID by name
            string query = "SELECT Id FROM Categories WHERE Category = @Category";

            // Establish connection and execute the query
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Category", category);
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    // If the category exists, return its ID
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            // Return -1 if category not found
            return -1;
        }

        // Create a new category
        private int CreateNewCategory(string category)
        {
            // Retrieve connection string from configuration
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // SQL query to insert a new category into the database
            string query = "INSERT INTO Categories (Category) OUTPUT INSERTED.Id VALUES (@Category)";

            // Establish connection and execute the query
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Category", category);
                    conn.Open();

                    // Execute the query and return the newly generated category ID
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // Create a new item
        private void CreateNewItem(string itemName, int categoryId, DateTime dateOfProduction, string description, int userId)
        {
            // Retrieve connection string from configuration
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // SQL query to insert a new item into the database
            string query = "INSERT INTO Items (UserId, ProductName, CategoryId, PDate, Description) VALUES (@UserId, @ProductName, @CategoryId, @PDate, @Description)";

            // Establish connection and execute the query
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ProductName", itemName);
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@PDate", dateOfProduction);
                    cmd.Parameters.AddWithValue("@Description", description);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
