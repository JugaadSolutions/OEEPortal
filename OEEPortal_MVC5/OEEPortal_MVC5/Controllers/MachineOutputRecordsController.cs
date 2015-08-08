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
    public class MachineOutputRecordsController : Controller
    {
        private OEEPortalContext db = new OEEPortalContext();

        // GET: MachineOutputRecords
        public ActionResult Index()
        {
            var machineOutputRecords = db.MachineOutputRecords.Include(m => m.Machine).Include(m => m.Reference);
            return View(machineOutputRecords.ToList());
        }

        // GET: MachineOutputRecords/Details/5
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

        // GET: MachineOutputRecords/Create
        public ActionResult Create()
        {
            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "Name");
            ViewBag.ReferenceId = new SelectList(db.References, "ReferenceId", "Name");
            ViewBag.ShiftId = new SelectList(db.Shifts, "ShiftId", "Name");
            return View();
        }

        // POST: MachineOutputRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MachineOutputRecordId,OperatorId,StartTime,EndTime,EquipmentBreakDown,ChangeOver,MaterialDownTime,QuantityDownTime,OtherNonProduct,PreventiveMaintenance,ManagementMeeting,RegulatoryBreaks,PilotRun,MachineId,ReferenceId,ShiftId")] MachineOutputRecord machineOutputRecord)
        {
            if (ModelState.IsValid)
            {
                db.MachineOutputRecords.Add(machineOutputRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "Name", machineOutputRecord.MachineId);
            ViewBag.ReferenceId = new SelectList(db.References, "ReferenceId", "Name", machineOutputRecord.ReferenceId);
            
            return View(machineOutputRecord);
        }

        // GET: MachineOutputRecords/Edit/5
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
            
            return View(machineOutputRecord);
        }

        // POST: MachineOutputRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MachineOutputRecordId,OperatorId,StartTime,EndTime,EquipmentBreakDown,ChangeOver,MaterialDownTime,QuantityDownTime,OtherNonProduct,PreventiveMaintenance,ManagementMeeting,RegulatoryBreaks,PilotRun,MachineId,ReferenceId,ShiftId")] MachineOutputRecord machineOutputRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machineOutputRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "Name", machineOutputRecord.MachineId);
            ViewBag.ReferenceId = new SelectList(db.References, "ReferenceId", "Name", machineOutputRecord.ReferenceId);
            
            return View(machineOutputRecord);
        }

        // GET: MachineOutputRecords/Delete/5
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

        // POST: MachineOutputRecords/Delete/5
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
