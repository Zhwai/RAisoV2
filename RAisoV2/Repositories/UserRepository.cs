using RAisoV2.Factories;
using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Repository
{
    public class UserRepository
    {
        LocaldatabaseEntities db = DatabaseSingleton.getInstance();

        private int generateID()
        {
            MsUser LastUser = db.MsUsers.ToList().LastOrDefault();

            if (LastUser == null)
            {
                return 1;
            }

            int LastIdNum = LastUser.UserId;
            int NewIdNum = LastIdNum + 1;

            return NewIdNum;
        }

        public void createUser(String UserName, String UserGender, DateTime UserDOB, String UserPhone, String UserAddress, String UserPassword, String UserRole)
        {
            MsUser newUser = UserFactory.createUser(generateID(), UserName, UserGender, UserDOB, UserPhone, UserAddress, UserPassword, UserRole);
            db.MsUsers.Add(newUser);
            db.SaveChanges();
        }

        public MsUser getUserByName(String UserName)
        {
            return (from x in db.MsUsers where x.UserName.Equals(UserName) select x).FirstOrDefault();
        }

        public MsUser getUserByID(int UserID)
        {
            return (from x in db.MsUsers where x.UserId == UserID select x).FirstOrDefault();
        }

        public int getIdByName(String name)
        {
            MsUser currentUser = getUserByName(name);

            return currentUser.UserId;
        }

        public void updateUser(String FirstUserName, String UserName, String UserGender, DateTime UserDOB, String UserPhone, String UserAddress, String UserPassword, String UserRole)
        {
            int id = getIdByName(FirstUserName);

            MsUser currentUser = db.MsUsers.Find(id);
            currentUser.UserName = UserName;
            currentUser.UserGender = UserGender;
            currentUser.UserDOB = UserDOB;
            currentUser.UserPhone = UserPhone;
            currentUser.UserAddress = UserAddress;
            currentUser.UserPassword = UserPassword;
            db.SaveChanges();
        }

    }
}