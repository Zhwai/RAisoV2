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
    public partial class User_TransactionDetailPage : System.Web.UI.Page
    {
        private static TransactionController transactionController = new TransactionController();
        List<MsStationery> currentStationery = new List<MsStationery>();
        List<TransactionDetail> currentTransactionDetails = new List<TransactionDetail>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int transactionID = (int)Session["TransactionID"];

                currentStationery = transactionController.getAllStationaries();
                currentTransactionDetails = transactionController.getAllTransactionDetails();

                List<MergedItem> mergedItems = GetMergedItems(transactionID);
                GVShow.DataSource = mergedItems;
                GVShow.DataBind();
            }
        }
        private List<MergedItem> GetMergedItems(int transactionID)
        {
            var filteredTransactionDetails = currentTransactionDetails
                .Where(td => td.TransactionId == transactionID)
                .ToList();

            var mergedItems = (from td in filteredTransactionDetails
                               join ms in currentStationery
                               on td.StationeryId equals ms.StationeryId
                               select new MergedItem
                               {
                                   Quantity = td.Quantity,
                                   StationeryName = ms.StationeryName,
                                   StationeryPrice = ms.StationeryPrice
                               }).ToList();

            return mergedItems;
        }

        public class MergedItem
        {
            public int Quantity { get; set; }
            public string StationeryName { get; set; }
            public int StationeryPrice { get; set; }
        }
    }
}