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
    public partial class User_TransactionPage : System.Web.UI.Page
    {
        private static TransactionController transactionController = new TransactionController();
        List<TransactionHeader> transactionHeaders = new List<TransactionHeader>();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            String UserName = cookie["UserName"];

            if (IsPostBack == false)
            {
                int UserID = transactionController.getIdByName(UserName);

                transactionHeaders = transactionController.getTransactionHeaders();

                List<MergedItem> MergedItem = (from TransactionHeader in transactionHeaders
                                               where TransactionHeader.UserId == UserID
                                               select new MergedItem
                                               {
                                                   TransactionID = TransactionHeader.TransactionId,
                                                   TransactionDate = TransactionHeader.TransactionDate,
                                                   UserName = UserName,
                                               }).ToList();

                GVHistory.DataSource = MergedItem;
                GVHistory.DataBind();
            }
        }
        
        public class MergedItem
        {
            public int TransactionID { get; set; }
            public DateTime TransactionDate { get; set; }
            public String UserName { get; set; }
            public int StationeryID { get; set; }
        }

        protected void GVHistory_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                String UserName = cookie["UserName"];

                int UserID = transactionController.getIdByName(UserName);

                GridViewRow rows = GVHistory.Rows[e.NewSelectedIndex];
                int TransactionID = Convert.ToInt32(rows.Cells[0].Text);

                Session["TransactionID"] = TransactionID;

                string url = "~/Views/User View/User_TransactionDetailPage.aspx";
                Response.Redirect(url);
            }
        }
    }
}