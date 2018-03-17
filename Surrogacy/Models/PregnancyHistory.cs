using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Surrogacy.Entity;
using Surrogacy.Util;


namespace Surrogacy.Models
{
    public class PregnancyHistory : BaseEntity
    {
        public string PregnancyHistoryID { get; set; }
        public string UserID { get; set; }
        public Int16 NoOfPregnancy { get; set; }
        public Int16 NoStillBirth { get; set; }
        public Int16 NoMisCarriage { get; set; }
        public Int16 NoLiveBirth { get; set; }
        public Int16 NoAbortion { get; set; }
        public String List { get; set; }
        public String Treatment { get; set; }
        public String Complication { get; set; }
        public String Desc { get; set; }
        public String ChildDeath { get; set; }
        public String Problem { get; set; }
        public int IsSubmit { get; set; }
    }
}