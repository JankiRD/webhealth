using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Util;

namespace Surrogacy.Entity
{
    public class MachineDetail
    {
        public MachineType MachineType { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
    }
}