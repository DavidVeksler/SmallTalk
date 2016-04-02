namespace SmallTalk.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Profile")]
    public partial class Profile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profile()
        {
            Lessons = new HashSet<Lesson>();
            Lessons1 = new HashSet<Lesson>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        [Required]
        public string Name { get; set; }

        public int? BirthYear { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public string PhotoUrl { get; set; }

        public int? NativeLanguage { get; set; }

        public int? LearningLanguage { get; set; }

        public string AboutMe { get; set; }

        public string PhoneNumber { get; set; }

        public int? LanguageLevelId { get; set; }

        public string Availability { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual Language Language { get; set; }

        public virtual Language Language1 { get; set; }

        public virtual LanguageLevel LanguageLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons1 { get; set; }
    }
}
