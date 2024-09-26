using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Factories
{
    public class CartFactory
    {
        public static Cart createCart(int UserID, int StationeryID, int Quantity)
        {
            Cart newCart = new Cart()
            {
                UserId = UserID,
                StationeryId = StationeryID,
                Quantity = Quantity
            };
            return newCart;
        }
    }
}