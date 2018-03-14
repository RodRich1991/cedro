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
using CedroBackend.Models;

namespace CedroBackend.Controllers
{
    public class PratoController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: api/Prato
        public IQueryable<Prato> GetPratoes()
        {
            return db.Pratoes;
        }

        // GET: api/Prato/5
        [ResponseType(typeof(Prato))]
        public IHttpActionResult GetPrato(int id)
        {
            Prato prato = db.Pratoes.Find(id);
            if (prato == null)
            {
                return NotFound();
            }

            return Ok(prato);
        }

        // PUT: api/Prato/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrato(int id, Prato prato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prato.PratoId)
            {
                return BadRequest();
            }

            db.Entry(prato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PratoExists(id))
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

        // POST: api/Prato
        [ResponseType(typeof(Prato))]
        public IHttpActionResult PostPrato(Prato prato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pratoes.Add(prato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prato.PratoId }, prato);
        }

        // DELETE: api/Prato/5
        [ResponseType(typeof(Prato))]
        public IHttpActionResult DeletePrato(int id)
        {
            Prato prato = db.Pratoes.Find(id);
            if (prato == null)
            {
                return NotFound();
            }

            db.Pratoes.Remove(prato);
            db.SaveChanges();

            return Ok(prato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PratoExists(int id)
        {
            return db.Pratoes.Count(e => e.PratoId == id) > 0;
        }
    }
}