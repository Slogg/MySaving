using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySaving.Models
{
    public class SpecificationModel
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Service { get; set; }
        public double Duration { get; set; }
        public string Type { get; set; }
        public string Operator { get; set; }
    }
}
