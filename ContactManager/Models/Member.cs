using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public class Member
    {
        public string UserName { get; set; }
        public string MemberId { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }        
    }
}