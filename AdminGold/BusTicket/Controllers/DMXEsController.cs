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
    public class DMXEsController : ApiController
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: api/DMXEs
        public IQueryable<DMXE> GetDMXEs()
        {
            return db.DMXEs;
        }

        // GET: api/DMXEs/5
        [ResponseType(typeof(DMXE))]
        public IHttpActionResult GetDMXE(string id)
        {
            DMXE dMXE = db.DMXEs.Find(id);
            if (dMXE == null)
            {
                return NotFound();
            }

            return Ok(dMXE);
        }

        // PUT: api/DMXEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDMXE(string id, DMXE dMXE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dMXE.MAXE)
            {
                return BadRequest();
            }

            db.Entry(dMXE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DMXEExists(id))
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

        // POST: api/DMXEs
        [ResponseType(typeof(DMXE))]
        public IHttpActionResult PostDMXE(DMXE dMXE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DMXEs.Add(dMXE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DMXEExists(dMXE.MAXE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dMXE.MAXE }, dMXE);
        }

        // DELETE: api/DMXEs/5
        [ResponseType(typeof(DMXE))]
        public IHttpActionResult DeleteDMXE(string id)
        {
            DMXE dMXE = db.DMXEs.Find(id);
            if (dMXE == null)
            {
                return NotFound();
            }

            db.DMXEs.Remove(dMXE);
            db.SaveChanges();

            return Ok(dMXE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DMXEExists(string id)
        {
            return db.DMXEs.Count(e => e.MAXE == id) > 0;
        }
    }
}