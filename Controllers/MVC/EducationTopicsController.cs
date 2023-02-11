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
    public class EducationTopicsController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: EducationTopics
        public ActionResult Index()
        {
            var educationTopics = db.EducationTopics.Include(e => e.EducationCategory);
            return View(educationTopics.ToList());
        }

        // GET: EducationTopics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationTopic educationTopic = db.EducationTopics.Find(id);
            if (educationTopic == null)
            {
                return HttpNotFound();
            }
            return View(educationTopic);
        }

        // GET: EducationTopics/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.EducationCategories, "CategoryID", "EducationCategory1");
            return View();
        }

        // POST: EducationTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EducationTopic1")] EducationTopic educationTopic)
        {
            if (ModelState.IsValid)
            {
                db.EducationTopics.Add(educationTopic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.EducationCategories, "CategoryID", "EducationCategory1", educationTopic.ID);
            return View(educationTopic);
        }

        // GET: EducationTopics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationTopic educationTopic = db.EducationTopics.Find(id);
            if (educationTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.EducationCategories, "CategoryID", "EducationCategory1", educationTopic.ID);
            return View(educationTopic);
        }

        // POST: EducationTopics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EducationTopic1")] EducationTopic educationTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationTopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.EducationCategories, "CategoryID", "EducationCategory1", educationTopic.ID);
            return View(educationTopic);
        }

        // GET: EducationTopics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationTopic educationTopic = db.EducationTopics.Find(id);
            if (educationTopic == null)
            {
                return HttpNotFound();
            }
            return View(educationTopic);
        }

        // POST: EducationTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationTopic educationTopic = db.EducationTopics.Find(id);
            db.EducationTopics.Remove(educationTopic);
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
