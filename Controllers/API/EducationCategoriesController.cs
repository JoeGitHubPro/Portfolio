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
    public class EducationCategoriesController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/EducationCategories
        public  IHttpActionResult GetEducationCategories()
        {
            var educationCategory = from Category in db.EducationCategories
                                      select new { CategoryID = Category.CategoryID, EducationCategory = Category.EducationCategory1 };
           
            return Ok(educationCategory);
        }

        // GET: api/EducationCategories/5
        [ResponseType(typeof(EducationCategory))]
        public IHttpActionResult GetEducationCategory(int id)
        {
            var educationCategory = from Category in db.EducationCategories
                                    where Category.CategoryID == id
                                    select new { CategoryID = Category.CategoryID, EducationCategory = Category.EducationCategory1 };

            if (educationCategory == null)
            {
                return NotFound();
            }

            return Ok(educationCategory.SingleOrDefault());
        }

        // PUT: api/EducationCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEducationCategory(int id, EducationCategory educationCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != educationCategory.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(educationCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationCategoryExists(id))
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

        // POST: api/EducationCategories
        [ResponseType(typeof(EducationCategory))]
        public IHttpActionResult PostEducationCategory(EducationCategory educationCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EducationCategories.Add(educationCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EducationCategoryExists(educationCategory.CategoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = educationCategory.CategoryID }, educationCategory);
        }

        // DELETE: api/EducationCategories/5
        [ResponseType(typeof(EducationCategory))]
        public IHttpActionResult DeleteEducationCategory(int id)
        {
            EducationCategory educationCategory = db.EducationCategories.Find(id);
            if (educationCategory == null)
            {
                return NotFound();
            }

            db.EducationCategories.Remove(educationCategory);
            db.SaveChanges();

            return Ok(educationCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EducationCategoryExists(int id)
        {
            return db.EducationCategories.Count(e => e.CategoryID == id) > 0;
        }
    }
}