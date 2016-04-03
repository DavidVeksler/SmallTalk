using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallTalk.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ChooseRole()
        {
            return View();
        }

        public ActionResult ChooseMentor()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Lesson()
        {
            return View();
        }

        public ActionResult Availability()
        {
            return View();
        }

        public ActionResult Feedback()
        {
            return View();
        }

        public ActionResult LessonHistory()
        {
            return View();
        }


    }
}
