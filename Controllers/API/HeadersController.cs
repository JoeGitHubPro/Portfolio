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
    public class HeadersController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/Headers
        public IHttpActionResult GetHeaders()
        {
            var header = from Header in db.Headers
                         select new { HeaderCategoryID = Header.ID, HeaderCategoryName = Header.HeaderCategory.HeaderName, Header =  Header.Header1 };
           
            return Ok(header);
        }

        // GET: api/Headers/5
        [ResponseType(typeof(Header))]
        public IHttpActionResult GetHeader(int id)
        {
            var header = from Header in db.Headers
                         where Header.ID == id
                         select new { HeaderCategoryID = Header.ID, HeaderCategoryName = Header.HeaderCategory.HeaderName, Header = Header.Header1 };

            if (header == null)
            {
                return NotFound();
            }

            return Ok(header.SingleOrDefault());
        }

        // PUT: api/Headers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHeader(int id, Header header)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != header.ID)
            {
                return BadRequest();
            }

            db.Entry(header).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeaderExists(id))
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

        // POST: api/Headers
        [ResponseType(typeof(Header))]
        public IHttpActionResult PostHeader(Header header)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Headers.Add(header);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HeaderExists(header.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = header.ID }, header);
        }

        // DELETE: api/Headers/5
        [ResponseType(typeof(Header))]
        public IHttpActionResult DeleteHeader(int id)
        {
            Header header = db.Headers.Find(id);
            if (header == null)
            {
                return NotFound();
            }

            db.Headers.Remove(header);
            db.SaveChanges();

            return Ok(header);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeaderExists(int id)
        {
            return db.Headers.Count(e => e.ID == id) > 0;
        }
    }
}