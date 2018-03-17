using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Surrogacy.Entity
{
    public class SystemConfiguration
    {
        public int SystemSettingID { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
        public string DisplayText { get; set; }
        public int IsInternal { get; set; }
        public int IsActive { get; set; }
    }
}