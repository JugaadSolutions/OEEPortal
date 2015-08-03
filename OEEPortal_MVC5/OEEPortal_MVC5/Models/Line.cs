using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class Line
    {
        
        public int LineId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
    }
}