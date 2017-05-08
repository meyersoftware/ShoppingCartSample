using Newtonsoft.Json;
using ShoppingCartExample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartExample.Content
{
    public static class WCFRESTHelper
    {
        public static List<Product> GetProduct(int ProductID)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://scwcfrest.apphb.com/api/service/?id=" + ProductID);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var test = reader.ReadToEnd();

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(test);

            return products;
        }

        public static bool StoreCustomer(Customer customer)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            //JsonResult customerdata = new JsonResult();
            //customerdata.Data = customer;
            JsonSerializer js = JsonSerializer.Create();
            JsonWriter writer = new JsonTextWriter(sw);
            js.Serialize(writer, customer);

            var request = (HttpWebRequest)WebRequest.Create("http://scwcfrest.apphb.com/api/service/GetCustomer/?customer=" + sb);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            bool test = bool.Parse(reader.ReadToEnd());
            //this is fun
            return test;
        }
    }
}