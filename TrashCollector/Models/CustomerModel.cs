using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class CustomerModel
    {
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Street { get; set; }
        public string Steet_2 { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
    }
}