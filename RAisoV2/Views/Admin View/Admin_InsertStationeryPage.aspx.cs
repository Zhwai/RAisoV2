using RAisoV2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoV2.Views.Admin_View
{
    public partial class Admin_InsertStationeryPage : System.Web.UI.Page
    {
        private static StationeryController StatController = new StationeryController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Lblerror.ForeColor = System.Drawing.Color.Red;
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            String StationeryName = TBName.Text;
            String StationeryPrice = TBPrice.Text;

            Lblerror.Text = StatController.validate(StationeryName, StationeryPrice); ;

            if (Lblerror.Text.Equals("Success"))
            {
                Lblerror.ForeColor = System.Drawing.Color.Green;

                int newStationeryPrice = Convert.ToInt32(StationeryPrice);
                StatController.createStationery(StationeryName, newStationeryPrice);

            }
        }
    }
}