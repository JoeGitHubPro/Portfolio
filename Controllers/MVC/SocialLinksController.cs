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
    public class SocialLinksController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: SocialLinks
        public ActionResult Index()
        {
            var socialLinks = db.SocialLinks.Include(s => s.SocialCategory);
            return View(socialLinks.ToList());
        }

        // GET: SocialLinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialLink socialLink = db.SocialLinks.Find(id);
            if (socialLink == null)
            {
                return HttpNotFound();
            }
            return View(socialLink);
        }

        // GET: SocialLinks/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.SocialCategories, "CategoryID", "SocialName");
            return View();
        }

        // POST: SocialLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SocialLink1")] SocialLink socialLink)
        {
            if (ModelState.IsValid)
            {
                db.SocialLinks.Add(socialLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.SocialCategories, "CategoryID", "SocialName", socialLink.ID);
            return View(socialLink);
        }

        // GET: SocialLinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialLink socialLink = db.SocialLinks.Find(id);
            if (socialLink == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.SocialCategories, "CategoryID", "SocialName", socialLink.ID);
            return View(socialLink);
        }

        // POST: SocialLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SocialLink1")] SocialLink socialLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.SocialCategories, "CategoryID", "SocialName", socialLink.ID);
            return View(socialLink);
        }

        // GET: SocialLinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialLink socialLink = db.SocialLinks.Find(id);
            if (socialLink == null)
            {
                return HttpNotFound();
            }
            return View(socialLink);
        }

        // POST: SocialLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialLink socialLink = db.SocialLinks.Find(id);
            db.SocialLinks.Remove(socialLink);
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
