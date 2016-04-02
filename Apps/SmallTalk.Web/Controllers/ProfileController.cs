using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallTalk.Data;

namespace SmallTalk.Web.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            var db = new SmallTalkEntities();

            var profiles = db.Profiles.Include("Language").Include("LanguageLevel").ToList();

            return View("ProfileList",profiles);
        }

        // http://localhost:1667/Profile/Profile/1
        public ActionResult Profile(int id)
        {
            var db = new SmallTalkEntities();

            var profile= db.Profiles.SingleOrDefault(p => p.id == id);


            return View("Profile",profile);
        }
    }
}