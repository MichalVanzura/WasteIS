using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WasteIS.DAL;
using WasteIS.Models;

namespace WasteIS.Controllers
{
    public class OrpsController : Controller
    {
        private WasteISContext db = new WasteISContext();

        // GET: Orps
        public ActionResult Index()
        {
            return View(db.Orps.ToList());
        }

        // GET: Orps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orp orp = db.Orps.Find(id);
            if (orp == null)
            {
                return HttpNotFound();
            }
            return View(orp);
        }

        // GET: Orps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ORP")] Orp orp)
        {
            if (ModelState.IsValid)
            {
                db.Orps.Add(orp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orp);
        }

        // GET: Orps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orp orp = db.Orps.Find(id);
            if (orp == null)
            {
                return HttpNotFound();
            }
            return View(orp);
        }

        // POST: Orps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ORP")] Orp orp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orp);
        }

        // GET: Orps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orp orp = db.Orps.Find(id);
            if (orp == null)
            {
                return HttpNotFound();
            }
            return View(orp);
        }

        // POST: Orps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orp orp = db.Orps.Find(id);
            db.Orps.Remove(orp);
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
