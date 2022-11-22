using NGO.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NGO.Controllers
{
    public class HomeController : Controller
    {
        public object Role { get; private set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User r)
        {
            NGOEntities nGOEntities = new NGOEntities();
            var login = (from c in nGOEntities.Users
                         where c.Name == r.Name && c.Password == r.Password
                         select c);
            if (login != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User u)
        {

            NGOEntities nGOEntities = new NGOEntities();
            nGOEntities.Users.Add(u);
            nGOEntities.SaveChanges();
            return RedirectToAction("Login");
            //return View(u);
        }

    }
}