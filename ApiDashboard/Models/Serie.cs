using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiDashboard.Models
{
    public class Serie
    {
        public string Label { get; set; }
        public float Value { get; set; }
        public string ValueLabel { get; set; }
        public string Color { get; set; }
    }
}