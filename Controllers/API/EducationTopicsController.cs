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
    public class EducationTopicsController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/EducationTopics
        public  IHttpActionResult GetEducationTopics()
        {
            var educationTopic = from Topic in db.EducationTopics
                                 select new { TopicID = Topic.ID, TopicEducationCategory = Topic.EducationCategory.EducationCategory1, TopicEducationTopic = Topic.EducationTopic1 };
            return Ok(educationTopic);
           
        }

        // GET: api/EducationTopics/5
        [ResponseType(typeof(EducationTopic))]
        public IHttpActionResult GetEducationTopic(int id)
        {
            var educationTopic = from Topic in db.EducationTopics
                                 where (Topic.ID == id)   
                                 select new { TopicID = Topic.ID, TopicEducationCategory = Topic.EducationCategory.EducationCategory1, TopicEducationTopic = Topic.EducationTopic1 };
            
            if (educationTopic == null)
            {
                return NotFound();
            }

             return Ok(educationTopic.SingleOrDefault());
        }

        // PUT: api/EducationTopics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEducationTopic(int id, EducationTopic educationTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != educationTopic.ID)
            {
                return BadRequest();
            }

            db.Entry(educationTopic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationTopicExists(id))
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

        // POST: api/EducationTopics
        [ResponseType(typeof(EducationTopic))]
        public IHttpActionResult PostEducationTopic(EducationTopic educationTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EducationTopics.Add(educationTopic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EducationTopicExists(educationTopic.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = educationTopic.ID }, educationTopic);
        }

        // DELETE: api/EducationTopics/5
        [ResponseType(typeof(EducationTopic))]
        public IHttpActionResult DeleteEducationTopic(int id)
        {
            EducationTopic educationTopic = db.EducationTopics.Find(id);
            if (educationTopic == null)
            {
                return NotFound();
            }

            db.EducationTopics.Remove(educationTopic);
            db.SaveChanges();

            return Ok(educationTopic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EducationTopicExists(int id)
        {
            return db.EducationTopics.Count(e => e.ID == id) > 0;
        }
    }
}