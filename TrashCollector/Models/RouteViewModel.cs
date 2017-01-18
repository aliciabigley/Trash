using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrashCollector.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core;
using static TrashCollector.Models.CustomerModel;
namespace TrashCollector.Models
{
    public class RouteViewModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int Customerid { get; set; }
        public virtual CustomerModel Customer { get; set; }
       
    }
}