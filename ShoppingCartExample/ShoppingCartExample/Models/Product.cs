using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShoppingCartExample.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        
        public string Name { get; set; }
        
        public string ProductDescription { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
        
        public int Stock { get; set; }
        
        public int SortOrder { get; set; }
        
        public string Image { get; set; }

        public int Count { get; set; }

        Product()
        {
            Count = 1;
        }
    }
}