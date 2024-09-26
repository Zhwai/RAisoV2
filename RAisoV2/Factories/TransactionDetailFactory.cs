using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail createTransactionDetail(int TransactionID, int StationeryID, int Quantity)
        {
            TransactionDetail newTransactionDetail = new TransactionDetail()
            {
                TransactionId = TransactionID,
                StationeryId = StationeryID,
                Quantity = Quantity,
            };
            return newTransactionDetail;
        }
    }
}