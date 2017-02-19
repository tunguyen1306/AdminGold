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
    public class DMTUYENsController : ApiController
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: api/DMTUYENs
        public IQueryable<DMTUYEN> GetDMTUYENs()
        {
            return db.DMTUYENs;
        }

        // GET: api/DMTUYENs/5
        [ResponseType(typeof(DMTUYEN))]
        public IHttpActionResult GetDMTUYEN(string id)
        {
            DMTUYEN dMTUYEN = db.DMTUYENs.Find(id);
            if (dMTUYEN == null)
            {
                return NotFound();
            }

            return Ok(dMTUYEN);
        }

        // PUT: api/DMTUYENs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDMTUYEN(string id, DMTUYEN dMTUYEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dMTUYEN.IDTUYEN)
            {
                return BadRequest();
            }

            db.Entry(dMTUYEN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DMTUYENExists(id))
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

        // POST: api/DMTUYENs
        [ResponseType(typeof(DMTUYEN))]
        public IHttpActionResult PostDMTUYEN(DMTUYEN dMTUYEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DMTUYENs.Add(dMTUYEN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DMTUYENExists(dMTUYEN.IDTUYEN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dMTUYEN.IDTUYEN }, dMTUYEN);
        }

        // DELETE: api/DMTUYENs/5
        [ResponseType(typeof(DMTUYEN))]
        public IHttpActionResult DeleteDMTUYEN(string id)
        {
            DMTUYEN dMTUYEN = db.DMTUYENs.Find(id);
            if (dMTUYEN == null)
            {
                return NotFound();
            }

            db.DMTUYENs.Remove(dMTUYEN);
            db.SaveChanges();

            return Ok(dMTUYEN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DMTUYENExists(string id)
        {
            return db.DMTUYENs.Count(e => e.IDTUYEN == id) > 0;
        }
    }
}