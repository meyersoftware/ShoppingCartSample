using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using ShoppingCartExample.Models;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using ShoppingCartExample.Content;

namespace ShoppingCartExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = WCFRESTHelper.GetProduct(0);
            return View(products);
        }

        public ActionResult Landing()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}