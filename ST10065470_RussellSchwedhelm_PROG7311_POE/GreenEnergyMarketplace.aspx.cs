using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class GreenEnergyMarketplace : System.Web.UI.Page
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
                // Proceed if the user is logged in
                if (!IsPostBack)
                {
                    // Check if the user is an employee
                    if (master.Employee)
                    {
                        // Hide MyStore section if the user is an employee
                        MyStore.Visible = false;
                    }
                    else
                    {
                        // Load user items for non-employee users
                        LoadUserItems();
                    }

                    // Load suppliers for both employee and non-employee users
                    LoadSuppliers();
                }
            }
        }

        // Event handler for search button click
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Retrieve search term from the text box
            string searchTerm = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Search suppliers based on the entered search term
                SearchSuppliers(searchTerm);
            }
            else
            {
                // Reload all suppliers if search term is empty
                LoadSuppliers();
            }
        }

        // Load suppliers excluding the logged-in user
        private void LoadSuppliers()
        {
            // Retrieve the logged-in user's ID from the session
            int loggedInUserId = Convert.ToInt32(Session["UserID"]);

            // Retrieve connection string from configuration
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // SQL query to fetch distinct suppliers excluding the logged-in user
            string query = @"
                SELECT DISTINCT u.FirstName, u.Surname 
                FROM Users u
                JOIN Items i ON u.Id = i.UserId
                WHERE u.Id <> @LoggedInUserId";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LoggedInUserId", loggedInUserId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Bind the retrieved data to the supplier list control
                        supplierList.DataSource = reader;
                        supplierList.DataBind();
                    }
                    else
                    {
                        // Display a default message if no suppliers found
                        supplierList.DataSource = new[] { new { FirstName = "No", Surname = "Items" } };
                        supplierList.DataBind();
                    }
                }
            }
        }

        // Search suppliers based on the entered search term
        private void SearchSuppliers(string searchTerm)
        {
            // Retrieve the logged-in user's ID from the session
            int loggedInUserId = Convert.ToInt32(Session["UserID"]);

            // Retrieve connection string from configuration
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // SQL query to search suppliers based on the entered search term
            string query = @"
                SELECT DISTINCT u.FirstName, u.Surname 
                FROM Users u
                JOIN Items i ON u.Id = i.UserId
                WHERE u.Id <> @LoggedInUserId
                AND (u.FirstName LIKE @SearchTerm
                     OR u.Surname LIKE @SearchTerm
                     OR u.Email LIKE @SearchTerm
                     OR i.ProductName LIKE @SearchTerm)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LoggedInUserId", loggedInUserId);
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Bind the retrieved data to the supplier list control
                        supplierList.DataSource = reader;
                        supplierList.DataBind();
                    }
                    else
                    {
                        // Display a default message if no search results found
                        supplierList.DataSource = new[] { new { FirstName = "No", Surname = "Results" } };
                        supplierList.DataBind();
                    }
                }
            }
        }

        // Load items belonging to the logged-in user
        private void LoadUserItems()
        {
            // Retrieve the logged-in user's ID from the session
            int loggedInUserId = Convert.ToInt32(Session["UserID"]);

            // Retrieve connection string from configuration
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // SQL query to fetch items belonging to the logged-in user
            string query = @"
                SELECT ProductName 
                FROM Items 
                WHERE UserId = @LoggedInUserId";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LoggedInUserId", loggedInUserId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Bind the retrieved data to the item list control
                        itemList.DataSource = reader;
                        itemList.DataBind();
                    }
                    else
                    {
                        // Display a default message if the user has no items
                        itemList.DataSource = new[] { new { ProductName = "No Items" } };
                        itemList.DataBind();
                    }
                }
            }
        }
    }
}
