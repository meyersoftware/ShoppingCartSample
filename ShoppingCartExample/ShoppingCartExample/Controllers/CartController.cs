using Newtonsoft.Json;
using ShoppingCartExample.Models;
using ShoppingCartExample.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartExample.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Cart sessionCart = new Cart();

            if (!Session.IsNewSession)
            {
                sessionCart = (Cart)Session["Cart"];
                return View(sessionCart.Products);
            }

            return View();
        }

        public ActionResult Add(int ProductID)
        {
            Cart sessionCart = new Cart();
            if (!Session.IsNewSession)
            {
                sessionCart = (Cart)Session["Cart"];
            }

            List<Product> products = WCFRESTHelper.GetProduct(ProductID);

            var item = sessionCart.Products.ToList().SingleOrDefault(x => x.ProductID == ProductID);
            if (item != null)
            {
                item.Count++;
            }
            else
            {
                sessionCart.Products.Add(products[0]);
            }

            Session["Cart"] = sessionCart;

            return View("Index", sessionCart.Products);
        }

        public ActionResult Remove(int ProductID)
        {
            List<Product> products = WCFRESTHelper.GetProduct(ProductID);
            Cart sessionCart = (Cart)Session["Cart"];

            var item = sessionCart.Products.ToList().SingleOrDefault(x => x.ProductID == ProductID);
            if (item != null && item.Count == 1)
            {
                sessionCart.Products.Remove(item);
            }
            else if (item != null)
            {
                item.Count--;
            }

            Session["Cart"] = sessionCart;

            if (sessionCart.Products.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}