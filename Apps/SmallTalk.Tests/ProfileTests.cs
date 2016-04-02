using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallTalk.Data;

namespace SmallTalk.Tests
{
    [TestClass]
    public class ProfileTests
    {
        [TestMethod]
        public void CanCreateProfileForStudent()
        {
            //var profile = new Profile
            //{
            //    Name = "Adnan al-Kuds",
            //    UserName = "AdnanAlKuds",
            //    BirthYear = 1985,
            //    AboutMe = "",
            //    Gender = "F",
            //    PhotoUrl =  "/Uploads/2.png",
            //    NativeLanguage = 2,
            //    LearningLanguage = 1,
            //    PhoneNumber =  "404-386-2918",
            //    LanguageLevelId = 1,
            //};

            var profile = new Profile
            {
                Name = "Sarah Ahmed",
                UserName = "Akbar",
                BirthYear = 1980,
                AboutMe = "",
                Gender = "F",
                PhotoUrl = "/Uploads/9.png",
                NativeLanguage = 1,
                LearningLanguage = 1,
                PhoneNumber = "404-387-2918",
                LanguageLevelId = 1,
                IsStudent = false
            };


            using (var db = new SmallTalkEntities())
            {
                db.Profiles.Add(profile);

                db.SaveChanges();

            }

            Assert.IsTrue(profile != null);

        }
    }
}
