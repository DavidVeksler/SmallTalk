namespace SmallTalk.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SmallTalkDB : DbContext
    {
        public SmallTalkDB()
            : base("name=SmallTalkDB")
        {
        }

        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LanguageLevel> LanguageLevels { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<StudentProgress> StudentProgresses { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>()
                .HasMany(e => e.Profiles)
                .WithOptional(e => e.Language)
                .HasForeignKey(e => e.NativeLanguage);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Profiles1)
                .WithOptional(e => e.Language1)
                .HasForeignKey(e => e.LearningLanguage);

            modelBuilder.Entity<LanguageLevel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<LanguageLevel>()
                .Property(e => e.CEFRLevel)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Profile>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Lessons)
                .WithOptional(e => e.Profile)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Lessons1)
                .WithOptional(e => e.Profile1)
                .HasForeignKey(e => e.MentorId);
        }
    }
}
