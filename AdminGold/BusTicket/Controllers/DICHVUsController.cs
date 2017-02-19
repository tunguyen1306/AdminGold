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
    public class DICHVUsController : ApiController
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: api/DICHVUs
        public IQueryable<DICHVU> GetDICHVUs()
        {
            return db.DICHVUs;
        }

        // GET: api/DICHVUs/5
        [ResponseType(typeof(DICHVU))]
        public IHttpActionResult GetDICHVU(int id)
        {
            DICHVU dICHVU = db.DICHVUs.Find(id);
            if (dICHVU == null)
            {
                return NotFound();
            }

            return Ok(dICHVU);
        }

        // PUT: api/DICHVUs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDICHVU(int id, DICHVU dICHVU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dICHVU.ID)
            {
                return BadRequest();
            }

            db.Entry(dICHVU).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DICHVUExists(id))
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

        // POST: api/DICHVUs
        [ResponseType(typeof(DICHVU))]
        public IHttpActionResult PostDICHVU(DICHVU dICHVU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DICHVUs.Add(dICHVU);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dICHVU.ID }, dICHVU);
        }

        // DELETE: api/DICHVUs/5
        [ResponseType(typeof(DICHVU))]
        public IHttpActionResult DeleteDICHVU(int id)
        {
            DICHVU dICHVU = db.DICHVUs.Find(id);
            if (dICHVU == null)
            {
                return NotFound();
            }

            db.DICHVUs.Remove(dICHVU);
            db.SaveChanges();

            return Ok(dICHVU);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DICHVUExists(int id)
        {
            return db.DICHVUs.Count(e => e.ID == id) > 0;
        }
    }
}