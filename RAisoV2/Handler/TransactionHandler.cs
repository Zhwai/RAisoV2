using RAisoV2.Models;
using RAisoV2.Repositories;
using RAisoV2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Handler
{
    public class TransactionHandler
    {
        private static TransactionHeaderRepository THRepo = new TransactionHeaderRepository();
        private static TransactionDetailRepository TDRepo = new TransactionDetailRepository();
        private static UserRepository UserRepo = new UserRepository();
        private static StationeryRepository STrepo = new StationeryRepository();

        public List<TransactionHeader> getTransactionHeader()
        {
            return THRepo.getTransactionHeader();
        }

        public int getIdByName(String name)
        {
            return UserRepo.getIdByName(name);
        }
        public List<TransactionDetail> getAllTransactionDetails()
        {
            return TDRepo.getAllTransactionDetails();
        }

        public List<MsStationery> getAllStationaries()
        {
            return STrepo.getAllStationaries();
        }
    }
}