using RAisoV2.Handler;
using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Controller
{
    public class TransactionController
    {
        private static TransactionHandler transactionHandler = new TransactionHandler();

        public List<TransactionHeader> getTransactionHeaders()
        {
            return transactionHandler.getTransactionHeader();
        }
        public int getIdByName(String name)
        {
            return transactionHandler.getIdByName(name);
        }
        public List<TransactionDetail> getAllTransactionDetails()
        {
            return transactionHandler.getAllTransactionDetails();
        }
        public List<MsStationery> getAllStationaries()
        {
            return transactionHandler.getAllStationaries();
        }
    }
}