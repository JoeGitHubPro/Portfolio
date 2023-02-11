using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portfolio;

namespace Portfolio.Controllers
{
    public class HeadersController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: Headers
        public ActionResult Index()
        {
            var headers = db.Headers.Include(h => h.HeaderCategory);
            return View(headers.ToList());
        }

        // GET: Headers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = db.Headers.Find(id);
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }

        // GET: Headers/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.HeaderCategories, "CategoryID", "HeaderName");
            return View();
        }

        // POST: Headers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Header1")] Header header)
        {
            if (ModelState.IsValid)
            {
                db.Headers.Add(header);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.HeaderCategories, "CategoryID", "HeaderName", header.ID);
            return View(header);
        }

        // GET: Headers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = db.Headers.Find(id);
            if (header == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.HeaderCategories, "CategoryID", "HeaderName", header.ID);
            return View(header);
        }

        // POST: Headers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Header1")] Header header)
        {
            if (ModelState.IsValid)
            {
                db.Entry(header).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.HeaderCategories, "CategoryID", "HeaderName", header.ID);
            return View(header);
        }

        // GET: Headers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = db.Headers.Find(id);
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }

        // POST: Headers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Header header = db.Headers.Find(id);
            db.Headers.Remove(header);
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
