using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Surrogacy.Entity;
using Surrogacy.Util;

namespace Surrogacy.Models
{
    public class SurrogacyHistory : BaseEntity
    {
        public string SurrogacyHistoryID { get; set; }
        public string UserID { get; set; }
        public string SurrogateBefore { get; set; }
        public string DetailSurrogate { get; set; }
        public string EggDonate { get; set; }
        public string DetailEggDonate { get; set; }
        public int IsSubmit { get; set; }

    }
}