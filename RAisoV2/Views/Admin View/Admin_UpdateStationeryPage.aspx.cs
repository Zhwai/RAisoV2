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
    public partial class Admin_UpdateStationeryPage : System.Web.UI.Page
    {
        MsStationery newStationery = new MsStationery();
        StationeryController StatController = new StationeryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LblError.ForeColor = System.Drawing.Color.Red;

                String id = Request.QueryString["id"];
                int newID = Convert.ToInt32(id);
                newStationery = StatController.getStationeryByID(newID);

                TBName.Text = newStationery.StationeryName;
                TBPrice.Text = newStationery.StationeryPrice.ToString();
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            String id = Request.QueryString["id"];
            String StationeryName = TBName.Text;
            String StationeryPrice = TBPrice.Text;

            LblError.Text = StatController.validate(StationeryName, StationeryPrice); ;

            if (LblError.Text.Equals("Success"))
            {
                LblError.ForeColor = System.Drawing.Color.Green;
                LblError.Text = "Success";

                int newID = Convert.ToInt32(id);
                int newStationeryPrice = Convert.ToInt32(StationeryPrice);

                StatController.updateStationery(newID, StationeryName, newStationeryPrice);
            }
        }
    }
}