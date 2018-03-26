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
        public string List { get; set; }
        public string Treatment { get; set; }
        public string Complication { get; set; }
        public string Desc { get; set; }
        public string ChildDeath { get; set; }
        public string Problem { get; set; }
        public int IsSubmit { get; set; }
    }
}