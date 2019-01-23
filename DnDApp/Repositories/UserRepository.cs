using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.DataBase;
using DnDApp.Models;

namespace DnDApp.Repositories
{

    public class UserRepository
    {
        private readonly DnDAppDbContext _db = new DnDAppDbContext();
        public User GetUser(int id)
        {
            return _db.Users.SingleOrDefault(_ => _.UserId == id);
        }

        public User GetUser(string username, string password)
        {
            return _db.Users.SingleOrDefault(_ => _.username == username && _.password == password);
        }
    }
}