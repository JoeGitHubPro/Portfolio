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
    public class CertifcatesController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/Certifcates
        public IQueryable<Certifcate> GetCertifcates()
        {
            return db.Certifcates;
        }

        // GET: api/Certifcates/5
        [ResponseType(typeof(Certifcate))]
        public IHttpActionResult GetCertifcate(int id)
        {
            Certifcate certifcate = db.Certifcates.Find(id);
            if (certifcate == null)
            {
                return NotFound();
            }

            return Ok(certifcate);
        }

        // PUT: api/Certifcates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCertifcate(int id, Certifcate certifcate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != certifcate.ID)
            {
                return BadRequest();
            }

            db.Entry(certifcate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertifcateExists(id))
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

        // POST: api/Certifcates
        [ResponseType(typeof(Certifcate))]
        public IHttpActionResult PostCertifcate(Certifcate certifcate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Certifcates.Add(certifcate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = certifcate.ID }, certifcate);
        }

        // DELETE: api/Certifcates/5
        [ResponseType(typeof(Certifcate))]
        public IHttpActionResult DeleteCertifcate(int id)
        {
            Certifcate certifcate = db.Certifcates.Find(id);
            if (certifcate == null)
            {
                return NotFound();
            }

            db.Certifcates.Remove(certifcate);
            db.SaveChanges();

            return Ok(certifcate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CertifcateExists(int id)
        {
            return db.Certifcates.Count(e => e.ID == id) > 0;
        }
    }
}