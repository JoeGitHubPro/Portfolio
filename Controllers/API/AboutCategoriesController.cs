using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Portfolio;

namespace Portfolio.Controllers.API
{
    public class AboutCategoriesController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/AboutCategories
        public IHttpActionResult GetAboutCategories()
        {
            var aboutCategories = from Category in db.AboutCategories
                    select new { AboutCategoryID = Category.CategoryID , AboutCategory = Category.AboutTopic  }  ;
            return Ok(aboutCategories);


        }

    // GET: api/AboutCategories/5
    [ResponseType(typeof(AboutCategory))]
        public IHttpActionResult GetAboutCategory(int id)
        {
            var aboutCategory = from Category in db.AboutCategories
                                where Category.CategoryID == id
                                select new { AboutCategoryID = Category.CategoryID, AboutCategory = Category.AboutTopic };

            if (aboutCategory == null)
            {
                return NotFound();
            }

            return Ok(aboutCategory.SingleOrDefault());
        }

        // PUT: api/AboutCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAboutCategory(int id, AboutCategory aboutCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aboutCategory.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(aboutCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AboutCategories
        [ResponseType(typeof(AboutCategory))]
        public IHttpActionResult PostAboutCategory(AboutCategory aboutCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AboutCategories.Add(aboutCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AboutCategoryExists(aboutCategory.CategoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aboutCategory.CategoryID }, aboutCategory);
        }

        // DELETE: api/AboutCategories/5
        [ResponseType(typeof(AboutCategory))]
        public IHttpActionResult DeleteAboutCategory(int id)
        {
            AboutCategory aboutCategory = db.AboutCategories.Find(id);
            if (aboutCategory == null)
            {
                return NotFound();
            }

            db.AboutCategories.Remove(aboutCategory);
            db.SaveChanges();

            return Ok(aboutCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AboutCategoryExists(int id)
        {
            return db.AboutCategories.Count(e => e.CategoryID == id) > 0;
        }
    }
}