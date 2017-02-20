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
    public class LOTRINHCHOXEsController : ApiController
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: api/LOTRINHCHOXEs
        public IQueryable<LOTRINHCHOXE> GetLOTRINHCHOXEs()
        {
            return db.LOTRINHCHOXEs;
        }

        // GET: api/LOTRINHCHOXEs/5
        [ResponseType(typeof(LOTRINHCHOXE))]
        public IHttpActionResult GetLOTRINHCHOXE(int id)
        {
            LOTRINHCHOXE lOTRINHCHOXE = db.LOTRINHCHOXEs.Find(id);
            if (lOTRINHCHOXE == null)
            {
                return NotFound();
            }

            return Ok(lOTRINHCHOXE);
        }

        // PUT: api/LOTRINHCHOXEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLOTRINHCHOXE(int id, LOTRINHCHOXE lOTRINHCHOXE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lOTRINHCHOXE.IDLOTRINH)
            {
                return BadRequest();
            }

            db.Entry(lOTRINHCHOXE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LOTRINHCHOXEExists(id))
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

        // POST: api/LOTRINHCHOXEs
        [ResponseType(typeof(LOTRINHCHOXE))]
        public IHttpActionResult PostLOTRINHCHOXE(LOTRINHCHOXE lOTRINHCHOXE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LOTRINHCHOXEs.Add(lOTRINHCHOXE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lOTRINHCHOXE.IDLOTRINH }, lOTRINHCHOXE);
        }

        // DELETE: api/LOTRINHCHOXEs/5
        [ResponseType(typeof(LOTRINHCHOXE))]
        public IHttpActionResult DeleteLOTRINHCHOXE(int id)
        {
            LOTRINHCHOXE lOTRINHCHOXE = db.LOTRINHCHOXEs.Find(id);
            if (lOTRINHCHOXE == null)
            {
                return NotFound();
            }

            db.LOTRINHCHOXEs.Remove(lOTRINHCHOXE);
            db.SaveChanges();

            return Ok(lOTRINHCHOXE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LOTRINHCHOXEExists(int id)
        {
            return db.LOTRINHCHOXEs.Count(e => e.IDLOTRINH == id) > 0;
        }
    }
}