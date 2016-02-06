using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public class Company
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Offers { get; set; }
        public double Discount { get; set; }
    }
}