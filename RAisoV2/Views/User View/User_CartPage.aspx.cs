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
    public partial class User_CartPage : System.Web.UI.Page
    {
        private static CartController cartController = new CartController();
        List<MsStationery> currentStationery = new List<MsStationery>();
        List<Cart> currentCart = new List<Cart>();
        MsUser currentUser = new MsUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartData();
            }
        }
        private void LoadCartData()
        {
            LblError.ForeColor = System.Drawing.Color.Red;

            currentStationery = cartController.getAllStationaries();
            currentCart = cartController.getAllCarts();

            HttpCookie cookie = Request.Cookies["UserInfo"];
            String UserName = cookie["UserName"];
            currentUser = cartController.getUserByName(UserName);

            List<MergedItem> mergedList = (from stationery in currentStationery
                                           join cart in currentCart on stationery.StationeryId equals cart.StationeryId
                                           where cart.UserId == currentUser.UserId
                                           select new MergedItem
                                           {
                                               StationeryName = stationery.StationeryName,
                                               StationeryPrice = stationery.StationeryPrice,
                                               Quantity = cart.Quantity,
                                               UserID = cart.UserId,
                                               StationeryID = stationery.StationeryId,
                                           }).ToList();
            GVCart.DataSource = mergedList;
            GVCart.DataBind();
        }

        protected void GVCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows = GVCart.Rows[e.RowIndex];
            String stationeryName = rows.Cells[0].Text;
            int stationeryID = cartController.getStationeryIDByName(stationeryName);

            HttpCookie cookie = Request.Cookies["UserInfo"];
            String UserName = cookie["UserName"];
            currentUser = cartController.getUserByName(UserName);

            cartController.deleteCart(currentUser.UserId, stationeryID);

            LoadCartData();
        }

        protected void GVCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow rows = GVCart.Rows[e.NewEditIndex];
            String stationeryName = rows.Cells[0].Text;
            int stationeryID = cartController.getStationeryIDByName(stationeryName);

            HttpCookie cookie = Request.Cookies["UserInfo"];
            String UserName = cookie["UserName"];
            currentUser = cartController.getUserByName(UserName);

            string url = string.Format("~/Views/User View/User_CartEditingPage.aspx?stationeryID={0}&userID={1}", stationeryID, currentUser.UserId);

            Response.Redirect(url);
        }

        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {
            currentStationery = cartController.getAllStationaries();
            currentCart = cartController.getAllCarts();

            HttpCookie cookie = Request.Cookies["UserInfo"];
            String UserName = cookie["UserName"];
            currentUser = cartController.getUserByName(UserName);

            List<CartDeletion> cartDeletion = (from stationery in currentStationery
                                               join cart in currentCart on stationery.StationeryId equals cart.StationeryId
                                               where cart.UserId == currentUser.UserId
                                               select new CartDeletion
                                               {
                                                   Quantity = cart.Quantity,
                                                   UserID = cart.UserId,
                                                   StationeryID = stationery.StationeryId,
                                               }).ToList();

            cartController.createTransactionHeader(currentUser.UserId, DateTime.Now);

            int lastTransactionDetailID = cartController.getLastTransactionID();

            for (int i = 0; i < cartDeletion.Count; i++)
            {
                cartController.createTransactionDetail(lastTransactionDetailID, cartDeletion[i].StationeryID, cartDeletion[i].Quantity);
                cartController.deleteCart(cartDeletion[i].UserID, cartDeletion[i].StationeryID);
            }

            LoadCartData();
        }

        public class MergedItem
        {
            public String StationeryName { get; set; }
            public int StationeryPrice { get; set; }
            public int Quantity { get; set; }
            public int UserID { get; set; }
            public int StationeryID { get; set; }
        }

        public class CartDeletion
        {
            public int Quantity { get; set; }
            public int UserID { get; set; }
            public int StationeryID { get; set; }
        }
    }
}