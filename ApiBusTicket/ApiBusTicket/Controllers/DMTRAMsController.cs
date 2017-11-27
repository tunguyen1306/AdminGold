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
    public class DMTRAMsController : ApiController
    {
        private BusEntities db = new BusEntities();

        // GET: api/DMTRAMs
        public IQueryable<DMTRAM> GetDMTRAMs()
        {
            return db.DMTRAMs;
        }

        // GET: api/DMTRAMs/5
        [ResponseType(typeof(DMTRAM))]
        public IHttpActionResult GetDMTRAM(int id)
        {
            DMTRAM dMTRAM = db.DMTRAMs.Find(id);
            if (dMTRAM == null)
            {
                return NotFound();
            }

            return Ok(dMTRAM);
        }

        // PUT: api/DMTRAMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDMTRAM(int id, DMTRAM dMTRAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dMTRAM.ID)
            {
                return BadRequest();
            }

            db.Entry(dMTRAM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DMTRAMExists(id))
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

        // POST: api/DMTRAMs
        [ResponseType(typeof(DMTRAM))]
        public IHttpActionResult PostDMTRAM(DMTRAM dMTRAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DMTRAMs.Add(dMTRAM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dMTRAM.ID }, dMTRAM);
        }

        // DELETE: api/DMTRAMs/5
        [ResponseType(typeof(DMTRAM))]
        public IHttpActionResult DeleteDMTRAM(int id)
        {
            DMTRAM dMTRAM = db.DMTRAMs.Find(id);
            if (dMTRAM == null)
            {
                return NotFound();
            }

            db.DMTRAMs.Remove(dMTRAM);
            db.SaveChanges();

            return Ok(dMTRAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DMTRAMExists(int id)
        {
            return db.DMTRAMs.Count(e => e.ID == id) > 0;
        }
    }
}