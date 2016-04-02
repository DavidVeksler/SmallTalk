namespace SmallTalk.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LanguageLevel",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        CEFRLevel = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        Name = c.String(nullable: false),
                        IsStudent = c.Boolean(),
                        BirthYear = c.Short(),
                        Gender = c.String(maxLength: 10, fixedLength: true),
                        PhotoUrl = c.String(),
                        NativeLanguage = c.Int(),
                        LearningLanguage = c.Int(),
                        AboutMe = c.String(),
                        PhoneNumber = c.String(unicode: false),
                        LanguageLevelId = c.Int(),
                        Availability = c.String(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Language", t => t.NativeLanguage)
                .ForeignKey("dbo.Language", t => t.LearningLanguage)
                .ForeignKey("dbo.LanguageLevel", t => t.LanguageLevelId)
                .Index(t => t.NativeLanguage)
                .Index(t => t.LearningLanguage)
                .Index(t => t.LanguageLevelId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LocalName = c.String(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(),
                        MentorId = c.Int(),
                        LocationId = c.Int(),
                        MeetingTime = c.DateTime(),
                        IsCancelled = c.Boolean(),
                        IsLessonOpened = c.Boolean(),
                        UnitId = c.Int(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .ForeignKey("dbo.Unit", t => t.UnitId)
                .ForeignKey("dbo.Profile", t => t.StudentId)
                .ForeignKey("dbo.Profile", t => t.MentorId)
                .Index(t => t.StudentId)
                .Index(t => t.MentorId)
                .Index(t => t.LocationId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.LessonRating",
                c => new
                    {
                        id = c.Int(nullable: false),
                        LessonId = c.Int(),
                        MentorRating = c.Int(),
                        StudentRating = c.Int(),
                        ContentMasteryRating = c.Int(),
                        IsFlagged = c.Boolean(),
                        MentorReview = c.String(),
                        StudentReview = c.String(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Lesson", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsFeature = c.Boolean(),
                        Address1 = c.String(),
                        PostalCode = c.String(unicode: false),
                        TimesUsed = c.Int(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        URL = c.String(maxLength: 500),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.StudentProgress",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UnitId = c.Int(),
                        LessonId = c.Int(),
                        StudyDate = c.DateTime(),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Unit", t => t.UnitId)
                .Index(t => t.UnitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lesson", "MentorId", "dbo.Profile");
            DropForeignKey("dbo.Lesson", "StudentId", "dbo.Profile");
            DropForeignKey("dbo.StudentProgress", "UnitId", "dbo.Unit");
            DropForeignKey("dbo.Lesson", "UnitId", "dbo.Unit");
            DropForeignKey("dbo.Lesson", "LocationId", "dbo.Location");
            DropForeignKey("dbo.LessonRating", "id", "dbo.Lesson");
            DropForeignKey("dbo.Profile", "LanguageLevelId", "dbo.LanguageLevel");
            DropForeignKey("dbo.Profile", "LearningLanguage", "dbo.Language");
            DropForeignKey("dbo.Profile", "NativeLanguage", "dbo.Language");
            DropIndex("dbo.StudentProgress", new[] { "UnitId" });
            DropIndex("dbo.LessonRating", new[] { "id" });
            DropIndex("dbo.Lesson", new[] { "UnitId" });
            DropIndex("dbo.Lesson", new[] { "LocationId" });
            DropIndex("dbo.Lesson", new[] { "MentorId" });
            DropIndex("dbo.Lesson", new[] { "StudentId" });
            DropIndex("dbo.Profile", new[] { "LanguageLevelId" });
            DropIndex("dbo.Profile", new[] { "LearningLanguage" });
            DropIndex("dbo.Profile", new[] { "NativeLanguage" });
            DropTable("dbo.StudentProgress");
            DropTable("dbo.Unit");
            DropTable("dbo.Location");
            DropTable("dbo.LessonRating");
            DropTable("dbo.Lesson");
            DropTable("dbo.Language");
            DropTable("dbo.Profile");
            DropTable("dbo.LanguageLevel");
        }
    }
}
