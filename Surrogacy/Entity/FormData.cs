using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Surrogacy.Entity
{
    public class FormData
    {
        public FormData(FormInputType inputType, string Value, string Name, string DisplayText, bool IsRequired, bool? IsComparision = false, string CompareWith = default(string))
        {
            this.inputType = inputType;
            this.Name = Name;
            this.Value = Value;
            this.DisplayText = DisplayText;
            this.IsRequired = IsRequired;
            this.IsComparision = IsComparision;
            this.CompareWith = CompareWith;
        }

        public enum FormInputType
        {
            DropDownListValue,
            MobileNumber,
            PhoneNumber,
            Email,            
            Group,            
            Name,
            NameWithSpace,
            None,                       
            State,
            City,
            Age,
            DOB,
            Height,
            Weight,
            TextNotEmpty,
            NumericOrZero,
            Date
        }

        public FormInputType inputType { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string DisplayText { get; set; }
        public bool IsRequired { get; set; }
        public bool? IsComparision { get; set; }
        public string CompareWith { get; set; }
    }
}