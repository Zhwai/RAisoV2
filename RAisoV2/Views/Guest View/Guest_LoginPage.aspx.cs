using RAisoV2.Controller;
using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoV2.Views.Guest_View
{
    public partial class Guest_LoginPage : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            LblError.ForeColor = System.Drawing.Color.Red;
            HttpCookie cookie = Request.Cookies["UserInfo"];

            if (IsPostBack == false)
            {
                if (cookie != null)
                {
                    TBUserName.Text = cookie["UserName"];
                    TBPassword.Text = cookie["Password"];
                    CBRemember.Checked = true;

                    BtnConfirm_Click(this, new EventArgs());
                }
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            String UserName = TBUserName.Text;
            String Password = TBPassword.Text;

            LblError.Text = userController.checkCredibility(UserName, Password);

            if (LblError.Text == "Success")
            {
                LblError.ForeColor = System.Drawing.Color.Green;

                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie["UserName"] = TBUserName.Text;
                cookie["Password"] = TBPassword.Text;
                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);

                MsUser currentUser = userController.getUserByName(UserName);
                Session["UserSession"] = currentUser;

                if (userController.checkRoles(UserName) == true)
                {
                    Response.Redirect("~/Views/Admin View/Admin_HomePage.aspx");
                }
                else
                {
                    Response.Redirect("~/Views/User View/User_HomePage.aspx");
                }
            }
        }
    }
}