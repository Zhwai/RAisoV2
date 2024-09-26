using RAisoV2.Factories;
using RAisoV2.Models;
using RAisoV2.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RAisoV2.Repositories
{
    public class CartRepository
    {
        LocaldatabaseEntities db = DatabaseSingleton.getInstance();

        public void createCart(int UserId, int StationeryId, int Quantity)
        {
            List<Cart> currentCart = new List<Cart>();
            currentCart = getAllCarts();

            Cart checkCart = currentCart.FirstOrDefault(x => x.UserId == UserId && x.StationeryId == StationeryId);

            if (checkCart == null)
            {
                Cart newCart = CartFactory.createCart(UserId, StationeryId, Quantity);
                db.Carts.Add(newCart);
                db.SaveChanges();
            }
            else
            {
                updateStationeryQuantityAdded(UserId, StationeryId, Quantity);
            }
        }
        public List<Cart> getAllCarts()
        {
            return (from x in db.Carts select x).ToList();
        }

        public void updateStationeryQuantity(int UserId, int StationeryId, int quantity)
        {
            Cart cart = db.Carts.FirstOrDefault(x => x.UserId == UserId && x.StationeryId == StationeryId);
            cart.Quantity = quantity;
            db.SaveChanges();
        }

        public void updateStationeryQuantityAdded(int UserId, int StationeryId, int quantity)
        {
            Cart cart = db.Carts.FirstOrDefault(x => x.UserId == UserId && x.StationeryId == StationeryId);
            cart.Quantity = cart.Quantity + quantity;
            db.SaveChanges();
        }

        public void deleteCart(int UserId, int StationeryId)
        {
            Cart cart = db.Carts.FirstOrDefault(x => x.UserId == UserId && x.StationeryId == StationeryId);
            db.Carts.Remove(cart);
            db.SaveChanges();
        }
    }
}