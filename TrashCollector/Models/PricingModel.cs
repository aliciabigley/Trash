using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PricingModel
    {
        public int id { get; set; }
        public string Service { get; set; }
        public double Price { get; set; }
    }
}