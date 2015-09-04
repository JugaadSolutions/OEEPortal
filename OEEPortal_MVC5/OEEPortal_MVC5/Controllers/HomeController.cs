using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OEEPortal_MVC5.Models;

namespace OEEPortal.Controllers
{
    public class HomeController : Controller
    {
        OEEPortalContext db = new OEEPortalContext();
        public ActionResult Index()
        {

            ViewBag.Message = "Home";

            return View();
        }
        public ActionResult Input()
        {
            using (OEEPortalContext db = new OEEPortalContext())
            {
                var lines = db.Lines.ToList();
            }
            ViewBag.Message = "Input";
            return View();
        }
        public ActionResult Report()
        {
            ViewBag.Title = "Report";
            return View();
        }
        public ActionResult Graphs()
        {
            ViewBag.Tittle = "Graphs";
            return View();
        }

        public ActionResult Manage()
        {
            using (OEEPortalContext db = new OEEPortalContext())
            {
                return View(db.Lines.ToList());
            }
        }


        #region AJAX_METHODS


        public JsonResult GetLines()
        {
            using (OEEPortalContext db = new OEEPortalContext())
            {
                var Lines = db.Lines.ToArray();

                Line[] LinesList = new Line[Lines.Length];

                int i = 0;
                foreach (Line l in Lines)
                {
                    LinesList[i++] = new Line { LineId = l.LineId, Name = l.Name };
                }

                return Json(LinesList, JsonRequestBehavior.AllowGet);


            }
        }


        public JsonResult GetMachines(int id)
        {
            using (OEEPortalContext db = new OEEPortalContext())
            {
                List<Machine> machines;
                if (id == 0)
                {
                    machines = db.Machines.ToList();
                }
                else
                {
                    machines = db.Machines.Where(m => m.LineId == id).ToList();
                }

                MachineVM[] machinesList = new MachineVM[machines.Count];

                int i = 0;
                foreach (Machine m in machines)
                {
                    machinesList[i++] =
                        new MachineVM { MachineId = m.MachineId, Name = m.Name, Icon = m.Icon };
                }

                return Json(machinesList, JsonRequestBehavior.AllowGet);

            }
        }


        public JsonResult GetReferences(int machine)
        {
            using (OEEPortalContext db = new OEEPortalContext())
            {
                var references = db.ReferenceMachines.Where(rm => rm.MachineId == machine).ToList();

                ReferenceVM[] ReferenceList = new ReferenceVM[references.Count];

                int i = 0;
                foreach (ReferenceMachine r in references)
                {
                    ReferenceList[i++] = new ReferenceVM { Name = r.Reference.Name, ReferenceId = r.ReferenceId, UsefullTime = r.UsefullTime };
                }



                return Json(ReferenceList, JsonRequestBehavior.AllowGet);

            }
        }



        public JsonResult GetMachineOutputRecords(LogFilter logFilter)
        {
            using (OEEPortalContext db = new OEEPortalContext())
            {
                logFilter.To = logFilter.To.AddDays(1);
                var MachineOutputRecords = db.MachineOutputRecords.Where(m => (m.StartTime >= logFilter.From) && (m.EndTime < logFilter.To)).ToArray();

                MachineOutputRecord[] MachineOutputRecordList = new MachineOutputRecord[MachineOutputRecords.Length];

                int i = 0;
                foreach (MachineOutputRecord m in MachineOutputRecords)
                {
                    MachineOutputRecordList[i++] = new MachineOutputRecord
                    {
                        MachineOutputRecordId = m.MachineOutputRecordId,
                        OperatorId = m.OperatorId,
                        StartTime = m.StartTime,
                        EndTime = m.EndTime,
                        OutputQuantity = m.OutputQuantity,
                        DefectQuantity = m.DefectQuantity,
                        MachineId = m.MachineId,
                        ReferenceId = m.ReferenceId,
                        EquipmentBreakDownStart = m.EquipmentBreakDownStart,
                        EquipmentBreakDownEnd = m.EquipmentBreakDownEnd,
                        ChangeOverStart = m.ChangeOverStart,
                        ChangeOverEnd = m.ChangeOverEnd,
                        MaterialDownStart = m.MaterialDownStart,
                        MaterialDownEnd = m.MaterialDownEnd,
                        QualityDownStart = m.QualityDownStart,
                        QualityDownEnd = m.QualityDownEnd,
                        PreventiveMaintenanceStart = m.PreventiveMaintenanceStart,
                        PreventiveMaintenanceEnd = m.PreventiveMaintenanceEnd,
                        ManagementMeetingStart = m.ManagementMeetingStart,
                        ManagementMeetingEnd = m.ManagementMeetingEnd,
                        RegulatoryBreaksStart = m.RegulatoryBreaksStart,
                        RegulatoryBreaksEnd = m.RegulatoryBreaksEnd,
                        PilotRunStart = m.PilotRunStart,
                        PilotRunEnd = m.PilotRunEnd
                    };
                }

                return Json(MachineOutputRecordList, JsonRequestBehavior.AllowGet);


            }
        }

