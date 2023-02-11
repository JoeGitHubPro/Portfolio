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
    public class SocialLinksController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/SocialLinks
        public  IHttpActionResult GetSocialLinks()
        {
            var socialLink = from social in db.SocialLinks
                             select new { socialID = social.ID, socialNameCategory = social.SocialCategory.SocialName , socialLink = social.SocialLink1 };
          
            return Ok(socialLink);
        }

        // GET: api/SocialLinks/5
        [ResponseType(typeof(SocialLink))]
        public IHttpActionResult GetSocialLink(int id)
        {
            var socialLink = from social in db.SocialLinks
                             where social.ID == id  
                             select new { socialID = social.ID, socialNameCategory = social.SocialCategory.SocialName, socialLink = social.SocialLink1 };

            if (socialLink == null)
            {
                return NotFound();
            }

            return Ok(socialLink.SingleOrDefault());
        }

        // PUT: api/SocialLinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSocialLink(int id, SocialLink socialLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != socialLink.ID)
            {
                return BadRequest();
            }

            db.Entry(socialLink).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialLinkExists(id))
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

        // POST: api/SocialLinks
        [ResponseType(typeof(SocialLink))]
        public IHttpActionResult PostSocialLink(SocialLink socialLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SocialLinks.Add(socialLink);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SocialLinkExists(socialLink.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = socialLink.ID }, socialLink);
        }

        // DELETE: api/SocialLinks/5
        [ResponseType(typeof(SocialLink))]
        public IHttpActionResult DeleteSocialLink(int id)
        {
            SocialLink socialLink = db.SocialLinks.Find(id);
            if (socialLink == null)
            {
                return NotFound();
            }

            db.SocialLinks.Remove(socialLink);
            db.SaveChanges();

            return Ok(socialLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SocialLinkExists(int id)
        {
            return db.SocialLinks.Count(e => e.ID == id) > 0;
        }
    }
}