using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;

namespace Surrogacy.Models
{
    public class DoctorDashboard : BaseEntity
    {
        public string UserID { get; set; }
        public string ApprovedApplication { get; set; }
        public string RejectedApplication { get; set; }
        public string PendingApplicaion { get; set; }
        public string NAApplication { get; set; }
    }
}