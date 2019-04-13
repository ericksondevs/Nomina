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
using NominaDataBase;

namespace NominaWeb.Services
{
    public class AsientosContablesApiController : BaseApiController
    {

       // private NominaDBEntities db = new NominaDBEntities();

        // GET: api/AsientosContablesApi
        public IQueryable<AsientosContables> GetAsientosContables()
        {
            return db.AsientosContables;
        }

        // GET: api/AsientosContablesApi/5
        [ResponseType(typeof(AsientosContables))]
        public IHttpActionResult GetAsientosContables(int id)
        {
            AsientosContables asientosContables = db.AsientosContables.Find(id);
            if (asientosContables == null)
            {
                return NotFound();
            }

            return Ok(asientosContables);
        }

        // PUT: api/AsientosContablesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsientosContables(int id, AsientosContables asientosContables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asientosContables.IdAsiento)
            {
                return BadRequest();
            }

            db.Entry(asientosContables).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsientosContablesExists(id))
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

        // POST: api/AsientosContablesApi
        [ResponseType(typeof(AsientosContables))]
        public IHttpActionResult PostAsientosContables(AsientosContables asientosContables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AsientosContables.Add(asientosContables);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asientosContables.IdAsiento }, asientosContables);
        }

        // DELETE: api/AsientosContablesApi/5
        [ResponseType(typeof(AsientosContables))]
        public IHttpActionResult DeleteAsientosContables(int id)
        {
            AsientosContables asientosContables = db.AsientosContables.Find(id);
            if (asientosContables == null)
            {
                return NotFound();
            }

            db.AsientosContables.Remove(asientosContables);
            db.SaveChanges();

            return Ok(asientosContables);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsientosContablesExists(int id)
        {
            return db.AsientosContables.Count(e => e.IdAsiento == id) > 0;
        }
    }
}