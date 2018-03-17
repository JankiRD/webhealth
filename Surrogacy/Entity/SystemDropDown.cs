using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Surrogacy.Entity
{
    public class SystemDropDown
    {
        public SystemDropDown()
        {

        }

        public SystemDropDown(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
        public string Category { get; set; }
        public string ParentCategory { get; set; }
        public string ParentValue { get; set; }
        public string ParentKey { get; set; }
        public string DisplayText { get; set; }
    }
}