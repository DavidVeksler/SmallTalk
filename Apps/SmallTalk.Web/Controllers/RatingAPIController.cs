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
    [RoutePrefix("api/rating")]
    public class RatingAPIController : ApiController
    {
        private SmallTalkEntities db = new SmallTalkEntities();

        // GET: api/RatingAPI
        // http://localhost:1667/api/rating/1/history
        [Route("{id}/history")]
        public IQueryable<LessonRating> GetLessonRatingsForProfile(int id)
        {
            var ratings = db.LessonRatings.Where(r => r.Lesson.StudentId == id);
            return ratings.Select(r=> r);
        }

        // GET: api/RatingAPI/5
        [ResponseType(typeof(LessonRating))]
        public IHttpActionResult GetLessonRating(int id)
        {
            LessonRating lessonRating = db.LessonRatings.Find(id);
            if (lessonRating == null)
            {
                return NotFound();
            }

            return Ok(lessonRating);
        }

        // PUT: api/RatingAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLessonRating(int id, LessonRating lessonRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lessonRating.id)
            {
                return BadRequest();
            }

            db.Entry(lessonRating).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonRatingExists(id))
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

        // POST: api/RatingAPI
        [ResponseType(typeof(LessonRating))]
        public IHttpActionResult PostLessonRating(LessonRating lessonRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LessonRatings.Add(lessonRating);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lessonRating.id }, lessonRating);
        }

        // DELETE: api/RatingAPI/5
        [ResponseType(typeof(LessonRating))]
        public IHttpActionResult DeleteLessonRating(int id)
        {
            LessonRating lessonRating = db.LessonRatings.Find(id);
            if (lessonRating == null)
            {
                return NotFound();
            }

            db.LessonRatings.Remove(lessonRating);
            db.SaveChanges();

            return Ok(lessonRating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LessonRatingExists(int id)
        {
            return db.LessonRatings.Count(e => e.id == id) > 0;
        }
    }
}