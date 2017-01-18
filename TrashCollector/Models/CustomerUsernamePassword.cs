using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class CustomerUsernamePassword
    {
        
        public int id { get; set; }
        [Required]
        public CustomerModel Customer { get; set; }
        public int Customerid { get; set; }
        [Required]
        public string Password { get; set; }

    }
}