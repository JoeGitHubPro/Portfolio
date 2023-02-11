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
    public class AboutCategoriesController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: AboutCategories
        public ActionResult Index()
        {
            var aboutCategories = db.AboutCategories.Include(a => a.AboutTopic1);
            return View(aboutCategories.ToList());
        }

        // GET: AboutCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutCategory aboutCategory = db.AboutCategories.Find(id);
            if (aboutCategory == null)
            {
                return HttpNotFound();
            }
            return View(aboutCategory);
        }

        // GET: AboutCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.AboutTopics, "ID", "TopicDescrption");
            return View();
        }

        // POST: AboutCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,AboutTopic")] AboutCategory aboutCategory)
        {
            if (ModelState.IsValid)
            {
                db.AboutCategories.Add(aboutCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.AboutTopics, "ID", "TopicDescrption", aboutCategory.CategoryID);
            return View(aboutCategory);
        }

        // GET: AboutCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutCategory aboutCategory = db.AboutCategories.Find(id);
            if (aboutCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.AboutTopics, "ID", "TopicDescrption", aboutCategory.CategoryID);
            return View(aboutCategory);
        }

        // POST: AboutCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,AboutTopic")] AboutCategory aboutCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.AboutTopics, "ID", "TopicDescrption", aboutCategory.CategoryID);
            return View(aboutCategory);
        }

        // GET: AboutCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutCategory aboutCategory = db.AboutCategories.Find(id);
            if (aboutCategory == null)
            {
                return HttpNotFound();
            }
            return View(aboutCategory);
        }

        // POST: AboutCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutCategory aboutCategory = db.AboutCategories.Find(id);
            db.AboutCategories.Remove(aboutCategory);
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
