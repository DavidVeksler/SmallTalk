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
    public class ProfileAPIController : ApiController
    {
        private SmallTalkEntities db = new SmallTalkEntities();

        //// GET: api/ProfileAPI
        //public IQueryable<Profile> GetProfiles()
        //{
        //    return db.Profiles;
        //}

        // GET: api/ProfileAPI/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult GetProfile(int id)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        [Route("profile/{id}/progress")]
        [ResponseType(typeof(List<StudentProgress>))]
        public IHttpActionResult GetAcademicProgress(int id)
        {
            throw new NotImplementedException();
        }

        // Update Profile
        // PUT: api/ProfileAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfile(int id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.id)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // CreateProfile
        // POST: api/ProfileAPI
        [ResponseType(typeof(Profile))]
        public IHttpActionResult PostProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(profile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profile.id }, profile);
        }

        //// DELETE: api/ProfileAPI/5
        //[ResponseType(typeof(Profile))]
        //public IHttpActionResult DeleteProfile(int id)
        //{
        //    Profile profile = db.Profiles.Find(id);
        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Profiles.Remove(profile);
        //    db.SaveChanges();

        //    return Ok(profile);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileExists(int id)
        {
            return db.Profiles.Count(e => e.id == id) > 0;
        }
    }
}