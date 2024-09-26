using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Factories
{
    public class StationeryFactory
    {
        public static MsStationery createStationery(int StationeryId, String StationeryName, int StationeryPrice)
        {
            MsStationery newStationery = new MsStationery()
            {
                StationeryId = StationeryId,
                StationeryName = StationeryName,
                StationeryPrice = StationeryPrice,
            };
            return newStationery;
        }
    }
}