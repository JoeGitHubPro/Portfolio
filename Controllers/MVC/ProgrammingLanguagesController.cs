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
    public class ProgrammingLanguagesController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: ProgrammingLanguages
        public ActionResult Index()
        {
            return View(db.ProgrammingLanguages.ToList());
        }

        // GET: ProgrammingLanguages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammingLanguage programmingLanguage = db.ProgrammingLanguages.Find(id);
            if (programmingLanguage == null)
            {
                return HttpNotFound();
            }
            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgrammingLanguages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProgrammingLanguage1,Pecentage")] ProgrammingLanguage programmingLanguage)
        {
            if (ModelState.IsValid)
            {
                db.ProgrammingLanguages.Add(programmingLanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammingLanguage programmingLanguage = db.ProgrammingLanguages.Find(id);
            if (programmingLanguage == null)
            {
                return HttpNotFound();
            }
            return View(programmingLanguage);
        }

        // POST: ProgrammingLanguages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProgrammingLanguage1,Pecentage")] ProgrammingLanguage programmingLanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programmingLanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammingLanguage programmingLanguage = db.ProgrammingLanguages.Find(id);
            if (programmingLanguage == null)
            {
                return HttpNotFound();
            }
            return View(programmingLanguage);
        }

        // POST: ProgrammingLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgrammingLanguage programmingLanguage = db.ProgrammingLanguages.Find(id);
            db.ProgrammingLanguages.Remove(programmingLanguage);
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
