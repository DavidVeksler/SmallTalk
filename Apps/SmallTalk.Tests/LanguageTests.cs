using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallTalk.Data;

namespace SmallTalk.Tests
{
    [TestClass]
    public class LanguageTests
    {
        [TestMethod]
        public void AddLangage()
        {
            var lang = new Language
            {
                Name = "Chinese (Simplified)",
                LocalName = "普通話"
            };


            using (var db = new SmallTalkEntities())
            {
                db.Languages.Add(lang);

                db.SaveChanges();

            }

           

        }
    }
}
