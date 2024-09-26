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
    public partial class Admin_HomePage : System.Web.UI.Page
    {
        private static StationeryController StatController = new StationeryController();
        List<MsStationery> allStationaries = new List<MsStationery>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                allStationaries = StatController.getAllStationaries();
                GVStationery.DataSource = allStationaries;
                GVStationery.DataBind();
            }
        }

        protected void GVStationery_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows = GVStationery.Rows[e.RowIndex];
            String stationeryName = rows.Cells[0].Text;
            int id = StatController.getStationeryIDByName(stationeryName);

            StatController.deleteStationery(id);

            allStationaries = StatController.getAllStationaries();
            GVStationery.DataSource = allStationaries;
            GVStationery.DataBind();
        }

        protected void GVStationery_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow rows = GVStationery.Rows[e.NewEditIndex];
            String stationeryName = rows.Cells[0].Text;
            int id = StatController.getStationeryIDByName(stationeryName);

            Response.Redirect("~/Views/Admin View/Admin_UpdateStationeryPage.aspx?id=" + id);
        }

        protected void GVStationery_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow rows = GVStationery.Rows[e.NewSelectedIndex];
            String stationeryName = rows.Cells[0].Text;
            int id = StatController.getStationeryIDByName(stationeryName);

            Response.Redirect("~/Views/Admin View/Admin_StationeryDetailPage.aspx?id=" + id);
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin View/Admin_InsertStationeryPage.aspx");
        }
    }
}