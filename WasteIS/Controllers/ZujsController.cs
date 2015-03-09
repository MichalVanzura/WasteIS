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
    public class ZujsController : Controller
    {
        private WasteISContext db = new WasteISContext();

        // GET: Zujs
        public ActionResult Index()
        {
            var zujs = db.Zujs.Include(z => z.Orp);
            return View(zujs.ToList());
        }

        // GET: Zujs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zuj zuj = db.Zujs.Find(id);
            if (zuj == null)
            {
                return HttpNotFound();
            }
            return View(zuj);
        }

        // GET: Zujs/Create
        public ActionResult Create()
        {
            ViewBag.OrpID = new SelectList(db.Orps, "ID", "Name");
            return View();
        }

        // POST: Zujs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,City,ZUJ,OrpID")] Zuj zuj)
        {
            if (ModelState.IsValid)
            {
                db.Zujs.Add(zuj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrpID = new SelectList(db.Orps, "ID", "Name", zuj.OrpID);
            return View(zuj);
        }

        // GET: Zujs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zuj zuj = db.Zujs.Find(id);
            if (zuj == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrpID = new SelectList(db.Orps, "ID", "Name", zuj.OrpID);
            return View(zuj);
        }

        // POST: Zujs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,City,ZUJ,OrpID")] Zuj zuj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zuj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrpID = new SelectList(db.Orps, "ID", "Name", zuj.OrpID);
            return View(zuj);
        }

        // GET: Zujs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zuj zuj = db.Zujs.Find(id);
            if (zuj == null)
            {
                return HttpNotFound();
            }
            return View(zuj);
        }

        // POST: Zujs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zuj zuj = db.Zujs.Find(id);
            db.Zujs.Remove(zuj);
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
