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
    public class SumaryTopicsController : ApiController
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: api/SumaryTopics
        public  IHttpActionResult GetSumaryTopics()
        {
            var sumaryTopic = from Sumary in db.SumaryTopics
                              select new { SumaryID = Sumary.ID, SumaryCategory = Sumary.SumaryCategory.SumaryCategory1 , SumaryTopicName = Sumary.SumaryTopicName };
           
            return Ok(sumaryTopic);
          
        }

        // GET: api/SumaryTopics/5
        [ResponseType(typeof(SumaryTopic))]
        public IHttpActionResult GetSumaryTopic(int id)
        {
            var sumaryTopic = from Sumary in db.SumaryTopics
                              where Sumary.ID == id
                              select new { SumaryID = Sumary.ID, SumaryCategory = Sumary.SumaryCategory.SumaryCategory1, SumaryTopicName = Sumary.SumaryTopicName };

            if (sumaryTopic == null)
            {
                return NotFound();
            }

            return Ok(sumaryTopic.SingleOrDefault());
        }

        // PUT: api/SumaryTopics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSumaryTopic(int id, SumaryTopic sumaryTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sumaryTopic.ID)
            {
                return BadRequest();
            }

            db.Entry(sumaryTopic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SumaryTopicExists(id))
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

        // POST: api/SumaryTopics
        [ResponseType(typeof(SumaryTopic))]
        public IHttpActionResult PostSumaryTopic(SumaryTopic sumaryTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SumaryTopics.Add(sumaryTopic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SumaryTopicExists(sumaryTopic.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sumaryTopic.ID }, sumaryTopic);
        }

        // DELETE: api/SumaryTopics/5
        [ResponseType(typeof(SumaryTopic))]
        public IHttpActionResult DeleteSumaryTopic(int id)
        {
            SumaryTopic sumaryTopic = db.SumaryTopics.Find(id);
            if (sumaryTopic == null)
            {
                return NotFound();
            }

            db.SumaryTopics.Remove(sumaryTopic);
            db.SaveChanges();

            return Ok(sumaryTopic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SumaryTopicExists(int id)
        {
            return db.SumaryTopics.Count(e => e.ID == id) > 0;
        }
    }
}