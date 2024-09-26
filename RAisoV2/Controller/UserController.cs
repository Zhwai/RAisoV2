using RAisoV2.Handler;
using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Controller
{
    public class UserController
    {
        private static UserHandler userHandler = new UserHandler();

        private bool checkDateAge(DateTime UserDOB)
        {
            DateTime Today = DateTime.Now;

            if (Today.Year - UserDOB.Year < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkDateEmpty(DateTime UserDOB)
        {
            if (UserDOB == null || UserDOB == DateTime.MinValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private bool checkName(String UserName)
        {
            if (UserName.Length < 5 || UserName.Length > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkNameUnique(String UserName)
        {
            if (userHandler.getUserByName(UserName) != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkGender(String UserGender)
        {
            if (string.IsNullOrWhiteSpace(UserGender) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkAddress(String UserAddress)
        {
            if (string.IsNullOrWhiteSpace(UserAddress) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkPhone(String UserPhone)
        {
            if (String.IsNullOrWhiteSpace(UserPhone) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkPasswordAlphanumeric(String UserPassword)
        {
            if (!(UserPassword.Any(c => char.IsLetter(c)) && UserPassword.Any(c => char.IsDigit(c))))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkPasswordEmpty(String UserPassword)
        {
            if (String.IsNullOrWhiteSpace(UserPassword) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkRole(String UserRole)
        {
            if (String.IsNullOrWhiteSpace(UserRole) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public String Validate(String UserName, String UserGender, String UserAddress, String UserPhone, DateTime UserDOB, String UserPassword, String UserRole)
        {

            if (checkName(UserName) == false)
            {
                return "Name Must be between 5 and 50 characters";
            }
            else if (checkNameUnique(UserName) == false)
            {
                return "Name Is Taken";
            }

            if (checkDateAge(UserDOB) == false)
            {
                return "DOB Must be at least 1 year of age";
            }
            else if (checkDateEmpty(UserDOB) == false)
            {
                return "DOB Must be filled";
            }

            if (checkGender(UserGender) == false)
            {
                return "Gender Must be selected";
            }

            if (checkAddress(UserAddress) == false)
            {
                return "Address Must be filled";
            }

            if (checkPasswordEmpty(UserPassword) == false)
            {
                return "Password Must Be Filled";
            }
            else if (checkPasswordAlphanumeric(UserPassword) == false)
            {
                return "Password Must Be Alphanumeric";
            }

            if (checkPhone(UserPhone) == false)
            {
                return "Phone Must be filled";
            }

            if (checkRole(UserRole) == false)
            {
                return "Role Must Be Filled";
            }

            createUser(UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword, UserRole);
            return "Sucess";
        }

        public void createUser(String UserName, String UserGender, DateTime UserDOB, String UserPhone, String UserAddress, String UserPassword, String UserRole)
        {
            userHandler.createUser(UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword, UserRole);
        }

        public String checkCredibility(string UserName, String Password)
        {

            if (userHandler.checkUserName(UserName) == false)
            {
                return "UserName Inccorect";
            }
            else if (userHandler.checkPassword(UserName, Password) == false)
            {
                return "Password Inccorect";
            }

            return "Success";
        }

        public bool checkRoles(String UserName)
        {
            if (userHandler.isAdmin(UserName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MsUser getUserByName(String UserName)
        {
            return userHandler.getUserByName(UserName);
        }

        public String updateValidate(String FirstUserName, String UserName, String UserGender, String UserAddress, String UserPhone, DateTime UserDOB, String UserPassword, String UserRole)
        {

            if (checkName(UserName) == false)
            {
                return "Name Must be between 5 and 50 characters";
            }

            else if (checkNameUnique(UserName) == false)
            {
                if (FirstUserName != UserName)
                {
                    return "Name Is Taken";
                }
            }

            if (checkDateAge(UserDOB) == false)
            {
                return "DOB Must be at least 1 year of age";
            }
            else if (checkDateEmpty(UserDOB) == false)
            {
                return "DOB Must be filled";
            }

            if (checkGender(UserGender) == false)
            {
                return "Gender Must be selected";
            }

            if (checkAddress(UserAddress) == false)
            {
                return "Address Must be filled";
            }

            if (checkPasswordEmpty(UserPassword) == false)
            {
                return "Password Must Be Filled";
            }
            else if (checkPasswordAlphanumeric(UserPassword) == false)
            {
                return "Password Must Be Alphanumeric";
            }

            if (checkPhone(UserPhone) == false)
            {
                return "Phone Must be filled";
            }

            if (checkRole(UserRole) == false)
            {
                return "Role Must Be Filled";
            }

            updateUser(FirstUserName, UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword, UserRole);
            return "Sucess";
        }

        public void updateUser(String FirstUserName, String UserName, String UserGender, DateTime UserDOB, String UserPhone, String UserAddress, String UserPassword, String UserRole)
        {
            userHandler.updateUser(FirstUserName, UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword, UserRole);
        }

    }
}