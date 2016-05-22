using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public class Member
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        [ForeignKey("Contact")] 
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }

        [ForeignKey("Company")] 
        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}