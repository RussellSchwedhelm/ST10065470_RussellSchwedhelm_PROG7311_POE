using System;
using System.Web.UI;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class SiteMaster : MasterPage
    {
        // Property to check if the user is an employee
        public bool Employee
        {
            get
            {
                if (Session["IsEmployee"] != null)
                {
                    return (bool)Session["IsEmployee"];
                }
                return false; // Return false by default if session variable is not set
            }
        }

        // Property to check if the user is logged on
        public bool LoggedOn
        {
            get
            {
                if (Session["IsLoggedOn"] != null)
                {
                    return (bool)Session["IsLoggedOn"];
                }
                return false; // Return false by default if session variable is not set
            }
            set
            {
                // Set the session variable indicating if the user is logged on
                Session["IsLoggedOn"] = value;
            }
        }

        // Property to get or set the user ID
        public int UserID
        {
            get
            {
                if (Session["UserID"] != null)
                {
                    return (int)Session["UserID"];
                }
                return -1; // Return a default value if user ID is not set
            }
            set
            {
                // Set the session variable for user ID
                Session["UserID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // No specific actions required on page load
        }
    }
}
