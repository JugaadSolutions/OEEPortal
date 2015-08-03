using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class ReferenceMachine
    {
        public int ReferenceMachineId { get; set; }
        public double UsefullTime { get; set; }
        public int ReferenceId { get; set; }
        public virtual Reference Reference { get; set; }
        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; }
    }
}