using CrystalDecisions.Web;
using RAisoV2.Controller;
using RAisoV2.Dataset;
using RAisoV2.Models;
using RAisoV2.TransactionReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoV2.Views.Admin_View
{
    public partial class Admin_TransactionPage : System.Web.UI.Page
    {
        TransactionController transactionController = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport report = new CrystalReport();
            CrystalReportViewer1.ReportSource = report;
            DataSet data = getData(transactionController.getTransactionHeaders());
            report.SetDataSource(data);
        }

        private DataSet getData(List<TransactionHeader> transactions)
        {
            DataSet data = new DataSet();
            var headertable = data.TransactionHeader;
            var detailtable = data.TransactionDetail;

            foreach (TransactionHeader transaction in transactions)
            {
                var hrow = headertable.NewRow();
                hrow["TransactionID"] = transaction.TransactionId;
                hrow["TransactionDate"] = transaction.TransactionDate;
                hrow["UserID"] = transaction.UserId;
                var grandTotal = 0;

                foreach (TransactionDetail transactionDetail in transaction.TransactionDetails)
                {
                    var subtotal = 0;
                    var drow = detailtable.NewRow();

                    drow["TransactionID"] = transactionDetail.TransactionId;
                    drow["StationeryName"] = transactionDetail.MsStationery.StationeryName;
                    drow["StationeryPrice"] = transactionDetail.MsStationery.StationeryPrice;
                    drow["Quantity"] = transactionDetail.Quantity;

                    subtotal += transactionDetail.MsStationery.StationeryPrice * transactionDetail.Quantity;
                    drow["SubTotalValue"] = subtotal;
                    grandTotal += subtotal;
                    detailtable.Rows.Add(drow);
                }
                hrow["GrandTotalValue"] = grandTotal;
                headertable.Rows.Add(hrow);
            }
            return data;
        }
    }
}