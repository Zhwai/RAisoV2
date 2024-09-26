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
    public partial class Guest_HomePage : System.Web.UI.Page
    {
        private static StationeryController StatController = new StationeryController();
        List<MsStationery> allStationaries = new List<MsStationery>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                allStationaries = StatController.getAllStationaries();
                GVStationary.DataSource = allStationaries;
                GVStationary.DataBind();
            }
        }

        protected void GVStationary_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow rows = GVStationary.Rows[e.NewSelectedIndex];
            String stationeryName = rows.Cells[0].Text;
            int id = StatController.getStationeryIDByName(stationeryName);

            Response.Redirect("~/Views/Guest View/Guest_StationeryDetailPage.aspx?id=" + id);
        }
    }
}