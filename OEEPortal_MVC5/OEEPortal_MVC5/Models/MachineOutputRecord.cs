using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class MachineOutputRecord
    {
        public MachineOutputRecord()
        {

        }
        public int MachineOutputRecordId { get; set; }
        public string OperatorId { get; set; }
        public Nullable<DateTime> StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }
        public int OutputQuantity { get; set; }
        public int DefectQuantity { get; set; }
        public Nullable<TimeSpan> EquipmentBreakDownTime { get; set; }
        public Nullable<TimeSpan> ChangeOverTime { get; set; }
        public Nullable<TimeSpan> MaterialDownTime { get; set; }
        public Nullable<TimeSpan> QuantityDownTime { get; set; }
        public Nullable<TimeSpan> OtherNonProductTime { get; set; }
        public Nullable<TimeSpan> PreventiveMaintenanceTime { get; set; }
        public Nullable<TimeSpan> ManagementMeetingTime { get; set; }
        public Nullable<TimeSpan> RegulatoryBreaksTime { get; set; }
        public Nullable<TimeSpan> PilotRunTime { get; set; }
        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; }
        public int ReferenceId { get; set; }
        public virtual Reference Reference { get; set; }
    }
}