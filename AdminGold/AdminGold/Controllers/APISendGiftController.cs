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
using AdminGold.Models;

namespace AdminGold.Controllers
{
    public class APISendGiftController : ApiController
    {
        private ApiSendGiftEntities db = new ApiSendGiftEntities();

        // GET: api/APISendGift
        public IQueryable<tblAdvertGift> GettblAdvertGifts()
        {
            return db.tblAdvertGifts;
        }

        // GET: api/APISendGift/5
        [ResponseType(typeof(tblAdvertGift))]
        public IHttpActionResult GettblAdvertGift(int id)
        {
            tblAdvertGift tblAdvertGift = db.tblAdvertGifts.Find(id);
            if (tblAdvertGift == null)
            {
                return NotFound();
            }

            return Ok(tblAdvertGift);
        }

        // PUT: api/APISendGift/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblAdvertGift(int id, tblAdvertGift tblAdvertGift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAdvertGift.IdAdvertGift)
            {
                return BadRequest();
            }

            db.Entry(tblAdvertGift).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAdvertGiftExists(id))
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

        // POST: api/APISendGift
        [ResponseType(typeof(tblAdvertGift))]
        public IHttpActionResult PosttblAdvertGift(tblAdvertGift tblAdvertGift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblAdvertGifts.Add(tblAdvertGift);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblAdvertGift.IdAdvertGift }, tblAdvertGift);
        }

        // DELETE: api/APISendGift/5
        [ResponseType(typeof(tblAdvertGift))]
        public IHttpActionResult DeletetblAdvertGift(int id)
        {
            tblAdvertGift tblAdvertGift = db.tblAdvertGifts.Find(id);
            if (tblAdvertGift == null)
            {
                return NotFound();
            }

            db.tblAdvertGifts.Remove(tblAdvertGift);
            db.SaveChanges();

            return Ok(tblAdvertGift);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAdvertGiftExists(int id)
        {
            return db.tblAdvertGifts.Count(e => e.IdAdvertGift == id) > 0;
        }
        private IList<tblAdvertGift> GetListAdvertBySearch(string search)
        {
            var ListAdvert = db.tblAdvertGifts.Where(x => x.KeySearchAdvertGift.Contains(search) || x.NameAdvertGift.Contains(search));
            return ListAdvert.ToList();
        }
    }
}