using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class Reference
    {
        public Reference() {
         
    }
        public int ReferenceId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ReferenceMachine> ReferenceMachine { get; set; }
        public virtual ICollection<MachineOutputRecord> MachineOutputRecords { get; set; }
    }

    public class ReferenceVM
    {
        public int ReferenceId { get; set; }
        public String Name { get; set; }
        public double UsefullTime { get; set; }
    }
}