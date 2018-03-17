using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Surrogacy.Entity;
using Surrogacy.Util;

namespace Surrogacy.Models
{
    public class Dashboard : BaseEntity
    {
        public int ID { set; get; }
        public string UserID { get; set; }
        public string FormName { get; set; }
        public string ApprovalStatus { get; set; }
        public string IsSubmitted { get; set; }
        public decimal Percentage { get; set; }
    }
}