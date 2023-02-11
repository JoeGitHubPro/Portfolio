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
    public class ProgrammingLanguagesController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/ProgrammingLanguages
        public IQueryable<ProgrammingLanguage> GetProgrammingLanguages()
        {
            return db.ProgrammingLanguages;
        }

        // GET: api/ProgrammingLanguages/5
        [ResponseType(typeof(ProgrammingLanguage))]
        public IHttpActionResult GetProgrammingLanguage(int id)
        {
            ProgrammingLanguage programmingLanguage = db.ProgrammingLanguages.Find(id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }

            return Ok(programmingLanguage);
        }

        // PUT: api/ProgrammingLanguages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProgrammingLanguage(int id, ProgrammingLanguage programmingLanguage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programmingLanguage.ID)
            {
                return BadRequest();
            }

            db.Entry(programmingLanguage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammingLanguageExists(id))
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

        // POST: api/ProgrammingLanguages
        [ResponseType(typeof(ProgrammingLanguage))]
        public IHttpActionResult PostProgrammingLanguage(ProgrammingLanguage programmingLanguage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProgrammingLanguages.Add(programmingLanguage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = programmingLanguage.ID }, programmingLanguage);
        }

        // DELETE: api/ProgrammingLanguages/5
        [ResponseType(typeof(ProgrammingLanguage))]
        public IHttpActionResult DeleteProgrammingLanguage(int id)
        {
            ProgrammingLanguage programmingLanguage = db.ProgrammingLanguages.Find(id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }

            db.ProgrammingLanguages.Remove(programmingLanguage);
            db.SaveChanges();

            return Ok(programmingLanguage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgrammingLanguageExists(int id)
        {
            return db.ProgrammingLanguages.Count(e => e.ID == id) > 0;
        }
    }
}