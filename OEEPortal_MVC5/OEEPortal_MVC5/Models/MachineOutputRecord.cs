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


        public Nullable<DateTime> EquipmentBreakDownStart { get; set; }
        public Nullable<DateTime> EquipmentBreakDownEnd { get; set; }

        public Nullable<DateTime> ChangeOverStart { get; set; }
        public Nullable<DateTime> ChangeOverEnd { get; set; }

        public Nullable<DateTime> MaterialDownStart { get; set; }
        public Nullable<DateTime> MaterialDownEnd { get; set; }

        public Nullable<DateTime> QualityDownStart { get; set; }
        public Nullable<DateTime> QualityDownEnd { get; set; }

        public Nullable<DateTime> NonProductionStart { get; set; }
        public Nullable<DateTime> NonProductionEnd { get; set; }

        public Nullable<DateTime> PreventiveMaintenanceStart { get; set; }
        public Nullable<DateTime> PreventiveMaintenanceEnd { get; set; }

        public Nullable<DateTime> ManagementMeetingStart { get; set; }
        public Nullable<DateTime> ManagementMeetingEnd { get; set; }

        public Nullable<DateTime> RegulatoryBreaksStart { get; set; }
        public Nullable<DateTime> RegulatoryBreaksEnd { get; set; }

        public Nullable<DateTime> PilotRunStart { get; set; }
        public Nullable<DateTime> PilotRunEnd { get; set; }

        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; }

        public int ReferenceId { get; set; }
        public virtual Reference Reference { get; set; }


       

    }

    public class MachineOutput
    {
        public String Machine { get; set; }
        public String Shift { get; set; }
        public double UsefullTime { get; set; }

        public Nullable<DateTime> StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }

        public int OutputQuantity { get; set; }
        public int DefectQuantity { get; set; }


        public Nullable<DateTime> EquipmentBreakDownStart { get; set; }
        public Nullable<DateTime> EquipmentBreakDownEnd { get; set; }

        public Nullable<DateTime> ChangeOverStart { get; set; }
        public Nullable<DateTime> ChangeOverEnd { get; set; }

        public Nullable<DateTime> MaterialDownStart { get; set; }
        public Nullable<DateTime> MaterialDownEnd { get; set; }

        public Nullable<DateTime> QualityDownStart { get; set; }
        public Nullable<DateTime> QualityDownEnd { get; set; }

        public Nullable<DateTime> NonProductionStart { get; set; }
        public Nullable<DateTime> NonProductionEnd { get; set; }

        public Nullable<DateTime> PreventiveMaintenanceStart { get; set; }
        public Nullable<DateTime> PreventiveMaintenanceEnd { get; set; }

        public Nullable<DateTime> ManagementMeetingStart { get; set; }
        public Nullable<DateTime> ManagementMeetingEnd { get; set; }

        public Nullable<DateTime> RegulatoryBreaksStart { get; set; }
        public Nullable<DateTime> RegulatoryBreaksEnd { get; set; }

        public Nullable<DateTime> PilotRunStart { get; set; }
        public Nullable<DateTime> PilotRunEnd { get; set; }

        public bool Normalize(DateTime rangeStart, DateTime rangeEnd)
        {
            bool result = false;
            if ((StartTime <= rangeStart) && (EndTime < rangeEnd) && (StartTime < rangeEnd) && (EndTime > rangeStart))
            {
                StartTime = rangeStart;
                result = true;
            }

            else if ((StartTime <= rangeEnd) && (EndTime > rangeEnd) && (StartTime < rangeEnd) && (EndTime > rangeStart))
            {
                EndTime = rangeEnd;
                result = true;

            }

            else if ((StartTime >= rangeStart) && (EndTime < rangeEnd) && (StartTime < rangeEnd) && (EndTime > rangeStart))
            {
                result = true;

            }
            else
                return result;

            if ((EquipmentBreakDownStart <= rangeStart) && (EquipmentBreakDownEnd < rangeEnd) &&
                (EquipmentBreakDownStart < rangeEnd) && (EquipmentBreakDownEnd > rangeStart))
            {
                EquipmentBreakDownStart = rangeStart;
            }

            if ((EquipmentBreakDownStart <= rangeEnd) && (EquipmentBreakDownEnd > rangeEnd) &&
                (EquipmentBreakDownStart < rangeEnd) && (EquipmentBreakDownEnd > rangeStart))
            {
                EquipmentBreakDownEnd = rangeEnd;
            }


            if ((ChangeOverStart <= rangeStart) && (ChangeOverEnd < rangeEnd) &&
                (ChangeOverStart < rangeEnd) && (ChangeOverEnd > rangeStart))
            {
                ChangeOverStart = rangeStart;
            }

            if ((ChangeOverStart <= rangeEnd) && (ChangeOverEnd > rangeEnd) &&
                (ChangeOverStart < rangeEnd) && (ChangeOverEnd > rangeStart))
            {
                ChangeOverEnd = rangeEnd;
            }



            if ((MaterialDownStart <= rangeStart) && (MaterialDownEnd < rangeEnd) &&
                (MaterialDownStart < rangeEnd) && (MaterialDownEnd > rangeStart))
            {
                MaterialDownStart = rangeStart;
            }

            if ((MaterialDownStart <= rangeEnd) && (MaterialDownEnd > rangeEnd) &&
                (MaterialDownStart < rangeEnd) && (MaterialDownEnd > rangeStart))
            {
                MaterialDownEnd = rangeEnd;
            }


            if ((QualityDownStart <= rangeStart) && (QualityDownEnd < rangeEnd) &&
                (QualityDownStart < rangeEnd) && (QualityDownEnd > rangeStart))
            {
                QualityDownStart = rangeStart;
            }

            if ((QualityDownStart <= rangeEnd) && (QualityDownEnd > rangeEnd) &&
                (QualityDownStart < rangeEnd) && (QualityDownEnd > rangeStart))
            {
                QualityDownEnd = rangeEnd;
            }



            if ((NonProductionStart <= rangeStart) && (NonProductionEnd < rangeEnd) &&
                (NonProductionStart < rangeEnd) && (NonProductionEnd > rangeStart))
            {
                NonProductionStart = rangeStart;
            }

            if ((NonProductionStart <= rangeEnd) && (NonProductionEnd > rangeEnd) &&
                (NonProductionStart < rangeEnd) && (NonProductionEnd > rangeStart))
            {
                NonProductionEnd = rangeEnd;
            }



            if ((PreventiveMaintenanceStart <= rangeStart) && (PreventiveMaintenanceEnd < rangeEnd) &&
                (PreventiveMaintenanceStart < rangeEnd) && (PreventiveMaintenanceEnd > rangeStart))
            {
                PreventiveMaintenanceStart = rangeStart;
            }

            if ((PreventiveMaintenanceStart <= rangeEnd) && (PreventiveMaintenanceEnd > rangeEnd) &&
                (PreventiveMaintenanceStart < rangeEnd) && (PreventiveMaintenanceEnd > rangeStart))
            {
                PreventiveMaintenanceEnd = rangeEnd;
            }


            if ((ManagementMeetingStart <= rangeStart) && (ManagementMeetingEnd < rangeEnd) &&
                (ManagementMeetingStart < rangeEnd) && (ManagementMeetingEnd > rangeStart))
            {
                ManagementMeetingStart = rangeStart;
            }

            if ((ManagementMeetingStart <= rangeEnd) && (ManagementMeetingEnd > rangeEnd) &&
                (ManagementMeetingStart < rangeEnd) && (ManagementMeetingEnd > rangeStart))
            {
                ManagementMeetingEnd = rangeEnd;
            }


            if ((RegulatoryBreaksStart <= rangeStart) && (RegulatoryBreaksEnd < rangeEnd) &&
                (RegulatoryBreaksStart < rangeEnd) && (RegulatoryBreaksEnd > rangeStart))
            {
                RegulatoryBreaksStart = rangeStart;
            }

            if ((RegulatoryBreaksStart <= rangeEnd) && (RegulatoryBreaksEnd > rangeEnd) &&
                (RegulatoryBreaksStart < rangeEnd) && (RegulatoryBreaksEnd > rangeStart))
            {
                RegulatoryBreaksEnd = rangeEnd;
            }


            if ((PilotRunStart <= rangeStart) && (PilotRunEnd < rangeEnd) &&
                (PilotRunStart < rangeEnd) && (PilotRunEnd > rangeStart))
            {
                PilotRunStart = rangeStart;
            }

            if ((PilotRunStart <= rangeEnd) && (PilotRunEnd > rangeEnd) &&
                (PilotRunStart < rangeEnd) && (PilotRunEnd > rangeStart))
            {
                PilotRunEnd = rangeEnd;
            }

            return result;
        }

    }
}