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
    public class HeaderCategoriesController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: HeaderCategories
        public ActionResult Index()
        {
            var headerCategories = db.HeaderCategories.Include(h => h.Header);
            return View(headerCategories.ToList());
        }

        // GET: HeaderCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeaderCategory headerCategory = db.HeaderCategories.Find(id);
            if (headerCategory == null)
            {
                return HttpNotFound();
            }
            return View(headerCategory);
        }

        // GET: HeaderCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Headers, "ID", "Header1");
            return View();
        }

        // POST: HeaderCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,HeaderName")] HeaderCategory headerCategory)
        {
            if (ModelState.IsValid)
            {
                db.HeaderCategories.Add(headerCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Headers, "ID", "Header1", headerCategory.CategoryID);
            return View(headerCategory);
        }

        // GET: HeaderCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeaderCategory headerCategory = db.HeaderCategories.Find(id);
            if (headerCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Headers, "ID", "Header1", headerCategory.CategoryID);
            return View(headerCategory);
        }

        // POST: HeaderCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,HeaderName")] HeaderCategory headerCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(headerCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Headers, "ID", "Header1", headerCategory.CategoryID);
            return View(headerCategory);
        }

        // GET: HeaderCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeaderCategory headerCategory = db.HeaderCategories.Find(id);
            if (headerCategory == null)
            {
                return HttpNotFound();
            }
            return View(headerCategory);
        }

        // POST: HeaderCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeaderCategory headerCategory = db.HeaderCategories.Find(id);
            db.HeaderCategories.Remove(headerCategory);
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
