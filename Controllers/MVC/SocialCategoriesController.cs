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
    public class SocialCategoriesController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: SocialCategories
        public ActionResult Index()
        {
            var socialCategories = db.SocialCategories.Include(s => s.SocialLink);
            return View(socialCategories.ToList());
        }

        // GET: SocialCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialCategory socialCategory = db.SocialCategories.Find(id);
            if (socialCategory == null)
            {
                return HttpNotFound();
            }
            return View(socialCategory);
        }

        // GET: SocialCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.SocialLinks, "ID", "SocialLink1");
            return View();
        }

        // POST: SocialCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,SocialName")] SocialCategory socialCategory)
        {
            if (ModelState.IsValid)
            {
                db.SocialCategories.Add(socialCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.SocialLinks, "ID", "SocialLink1", socialCategory.CategoryID);
            return View(socialCategory);
        }

        // GET: SocialCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialCategory socialCategory = db.SocialCategories.Find(id);
            if (socialCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.SocialLinks, "ID", "SocialLink1", socialCategory.CategoryID);
            return View(socialCategory);
        }

        // POST: SocialCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,SocialName")] SocialCategory socialCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.SocialLinks, "ID", "SocialLink1", socialCategory.CategoryID);
            return View(socialCategory);
        }

        // GET: SocialCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialCategory socialCategory = db.SocialCategories.Find(id);
            if (socialCategory == null)
            {
                return HttpNotFound();
            }
            return View(socialCategory);
        }

        // POST: SocialCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialCategory socialCategory = db.SocialCategories.Find(id);
            db.SocialCategories.Remove(socialCategory);
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
