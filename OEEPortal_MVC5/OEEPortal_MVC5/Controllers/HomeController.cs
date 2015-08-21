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


      

    }
}
