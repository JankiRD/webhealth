using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;

namespace Surrogacy.Models
{
    public class Documents : BaseEntity
    {
        public string DocumentID { get; set; }
        public string UserID { get; set; }
        public string IDProof { get; set; }
        public string Pic { get; set; }
        public string FamilyPic { get; set; }
        public string UploadPath { get; set; }
        public string IsSubmit { get; set; }
    }
}