using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public string Name { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}