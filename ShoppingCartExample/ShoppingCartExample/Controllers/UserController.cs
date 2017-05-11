using ShoppingCartExample.Content;
using ShoppingCartExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartExample.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            //User user = new User();
            //return View(user);
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            WCFRESTHelper.StoreCustomer(user.ToCustomer(user));
            return RedirectToAction("GoodJob");
        }
    }
}