using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Surrogacy.Entity;
using Surrogacy.Util;

namespace Surrogacy.Models
{
    public class MedicalInfo : BaseEntity
    {
        public string MedicalInfoID { set; get; }
        public string UserID { set; get; }
        public string Ablation { set; get; }
        public string WeightLoss { set; get; }
        public string Medical { set; get; }
        public string MedicalDetail { set; get; }
        public string Medication { set; get; }
        public string MedicationDetail { set; get; }
        public string BreastFeeding { set; get; }
        public string Periods { set; get; }
        public int IsSubmit { set; get; }
    }
}