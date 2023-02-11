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
    public class SumaryTopicsController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: SumaryTopics
        public ActionResult Index()
        {
            var sumaryTopics = db.SumaryTopics.Include(s => s.SumaryCategory);
            return View(sumaryTopics.ToList());
        }

        // GET: SumaryTopics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumaryTopic sumaryTopic = db.SumaryTopics.Find(id);
            if (sumaryTopic == null)
            {
                return HttpNotFound();
            }
            return View(sumaryTopic);
        }

        // GET: SumaryTopics/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.SumaryCategories, "CategoryID", "SumaryCategory1");
            return View();
        }

        // POST: SumaryTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SumaryTopicName")] SumaryTopic sumaryTopic)
        {
            if (ModelState.IsValid)
            {
                db.SumaryTopics.Add(sumaryTopic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.SumaryCategories, "CategoryID", "SumaryCategory1", sumaryTopic.ID);
            return View(sumaryTopic);
        }

        // GET: SumaryTopics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumaryTopic sumaryTopic = db.SumaryTopics.Find(id);
            if (sumaryTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.SumaryCategories, "CategoryID", "SumaryCategory1", sumaryTopic.ID);
            return View(sumaryTopic);
        }

        // POST: SumaryTopics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SumaryTopicName")] SumaryTopic sumaryTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sumaryTopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.SumaryCategories, "CategoryID", "SumaryCategory1", sumaryTopic.ID);
            return View(sumaryTopic);
        }

        // GET: SumaryTopics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumaryTopic sumaryTopic = db.SumaryTopics.Find(id);
            if (sumaryTopic == null)
            {
                return HttpNotFound();
            }
            return View(sumaryTopic);
        }

        // POST: SumaryTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SumaryTopic sumaryTopic = db.SumaryTopics.Find(id);
            db.SumaryTopics.Remove(sumaryTopic);
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
