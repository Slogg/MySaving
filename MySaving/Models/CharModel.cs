using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySaving.Models
{
    public class CharModel
    {
        public double DurationOperator { get; set; }
        public DateTime DateFirst { get; set; }
        public DateTime DateLast { get; set; }
        public string Type { get; set; }
        public string Service { get; set; }
    }
}
