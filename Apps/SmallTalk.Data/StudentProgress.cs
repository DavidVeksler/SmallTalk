namespace SmallTalk.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentProgress")]
    public partial class StudentProgress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? UnitId { get; set; }

        public int? LessonId { get; set; }

        public DateTime? StudyDate { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
