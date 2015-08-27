using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class LogFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    public class MachineCumulativeFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Boolean ShiftA { get; set; }
        public Boolean ShiftB { get; set; }
        public Boolean ShiftC { get; set; }
        public int[] Machines { get; set; }
    }
}