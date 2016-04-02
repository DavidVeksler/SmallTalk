namespace SmallTalk.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LessonRating")]
    public partial class LessonRating
    {
        public int id { get; set; }

        public int? LessonId { get; set; }

        public int? MentorRating { get; set; }

        public int? StudentRating { get; set; }

        public int? ContentMasteryRating { get; set; }

        public bool? IsFlagged { get; set; }

        public string MentorReview { get; set; }

        public string StudentReview { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}
