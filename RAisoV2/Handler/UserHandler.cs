using RAisoV2.Models;
using RAisoV2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Handler
{
    public class UserHandler
    {
        private static UserRepository UserRepo = new UserRepository();
        MsUser currentUser = new MsUser();
        public void createUser(String UserName, String UserGender, DateTime UserDOB, String UserPhone, String UserAddress, String UserPassword, String UserRole)
        {
            UserRepo.createUser(UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword, UserRole);
        }

        public MsUser getUserByName(String UserName)
        {
            return UserRepo.getUserByName(UserName);
        }

        public bool checkUserName(String UserName)
        {
            currentUser = UserRepo.getUserByName(UserName);

            if (currentUser == null)
            {
                return false;
            }
            else if (!UserName.Equals(currentUser.UserName))
            {
                return false;
            }

            return true;
        }

        public bool checkPassword(String UserName, String password)
        {
            currentUser = UserRepo.getUserByName(UserName);

            if (!password.Equals(currentUser.UserPassword))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isAdmin(String UserName)
        {
            currentUser = UserRepo.getUserByName(UserName);

            if (currentUser.UserRole.Equals("Admin"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void updateUser(String FirstUserName, String UserName, String UserGender, DateTime UserDOB, String UserPhone, String UserAddress, String UserPassword, String UserRole)
        {
            UserRepo.updateUser(FirstUserName, UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword, UserRole);
        }

    }
}