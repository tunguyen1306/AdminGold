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
    public class DMTUYENCHITIETTRAMsController : ApiController
    {
        private BusEntities db = new BusEntities();

        // GET: api/DMTUYENCHITIETTRAMs
        public IQueryable<DMTUYENCHITIETTRAM> GetDMTUYENCHITIETTRAMs()
        {
            return db.DMTUYENCHITIETTRAMs;
        }

        // GET: api/DMTUYENCHITIETTRAMs/5
        [ResponseType(typeof(DMTUYENCHITIETTRAM))]
        public IHttpActionResult GetDMTUYENCHITIETTRAM(int id)
        {
            DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM = db.DMTUYENCHITIETTRAMs.Find(id);
            if (dMTUYENCHITIETTRAM == null)
            {
                return NotFound();
            }

            return Ok(dMTUYENCHITIETTRAM);
        }

        // PUT: api/DMTUYENCHITIETTRAMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDMTUYENCHITIETTRAM(int id, DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dMTUYENCHITIETTRAM.ID)
            {
                return BadRequest();
            }

            db.Entry(dMTUYENCHITIETTRAM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DMTUYENCHITIETTRAMExists(id))
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

        // POST: api/DMTUYENCHITIETTRAMs
        [ResponseType(typeof(DMTUYENCHITIETTRAM))]
        public IHttpActionResult PostDMTUYENCHITIETTRAM(DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DMTUYENCHITIETTRAMs.Add(dMTUYENCHITIETTRAM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dMTUYENCHITIETTRAM.ID }, dMTUYENCHITIETTRAM);
        }

        // DELETE: api/DMTUYENCHITIETTRAMs/5
        [ResponseType(typeof(DMTUYENCHITIETTRAM))]
        public IHttpActionResult DeleteDMTUYENCHITIETTRAM(int id)
        {
            DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM = db.DMTUYENCHITIETTRAMs.Find(id);
            if (dMTUYENCHITIETTRAM == null)
            {
                return NotFound();
            }

            db.DMTUYENCHITIETTRAMs.Remove(dMTUYENCHITIETTRAM);
            db.SaveChanges();

            return Ok(dMTUYENCHITIETTRAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DMTUYENCHITIETTRAMExists(int id)
        {
            return db.DMTUYENCHITIETTRAMs.Count(e => e.ID == id) > 0;
        }
    }
}