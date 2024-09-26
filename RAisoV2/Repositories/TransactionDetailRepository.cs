using RAisoV2.Factories;
using RAisoV2.Models;
using RAisoV2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Repositories
{
    public class TransactionDetailRepository
    {
        LocaldatabaseEntities db = DatabaseSingleton.getInstance();
        public void createTransactionDetail(int TransactionID, int StationeryID, int Quantity)
        {
           TransactionDetail newTransactionDetail = TransactionDetailFactory.createTransactionDetail(TransactionID, StationeryID, Quantity);
            db.TransactionDetails.Add(newTransactionDetail);
            db.SaveChanges();
        }

        public List<TransactionDetail> getAllTransactionDetails()
        {
            return (from x in db.TransactionDetails select x).ToList();
        }
    }
}