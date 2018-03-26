using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;

namespace Surrogacy.Models
{
    public class FinalSubmit : BaseEntity
    {
        public string FinalSubmitID { get; set; }
        public string UserID { get; set; }
        public bool Agree { get; set; }
        public string SurrogateSignature { get; set; }
        public string SignDate { get; set; }
        public string IsSubmitted { get; set; }
    }
}