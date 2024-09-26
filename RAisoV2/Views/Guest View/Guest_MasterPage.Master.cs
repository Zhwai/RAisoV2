using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoV2.Views.Guest_View
{
    public partial class GuestMP : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuestHomePageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Guest View/Guest_HomePage.aspx");
        }

        protected void LoginPageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Guest View/Guest_LoginPage.aspx");
        }

        protected void RegisterPageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Guest View/Guest_RegisterPage.aspx");
        }
    }
}