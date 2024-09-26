using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Factories
{
    public class UserFactory
    {
        public static MsUser createUser(int UserId, String UserName, String UserGender, DateTime UserDOB, String UserPhone, String UserAddress, String UserPassword, String UserRole)
        {
            MsUser newUser = new MsUser()
            {
                UserId = UserId,
                UserName = UserName,
                UserGender = UserGender,
                UserDOB = UserDOB,
                UserPhone = UserPhone,
                UserAddress = UserAddress,
                UserPassword = UserPassword,
                UserRole = UserRole,
            };
            return newUser;
        }

    }
}