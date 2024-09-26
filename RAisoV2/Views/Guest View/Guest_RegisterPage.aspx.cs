using RAisoV2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoV2.Views.Guest_View
{
    public partial class Guest_RegisterPage : System.Web.UI.Page
    {
        private static UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            LblError.ForeColor = System.Drawing.Color.Red;
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            String UserName = TBName.Text;
            String UserAddress = TBAddress.Text;
            String UserGender = " ";
            DateTime UserDOB = CldDOB.SelectedDate;
            String UserPhone = TBPhone.Text;
            String UserPassword = TBPassword.Text;
            String UserRole = "User";

            if (RBFemale.Checked)
            {
                UserGender = "Female";
            }
            else if (RBMale.Checked)
            {
                UserGender = "Male";
            }

            LblError.Text = userController.Validate(UserName, UserGender, UserAddress, UserPhone, UserDOB, UserPassword, UserRole);

            if (LblError.Text == "Sucess")
            {
                LblError.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}