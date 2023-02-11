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
    public class EducationCategoriesController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: EducationCategories
        public ActionResult Index()
        {
            var educationCategories = db.EducationCategories.Include(e => e.EducationTopic);
            return View(educationCategories.ToList());
        }

        // GET: EducationCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationCategory educationCategory = db.EducationCategories.Find(id);
            if (educationCategory == null)
            {
                return HttpNotFound();
            }
            return View(educationCategory);
        }

        // GET: EducationCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.EducationTopics, "ID", "EducationTopic1");
            return View();
        }

        // POST: EducationCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,EducationCategory1")] EducationCategory educationCategory)
        {
            if (ModelState.IsValid)
            {
                db.EducationCategories.Add(educationCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.EducationTopics, "ID", "EducationTopic1", educationCategory.CategoryID);
            return View(educationCategory);
        }

        // GET: EducationCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationCategory educationCategory = db.EducationCategories.Find(id);
            if (educationCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.EducationTopics, "ID", "EducationTopic1", educationCategory.CategoryID);
            return View(educationCategory);
        }

        // POST: EducationCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,EducationCategory1")] EducationCategory educationCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.EducationTopics, "ID", "EducationTopic1", educationCategory.CategoryID);
            return View(educationCategory);
        }

        // GET: EducationCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationCategory educationCategory = db.EducationCategories.Find(id);
            if (educationCategory == null)
            {
                return HttpNotFound();
            }
            return View(educationCategory);
        }

        // POST: EducationCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationCategory educationCategory = db.EducationCategories.Find(id);
            db.EducationCategories.Remove(educationCategory);
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
