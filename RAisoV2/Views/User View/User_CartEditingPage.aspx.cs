using RAisoV2.Controller;
using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static RAisoV2.Views.User_View.User_CartPage;

namespace RAisoV2.Views.User_View
{
    public partial class User_CartEditingPage : System.Web.UI.Page
    {
        CartController cartController = new CartController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Lblerror.ForeColor = System.Drawing.Color.Red;
                LoadCartData();
            }
        }
        private void LoadCartData()
        {
            List<MsStationery> currentStationery = cartController.getAllStationaries();
            List<Cart> currentCart = cartController.getAllCarts();

            String oldstationeryID = Request.QueryString["stationeryID"];
            String oldUserID = Request.QueryString["userID"];

            int newStationeryID = Convert.ToInt32(oldstationeryID);
            int newUserID = Convert.ToInt32(oldUserID);

            var mergedList = from stationery in currentStationery
                             join cart in currentCart on stationery.StationeryId equals cart.StationeryId
                             where cart.UserId == newUserID
                             select new MergedItem
                             {
                                 StationeryName = stationery.StationeryName,
                                 StationeryPrice = stationery.StationeryPrice,
                                 Quantity = cart.Quantity,
                                 UserID = cart.UserId,
                                 StationeryID = stationery.StationeryId,
                             };

            MergedItem merge = mergedList.FirstOrDefault(x => x.StationeryID == newStationeryID);
            if (merge != null)
            {
                LblNameShow.Text = merge.StationeryName;
                LblPriceShow.Text = merge.StationeryPrice.ToString();
                TBQuantity.Text = merge.Quantity.ToString();
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            String oldstationeryID = Request.QueryString["stationeryID"];
            String oldUserID = Request.QueryString["userID"];
            String oldQuantity = TBQuantity.Text;

            int newStationeryID = Convert.ToInt32(oldstationeryID);
            int newUserID = Convert.ToInt32(oldUserID);

            Lblerror.Text = cartController.validate(oldQuantity);

            if (Lblerror.Text.Equals("Success"))
            {
                Lblerror.ForeColor = System.Drawing.Color.Green;

                int newQuantity = Convert.ToInt32(oldQuantity);
                cartController.updateStationeryQuantity(newUserID, newStationeryID, newQuantity);

                LoadCartData();
            }
        }

        public class MergedItem
        {
            public String StationeryName { get; set; }
            public int StationeryPrice { get; set; }
            public int Quantity { get; set; }
            public int UserID { get; set; }
            public int StationeryID { get; set; }
        }
    }
}