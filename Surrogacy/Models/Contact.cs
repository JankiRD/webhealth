using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;
using Surrogacy.Util;

namespace Surrogacy.Models
{
    public class Contact : BaseEntity
    {
        public string ContactID { get; set; }
        public string EntityID { get; set;  }
        public string EntityTypeID { get; set; }
        public string ContactName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactType contactType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }        
        public bool IsPrimary { get; set; }
    }
}