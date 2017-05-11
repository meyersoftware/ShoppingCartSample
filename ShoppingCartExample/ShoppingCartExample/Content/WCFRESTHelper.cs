using Newtonsoft.Json;
using ShoppingCartExample.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

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

        public static int StoreCustomer(Customer customer)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            //JsonResult customerdata = new JsonResult();
            //customerdata.Data = customer;
            JsonSerializer js = JsonSerializer.Create();
            JsonWriter writer = new JsonTextWriter(sw);
            //writer.WriteStartObject();
            //writer.WriteEnd();
            js.Serialize(writer, customer);

            var request = (HttpWebRequest)WebRequest.Create("http://localhost:59001/api/service/GetCustomer/?customer=" + sb);
            request.ContentType = "application/json";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            int customerID = int.Parse(reader.ReadToEnd());
            //this is fun
            return customerID;
        }
    }
}