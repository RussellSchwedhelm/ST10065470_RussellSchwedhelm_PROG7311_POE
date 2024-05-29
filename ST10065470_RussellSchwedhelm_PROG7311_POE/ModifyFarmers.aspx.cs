using ST10065470_RussellSchwedhelm_PROG7311_POE.Classes;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class ModifyFarmers : System.Web.UI.Page
    {
        DBController dbController;
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
                else
                {
                    dbController = new DBController();
                    LoadFarmers();
                }
            }
        }

        private void LoadFarmers()
        {
            SqlDataReader reader = dbController.GetAllFarmers();

            if (reader != null)
            {
                try
                {
                    itemList.DataSource = reader;
                    itemList.DataBind();
                }
                finally
                {
                    reader.Close();
                }
            }
            else
            {
                // Handle exception
                Response.Write("An Error Occurred!");
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
            string response = dbController.DeleteFarmer(farmerId);
            if (response != null)
            {
                Response.Write("An error occurred: " + response);
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
