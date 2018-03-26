using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;
using Surrogacy.Util;

namespace Surrogacy.Models
{
    public class User : BaseEntity
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? DOB { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }        
        public string UserRole { get; set; }
        public string UserRoleName { get; set; }
        public string IsActive { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string SessionId { get; set; }
        public MachineDetail machineDetail { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }
        public string SecQuestion { get; set; }
        public string SecAnswer { get; set; }
        public List<Contact> Contact { get; set; }
        public List<Address> Address { get; set; }
        public int? PasswordExpired { get; set; }
        public DateTime? LastPasswordExpired { get; set; }
        public int? ResetPassword { get; set; }
        public string IDProof { get; set; }
    }
}