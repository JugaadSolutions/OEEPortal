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
       
        public int[] Machines { get; set; }
    }

    public class ShiftCumulativeFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int[] Shifts { get; set; }
    }

    public class DailyCumulativeFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

    public class MonthlyCumulativeFilter
    {
        public int[] Months { get; set; }
    }

   public class MachineFilter
   {
       public int[] Machines { get; set; }
   }
}