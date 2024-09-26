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
    public class StationeryRepository
    {
        LocaldatabaseEntities db = DatabaseSingleton.getInstance();
        private int generateID()
        {
            MsStationery LastStationey = db.MsStationeries.ToList().LastOrDefault();

            if (LastStationey == null)
            {
                return 1;
            }

            int LastIdNum = LastStationey.StationeryId;
            int NewIdNum = LastIdNum + 1;

            return NewIdNum;
        }

        public List<MsStationery> getAllStationaries()
        {
            return (from x in db.MsStationeries select x).ToList();
        }

        public MsStationery getStationeryByName(String StationeryName)
        {
            return (from x in db.MsStationeries where x.StationeryName.Equals(StationeryName) select x).FirstOrDefault();
        }

        public MsStationery getStationeryByID(int StationeryID)
        {
            return (from x in db.MsStationeries where x.StationeryId == StationeryID select x).FirstOrDefault();
        }

        public void createStationery(String StationeryName, int StationeryPrice)
        {
            MsStationery newStationery = StationeryFactory.createStationery(generateID(), StationeryName, StationeryPrice);
            db.MsStationeries.Add(newStationery);
            db.SaveChanges();
        }
        public void updateStationeryDetails(int id, String name, int price)
        {
            MsStationery UpdateStationery = db.MsStationeries.Find(id);
            UpdateStationery.StationeryName = name;
            UpdateStationery.StationeryPrice = price;
            db.SaveChanges();
        }

        public void deleteStationery(int StationeryID)
        {
            MsStationery DeleteStationery = db.MsStationeries.Find(StationeryID);
            db.MsStationeries.Remove(DeleteStationery);
            db.SaveChanges();
        }
    }
}