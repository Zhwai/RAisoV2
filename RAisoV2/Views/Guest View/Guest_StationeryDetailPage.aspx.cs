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
    public partial class Guest_StationeryDetail : System.Web.UI.Page
    {
        private static StationeryController StatController = new StationeryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            String oldID = Request.QueryString["id"];
            int newID = Convert.ToInt32(oldID);
            MsStationery currentStationery = StatController.getStationeryByID(newID);

            LblNameShow.Text = currentStationery.StationeryName;
            LblPriceShow.Text = currentStationery.StationeryPrice.ToString();
        }
    }
}