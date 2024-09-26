using RAisoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoV2.Repository
{
    public class DatabaseSingleton
    {
        private static LocaldatabaseEntities db = null;
        public static LocaldatabaseEntities getInstance()
        {
            if (db == null)
            {
                db = new LocaldatabaseEntities();
            }
            return db;
        }
    }
}