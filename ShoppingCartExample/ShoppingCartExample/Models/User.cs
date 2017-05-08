using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartExample.Models
{
    public class User
    {
        [Required(ErrorMessage = "You don't know your first name?")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "You don't know your last name? Or are you too cool for one?")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "How do you get home if you don't know your address?")]
        public string Address { get; set; }

        public string Address2 { get; set; }

        [Required(ErrorMessage = "The city you're in. Right now. Ask the police, that should work out.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Not of mind. Where the lines are drawn on the map.")]
        public string State { get; set; }

        [Required(ErrorMessage = "I'll give you a hint: it's 5 digits.")]
        public string Zip { get; set; }

        public string Status { get; set; }

        public User()
        {
            Status = "Don't worry about payment information. This one's on the house.";
        }
    }
}