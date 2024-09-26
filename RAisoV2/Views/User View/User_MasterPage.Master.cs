using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoV2.Views.User_View
{
    public partial class User_MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UserHomePageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/User View/User_HomePage.aspx");
        }

        protected void CartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/User View/User_CartPage.aspx");
        }

        protected void TransactionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/User View/User_TransactionPage.aspx");

        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/User View/User_UpdateProfilePage.aspx");
        }

        protected void LogOutBtn_Click(object sender, EventArgs e)
        {
            Session["UserSession"] = null;
            Session.Abandon();

            Response.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(-1);

            Response.Redirect("~/Views/Guest View/Guest_HomePage.aspx");
        }
    }
}