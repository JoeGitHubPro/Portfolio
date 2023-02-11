using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portfolio;
using System.IO;


namespace Portfolio.Controllers.MVC
{
    public class ImagesController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();



   

        // GET: Images
        public ActionResult Index()
        {
            var result = db.Images.Where(a=>a.ImageID== 1).Select(e => e.ImagePath).SingleOrDefault();
                  
            string s = "/IMG/" + Url.Content(result);
             ViewBag.ImageUrl = s;

            return View(db.Images.ToList());
        }
      

        // GET: Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImageID,ImagePath")] Image image , HttpPostedFileBase SendFile)
        {
            
        
            if (ModelState.IsValid)
            {
                if (SendFile != null)
                {
                    SendFile.SaveAs(HttpContext.Server.MapPath("~/IMG/") + SendFile.FileName);
                    image.ImagePath = SendFile.FileName;
                }
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(image);
        }

        // GET: Images/Edit/5
        public ActionResult Edit(int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);

         
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageURL = "/IMG/" + Url.Content(image.ImagePath);

            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageID,ImagePath")] Image image, HttpPostedFileBase EditFile)
        {
          
            if (ModelState.IsValid)
            {
                string s = db.Images.Where(a => a.ImageID == 1).Select(b => b.ImagePath).SingleOrDefault();
                if (EditFile != null)
                {
                   
                    EditFile.SaveAs(HttpContext.Server.MapPath("~/IMG/") + EditFile.FileName);
                    image.ImagePath = EditFile.FileName;
                }
                db.Entry(image).State = EntityState.Modified;
                DeleteFile(s);
                db.SaveChanges();
                return RedirectToAction("Control", "Home", null);

            }
            return View(image);
        }

        // GET: Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void DeleteFile(string image)
        {
         

            var preroot = HttpContext.Server.MapPath("~/IMG");
            string root = preroot + "/" + image;
            System.IO.File.Delete(root);
            
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
