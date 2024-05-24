using System.Web.UI;
using System;

namespace ST10065470_RussellSchwedhelm_PROG7311_POE
{
    public partial class SiteMaster : MasterPage
    {
        public bool Employee
        {
            get
            {
                if (Session["IsEmployee"] != null)
                {
                    return (bool)Session["IsEmployee"];
                }
                return false;
            }
        }

        public bool LoggedOn
        {
            get
            {
                if (Session["IsLoggedOn"] != null)
                {
                    return (bool)Session["IsLoggedOn"];
                }
                return false;
            }
            set
            {
                Session["IsLoggedOn"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
