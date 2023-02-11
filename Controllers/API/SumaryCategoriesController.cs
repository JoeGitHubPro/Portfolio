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
    public class SumaryCategoriesController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/SumaryCategories
        public  IHttpActionResult GetSumaryCategories()
        {
            var sumaryCategory = from Category in db.SumaryCategories
                                 select new { CategoryID = Category.CategoryID, SumaryCategory = Category.SumaryCategory1 };
          
            return Ok(sumaryCategory);
        }

        // GET: api/SumaryCategories/5
        [ResponseType(typeof(SumaryCategory))]
        public IHttpActionResult GetSumaryCategory(int id)
        {
            var sumaryCategory = from Cat in db.SumaryCategories
                    where Cat.CategoryID == id
                    select new { CategoryID = Cat.CategoryID, SumaryCategory = Cat.SumaryCategory1 };
           
            if (sumaryCategory == null)
            {
                return NotFound();
            }

            return Ok(sumaryCategory.SingleOrDefault());
        }

        // PUT: api/SumaryCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSumaryCategory(int id, SumaryCategory sumaryCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sumaryCategory.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(sumaryCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SumaryCategoryExists(id))
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

        // POST: api/SumaryCategories
        [ResponseType(typeof(SumaryCategory))]
        public IHttpActionResult PostSumaryCategory(SumaryCategory sumaryCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SumaryCategories.Add(sumaryCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SumaryCategoryExists(sumaryCategory.CategoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sumaryCategory.CategoryID }, sumaryCategory);
        }

        // DELETE: api/SumaryCategories/5
        [ResponseType(typeof(SumaryCategory))]
        public IHttpActionResult DeleteSumaryCategory(int id)
        {
            SumaryCategory sumaryCategory = db.SumaryCategories.Find(id);
            if (sumaryCategory == null)
            {
                return NotFound();
            }

            db.SumaryCategories.Remove(sumaryCategory);
            db.SaveChanges();

            return Ok(sumaryCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SumaryCategoryExists(int id)
        {
            return db.SumaryCategories.Count(e => e.CategoryID == id) > 0;
        }
    }
}