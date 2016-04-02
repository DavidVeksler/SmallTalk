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
    [RoutePrefix("api/lesson")]
    public class LessonAPIController : ApiController
    {
        private SmallTalkEntities db = new SmallTalkEntities();


        // GET: api/RatingAPI
        // http://localhost:1667/api/rating/1/history
        [Route("{id}/history")]
        public IHttpActionResult GetLessonsForProfile(int id)
        {
            var lessons = db.Lessons.Where(r => r.StudentId == id || r.MentorId == id);

            var model = lessons.Select(r => new
            {
                LocationId = r.Location.id,
                MeetingTime = r.MeetingTime,
                UnitId = r.UnitId
            });

            return Ok(model);
        }

        // GET: api/LessonAPI/5
        [ResponseType(typeof(Lesson))]
        public IHttpActionResult GetLesson(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }

        // PUT: api/LessonAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLesson(int id, Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lesson.id)
            {
                return BadRequest();
            }

            db.Entry(lesson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
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

        // POST: api/LessonAPI
        [ResponseType(typeof(Lesson))]
        public IHttpActionResult PostLesson(Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lessons.Add(lesson);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lesson.id }, lesson);
        }

        // confirm lesson:
        [Route("{id}/confirm")]
        public IHttpActionResult Confirm(int id, bool isMentor = false, bool isStudent = false)
        {
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return NotFound();
            }

            if (isMentor)
                lesson.MentorHasApproved = true;

            if (isStudent)
                lesson.StudentHasApproved = true;

            
            db.SaveChanges();

            return Ok(lesson);
        }

        // DELETE: api/LessonAPI/5
        [ResponseType(typeof(Lesson))]
        public IHttpActionResult DeleteLesson(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return NotFound();
            }

            db.Lessons.Remove(lesson);
            db.SaveChanges();

            return Ok(lesson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LessonExists(int id)
        {
            return db.Lessons.Count(e => e.id == id) > 0;
        }
    }
}