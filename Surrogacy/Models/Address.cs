using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;

namespace Surrogacy.Models
{
    public class Address: BaseEntity
    {
        public string AddressID { get; set; }
        public string AddressTypeID { get; set; }
        public string EntityID { get; set; }
        public string EntityTypeID { get; set; }        
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIPCode { get; set; }
        public string PINCode { get; set; }
        public string Country { get; set; }
        public bool IsPrimary { get; set; }
    }
}