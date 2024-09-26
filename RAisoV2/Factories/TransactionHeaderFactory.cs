using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Factories
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader createTransactionHeader(int TransactionID, int UserID, DateTime TransactionDate)
        {
            TransactionHeader newTransactionHeader = new TransactionHeader()
            {
                TransactionId = TransactionID,
                UserId = UserID,
                TransactionDate = TransactionDate
            };
            return newTransactionHeader;
        }
    }
}