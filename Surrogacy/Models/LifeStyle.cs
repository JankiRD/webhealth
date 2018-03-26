using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;

namespace Surrogacy.Models
{
    public class LifeStyle : BaseEntity
    {
        public String LifeStyleID { get; set; }
        public string UserID { get; set; }
        public string Smoke { get; set; }
        public string MemberSmoke { get; set; }
        public string Alcohol { get; set; }
        public string Drug { get; set; }
        public string Past { get; set; }
        public string SpouseDrug { get; set; }
        public string IsSubmit { get; set; }
    }
}