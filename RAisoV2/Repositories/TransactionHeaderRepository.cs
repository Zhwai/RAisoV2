using RAisoV2.Factories;
using RAisoV2.Models;
using RAisoV2.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RAisoV2.Repositories
{
    public class TransactionHeaderRepository
    {
        LocaldatabaseEntities db = DatabaseSingleton.getInstance();

        public void createTransactionHeader(int UserId, DateTime TransactionDate)
        {
            TransactionHeader newTransactionHeader = TransactionHeaderFactory.createTransactionHeader(generateID(), UserId, TransactionDate);
            db.TransactionHeaders.Add(newTransactionHeader);
            db.SaveChanges();
        }

        private int generateID()
        {
            TransactionHeader LastTransactionHeader = db.TransactionHeaders.ToList().LastOrDefault();

            if (LastTransactionHeader == null)
            {
                return 1;
            }

            int LastIdNum = LastTransactionHeader.TransactionId;
            int NewIdNum = LastIdNum + 1;

            return NewIdNum;
        }
        public int getLastTransactionID()
        {
            TransactionHeader LastTransactionHeader = db.TransactionHeaders.ToList().LastOrDefault();

            if (LastTransactionHeader == null)
            {
                return 1;
            } 
            else
            {
                return LastTransactionHeader.TransactionId;
            }
        }
        public List<TransactionDetail> getTransactionDetail()
        {
            return (from x in db.TransactionDetails select x).ToList();
        }

        public List<TransactionHeader> getTransactionHeader()
        {
            return (from x in db.TransactionHeaders select x).ToList();
        }
    }
}