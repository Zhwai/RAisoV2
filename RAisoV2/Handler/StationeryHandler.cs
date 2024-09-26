using RAisoV2.Models;
using RAisoV2.Repositories;
using RAisoV2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Handler
{
    public class StationeryHandler
    {
        private static StationeryRepository StatRepo = new StationeryRepository();
        private static UserRepository UserRepo = new UserRepository();
        private static CartRepository CartRepo = new CartRepository();

        public List<MsStationery> getAllStationaries()
        {
            return StatRepo.getAllStationaries();
        }

        public int getStationeryIDByName(String StationeryName)
        {
            MsStationery newStationery = new MsStationery();
            newStationery = StatRepo.getStationeryByName(StationeryName);

            return newStationery.StationeryId;
        }

        public MsStationery getStationeryByID(int StationeryID)
        {
            return StatRepo.getStationeryByID(StationeryID);
        }

        public int getIdByName(String name)
        {
            return UserRepo.getIdByName(name);
        }

        public void createCart(int UserID, int StationeryID, int Quantity)
        {
            CartRepo.createCart(UserID, StationeryID, Quantity);
        }

        public void deleteStationery(int id)
        {
            StatRepo.deleteStationery(id);
        }

        public void createStationery(String StationeryName, int StationeryPrice)
        {
            StatRepo.createStationery(StationeryName, StationeryPrice);
        }

        public void updateStationeryDetails(int id, String name, int price)
        {
            StatRepo.updateStationeryDetails(id, name, price);
        }

    }
}