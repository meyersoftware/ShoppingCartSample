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

            int customerID = WCFRESTHelper.StoreCustomer(user.ToCustomer(user));

            Cart sessionCart = (Cart)Session["Cart"];

            foreach(Product p in sessionCart.Products)
            {
                WCFRESTHelper.StoreOrders(customerID, p.ProductID, p.Count);
            }
            
            return RedirectToAction("GoodJob");
        }

        [HttpGet]
        public ActionResult GoodJob()
        {

            return View();
        }
    }
}