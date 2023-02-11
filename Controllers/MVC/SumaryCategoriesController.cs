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
    public class SumaryCategoriesController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: SumaryCategories
        public ActionResult Index()
        {
            var sumaryCategories = db.SumaryCategories.Include(s => s.SumaryTopic);
            return View(sumaryCategories.ToList());
        }

        // GET: SumaryCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumaryCategory sumaryCategory = db.SumaryCategories.Find(id);
            if (sumaryCategory == null)
            {
                return HttpNotFound();
            }
            return View(sumaryCategory);
        }

        // GET: SumaryCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.SumaryTopics, "ID", "SumaryTopicName");
            return View();
        }

        // POST: SumaryCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,SumaryCategory1")] SumaryCategory sumaryCategory)
        {
            if (ModelState.IsValid)
            {
                db.SumaryCategories.Add(sumaryCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.SumaryTopics, "ID", "SumaryTopicName", sumaryCategory.CategoryID);
            return View(sumaryCategory);
        }

        // GET: SumaryCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumaryCategory sumaryCategory = db.SumaryCategories.Find(id);
            if (sumaryCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.SumaryTopics, "ID", "SumaryTopicName", sumaryCategory.CategoryID);
            return View(sumaryCategory);
        }

        // POST: SumaryCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,SumaryCategory1")] SumaryCategory sumaryCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sumaryCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.SumaryTopics, "ID", "SumaryTopicName", sumaryCategory.CategoryID);
            return View(sumaryCategory);
        }

        // GET: SumaryCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumaryCategory sumaryCategory = db.SumaryCategories.Find(id);
            if (sumaryCategory == null)
            {
                return HttpNotFound();
            }
            return View(sumaryCategory);
        }

        // POST: SumaryCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SumaryCategory sumaryCategory = db.SumaryCategories.Find(id);
            db.SumaryCategories.Remove(sumaryCategory);
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