        public JsonResult GetMachineCumulativeRecords(MachineCumulativeFilter machineCumulativeFilter)
        {
            List<MachineCumulativeRecord> MachineCumulativeRecords = new List<MachineCumulativeRecord>();
            List<MachineOutput> MachineOutputRecords = new List<MachineOutput>();
            Dictionary<String, List<MachineOutput>> MachineOutputRecordGroup =
                new Dictionary<string, List<MachineOutput>>();
            using (OEEPortalContext db = new OEEPortalContext())
            {



                List<Shift> Shifts = db.Shifts.ToList();

                DateTime rangeStart = DateTime.MaxValue;
                DateTime rangeEnd = DateTime.MinValue;
                foreach (Shift s in Shifts)
                {
                    DateTime Start = s.GetShiftStart(machineCumulativeFilter.From);
                    DateTime End = s.GetShiftEnd(machineCumulativeFilter.To);
                    if (Start < rangeStart)
                    {
                        rangeStart = Start;
                    }

                    if (End > rangeEnd)
                        rangeEnd = End;

                }

                MachineOutputRecords = (from m in db.MachineOutputRecords
                                        join rm in db.ReferenceMachines on new { mId = m.MachineId, rId = m.ReferenceId } equals new { mId = rm.MachineId, rId = rm.ReferenceId }
                                        join mc in db.Machines on m.MachineId equals mc.MachineId
                                        where ((m.StartTime <= rangeStart) && (m.EndTime < rangeEnd) && (m.StartTime < rangeEnd) && (m.EndTime > rangeStart)
                                   || (m.StartTime >= rangeStart) && (m.EndTime < rangeEnd) && (m.StartTime < rangeEnd) && (m.EndTime > rangeStart)
                                   || (m.StartTime <= rangeEnd) && (m.EndTime > rangeEnd) && (m.StartTime < rangeEnd) && (m.EndTime > rangeStart))
                                   && (machineCumulativeFilter.Machines.Contains(m.MachineId))
                                        select new MachineOutput
                                        {
                                            Machine = mc.Name,
                                            UsefullTime = rm.UsefullTime,
                                            StartTime = m.StartTime,
                                            EndTime = m.EndTime,
                                            OutputQuantity = m.OutputQuantity,
                                            DefectQuantity = m.DefectQuantity,
                                            EquipmentBreakDownStart = m.EquipmentBreakDownStart,
                                            EquipmentBreakDownEnd = m.EquipmentBreakDownEnd,
                                            ChangeOverStart = m.ChangeOverStart,
                                            ChangeOverEnd = m.ChangeOverEnd,
                                            MaterialDownStart = m.MaterialDownStart,
                                            MaterialDownEnd = m.MaterialDownEnd,
                                            QualityDownStart = m.QualityDownStart,
                                            QualityDownEnd = m.QualityDownEnd,
                                            NonProductionStart = m.NonProductionStart,
                                            NonProductionEnd = m.NonProductionEnd,
                                            PreventiveMaintenanceStart = m.PreventiveMaintenanceStart,
                                            PreventiveMaintenanceEnd = m.PreventiveMaintenanceEnd,
                                            ManagementMeetingStart = m.ManagementMeetingStart,
                                            ManagementMeetingEnd = m.ManagementMeetingEnd,
                                            RegulatoryBreaksStart = m.RegulatoryBreaksStart,
                                            RegulatoryBreaksEnd = m.RegulatoryBreaksEnd,
                                            PilotRunStart = m.PilotRunStart,
                                            PilotRunEnd = m.PilotRunEnd
                                        }).ToList();







                foreach (MachineOutput r in MachineOutputRecords)
                {
                    r.Normalize(rangeStart, rangeEnd);
                    if (MachineOutputRecordGroup.ContainsKey(r.Machine))
                    {
                        MachineOutputRecordGroup[r.Machine].Add(r);
                    }
                    else
                    {
                        var sublist = new List<MachineOutput>();
                        sublist.Add(r);
                        MachineOutputRecordGroup.Add(r.Machine, sublist);
                    }


                }

                foreach (KeyValuePair<String, List<MachineOutput>> kv in MachineOutputRecordGroup)
                {
                    MachineCumulativeRecord mc = new MachineCumulativeRecord();
                    mc.Machine = kv.Key;

                    foreach (MachineOutput o in kv.Value)
                    {
                        mc.POT += (o.EndTime.Value - o.StartTime.Value).TotalSeconds;
                        mc.UsefulTime += o.UsefullTime;
                        mc.TotalQuantity += o.OutputQuantity;
                        mc.DefectQuantity += o.DefectQuantity;
                        if (o.EquipmentBreakDownStart != null)
                        {
                            mc.EquipmentBreakdown += (o.EquipmentBreakDownEnd.Value - o.EquipmentBreakDownStart.Value).TotalSeconds;
                        }

                        if (o.ChangeOverStart != null)
                            mc.ChangeOver += (o.ChangeOverEnd.Value - o.ChangeOverStart.Value).TotalSeconds;

                        if (o.MaterialDownStart != null)
                            mc.MaterialShortage += (o.MaterialDownEnd.Value - o.MaterialDownStart.Value).TotalSeconds;

                        if (o.QualityDownStart != null)
                            mc.QualityDowntime += (o.QualityDownEnd.Value - o.QualityDownStart.Value).TotalSeconds;

                        if (o.NonProductionStart != null)
                            mc.NonProductionTime += (o.NonProductionEnd.Value - o.NonProductionStart.Value).TotalSeconds;

                        if (o.PreventiveMaintenanceStart != null)
                            mc.PreventiveMaintenance += (o.PreventiveMaintenanceEnd.Value - o.PreventiveMaintenanceStart.Value).TotalSeconds;

                        if (o.ManagementMeetingStart != null)
                            mc.ManagementMeeting += (o.ManagementMeetingEnd.Value - o.ManagementMeetingStart.Value).TotalSeconds;

                        if (o.RegulatoryBreaksStart != null)
                            mc.RegulatoryBreaks += (o.RegulatoryBreaksEnd.Value - o.RegulatoryBreaksStart.Value).TotalSeconds;

                        if (o.PilotRunStart != null)
                            mc.PilotRun += (o.PilotRunEnd.Value - o.PilotRunStart.Value).TotalSeconds;
                    }

                    mc.GoodQuantity = mc.TotalQuantity - mc.DefectQuantity;
                    mc.QualityDefectTime = mc.DefectQuantity * mc.UsefulTime;
                    mc.RT = mc.UsefulTime + mc.QualityDefectTime;
                    mc.QualityRate = (mc.UsefulTime / mc.RT) * 100;

                    mc.SPT = mc.POT - (mc.PreventiveMaintenance + mc.ManagementMeeting + mc.RegulatoryBreaks + mc.PilotRun);

                    mc.UPT = mc.POT - (mc.EquipmentBreakdown + mc.ChangeOver + mc.MaterialShortage + mc.QualityDowntime + mc.NonProductionTime);

                    mc.PerformanceLossTime = mc.UPT - mc.RT;
                    mc.PerformanceRate = (mc.RT / mc.UPT )*100;
                    mc.AvailabilityRate = (mc.UPT / mc.SPT)*100;
                    mc.UtilizationRate = (mc.SPT / mc.POT)*100;



                    mc.OEE = (mc.QualityRate * mc.PerformanceRate * mc.AvailabilityRate)/1000;

                    mc.NEE =( mc.OEE * mc.UtilizationRate )/ 100;

                    MachineCumulativeRecords.Add(mc);
                }




                return Json(MachineCumulativeRecords, JsonRequestBehavior.AllowGet);


            }
        }
        #endregion


    }
}
