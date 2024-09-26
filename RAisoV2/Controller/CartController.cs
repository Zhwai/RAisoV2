using RAisoV2.Handler;
using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Controller
{
    public class CartController
    {

        CartHandler cartHandler = new CartHandler();
        public List<MsStationery> getAllStationaries()
        {
            return cartHandler.getAllStationaries();
        }
        public List<Cart> getAllCarts()
        {
            return cartHandler.getAllCarts();
        }

        public MsUser getUserByName(String UserName)
        {
            return cartHandler.getUserByName(UserName);
        }

        public int getStationeryIDByName(String StationeryName)
        {
            return cartHandler.getStationeryIDByName(StationeryName);
        }
        public void deleteCart(int userID, int stationeryID)
        {
            cartHandler.deleteCart(userID, stationeryID);
        }
        public void createTransactionHeader(int UserID, DateTime TransactionDate)
        {
            cartHandler.createTransactionHeader(UserID, TransactionDate);
        }
        public int getLastTransactionID()
        {
            return cartHandler.getLastTransactionID();
        }
        public void createTransactionDetail(int TransactionID, int StationeryID, int Quantity)
        {
            cartHandler.createTransactionDetail(TransactionID, StationeryID, Quantity);
        }

        public void updateStationeryQuantity(int userID, int StationeryID, int quantity)
        {
            cartHandler.updateStationeryQuantity(userID, StationeryID, quantity);
        }

        private bool validateQuantity(int quantity)
        {
            return quantity > 0;
        }

        private bool validateIsEmpty(string quantity)
        {
            return !string.IsNullOrWhiteSpace(quantity);
        }

        public string validate(string quantityString)
        {
            if (!validateIsEmpty(quantityString))
            {
                return "Quantity Must Be Filled";
            }

            if (!int.TryParse(quantityString, out int quantityInteger) || !validateQuantity(quantityInteger))
            {
                return "Quantity Must Be More Than 0";
            }

            return "Success";
        }

    }
}