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
    public class HeaderCategoriesController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/HeaderCategories
        public IHttpActionResult GetHeaderCategories()
        {
            var headerCategory = from Header in db.HeaderCategories                   
                                 select new { HeaderCategoryID = Header.CategoryID, HeaderName = Header.HeaderName };

            return Ok(headerCategory);
        }

        // GET: api/HeaderCategories/5
        [ResponseType(typeof(HeaderCategory))]
        public IHttpActionResult GetHeaderCategory(int id)
        {
            var headerCategory = from Header in db.HeaderCategories
                                 where Header.CategoryID == id
                                 select new { HeaderCategoryID = Header.CategoryID, HeaderName = Header.HeaderName };

            if (headerCategory == null)
            {
                return NotFound();
            }

            return Ok(headerCategory.SingleOrDefault());
        }

        // PUT: api/HeaderCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHeaderCategory(int id, HeaderCategory headerCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != headerCategory.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(headerCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeaderCategoryExists(id))
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

        // POST: api/HeaderCategories
        [ResponseType(typeof(HeaderCategory))]
        public IHttpActionResult PostHeaderCategory(HeaderCategory headerCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HeaderCategories.Add(headerCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HeaderCategoryExists(headerCategory.CategoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = headerCategory.CategoryID }, headerCategory);
        }

        // DELETE: api/HeaderCategories/5
        [ResponseType(typeof(HeaderCategory))]
        public IHttpActionResult DeleteHeaderCategory(int id)
        {
            HeaderCategory headerCategory = db.HeaderCategories.Find(id);
            if (headerCategory == null)
            {
                return NotFound();
            }

            db.HeaderCategories.Remove(headerCategory);
            db.SaveChanges();

            return Ok(headerCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeaderCategoryExists(int id)
        {
            return db.HeaderCategories.Count(e => e.CategoryID == id) > 0;
        }
    }
}