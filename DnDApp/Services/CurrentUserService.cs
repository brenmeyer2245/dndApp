using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.Models;
using DnDApp.DataBase;

namespace DnDApp.Services
{
    public class CurrentUserService
    {
        private readonly DnDAppDbContext _db = new DnDAppDbContext();


        public User GetCurrentUser()
        {
            //var upn = HttpContext.Current.User.Identity.Name?.ToLower();
            //if (string.IsNullOrEmpty(upn)) return null;

            if (null == HttpContext.Current.Session["CurrentUser"])
            {
                // HttpContext.Current.Session["CurrentUser"] = EnsureUser("dude");
                return new User {
                    Name = "N/A",
                    username = "N/A",
                    password = "N/A"
                    
                };
            }


            return (User)HttpContext.Current.Session["CurrentUser"];
        }
  


        private User EnsureUser(string upn)
        {
            //get the user from the db
            var user = (from u in _db.Users
                        where u.username == upn
                        select u).SingleOrDefault();

            if (null == user) 
            {
                user = new User()
                {
                    username = upn,
                    Name = upn
                };
            }
            
            return user;
        }

        public void SetCurrentUser(User user)
        {
            HttpContext.Current.Session.Add("CurrentUser", user);
        }

        public void ClearCurrentUser()
        {

           if (HttpContext.Current.Session != null && HttpContext.Current.Session["CurrentUser"] != null)
            {
                HttpContext.Current.Session["CurrentUser"] = null;
            }
        }

    }


}