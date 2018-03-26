using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;

namespace Surrogacy.Models
{
    public class InfoSurrogate : BaseEntity
    {
        public string SurrogateID { get; set; }
        public string ApprovalStatus { get; set; }
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
        public string SurrogateBefore { get; set; }
        public string DetailSurrogate { get; set; }
        public string EggDonate { get; set; }
        public string DetailEggDonate { get; set; }
        public string Ablation { set; get; }
        public string WeightLoss { set; get; }
        public string Medical { set; get; }
        public string MedicalDetail { set; get; }
        public string Medication { set; get; }
        public string MedicationDetail { set; get; }
        public string BreastFeeding { set; get; }
        public string Periods { set; get; }
        public string NoOfPregnancy { get; set; }
        public string NoStillBirth { get; set; }
        public string NoMisCarriage { get; set; }
        public string NoLiveBirth { get; set; }
        public string NoAbortion { get; set; }
        public string List { get; set; }
        public string Treatment { get; set; }
        public string Complication { get; set; }
        public string Desc { get; set; }
        public string ChildDeath { get; set; }
        public string Problem { get; set; }
        public string Depression { get; set; }
        public string Illness { get; set; }
        public string Suicide { get; set; }
        public string Thoughts { get; set; }
        public string Professional { get; set; }
        public string Details { get; set; }
        public string Smoke { get; set; }
        public string MemberSmoke { get; set; }
        public string Alcohol { get; set; }
        public string Drug { get; set; }
        public string Past { get; set; }
        public string SpouseDrug { get; set; }
        public string DoctorApprovalStatusID { get; set; }
        public string Description { get; set; }
    }
}