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
using ApiBusTicket.Models;

namespace ApiBusTicket.Controllers
{
    public class DMTAIXEsController : ApiController
    {
        private BusEntities db = new BusEntities();

        // GET: api/DMTAIXEs
        public IQueryable<DMTAIXE> GetDMTAIXEs()
        {
            return db.DMTAIXEs;
        }

        // GET: api/DMTAIXEs/5
        [ResponseType(typeof(DMTAIXE))]
        public IHttpActionResult GetDMTAIXE(string id)
        {
            DMTAIXE dMTAIXE = db.DMTAIXEs.Find(id);
            if (dMTAIXE == null)
            {
                return NotFound();
            }

            return Ok(dMTAIXE);
        }

        // PUT: api/DMTAIXEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDMTAIXE(string id, DMTAIXE dMTAIXE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dMTAIXE.MATAIXE)
            {
                return BadRequest();
            }

            db.Entry(dMTAIXE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DMTAIXEExists(id))
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

        // POST: api/DMTAIXEs
        [ResponseType(typeof(DMTAIXE))]
        public IHttpActionResult PostDMTAIXE(DMTAIXE dMTAIXE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DMTAIXEs.Add(dMTAIXE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DMTAIXEExists(dMTAIXE.MATAIXE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dMTAIXE.MATAIXE }, dMTAIXE);
        }

        // DELETE: api/DMTAIXEs/5
        [ResponseType(typeof(DMTAIXE))]
        public IHttpActionResult DeleteDMTAIXE(string id)
        {
            DMTAIXE dMTAIXE = db.DMTAIXEs.Find(id);
            if (dMTAIXE == null)
            {
                return NotFound();
            }

            db.DMTAIXEs.Remove(dMTAIXE);
            db.SaveChanges();

            return Ok(dMTAIXE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DMTAIXEExists(string id)
        {
            return db.DMTAIXEs.Count(e => e.MATAIXE == id) > 0;
        }
    }
}