using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;

namespace Surrogacy.Models
{
    public class ListSurrogate : BaseEntity
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string SurrogateUserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Citizenship { get; set; } 
        public string ApprovalStatus { get; set; }
    }
}