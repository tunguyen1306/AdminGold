﻿using System;
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
    public class DMHOADONsController : ApiController
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: api/DMHOADONs
        public IQueryable<DMHOADON> GetDMHOADONs()
        {
            return db.DMHOADONs;
        }

        // GET: api/DMHOADONs/5
        [ResponseType(typeof(DMHOADON))]
        public IHttpActionResult GetDMHOADON(string id)
        {
            DMHOADON dMHOADON = db.DMHOADONs.Find(id);
            if (dMHOADON == null)
            {
                return NotFound();
            }

            return Ok(dMHOADON);
        }

        // PUT: api/DMHOADONs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDMHOADON(string id, DMHOADON dMHOADON)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dMHOADON.IDHOADON)
            {
                return BadRequest();
            }

            db.Entry(dMHOADON).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DMHOADONExists(id))
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

        // POST: api/DMHOADONs
        [ResponseType(typeof(DMHOADON))]
        public IHttpActionResult PostDMHOADON(DMHOADON dMHOADON)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DMHOADONs.Add(dMHOADON);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DMHOADONExists(dMHOADON.IDHOADON))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dMHOADON.IDHOADON }, dMHOADON);
        }

        // DELETE: api/DMHOADONs/5
        [ResponseType(typeof(DMHOADON))]
        public IHttpActionResult DeleteDMHOADON(string id)
        {
            DMHOADON dMHOADON = db.DMHOADONs.Find(id);
            if (dMHOADON == null)
            {
                return NotFound();
            }

            db.DMHOADONs.Remove(dMHOADON);
            db.SaveChanges();

            return Ok(dMHOADON);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DMHOADONExists(string id)
        {
            return db.DMHOADONs.Count(e => e.IDHOADON == id) > 0;
        }
    }
}