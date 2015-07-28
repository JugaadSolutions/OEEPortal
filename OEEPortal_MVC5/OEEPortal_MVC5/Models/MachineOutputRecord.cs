using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class MachineOutputRecord
    {
        public int MachineOutputRecordId { get; set; }
        public string OperatorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double EquipmentBreakDown { get; set; }
        public double ChangeOver { get; set; }
        public double MaterialDownTime { get; set; }
        public double QuantityDownTime { get; set; }
        public double OtherNonProduct { get; set; }
        public double PreventiveMaintenance { get; set; }
        public double ManagementMeeting { get; set; }
        public double RegulatoryBreaks { get; set; }
        public double PilotRun { get; set; }
        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; }
        public int ReferenceId { get; set; }
        public virtual Reference Reference { get; set; }
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
       
    }
}