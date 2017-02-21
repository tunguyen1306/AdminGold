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
using BusTicket.Models;

namespace BusTicket.Controllers
{
    public class CountersController : ApiController
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: api/Counters
        public IQueryable<Counter> GetCounters()
        {
            return db.Counters;
        }

        // GET: api/Counters/5
        [ResponseType(typeof(Counter))]
        public IHttpActionResult GetCounter(string id)
        {
            Counter counter = db.Counters.Find(id);
            if (counter == null)
            {
                return NotFound();
            }

            return Ok(counter);
        }

        // PUT: api/Counters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCounter(string id, Counter counter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != counter.MAXE)
            {
                return BadRequest();
            }

            db.Entry(counter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CounterExists(id))
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

        // POST: api/Counters
        [ResponseType(typeof(Counter))]
        public IHttpActionResult PostCounter(Counter counter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Counters.Add(counter);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CounterExists(counter.MAXE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = counter.MAXE }, counter);
        }

        // DELETE: api/Counters/5
        [ResponseType(typeof(Counter))]
        public IHttpActionResult DeleteCounter(string id)
        {
            Counter counter = db.Counters.Find(id);
            if (counter == null)
            {
                return NotFound();
            }

            db.Counters.Remove(counter);
            db.SaveChanges();

            return Ok(counter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CounterExists(string id)
        {
            return db.Counters.Count(e => e.MAXE == id) > 0;
        }
    }
}