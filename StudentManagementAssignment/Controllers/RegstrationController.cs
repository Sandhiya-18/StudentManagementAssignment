using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementAssignment.Models;

namespace StudentManagementAssignment.Controllers
{
    public class RegstrationController : Controller
    {
        private StudentMngEntities1 db = new StudentMngEntities1();

        // GET: Regstration
        public ActionResult Index()
        {
            var regstrations = db.Regstrations.Include(r => r.Batch).Include(r => r.Course);
            return View(regstrations.ToList());
        }

        // GET: Regstration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regstration regstration = db.Regstrations.Find(id);
            if (regstration == null)
            {
                return HttpNotFound();
            }
            return View(regstration);
        }

        // GET: Regstration/Create
        public ActionResult Create()
        {
            ViewBag.Batch_ID = new SelectList(db.Batches, "ID", "Batch1");
            ViewBag.Course_ID = new SelectList(db.Courses, "ID", "CourseName");
            return View();
        }

        // POST: Regstration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,nic,Course_ID,Batch_ID,Phone")] Regstration regstration)
        {
            if (ModelState.IsValid)
            {
                db.Regstrations.Add(regstration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Batch_ID = new SelectList(db.Batches, "ID", "Batch1", regstration.Batch_ID);
            ViewBag.Course_ID = new SelectList(db.Courses, "ID", "CourseName", regstration.Course_ID);
            return View(regstration);
        }

        // GET: Regstration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regstration regstration = db.Regstrations.Find(id);
            if (regstration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Batch_ID = new SelectList(db.Batches, "ID", "Batch1", regstration.Batch_ID);
            ViewBag.Course_ID = new SelectList(db.Courses, "ID", "CourseName", regstration.Course_ID);
            return View(regstration);
        }

        // POST: Regstration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,nic,Course_ID,Batch_ID,Phone")] Regstration regstration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regstration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Batch_ID = new SelectList(db.Batches, "ID", "Batch1", regstration.Batch_ID);
            ViewBag.Course_ID = new SelectList(db.Courses, "ID", "CourseName", regstration.Course_ID);
            return View(regstration);
        }

        // GET: Regstration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regstration regstration = db.Regstrations.Find(id);
            if (regstration == null)
            {
                return HttpNotFound();
            }
            return View(regstration);
        }

        // POST: Regstration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Regstration regstration = db.Regstrations.Find(id);
            db.Regstrations.Remove(regstration);
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
