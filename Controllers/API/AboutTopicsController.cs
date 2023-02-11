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
    public class AboutTopicsController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/AboutTopics
        public IHttpActionResult GetAboutTopics()
        {
            var aboutTopic = from Topic in db.AboutTopics
                              select new { TopicID = Topic.ID , TopicAboutCategory = Topic.AboutCategory.AboutTopic, TopicTopicDescrption = Topic.TopicDescrption };
         
            return Ok(aboutTopic);
             
        }

        // GET: api/AboutTopics/5
        [ResponseType(typeof(AboutTopic))]
        public IHttpActionResult GetAboutTopic(int id)
        {
            var aboutTopic = from Topic in db.AboutTopics
                             where Topic.ID == id    
                             select new { TopicID = Topic.ID, TopicAboutCategory = Topic.AboutCategory.AboutTopic, TopicTopicDescrption = Topic.TopicDescrption };

            if (aboutTopic == null)
            {
                return NotFound();
            }

            return Ok(aboutTopic.SingleOrDefault());
        }

        // PUT: api/AboutTopics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAboutTopic(int id, AboutTopic aboutTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aboutTopic.ID)
            {
                return BadRequest();
            }

            db.Entry(aboutTopic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutTopicExists(id))
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

        // POST: api/AboutTopics
        [ResponseType(typeof(AboutTopic))]
        public IHttpActionResult PostAboutTopic(AboutTopic aboutTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AboutTopics.Add(aboutTopic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AboutTopicExists(aboutTopic.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aboutTopic.ID }, aboutTopic);
        }

        // DELETE: api/AboutTopics/5
        [ResponseType(typeof(AboutTopic))]
        public IHttpActionResult DeleteAboutTopic(int id)
        {
            AboutTopic aboutTopic = db.AboutTopics.Find(id);
            if (aboutTopic == null)
            {
                return NotFound();
            }

            db.AboutTopics.Remove(aboutTopic);
            db.SaveChanges();

            return Ok(aboutTopic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AboutTopicExists(int id)
        {
            return db.AboutTopics.Count(e => e.ID == id) > 0;
        }
    }
}