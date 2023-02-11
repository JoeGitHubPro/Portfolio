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
    public class SocialCategoriesController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/SocialCategories
        public  IHttpActionResult GetSocialCategories()
        {
            var socialCategory = from Category in db.SocialCategories
                                 select new { CategoryID = Category.CategoryID, CategorySocialName = Category.SocialName};
          
            return Ok(socialCategory);
          
        }

        // GET: api/SocialCategories/5
        [ResponseType(typeof(SocialCategory))]
        public IHttpActionResult GetSocialCategory(int id)
        {
            var socialCategory = from Category in db.SocialCategories
                                 where Category.CategoryID == id
                                 select new { CategoryID = Category.CategoryID, CategorySocialName = Category.SocialName };

            if (socialCategory == null)
            {
                return NotFound();
            }

            return Ok(socialCategory.SingleOrDefault());
        }

        // PUT: api/SocialCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSocialCategory(int id, SocialCategory socialCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != socialCategory.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(socialCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialCategoryExists(id))
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

        // POST: api/SocialCategories
        [ResponseType(typeof(SocialCategory))]
        public IHttpActionResult PostSocialCategory(SocialCategory socialCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SocialCategories.Add(socialCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SocialCategoryExists(socialCategory.CategoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = socialCategory.CategoryID }, socialCategory);
        }

        // DELETE: api/SocialCategories/5
        [ResponseType(typeof(SocialCategory))]
        public IHttpActionResult DeleteSocialCategory(int id)
        {
            SocialCategory socialCategory = db.SocialCategories.Find(id);
            if (socialCategory == null)
            {
                return NotFound();
            }

            db.SocialCategories.Remove(socialCategory);
            db.SaveChanges();

            return Ok(socialCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SocialCategoryExists(int id)
        {
            return db.SocialCategories.Count(e => e.CategoryID == id) > 0;
        }
    }
}