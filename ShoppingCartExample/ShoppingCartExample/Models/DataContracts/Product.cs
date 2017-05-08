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
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ProductDescription { get; set; }

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        [DataMember]
        public int Stock { get; set; }

        [DataMember]
        public int SortOrder { get; set; }

        [DataMember]
        public string Image { get; set; }

        public int Count { get; set; }

        Product()
        {
            Count = 1;
        }
    }
}