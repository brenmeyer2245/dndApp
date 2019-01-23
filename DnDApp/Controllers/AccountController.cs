using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDApp.Models;
using DnDApp.Repositories;
using DnDApp.Services;

namespace DnDApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly CurrentUserService userService = new CurrentUserService();
        private readonly UserRepository userRepository = new UserRepository();
        // GET: Account
        public ActionResult SignIn()
        {
            return View();
        }

  
        [HttpPost]
        public ActionResult SignIn([Bind(Include = "username, password")] User user)
        {

            var myUser = userRepository.GetUser(user.username, user.password);
                if (null == myUser)
                {
                  return  RedirectToAction("Index", "Book");
                }
                userService.SetCurrentUser(myUser);
               
                return RedirectToAction("Index", "Book");
            
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            userService.ClearCurrentUser();
            return View();
        }

    }
}
