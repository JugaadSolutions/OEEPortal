using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OEEPortal_MVC5.Models;

namespace OEEPortal_MVC5.Controllers
{
    public class InputController : Controller
    {
        private OEEPortalContext db = new OEEPortalContext();

        // GET: Input
        public ActionResult Index()
        {
            var machineOutputRecords = 
                db.MachineOutputRecords.Include(m => m.Machine).Include(m => m.Reference).Include(m => m.Shift);
            return View(machineOutputRecords.ToList());
        }

        // GET: Input/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineOutputRecord machineOutputRecord = db.MachineOutputRecords.Find(id);
            if (machineOutputRecord == null)
            {
                return HttpNotFound();
            }
            return View(machineOutputRecord);
        }

        // GET: Input/Create
        public ActionResult Create()
        {
            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "Name");
            ViewBag.ReferenceId = new SelectList(db.References, "ReferenceId", "Name");
            ViewBag.ShiftId = new SelectList(db.Shifts, "ShiftId", "Name");
            return View();
        }

        // POST: Input/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MachineOutputRecordId,EquipmentBreakDown,ChangeOver,MaterialDownTime,QuantityDownTime,OtherNonProduct,PreventiveMaintenance,ManagementMeeting,RegulatoryBreaks,PilotRun,MachineId,ReferenceId,ShiftId")] MachineOutputRecord machineOutputRecord)
        {
            if (ModelState.IsValid)
            {
                db.MachineOutputRecords.Add(machineOutputRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "Name", machineOutputRecord.MachineId);
            ViewBag.ReferenceId = new SelectList(db.References, "ReferenceId", "Name", machineOutputRecord.ReferenceId);
            ViewBag.ShiftId = new SelectList(db.Shifts, "ShiftId", "Name", machineOutputRecord.ShiftId);
            return View(machineOutputRecord);
        }

        // GET: Input/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineOutputRecord machineOutputRecord = db.MachineOutputRecords.Find(id);
            if (machineOutputRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "Name", machineOutputRecord.MachineId);
            ViewBag.ReferenceId = new SelectList(db.References, "ReferenceId", "Name", machineOutputRecord.ReferenceId);
            ViewBag.ShiftId = new SelectList(db.Shifts, "ShiftId", "Name", machineOutputRecord.ShiftId);
            return View(machineOutputRecord);
        }

        // POST: Input/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MachineOutputRecordId,EquipmentBreakDown,ChangeOver,MaterialDownTime,QuantityDownTime,OtherNonProduct,PreventiveMaintenance,ManagementMeeting,RegulatoryBreaks,PilotRun,MachineId,ReferenceId,ShiftId")] MachineOutputRecord machineOutputRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machineOutputRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "Name", machineOutputRecord.MachineId);
            ViewBag.ReferenceId = new SelectList(db.References, "ReferenceId", "Name", machineOutputRecord.ReferenceId);
            ViewBag.ShiftId = new SelectList(db.Shifts, "ShiftId", "Name", machineOutputRecord.ShiftId);
            return View(machineOutputRecord);
        }

        // GET: Input/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineOutputRecord machineOutputRecord = db.MachineOutputRecords.Find(id);
            if (machineOutputRecord == null)
            {
                return HttpNotFound();
            }
            return View(machineOutputRecord);
        }

        // POST: Input/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MachineOutputRecord machineOutputRecord = db.MachineOutputRecords.Find(id);
            db.MachineOutputRecords.Remove(machineOutputRecord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
