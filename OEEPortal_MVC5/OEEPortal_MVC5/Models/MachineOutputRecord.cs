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


        public Nullable<TimeSpan> EquipmentBreakDownStart{ get; set; }
        public Nullable<TimeSpan> EquipmentBreakDownEnd{ get; set; }

        public Nullable<TimeSpan> ChangeOverStart { get; set; }
        public Nullable<TimeSpan> ChangeOverEnd { get; set; }

        public Nullable<TimeSpan> MaterialDownStart { get; set; }
        public Nullable<TimeSpan> MaterialDownEnd { get; set; }

        public Nullable<TimeSpan> QualityDownStart { get; set; }
        public Nullable<TimeSpan> QualityDownEnd { get; set; }

        public Nullable<TimeSpan> NonProductionStart { get; set; }
        public Nullable<TimeSpan> NonProductionEnd { get; set; }

        public Nullable<TimeSpan> PreventiveMaintenanceStart { get; set; }
        public Nullable<TimeSpan> PreventiveMaintenanceEnd { get; set; }

        public Nullable<TimeSpan> ManagementMeetingStart { get; set; }
        public Nullable<TimeSpan> ManagementMeetingEnd { get; set; }

        public Nullable<TimeSpan> RegulatoryBreaksStart { get; set; }
        public Nullable<TimeSpan> RegulatoryBreaksEnd { get; set; }

        public Nullable<TimeSpan> PilotRunStart { get; set; }
        public Nullable<TimeSpan> PilotRunEnd { get; set; }

        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; }

        public int ReferenceId { get; set; }
        public virtual Reference Reference { get; set; }

        
    }
}