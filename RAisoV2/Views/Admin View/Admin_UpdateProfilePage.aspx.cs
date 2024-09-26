using RAisoV2.Controller;
using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoV2.Views.Admin_View
{
    public partial class Admin_UpdateProfilePage : System.Web.UI.Page
    {
        UserController userController = new UserController();
        MsUser currentUser = new MsUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                HttpCookie cookie = Request.Cookies["UserInfo"];
                String UserName = cookie["UserName"];

                currentUser = userController.getUserByName(UserName);

                TBName.Text = currentUser.UserName;
                TBAddress.Text = currentUser.UserAddress;
                TBPassword.Text = currentUser.UserPassword;
                TBPhone.Text = currentUser.UserPhone;

                if (currentUser.UserGender == "Female")
                {
                    RBFemale.Checked = true;
                }
                else
                {
                    RBMale.Checked = true;
                }

                DateTime date = currentUser.UserDOB.Date;
                CldDOB.SelectedDate = date;
                CldDOB.VisibleDate = date;
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            String FirstUserName = cookie["UserName"];

            String UserName = TBName.Text;
            String UserAddress = TBAddress.Text;
            String UserGender = " ";
            DateTime UserDOB = CldDOB.SelectedDate;
            String UserPhone = TBPhone.Text;
            String UserPassword = TBPassword.Text;
            String UserRole = "Admin";

            if (RBFemale.Checked)
            {
                UserGender = "Female";
            }
            else if (RBMale.Checked)
            {
                UserGender = "Male";
            }

            LblError.Text = userController.updateValidate(FirstUserName, UserName, UserGender, UserAddress, UserPhone, UserDOB, UserPassword, UserRole);

            if (LblError.Text == "Sucess")
            {
                LblError.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}