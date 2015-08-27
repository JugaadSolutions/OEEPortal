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
        public bool ShiftA { get; set; }
        public bool ShiftB { get; set; }
        public bool ShiftC { get; set; }
        public int[] Machines { get; set; }
    }
}