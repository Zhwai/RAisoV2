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
    public partial class User_StationeryDetailPage : System.Web.UI.Page
    {
        StationeryController StatController = new StationeryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Lblerror.ForeColor = System.Drawing.Color.Red;

            String oldID = Request.QueryString["id"];
            int newID = Convert.ToInt32(oldID);
            MsStationery currentStationery = StatController.getStationeryByID(newID);

            LblNameShow.Text = currentStationery.StationeryName;
            LblPriceShow.Text = currentStationery.StationeryPrice.ToString();
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            String oldID = Request.QueryString["id"];
            int stationeryID = Convert.ToInt32(oldID);

            HttpCookie cookie = Request.Cookies["UserInfo"];
            String UserName = cookie["UserName"];
            int id = StatController.getIdByName(UserName);

            String quantityString = TBQuantity.Text;

            Lblerror.Text = StatController.validate(quantityString);

            if (Lblerror.Text.Equals("Success"))
            {
                Lblerror.ForeColor = System.Drawing.Color.Green;

                int newQuantityString = Convert.ToInt32(quantityString);
                StatController.createCart(id, stationeryID, newQuantityString);
            }
        }
    }
}