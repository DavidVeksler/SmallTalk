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
            var profile = new Profile();

            profile.Name = "Johhny Cash";
            profile.UserName = "JohhnyCash";

            using (var db = new SmallTalkEntities())
            {
                db.Profiles.Add(profile);

                db.SaveChanges();

            }

            Assert.IsTrue(profile != null);

        }
    }
}
