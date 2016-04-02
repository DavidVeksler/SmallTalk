//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmallTalk.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profile()
        {
            this.Lessons = new HashSet<Lesson>();
            this.Lessons1 = new HashSet<Lesson>();
            this.LocationPreferences = new HashSet<LocationPreference>();
            this.StudentProgresses = new HashSet<StudentProgress>();
            this.ProfileLessonAvailabilities = new HashSet<ProfileLessonAvailability>();
        }
    
        public int id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsStudent { get; set; }
        public Nullable<short> BirthYear { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public Nullable<int> NativeLanguage { get; set; }
        public Nullable<int> LearningLanguage { get; set; }
        public string AboutMe { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> LanguageLevelId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Language Language1 { get; set; }
        public virtual LanguageLevel LanguageLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LocationPreference> LocationPreferences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentProgress> StudentProgresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfileLessonAvailability> ProfileLessonAvailabilities { get; set; }
    }
}
