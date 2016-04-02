namespace SmallTalk.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lesson")]
    public partial class Lesson
    {
        public int id { get; set; }

        public int? StudentId { get; set; }

        public int? MentorId { get; set; }

        public int? LocationId { get; set; }

        public DateTime? MeetingTime { get; set; }

        public bool? IsCancelled { get; set; }

        public bool? IsLessonOpened { get; set; }

        public int? UnitId { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual Location Location { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual Profile Profile1 { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual LessonRating LessonRating { get; set; }
    }
}
