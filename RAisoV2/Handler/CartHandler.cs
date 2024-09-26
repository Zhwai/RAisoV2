using RAisoV2.Models;
using RAisoV2.Repositories;
using RAisoV2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Handler
{
    public class CartHandler
    {

        private static CartRepository CartRepo = new CartRepository();
        private static StationeryRepository StatRepo = new StationeryRepository();
        private static UserRepository UserRepo = new UserRepository();
        private static TransactionHeaderRepository THRepo = new TransactionHeaderRepository();
        private static TransactionDetailRepository TDRepo = new TransactionDetailRepository();

        public List<MsStationery> getAllStationaries()
        {
            return StatRepo.getAllStationaries();
        }

        public List<Cart> getAllCarts()
        {
            return CartRepo.getAllCarts();
        }
        public MsUser getUserByName(String UserName)
        {
            return UserRepo.getUserByName(UserName);
        }
        public int getStationeryIDByName(String StationeryName)
        {
            MsStationery newStationery = new MsStationery();
            newStationery = StatRepo.getStationeryByName(StationeryName);

            return newStationery.StationeryId;
        }
        public void deleteCart(int userID, int stationeryID)
        {
            CartRepo.deleteCart(userID, stationeryID);
        }
        public void createTransactionHeader(int UserID, DateTime TransactionDate)
        {
            THRepo.createTransactionHeader(UserID, TransactionDate);
        }

        public int getLastTransactionID()
        {
            return THRepo.getLastTransactionID();
        }
        public void createTransactionDetail(int TransactionID, int StationeryID, int Quantity)
        {
            TDRepo.createTransactionDetail(TransactionID, StationeryID, Quantity);
        }

        public void updateStationeryQuantity(int userID, int StationeryID, int quantity)
        {
            CartRepo.updateStationeryQuantity(userID, StationeryID, quantity);
        }
    }
}