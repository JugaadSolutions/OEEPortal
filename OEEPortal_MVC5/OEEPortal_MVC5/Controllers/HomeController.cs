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

            return View(db.Lines.ToList());
        }

        public JsonResult GetData()
        {
            var dbResult = db.Lines.ToList();
            var lines = (from Lines in dbResult
                         select new
                         {
                             Lines.LineId,
                             Lines.Name
                         });
            return Json(lines, JsonRequestBehavior.AllowGet);
        }
       
    }
}
