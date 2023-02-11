using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portfolio;

namespace Portfolio.Controllers.MVC
{
    public class ViewersController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: Viewers
        public ActionResult Index()
        {
            ViewData["TotalViewers"] = db.Viewers.ToList().Count();
           // ViewBag.count = db.Viewers.ToList().Count();
            return View(db.Viewers.ToList());
        }

        // GET: Viewers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viewer viewer = db.Viewers.Find(id);
            if (viewer == null)
            {
                return HttpNotFound();
            }
            return View(viewer);
        }

        // GET: Viewers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Viewers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date")] Viewer viewer)
        {
            if (ModelState.IsValid)
            {
                db.Viewers.Add(viewer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewer);
        }

        // GET: Viewers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viewer viewer = db.Viewers.Find(id);
            if (viewer == null)
            {
                return HttpNotFound();
            }
            return View(viewer);
        }

        // POST: Viewers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date")] Viewer viewer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewer);
        }

        // GET: Viewers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viewer viewer = db.Viewers.Find(id);
            if (viewer == null)
            {
                return HttpNotFound();
            }
            return View(viewer);
        }

        // POST: Viewers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viewer viewer = db.Viewers.Find(id);
            db.Viewers.Remove(viewer);
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
