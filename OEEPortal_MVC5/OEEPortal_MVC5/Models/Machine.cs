using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string Name { get; set; }

        public int LineID { get; set; }
        public virtual Line Line { get; set; }

        public virtual ICollection<MachineOutputRecord> MachineOutputRecords { get; set; }
    }
}