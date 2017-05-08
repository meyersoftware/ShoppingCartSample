using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartExample.Models
{
    public class Cart
    {
        public IList<Product> Products { get; set;}

        public Cart()
        {
            Products = new List<Product>();
        }
    }
}