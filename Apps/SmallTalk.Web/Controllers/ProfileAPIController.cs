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
    [RoutePrefix("api/profile")]
    public class ProfileAPIController : ApiController
    {
        private SmallTalkEntities db = new SmallTalkEntities();

        // GET: api/ProfileAPI/5
        // http://localhost:1667/api/profileAPI/1
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

        // POST: http://localhost:1667/api/profile/1/availability/
        [HttpPost]
        [ResponseType(typeof(Profile))]
        [Route("{id}/availability")]
        public IHttpActionResult UpdateAvailability(List<ProfileLessonAvailability> times)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int profileId = times.First().ProfileId;
            db.ProfileLessonAvailabilities.RemoveRange(
                db.ProfileLessonAvailabilities.Where(p => p.ProfileId == profileId));

            db.ProfileLessonAvailabilities.AddRange(times);
            db.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [ResponseType(typeof(Profile))]
        [Route("{id}/availability")]
        public IHttpActionResult GetAvailability(int id)
        {
            var times = db.ProfileLessonAvailabilities.Where(p => p.ProfileId == id).ToList();

            //times.ForEach(t =>
            //{
                
            //})

            return Ok();
        }

        // /profileapi/1/progress
        //http://localhost:1667/api/profile/1/progress
        [Route("{id}/progress")]
      //  [ResponseType(typeof(List<StudentProgress>))]
        public IHttpActionResult GetAcademicProgress(int id)
        {
            var progress = db.StudentProgresses.Where(sp=> sp.ProfileId == id);
            if (!progress.Any())
            {
                return NotFound();
            }

            var lessonProgress = progress.Select(s => new
            {
                s.id,
                s.ProfileId,
                s.LessonId,
                s.StudyDate
            });

            return Ok(lessonProgress);


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