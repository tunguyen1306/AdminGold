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
    public class PostDatasController : ApiController
    {
        private BusEntities db = new BusEntities();

        // GET: api/PostDatas
        public IQueryable<PostData> GetPostDatas()
        {
            return db.PostDatas;
        }

        // GET: api/PostDatas/5
        [ResponseType(typeof(PostData))]
        public IHttpActionResult GetPostData(int id)
        {
            PostData postData = db.PostDatas.Find(id);
            if (postData == null)
            {
                return NotFound();
            }

            return Ok(postData);
        }

        // PUT: api/PostDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPostData(int id, PostData postData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postData.ID)
            {
                return BadRequest();
            }

            db.Entry(postData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostDataExists(id))
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

        // POST: api/PostDatas
        [ResponseType(typeof(PostData))]
        public IHttpActionResult PostPostData(PostData postData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PostDatas.Add(postData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = postData.ID }, postData);
        }

        // DELETE: api/PostDatas/5
        [ResponseType(typeof(PostData))]
        public IHttpActionResult DeletePostData(int id)
        {
            PostData postData = db.PostDatas.Find(id);
            if (postData == null)
            {
                return NotFound();
            }

            db.PostDatas.Remove(postData);
            db.SaveChanges();

            return Ok(postData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostDataExists(int id)
        {
            return db.PostDatas.Count(e => e.ID == id) > 0;
        }
    }
}