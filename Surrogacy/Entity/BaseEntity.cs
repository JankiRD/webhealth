using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Util;

namespace Surrogacy.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            responseDetail = new ResponseDetail();
        }

        public string InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string ChangeBy { get; set; }
        public EntityState EntityState { get; set; }
        public ResponseDetail responseDetail { get; set; }
    }
}