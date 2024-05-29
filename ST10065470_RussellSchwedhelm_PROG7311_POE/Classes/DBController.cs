using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE.Classes
{
    public class DBController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public object Login(string email, string hashedPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id FROM Users WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", hashedPassword);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool CheckIfEmployee(string email)
        {
            // Connect to the database and check if the user is an employee
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Employee FROM Users WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                object result = command.ExecuteScalar();
                connection.Close();
                if (result != null && result != DBNull.Value)
                {
                    // If Employee column is 1, user is an employee; otherwise, not an employee
                    return Convert.ToInt32(result) == 1;
                }
            }

            // If no employee status is found or if an error occurs, return false
            return false;
        }
        public SqlDataReader GetAllFarmers()
        {
            string query = "SELECT Id, FirstName + ' ' + Surname AS Username FROM Users WHERE Employee = 0";
            SqlConnection connection = new SqlConnection(connectionString); // Connection needs to stay open

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection); // Ensures connection is closed when reader is closed
                return reader; // Return the open reader
            }
            catch (Exception ex)
            {
                connection.Close();
                return null;
            }
        }

        public string DeleteFarmer(string farmerId)
        {
            string query = "DELETE FROM Users WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", farmerId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public Dictionary<string, string> GetFarmerDetails(string farmerId)
        {
            Dictionary<string, string> farmerDetails = new Dictionary<string, string>();

            // Query to retrieve farmer details
            string selectQuery = "SELECT FirstName, Surname, Email, StreetNumber, Street, Suburb, City, Province, Country, Phone FROM Users WHERE Id = @FarmerId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@FarmerId", farmerId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Check if there are rows returned
                if (reader.Read())
                {
                    farmerDetails["FirstName"] = reader["FirstName"].ToString();
                    farmerDetails["Surname"] = reader["Surname"].ToString();
                    farmerDetails["Email"] = reader["Email"].ToString();
                    farmerDetails["StreetNumber"] = reader["StreetNumber"].ToString();
                    farmerDetails["Street"] = reader["Street"].ToString();
                    farmerDetails["Suburb"] = reader["Suburb"].ToString();
                    farmerDetails["City"] = reader["City"].ToString();
                    farmerDetails["Province"] = reader["Province"].ToString();
                    farmerDetails["Country"] = reader["Country"].ToString();
                    farmerDetails["Phone"] = reader["Phone"].ToString();
                }

                reader.Close(); // Close the reader after reading data
            }

            return farmerDetails;
        }

        public bool CreateUser(string firstName, string surname, string email, string hashedPassword, string streetNumber,
            string street, string suburb, string city, string province, string country, string phone, string employeeStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query;
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                connection.Open();

                query = "INSERT INTO Users (FirstName, Surname, Email, Password, StreetNumber, Street, Suburb, " +
                        "City, Province, Country, Phone, Employee) " +
                        "VALUES (@FirstName, @Surname, @Email, @Password, @StreetNumber, @Street, @Suburb, @City, " +
                        "@Province, @Country, @Phone, @Employee)";
                command.CommandText = query;

                // Clear and add parameters
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", hashedPassword);
                command.Parameters.AddWithValue("@StreetNumber", streetNumber);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@Suburb", suburb);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Province", province);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Employee", employeeStatus);

                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateUser(string farmerId, string firstName, string surname, string email, string streetNumber,
        string street, string suburb, string city, string province, string country, string phone, string employeeStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query;
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                connection.Open();

                query = "UPDATE Users SET FirstName = @FirstName, Surname = @Surname, Email = @Email, " +
                        "StreetNumber = @StreetNumber, Street = @Street, Suburb = @Suburb, City = @City, Province = @Province, Country = " +
                        "@Country, Phone = @Phone, Employee = @Employee WHERE Id = @FarmerId";
                command.CommandText = query;

                // Clear and add parameters
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@StreetNumber", streetNumber);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@Suburb", suburb);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Province", province);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Employee", employeeStatus);
                command.Parameters.AddWithValue("@FarmerId", farmerId);

                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CheckForEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query;
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                connection.Open();

                // Check if email exists
                query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                command.CommandText = query;
                command.Parameters.AddWithValue("@Email", email);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CheckEmployeeCodes(string code)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM EmployeeCodes WHERE Codes = @EmployeeCode";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeCode", code);

                connection.Open();

                int count = (int)command.ExecuteScalar();
                connection.Close();
                if (count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool UpdatePassword(string email, string hashedPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Password = @Password WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Password", hashedPassword);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                int changes = command.ExecuteNonQuery();
                connection.Close();

                if (changes > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ComparePasswords(string email, string newHashedPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", newHashedPassword);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }

        public DataTable GetAllItems(int UserId, bool userOnly)
        {
            DataTable dt = new DataTable();

            try
            {
                string query;

                if (userOnly)
                {
                    query = @"
                SELECT i.ProductName, c.Category, CAST(i.PDate AS DATE) AS PDate
                FROM Items i
                INNER JOIN Categories c ON i.CategoryId = c.Id
                WHERE i.UserId = @LoggedInUserId";
                }
                else
                {
                    query = @"
                SELECT i.ProductName, c.Category, CAST(i.PDate AS DATE) AS PDate
                FROM Items i
                INNER JOIN Categories c ON i.CategoryId = c.Id
                WHERE i.UserId <> @LoggedInUserId";
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LoggedInUserId", UserId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                // Check if the DataTable is empty and add a row indicating no items found
                if (dt.Rows.Count == 0)
                {
                    dt.Columns.Add("ProductName", typeof(string));
                    dt.Columns.Add("Category", typeof(string));
                    dt.Columns.Add("PDate", typeof(DateTime));
                    dt.Rows.Add("No Items", DBNull.Value, DBNull.Value);
                }
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable GetAllSuppliers(int UserId, bool userOnly)
        {
            DataTable dt = new DataTable();
            if (!userOnly)
            {
                try
                {
                    string query = @"
                    SELECT DISTINCT u.Id as UserId, u.FirstName, u.Surname 
                    FROM Users u
                    JOIN Items i ON u.Id = i.UserId
                    WHERE u.Id <> @LoggedInUserId 
                    AND Employee != 1";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@LoggedInUserId", UserId);
                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            dt.Load(reader);
                        }
                    }

                    // Check if the DataTable is empty and add a row indicating no suppliers found
                    if (dt.Rows.Count == 0)
                    {
                        dt.Columns.Add("UserId", typeof(int));
                        dt.Columns.Add("FirstName", typeof(string));
                        dt.Columns.Add("Surname", typeof(string));
                        dt.Rows.Add(0, "No", "Suppliers");
                    }
                }
                catch (Exception)
                {
                    dt = null;
                }
                return dt;
            }
            else
            {
                try
                {
                    string query = @"
                    SELECT DISTINCT u.Id as UserId, u.FirstName, u.Surname 
                    FROM Users u
                    JOIN Items i ON u.Id = i.UserId
                    WHERE u.Id = @LoggedInUserId 
                    AND Employee != 1";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@LoggedInUserId", UserId);
                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception)
                {
                    dt = null;
                }
                return dt;
            }

        }

        public List<ListItem> GetAllCategories()
        {
            // SQL query to retrieve categories from the database
            string query = "SELECT Id, Category FROM Categories ORDER BY Category";

            // Initialize a list to store ListItem objects
            List<ListItem> categoryList = new List<ListItem>();

            // Establish connection and execute the query
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through the result set and add each category as a ListItem object to the list
                    while (reader.Read())
                    {
                        ListItem listItem = new ListItem(reader["Category"].ToString(), reader["Id"].ToString());
                        categoryList.Add(listItem);
                    }
                }
            }

            // Return the list of ListItem objects containing categories
            return categoryList;
        }

        public string GetCategoryID(string category)
        {
            string id = null;

            // SQL query to retrieve categories from the database
            string query = "SELECT Id FROM Categories WHERE Category = @Category;";

            // Establish connection and execute the query
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameter for category to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Category", category);

                    conn.Open();
                    // Execute the query and retrieve the category ID
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        id = result.ToString();
                    }
                }
            }

            return id;
        }

        public string GetIdFromItem(string itemName)
        {
            string id = null;

            // SQL query to retrieve categories from the database
            string query = "SELECT UserId FROM Items WHERE ProductName = @ItemName;";

            // Establish connection and execute the query
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameter for category to prevent SQL injection
                    cmd.Parameters.AddWithValue("@ItemName", itemName);

                    conn.Open();
                    // Execute the query and retrieve the category ID
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        id = result.ToString();
                    }
                }
            }

            return id;
        }

        public DataTable FilterItems(DataTable dt, string dt_type, string searchTerm, string startDate, string endDate, string category)
        {
            if (dt_type == "supplier")
            {
                // Create a clone of the original DataTable structure
                DataTable filteredDt = dt.Clone();

                // Check if the DataTable is null or empty
                if (dt == null || dt.Rows.Count == 0)
                {
                    return filteredDt; // Return the empty DataTable structure
                }

                // Create a DataView from the DataTable to apply filters
                DataView dv = new DataView(dt);

                // Build the filter string
                List<string> filters = new List<string>();

                // Search term filter for FirstName, or Surname
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    string escapedSearchTerm = searchTerm.Replace("'", "''");
                    filters.Add($"(FirstName LIKE '%{escapedSearchTerm}%' OR Surname LIKE '%{escapedSearchTerm}%')");
                }

                // Combine all filters with AND operator
                string filterString = string.Join(" AND ", filters);

                // Apply the filter to the DataView
                dv.RowFilter = filterString;

                // Load the filtered rows into the cloned DataTable
                filteredDt = dv.ToTable();

                if (filteredDt.Rows.Count == 0)
                {
                    filteredDt = null;
                }

                return filteredDt;
            }
            else
            {
                // Create a clone of the original DataTable structure
                DataTable filteredDt = dt.Clone();

                // Check if the DataTable is null or empty
                if (dt == null || dt.Rows.Count == 0)
                {
                    return filteredDt; // Return the empty DataTable structure
                }

                // Create a DataView from the DataTable to apply filters
                DataView dv = new DataView(dt);

                // Build the filter string
                List<string> filters = new List<string>();

                // Date range filter
                if (!string.IsNullOrEmpty(startDate) && DateTime.TryParse(startDate, out DateTime start))
                {
                    filters.Add($"PDate >= #{start:yyyy/MM/dd}#");
                }

                if (!string.IsNullOrEmpty(endDate) && DateTime.TryParse(endDate, out DateTime end))
                {
                    filters.Add($"PDate <= #{end:yyyy/MM/dd}#");
                }

                // Category filter
                if (!string.IsNullOrEmpty(category))
                {
                    filters.Add($"Category = '{category}'");
                }

                // Search term filter for product name
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    string escapedSearchTerm = searchTerm.Replace("'", "''");
                    filters.Add($"(ProductName LIKE '%{escapedSearchTerm}%')");
                }

                // Combine all filters with AND operator
                string filterString = string.Join(" AND ", filters);

                // Apply the filter to the DataView
                dv.RowFilter = filterString;

                // Load the filtered rows into the cloned DataTable
                filteredDt = dv.ToTable();

                if (filteredDt.Rows.Count == 0)
                {
                    filteredDt = null;
                }

                return filteredDt;
            }
        }
    }
}