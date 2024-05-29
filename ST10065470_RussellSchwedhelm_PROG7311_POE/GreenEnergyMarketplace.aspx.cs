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
        DBController dBController = new DBController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.Master is SiteMaster master) || !master.LoggedOn)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    if (master.Employee)
                    {
                        MyStore.Visible = false;
                    }
                    else
                    {
                        LoadUserItems();
                    }

                    PopulateCategories();
                    LoadSuppliers();
                    LoadAllItems();
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            // Reset dp_fromDate
            dp_fromDate.Value = "";

            // Reset dp_toDate
            dp_toDate.Value = "";
            LoadSuppliers();
            LoadAllItems();

            sel_category.SelectedIndex = 0;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            // Get the selected date from dp_fromDate
            string fromDate = dp_fromDate.Value;
            string toDate = dp_toDate.Value;

            string category = sel_category.Value;

            if (!string.IsNullOrEmpty(searchTerm) || !string.IsNullOrEmpty(fromDate) || !string.IsNullOrEmpty(toDate) || !string.IsNullOrEmpty(category))
            {
                DataTable dt_suppliers = dBController.GetAllSuppliers(Convert.ToInt32(Session["UserID"]), false);
                DataTable dt_items = dBController.GetAllItems(Convert.ToInt32(Session["UserID"]), false);

                dt_suppliers = dBController.FilterItems(dt_suppliers, "supplier", searchTerm, fromDate, toDate, category);
                dt_items = dBController.FilterItems(dt_items, "items", searchTerm, fromDate, toDate, category);

                if (dt_suppliers == null && dt_items == null)
                {
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
                    foreach (DataRow row in dt_items.Rows)
                    {
                        dt_suppliers.Merge(dBController.GetAllSuppliers(Convert.ToInt32(dBController.GetIdFromItem(row["ProductName"].ToString())), true));
                    }
                }
                else
                {
                    dt_items = new DataTable();

                    dt_items.Columns.Add("ProductName", typeof(string));
                    dt_items.Columns.Add("Category", typeof(string));
                    dt_items.Columns.Add("PDate", typeof(DateTime));
                    dt_items.Rows.Add("No Items", DBNull.Value, DBNull.Value);
                }
                supplierList.DataSource = dt_suppliers;
                supplierList.DataBind();

                allItemList.DataSource = dt_items;
                allItemList.DataBind();
            }
            else
            {
                LoadSuppliers();
                LoadAllItems();
                sel_category.SelectedIndex = 0;
            }
        }

        private void LoadSuppliers()
        {
            int loggedInUserId = Convert.ToInt32(Session["UserID"]);

            DataTable dt = dBController.GetAllSuppliers(loggedInUserId, false);

            if (dt == null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occurred');", true);
            }
            else
            {
                supplierList.DataSource = dt;
                supplierList.DataBind();
            }
        }

        private void LoadUserItems()
        {
            int loggedInUserId = Convert.ToInt32(Session["UserID"]);

            DataTable dt = dBController.GetAllItems(loggedInUserId, false);

            if (dt == null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occurred');", true);
            }
            else
            {
                itemList.DataSource = dt;
                itemList.DataBind();
            }                
        }

        private void LoadAllItems()
        {
            int loggedInUserId = Convert.ToInt32(Session["UserID"]);

            DataTable dt = dBController.GetAllItems(loggedInUserId, false);

            if (dt == null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error Occurred');", true);
            }
            else
            {
                allItemList.DataSource = dt;
                allItemList.DataBind();
            }             
        }

        protected void SupplierList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int supplierId = Convert.ToInt32(e.CommandArgument);

            DataTable dt = dBController.GetAllItems(supplierId, true);

            allItemList.DataSource = dt;
            allItemList.DataBind();
        }

        private void PopulateCategories()
        {
            // Retrieve categories from the database
            List<ListItem> categories = dBController.GetAllCategories();

            // Add a blank option at the beginning of the list
            categories.Insert(0, new ListItem("", ""));

            // Bind the categories list to the selector drop-down box
            sel_category.DataSource = categories;
            sel_category.DataBind();
        }
    }
}