﻿using System;
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
    public class LinesController : Controller
    {
        //private 

        // GET: Lines
        public ActionResult Index()
        {
            using (OEEPortalContext db = new OEEPortalContext())
            {
                var lines = db.Lines.Include("Machines").ToList();
                return View(lines);
            }

        }

        // GET: Lines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (OEEPortalContext db = new OEEPortalContext())
            {
                Line line = db.Lines.Find(id);
                if (line == null)
                {
                    return HttpNotFound();
                }
                return View(line);
            }
        }

        // GET: Lines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LineId,Name")] Line line)
        {
            if (ModelState.IsValid)
            {
                using (OEEPortalContext db = new OEEPortalContext())
                {
                    db.Lines.Add(line);
                    db.SaveChanges();
                    return RedirectToAction("Manage", "Home");
                }
            }
            return View(line);
        }

        // GET: Lines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (OEEPortalContext db = new OEEPortalContext())
            {
                Line line = db.Lines.Find(id);
                if (line == null)
                {
                    return HttpNotFound();
                }
                return View(line);
            }
        }

        // POST: Lines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LineId,Name")] Line line)
        {
            if (ModelState.IsValid)
            {
                using (OEEPortalContext db = new OEEPortalContext())
                {
                    db.Entry(line).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Manage", "Home");
                }
            }
            return View(line);
        }

        // GET: Lines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (OEEPortalContext db = new OEEPortalContext())
            {
                Line line = db.Lines.Find(id);
                if (line == null)
                {
                    return HttpNotFound();
                }
                return View(line);
            }

        }

        // POST: Lines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (OEEPortalContext db = new OEEPortalContext())
            {
                Line line = db.Lines.Find(id);
                db.Lines.Remove(line);
                db.SaveChanges();
                return RedirectToAction("Manage", "Home");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                using (OEEPortalContext db = new OEEPortalContext())
                {
                    db.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
