using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class Reference
    {
        public Reference() {
            this.Machine = new HashSet<Machine>();
    }
        public int ReferenceId { get; set; }
        public string Name { get; set; }
        public double UsefullTme { get; set; }
        public virtual ICollection<Machine> Machine{ get; set; }
        public virtual ICollection<MachineOutputRecord> MachineOutputRecords { get; set; }
    }
}