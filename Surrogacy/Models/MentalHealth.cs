using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Surrogacy.Entity;
using Surrogacy.Util;

namespace Surrogacy.Models
{
    public class MentalHealth : BaseEntity
    {
        public string MentalHealthID { get; set; }
        public string UserID { get; set; }
        public Int16 Depression { get; set; }
        public Int16 Illness { get; set; }
        public Int16 Suicide { get; set; }
        public Int16 Thoughts { get; set; }
        public Int16 Professional { get; set; }
        public string Details { get; set; }
        public int IsSubmit { get; set; }

    }
}