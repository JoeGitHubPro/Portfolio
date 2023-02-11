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
    public class AboutTopicsController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: AboutTopics
        public ActionResult Index()
        {
            var aboutTopics = db.AboutTopics.Include(a => a.AboutCategory);
            return View(aboutTopics.ToList());
        }

        // GET: AboutTopics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutTopic aboutTopic = db.AboutTopics.Find(id);
            if (aboutTopic == null)
            {
                return HttpNotFound();
            }
            return View(aboutTopic);
        }

        // GET: AboutTopics/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.AboutCategories, "CategoryID", "AboutTopic");
            return View();
        }

        // POST: AboutTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TopicDescrption")] AboutTopic aboutTopic)
        {
            if (ModelState.IsValid)
            {
                db.AboutTopics.Add(aboutTopic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.AboutCategories, "CategoryID", "AboutTopic", aboutTopic.ID);
            return View(aboutTopic);
        }

        // GET: AboutTopics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutTopic aboutTopic = db.AboutTopics.Find(id);
            if (aboutTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.AboutCategories, "CategoryID", "AboutTopic", aboutTopic.ID);
            return View(aboutTopic);
        }

        // POST: AboutTopics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TopicDescrption")] AboutTopic aboutTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutTopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.AboutCategories, "CategoryID", "AboutTopic", aboutTopic.ID);
            return View(aboutTopic);
        }

        // GET: AboutTopics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutTopic aboutTopic = db.AboutTopics.Find(id);
            if (aboutTopic == null)
            {
                return HttpNotFound();
            }
            return View(aboutTopic);
        }

        // POST: AboutTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutTopic aboutTopic = db.AboutTopics.Find(id);
            db.AboutTopics.Remove(aboutTopic);
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
