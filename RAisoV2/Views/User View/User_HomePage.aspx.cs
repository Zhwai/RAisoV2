using RAisoV2.Controller;
using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoV2.Views.User_View
{
    public partial class User_HomePage : System.Web.UI.Page
    {
        StationeryController StatController = new StationeryController();
        List<MsStationery> allStationery = new List<MsStationery>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                allStationery = StatController.getAllStationaries();
                GVStationary.DataSource = allStationery;
                GVStationary.DataBind();
            }
        }

        protected void GVStationary_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow rows = GVStationary.Rows[e.NewSelectedIndex];
            String stationeryName = rows.Cells[0].Text;
            int id = StatController.getStationeryIDByName(stationeryName);

            Response.Redirect("~/Views/User View/User_StationeryDetailPage.aspx?id=" + id);
        }
    }
}