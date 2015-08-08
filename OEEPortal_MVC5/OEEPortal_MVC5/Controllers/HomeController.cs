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

    }
}
