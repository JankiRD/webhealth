using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Surrogacy.Entity;
using Surrogacy.Util;

namespace Surrogacy.Models
{
    public class SurrogatePersonalInfo : BaseEntity
    {
        public string SurrogateID { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DOB { get; set; }
        public int? Age { get; set; }
        public string Citizenship { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string MaritalStatus { get; set; }
        public string SpouseFullName { get; set; }
        public string SpouseDOB { get; set; }
        public string NoOfChild { get; set; }
        public string StepChild { get; set; }
        public string ChildDescription { get; set; }
        public string Pregnant { get; set; }
        public string Adopted { get; set; }
        public string Residence { get; set; }
        public string EthnicBackGround { get; set; }
        public int IsSubmit { get; set; }
    }
}
