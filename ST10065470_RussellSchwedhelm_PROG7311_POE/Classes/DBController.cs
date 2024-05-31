using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE.Classes
{
    public class DBController
    {
        // Retrieves the connection string named "ConnectionString" from the application's configuration file (e.g., web.config or app.config)
        // and stores it in the connectionString variable.
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //----------------------------------------------------------------------------------------------------------------------//
        // Logs in a user by checking the provided email and hashed password against the database,
        // and returns the user Id if found, or null if not found or an error occurs.
        public object Login(string email, string hashedPassword)
        {
            // Create a new SQL connection using the provided connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query to select the user Id where email and password match
                string query = "SELECT Id FROM Users WHERE Email = @Email AND Password = @Password";

                // Create a SQL command object with the query and the connection
                SqlCommand command = new SqlCommand(query, connection);

                // Add the email parameter to the SQL command
                command.Parameters.AddWithValue("@Email", email);

                // Add the hashed password parameter to the SQL command
                command.Parameters.AddWithValue("@Password", hashedPassword);

                try
                {
                    // Open the SQL connection
                    connection.Open();

                    // Execute the command and get the first column of the first row in the result set
                    object result = command.ExecuteScalar();

                    // Close the SQL connection
                    connection.Close();

                    // Return the result (user Id or null if not found)
                    return result;
                }
                catch (Exception ex)
                {
                    // Return null if there is an exception (e.g., connection issue, SQL error)
                    return null;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Checks if a user with the given email is an employee by querying the database, and returns true
        // if the user is an employee, otherwise returns false.
        public bool CheckIfEmployee(string email)
        {
            // Connect to the database and check if the user is an employee
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query to select the Employee status where the email matches
                string query = "SELECT Employee FROM Users WHERE Email = @Email";

                // Create a SQL command object with the query and the connection
                SqlCommand command = new SqlCommand(query, connection);

                // Add the email parameter to the SQL command
                command.Parameters.AddWithValue("@Email", email);

                // Open the SQL connection
                connection.Open();

                // Execute the command and get the first column of the first row in the result set
                object result = command.ExecuteScalar();

                // Close the SQL connection
                connection.Close();

                // Check if the result is not null and not a database null value
                if (result != null && result != DBNull.Value)
                {
                    // If Employee column value is 1, return true (user is an employee); otherwise, return false
                    return Convert.ToInt32(result) == 1;
                }
            }

            // If no employee status is found or if an error occurs, return false
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Retrieves a SqlDataReader containing the Id and concatenated username (FirstName + Surname)
        // of all non-employee users (farmers) from the database.
        public SqlDataReader GetAllFarmers()
        {
            // Define the SQL query to select Id and concatenated username of non-employee users
            string query = "SELECT Id, FirstName + ' ' + Surname AS Username FROM Users WHERE Employee = 0";

            // Create a new SQL connection using the provided connection string
            SqlConnection connection = new SqlConnection(connectionString); // Connection needs to stay open

            try
            {
                // Create a SQL command object with the query and the connection
                SqlCommand command = new SqlCommand(query, connection);

                // Open the SQL connection
                connection.Open();

                // Execute the command and obtain a data reader with a command behavior that closes the connection when the reader is closed
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection); // Ensures connection is closed when reader is closed

                // Return the open data reader
                return reader;
            }
            catch (Exception ex)
            {
                // Close the connection in case of an exception
                connection.Close();

                // Return null if there is an exception (e.g., connection issue, SQL error)
                return null;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Deletes a user from the database based on their Id and returns null if successful, or an error
        // message if an exception occurs.
        public string DeleteFarmer(string farmerId)
        {
            // Define the SQL query to delete items associated with the farmer by their UserId
            string deleteItemsQuery = "DELETE FROM Items WHERE UserId = @UserId";

            // Define the SQL query to delete a user by their Id
            string deleteUserQuery = "DELETE FROM Users WHERE Id = @Id";

            // Create a new SQL connection using the provided connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the SQL connection
                connection.Open();

                // Start a SQL transaction
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Create a SQL command object to delete items associated with the farmer
                    SqlCommand deleteItemsCommand = new SqlCommand(deleteItemsQuery, connection, transaction);
                    deleteItemsCommand.Parameters.AddWithValue("@UserId", farmerId);

                    // Execute the command to delete items associated with the farmer
                    deleteItemsCommand.ExecuteNonQuery();

                    // Create a SQL command object to delete the farmer
                    SqlCommand deleteUserCommand = new SqlCommand(deleteUserQuery, connection, transaction);
                    deleteUserCommand.Parameters.AddWithValue("@Id", farmerId);

                    // Execute the command to delete the farmer
                    deleteUserCommand.ExecuteNonQuery();

                    // Commit the transaction
                    transaction.Commit();

                    // Return null to indicate success
                    return null;
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if an error occurs
                    transaction.Rollback();

                    // Return the exception message as a string if an error occurs
                    return ex.ToString();
                }
                finally
                {
                    // Close the SQL connection
                    connection.Close();
                }
            }
        }

        //----------------------------------------------------------------------------------------------------------------------//
        // Retrieves details of a farmer from the database based on their Id and returns a dictionary containing
        // the farmer's personal information.
        public Dictionary<string, string> GetFarmerDetails(string farmerId)
        {
            // Create a dictionary to hold farmer details
            Dictionary<string, string> farmerDetails = new Dictionary<string, string>();

            // Query to retrieve farmer details
            string selectQuery = "SELECT FirstName, Surname, Email, StreetNumber, Street, Suburb, City, Province, Country, Phone FROM Users WHERE Id = @FarmerId";

            // Create a new SQL connection using the provided connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SQL command object with the query and the connection
                SqlCommand command = new SqlCommand(selectQuery, connection);

                // Add the farmerId parameter to the SQL command
                command.Parameters.AddWithValue("@FarmerId", farmerId);

                // Open the SQL connection
                connection.Open();

                // Execute the command and obtain a data reader
                SqlDataReader reader = command.ExecuteReader();

                // Check if there are rows returned
                if (reader.Read())
                {
                    // Populate the dictionary with farmer details from the reader
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

                // Close the reader after reading data
                reader.Close();
            }

            // Return the dictionary with farmer details
            return farmerDetails;
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Creates a new user in the database with the provided details and returns true if the operation is successful,
        // otherwise returns false.
        public bool CreateUser(string firstName, string surname, string email, string hashedPassword, string streetNumber,
                string street, string suburb, string city, string province, string country, string phone, string employeeStatus)
        {
            // Create a new SQL connection using the provided connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query to insert a new user into the Users table
                string query = "INSERT INTO Users (FirstName, Surname, Email, Password, StreetNumber, Street, Suburb, " +
                               "City, Province, Country, Phone, Employee) " +
                               "VALUES (@FirstName, @Surname, @Email, @Password, @StreetNumber, @Street, @Suburb, @City, " +
                               "@Province, @Country, @Phone, @Employee)";

                // Create a SQL command object
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;

                // Clear and add parameters to the SQL command
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

                try
                {
                    // Open the SQL connection
                    connection.Open();

                    // Execute the command and get the number of affected rows
                    int rowsAffected = command.ExecuteNonQuery();

                    // Close the SQL connection
                    connection.Close();

                    // Return true if at least one row was affected, indicating success
                    return rowsAffected > 0;
                }
                catch (Exception)
                {
                    // Return false if there is an exception (e.g., connection issue, SQL error)
                    return false;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Updates the details of an existing user in the database with the provided information and returns true
        // if the operation is successful, otherwise returns false.
        public bool UpdateUser(string farmerId, string firstName, string surname, string email, string streetNumber,
            string street, string suburb, string city, string province, string country, string phone, string employeeStatus)
        {
            // Create a new SQL connection using the provided connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query to update user details in the Users table
                string query = "UPDATE Users SET FirstName = @FirstName, Surname = @Surname, Email = @Email, " +
                               "StreetNumber = @StreetNumber, Street = @Street, Suburb = @Suburb, City = @City, Province = @Province, " +
                               "Country = @Country, Phone = @Phone, Employee = @Employee WHERE Id = @FarmerId";

                // Create a SQL command object
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;

                // Clear and add parameters to the SQL command
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

                try
                {
                    // Open the SQL connection
                    connection.Open();

                    // Execute the command and get the number of affected rows
                    int rowsAffected = command.ExecuteNonQuery();

                    // Close the SQL connection
                    connection.Close();

                    // Return true if at least one row was affected, indicating success
                    return rowsAffected > 0;
                }
                catch (Exception)
                {
                    // Return false if there is an exception (e.g., connection issue, SQL error)
                    return false;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Checks if an email exists in the database by counting the number of records with the given email and
        // returns true if the email exists, otherwise returns false.
        public bool CheckForEmail(string email)
        {
            // Create a new SQL connection using the provided connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query to check if an email exists in the Users table
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

                // Create a SQL command object
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;

                // Add the email parameter to the SQL command
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    // Open the SQL connection
                    connection.Open();

                    // Execute the command and get the count of rows with the given email
                    int count = (int)command.ExecuteScalar();

                    // Close the SQL connection
                    connection.Close();

                    // Return true if the count is greater than 0, indicating the email exists
                    return count > 0;
                }
                catch (Exception)
                {
                    // Return false if there is an exception (e.g., connection issue, SQL error)
                    return false;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Checks if an employee code exists in the EmployeeCodes table by counting the number of records with the
        // given code and returns true if the code exists, otherwise returns false.
        public bool CheckEmployeeCodes(string code)
        {
            // Create a new SQL connection using the provided connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query to check if an employee code exists in the EmployeeCodes table
                string query = "SELECT COUNT(*) FROM EmployeeCodes WHERE Codes = @EmployeeCode";

                // Create a SQL command object with the query and the connection
                SqlCommand command = new SqlCommand(query, connection);

                // Add the employee code parameter to the SQL command
                command.Parameters.AddWithValue("@EmployeeCode", code);

                try
                {
                    // Open the SQL connection
                    connection.Open();

                    // Execute the command and get the count of rows with the given employee code
                    int count = (int)command.ExecuteScalar();

                    // Close the SQL connection
                    connection.Close();

                    // Return true if the count is greater than 0, indicating the code exists
                    return count > 0;
                }
                catch (Exception)
                {
                    // Return false if there is an exception (e.g., connection issue, SQL error)
                    return false;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Updates the user's password in the database based on the provided email and hashed password,
        // and returns true if the operation is successful, otherwise returns false.
        public bool UpdatePassword(string email, string hashedPassword)
        {
            // Create a new SQL connection using the provided connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query to update the user's password in the Users table
                string query = "UPDATE Users SET Password = @Password WHERE Email = @Email";

                // Create a SQL command object with the query and the connection
                SqlCommand command = new SqlCommand(query, connection);

                // Add the hashed password parameter to the SQL command
                command.Parameters.AddWithValue("@Password", hashedPassword);

                // Add the email parameter to the SQL command
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    // Open the SQL connection
                    connection.Open();

                    // Execute the command and get the number of affected rows
                    int changes = command.ExecuteNonQuery();

                    // Close the SQL connection
                    connection.Close();

                    // Return true if at least one row was affected, indicating success
                    return changes > 0;
                }
                catch (Exception)
                {
                    // Return false if there is an exception (e.g., connection issue, SQL error)
                    return false;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Compares the provided email and hashed password against the database to see if they match a record, and returns
        // true if they match, otherwise returns false.
        public bool ComparePasswords(string email, string newHashedPassword)
        {
            // Create a new SQL connection using the provided connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query to check if the email and hashed password match a record in the Users table
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";

                // Create a SQL command object with the query and the connection
                SqlCommand command = new SqlCommand(query, connection);

                // Add the email parameter to the SQL command
                command.Parameters.AddWithValue("@Email", email);

                // Add the hashed password parameter to the SQL command
                command.Parameters.AddWithValue("@Password", newHashedPassword);

                try
                {
                    // Open the SQL connection
                    connection.Open();

                    // Execute the command and get the count of rows that match the email and password
                    int count = (int)command.ExecuteScalar();

                    // Close the SQL connection
                    connection.Close();

                    // Return true if the count is greater than 0, indicating the email and password match
                    return count > 0;
                }
                catch (Exception)
                {
                    // Return false if there is an exception (e.g., connection issue, SQL error)
                    return false;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Retrieves all items from the database for a given user based on the userOnly flag, and returns a DataTable containing
        // the results. If userOnly is true, returns items for the specified user; otherwise, returns items for all other users.
        // If no items are found, returns a DataTable indicating "No Items".
        public DataTable GetAllItems(int userId, bool userOnly)
        {
            // Create a DataTable to hold the result
            DataTable dt = new DataTable();

            try
            {
                // Define the SQL query based on the userOnly flag
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

                // Create a new SQL connection using the provided connection string
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the SQL connection
                    conn.Open();

                    // Create a SQL command object with the query and the connection
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add the userId parameter to the SQL command
                        cmd.Parameters.AddWithValue("@LoggedInUserId", userId);

                        // Execute the command and load the result into the DataTable
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                // Check if the DataTable is empty and add a row indicating no items found
                if (dt.Rows.Count == 0)
                {
                    dt = new DataTable();
                    dt.Columns.Add("ProductName", typeof(string));
                    dt.Columns.Add("Category", typeof(string));
                    dt.Columns.Add("PDate", typeof(DateTime));
                    dt.Rows.Add("No Items", DBNull.Value, DBNull.Value);
                }
            }
            catch (Exception)
            {
                // Set the DataTable to null if there is an exception
                dt = null;
            }

            // Return the DataTable
            return dt;
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Retrieves a list of suppliers from the database based on the userOnly flag, and returns a DataTable containing the
        // results. If userOnly is true, returns suppliers for the specified user; otherwise, returns suppliers for all other
        // users. If no suppliers are found, returns a DataTable indicating "No Suppliers".
        public DataTable GetAllSuppliers(int userId, bool userOnly)
        {
            // Create a DataTable to hold the result
            DataTable dt = new DataTable();

            try
            {
                // Define the SQL query based on the userOnly flag
                string query;
                if (!userOnly)
                {
                    query = @"
            SELECT DISTINCT u.Id as UserId, u.FirstName, u.Surname 
            FROM Users u
            JOIN Items i ON u.Id = i.UserId
            WHERE u.Id <> @LoggedInUserId 
            AND Employee != 1";
                }
                else
                {
                    query = @"
            SELECT DISTINCT u.Id as UserId, u.FirstName, u.Surname 
            FROM Users u
            JOIN Items i ON u.Id = i.UserId
            WHERE u.Id = @LoggedInUserId 
            AND Employee != 1";
                }

                // Create a new SQL connection using the provided connection string
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Create a SQL command object with the query and the connection
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add the userId parameter to the SQL command
                        cmd.Parameters.AddWithValue("@LoggedInUserId", userId);

                        // Open the SQL connection
                        conn.Open();

                        // Execute the command and load the result into the DataTable
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                // Check if the DataTable is empty and add a row indicating no suppliers found
                if (dt.Rows.Count == 0)
                {
                    dt = new DataTable();
                    dt.Columns.Add("UserId", typeof(int));
                    dt.Columns.Add("FirstName", typeof(string));
                    dt.Columns.Add("Surname", typeof(string));
                    dt.Rows.Add(0, "No", "Suppliers");
                }
            }
            catch (Exception)
            {
                // Set the DataTable to null if there is an exception
                dt = null;
            }

            // Return the DataTable
            return dt;
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Retrieves all categories from the database, orders them by category name, and returns a list of ListItem objects
        // containing the category names and their corresponding Ids.
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
        //----------------------------------------------------------------------------------------------------------------------//
        // Retrieves the UserId associated with a given item name from the database and returns the UserId as a string.
        // If no matching item is found, returns null.
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
        //----------------------------------------------------------------------------------------------------------------------//
        // Filters items in the provided DataTable based on various criteria such as search term, date range, and category.
        // Returns a new DataTable containing the filtered results. The filtering logic differs based on the value of dt_type,
        // handling either "supplier" or other item types.
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

                return filteredDt;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------//
        // Create a new item
        public void CreateNewItem(string itemName, int categoryId, DateTime dateOfProduction, string description, int userId)
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
        //----------------------------------------------------------------------------------------------------------------------//
        // Create a new category
        public int CreateNewCategory(string category)
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
        //----------------------------------------------------------------------------------------------------------------------//
        // Retrieves the category ID from the database.
        public int GetCategoryId(string categoryName)
        {
            // SQL query to retrieve categories from the database
            string query = "SELECT Id FROM Categories WHERE Category LIKE @Category";

            // Initialize a variable to store the category ID
            int categoryId = -1; // Default value if category is not found

            // Establish connection and execute the query
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameter for category name
                    cmd.Parameters.AddWithValue("@Category", categoryName);

                    conn.Open();

                    // Execute the query and retrieve the category ID
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            categoryId = Convert.ToInt32(reader["Id"]);
                        }
                    }
                }
            }

            // Return the category ID
            return categoryId;
        }
    }
}
//-----------------------------------------------End Of Page-----------------------------------------------------------------------//