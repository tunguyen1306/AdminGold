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
    public class TrackingGPsController : ApiController
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: api/TrackingGPs
        public IQueryable<TrackingGP> GetTrackingGPS()
        {
            return db.TrackingGPS;
        }

        // GET: api/TrackingGPs/5
        [ResponseType(typeof(TrackingGP))]
        public IHttpActionResult GetTrackingGP(long id)
        {
            TrackingGP trackingGP = db.TrackingGPS.Find(id);
            if (trackingGP == null)
            {
                return NotFound();
            }

            return Ok(trackingGP);
        }

        // PUT: api/TrackingGPs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrackingGP(long id, TrackingGP trackingGP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trackingGP.IdTracking)
            {
                return BadRequest();
            }

            db.Entry(trackingGP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackingGPExists(id))
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

        // POST: api/TrackingGPs
        [ResponseType(typeof(TrackingGP))]
        public IHttpActionResult PostTrackingGP([FromBody]TrackingGP trackingGP)
        {
            var selectDta = db.TrackingGPS.Where(x=>x.MaXe== trackingGP.MaXe && x.MaTuyen== trackingGP.MaTuyen);
            if (selectDta.Count()>0)
            {
                var select = db.TrackingGPS.Where(x => x.MaXe == trackingGP.MaXe && x.MaTuyen == trackingGP.MaTuyen).Select(x=>x.IdTracking).FirstOrDefault();
                TrackingGP tblTracking = db.TrackingGPS.Find(select);
               
                tblTracking.Lat = trackingGP.Lat;
                tblTracking.lng = trackingGP.lng;
                tblTracking.Time = trackingGP.Time;
                tblTracking.DeviceId = trackingGP.DeviceId;
                db.Entry(tblTracking).State = EntityState.Modified;
                db.SaveChanges();
                TrackingGPSDetail trackingDetail = new TrackingGPSDetail();
                trackingDetail.IdTracking = select;
                trackingDetail.Lat = trackingGP.Lat;
                trackingDetail.Lng = trackingGP.lng;
                trackingDetail.Time = trackingGP.Time;
                db.TrackingGPSDetails.Add(trackingDetail);
                db.SaveChanges();
            }
            else
            {
               
                db.TrackingGPS.Add(trackingGP);

                db.SaveChanges();
                TrackingGPSDetail trackingDetail = new TrackingGPSDetail();
                trackingDetail.IdTracking = trackingGP.IdTracking;
                trackingDetail.Lat = trackingGP.Lat;
                trackingDetail.Lng = trackingGP.lng;
                trackingDetail.Time = trackingGP.Time;
                db.TrackingGPSDetails.Add(trackingDetail);
                db.SaveChanges();
            }
            

            return CreatedAtRoute("DefaultApi", new { id = trackingGP.IdTracking }, trackingGP);
        }

        // DELETE: api/TrackingGPs/5
        [ResponseType(typeof(TrackingGP))]
        public IHttpActionResult DeleteTrackingGP(long id)
        {
            TrackingGP trackingGP = db.TrackingGPS.Find(id);
            if (trackingGP == null)
            {
                return NotFound();
            }

            db.TrackingGPS.Remove(trackingGP);
            db.SaveChanges();

            return Ok(trackingGP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackingGPExists(long id)
        {
            return db.TrackingGPS.Count(e => e.IdTracking == id) > 0;
        }
    }
}