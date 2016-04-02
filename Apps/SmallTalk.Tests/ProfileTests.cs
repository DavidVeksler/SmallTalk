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
            var profile = new Profile
            {
                Name = "Johhny Cash",
                UserName = "JohhnyCash",
                BirthYear = 1985,
                AboutMe = "About me...",
                Gender = "M",
                PhotoUrl = 
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
