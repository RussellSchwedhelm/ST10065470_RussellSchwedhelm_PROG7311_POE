using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class ModifyFarmers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.Master is SiteMaster master) || !master.LoggedOn)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!master.Employee)
                {
                    Response.Redirect("~/Home.aspx");
                }
                else if (!IsPostBack)
                {
                    LoadFarmers();
                }
            }
        }

        private void LoadFarmers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string query = "SELECT Id, FirstName + ' ' + Surname AS Username FROM Users WHERE Employee = 0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    itemList.DataSource = reader;
                    itemList.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Response.Write("An error occurred: " + ex.Message);
                }
            }
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateFarmer.aspx");
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string farmerId = button.CommandArgument;
            Response.Redirect($"CreateFarmer.aspx?FarmerId={farmerId}");
        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            string farmerId = hiddenFarmerId.Value;
            DeleteFarmer(farmerId);
            LoadFarmers();
            showRemovePopup();
        }

        private void DeleteFarmer(string farmerId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string query = "DELETE FROM Users WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", farmerId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Response.Write("An error occurred: " + ex.Message);
                }
            }
        }

        protected void btnContinueRemove_Click(object sender, EventArgs e)
        {
            hideRemovePopup();
        }

        private void showRemovePopup()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showRemovePopup", "showRemovePopup();", true);
        }

        private void hideRemovePopup()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "hideRemovePopup", "hideRemovePopup();", true);
        }
    }
}
