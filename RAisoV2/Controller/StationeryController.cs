using RAisoV2.Handler;
using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Controller
{
    public class StationeryController
    {
        private static StationeryHandler StatHandler = new StationeryHandler();

        public List<MsStationery> getAllStationaries()
        {
            return StatHandler.getAllStationaries();
        }

        public int getStationeryIDByName(String StationeryName)
        {
            return StatHandler.getStationeryIDByName(StationeryName);
        }

        public MsStationery getStationeryByID(int StationeryID)
        {
            return StatHandler.getStationeryByID(StationeryID);
        }

        private bool validateQuantity(int quantity)
        {
            if (quantity == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool validateIsEmpty(String quantity)
        {
            if (String.IsNullOrWhiteSpace(quantity) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public String validate(String quantityString)
        {
            if (validateIsEmpty(quantityString) == false)
            {
                return "Quantity Must Be Filled";
            }

            int quantityInteger = Convert.ToInt32(quantityString);

            if (validateQuantity(quantityInteger) == false)
            {
                return "Quantity Must Be More Than 0";
            }

            return "Success";
        }
        public int getIdByName(String name)
        {
            return StatHandler.getIdByName(name);
        }

        public void createCart(int UserID, int StationeryID, int Quantity)
        {
            StatHandler.createCart(UserID, StationeryID, Quantity);
        }

        public void deleteStationery(int id)
        {
            StatHandler.deleteStationery(id);
        }

        private bool checkIsEmpty(String check)
        {
            if (string.IsNullOrWhiteSpace(check) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validateName(String StationeryName)
        {
            if (StationeryName.Length < 3 || StationeryName.Length > 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkNumerical(String StationeryPrice)
        {
            if (double.TryParse(StationeryPrice, out _) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkPrice(int StationeryPrice)
        {
            if (StationeryPrice < 2000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public String validate(String StationeryName, String StationeryPrice)
        {
            if (checkIsEmpty(StationeryName) == false)
            {
                return "Name Must Be Filled";
            }

            if (validateName(StationeryName) == false)
            {
                return "Name Must Be In Lenght 3 - 50";
            }

            if (checkIsEmpty(StationeryPrice) == false)
            {
                return "Price Must Be Filled";
            }

            if (checkNumerical(StationeryPrice) == false)
            {
                return "Price Must Be Numerical";
            }

            int newPrice = Convert.ToInt32(StationeryPrice);

            if (checkPrice(newPrice) == false)
            {
                return "Price Must Be More Or Equal to 2000";
            }

            return "Success";
        }
        public void createStationery(String StationeryName, int StationeryPrice)
        {
            StatHandler.createStationery(StationeryName, StationeryPrice);
        }

        public void updateStationery(int id, String name, int price)
        {
            StatHandler.updateStationeryDetails(id, name, price);
        }

    }
}