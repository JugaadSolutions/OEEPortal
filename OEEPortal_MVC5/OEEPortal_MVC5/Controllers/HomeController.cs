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
            using(OEEPortalContext db = new OEEPortalContext())
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

                int i  = 0;
                foreach(Machine m in machines)
                {
                    machinesList[i++] = 
                        new MachineVM { MachineId = m.MachineId, Name = m.Name, Icon= m.Icon };
                }

                return Json(machinesList,JsonRequestBehavior.AllowGet);

            }
        }


        public JsonResult GetReferences(int machine)
        {
            using (OEEPortalContext db = new OEEPortalContext())
            {
                var references = db.ReferenceMachines.Where(rm => rm.MachineId == machine).ToList();

                ReferenceVM[] ReferenceList = new ReferenceVM[references.Count];

                int i = 0;
                foreach(ReferenceMachine r in references )
                {
                    ReferenceList[i++] = new ReferenceVM { Name = r.Reference.Name, ReferenceId = r.ReferenceId,  UsefullTime = r.UsefullTime };
                }

                

                return Json(ReferenceList, JsonRequestBehavior.AllowGet);

            }
        }



        public JsonResult GetMachineOutputRecords(LogFilter logFilter)
        {
            using (OEEPortalContext db = new OEEPortalContext())
            {
                logFilter.To = logFilter.To.AddDays(1);
                var MachineOutputRecords = db.MachineOutputRecords.Where(m=>(m.StartTime>=logFilter.From) && (m.EndTime<logFilter.To)).ToArray();

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
            using (OEEPortalContext db = new OEEPortalContext())
            {
                machineCumulativeFilter.To = machineCumulativeFilter.To.AddDays(1);
                var MachineOutputRecords = db.MachineOutputRecords.Where(m => (m.StartTime >= machineCumulativeFilter.From) && (m.EndTime < machineCumulativeFilter.To)).ToArray();

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
        #endregion


    }
}
