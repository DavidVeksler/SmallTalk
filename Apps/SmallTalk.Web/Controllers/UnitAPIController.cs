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
using SmallTalk.Data;

namespace SmallTalk.Web.Controllers
{
    public class UnitAPIController : ApiController
    {
        private SmallTalkEntities db = new SmallTalkEntities();

        // GET: api/UnitAPI
        public IQueryable<Unit> GetUnits()
        {
            return db.Units;
        }

        // GET: api/UnitAPI/5
        [ResponseType(typeof(Unit))]
        public IHttpActionResult GetUnit(int id)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // PUT: api/UnitAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUnit(int id, Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unit.id)
            {
                return BadRequest();
            }

            db.Entry(unit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
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

        // POST: api/UnitAPI
        [ResponseType(typeof(Unit))]
        public IHttpActionResult PostUnit(Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Units.Add(unit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unit.id }, unit);
        }

        // DELETE: api/UnitAPI/5
        [ResponseType(typeof(Unit))]
        public IHttpActionResult DeleteUnit(int id)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return NotFound();
            }

            db.Units.Remove(unit);
            db.SaveChanges();

            return Ok(unit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnitExists(int id)
        {
            return db.Units.Count(e => e.id == id) > 0;
        }
    }
}