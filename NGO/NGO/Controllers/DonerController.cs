using NGO.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGO.Controllers
{
    public class DonerController : Controller
    {
        // GET: Doner
        public ActionResult Index()
        {
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
                return RedirectToAction("Index", "Doner");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Food f)
        {
            NGOEntities nGOEntities = new NGOEntities();
            nGOEntities.Foods.Add(f);
            nGOEntities.SaveChanges();
            return RedirectToAction("Index", "Doner");
        }
        public ActionResult List()
        {
            var db = new NGOEntities();
            var foods = db.Foods.ToList();
            return View(foods);
        }
        public ActionResult Edit(int id)
        {
            var db = new NGOEntities();
            var ext = (from it in db.Foods
                       where it.id == id
                       select it).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Edit(Food f)
        {
            var db = new NGOEntities();
            var ext = (from it in db.Foods
                       where it.id == f.id
                       select it).SingleOrDefault();
            ext.Fname = f.Fname;
            ext.Date = f.Date;
            ext.ResturantName = f.ResturantName;
            ext.Location = f.Location;
            ext.Quantity = f.Quantity;
            db.SaveChanges();
            return RedirectToAction("List", "Doner");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new NGOEntities();
            var ext = (from it in db.Foods
                       where it.id == id
                       select it).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Delete(Food s)
        {
            var db = new NGOEntities();
            var ext = (from it in db.Foods
                       where it.id == s.id
                       select it).SingleOrDefault();
            db.Foods.Remove(ext);
            db.SaveChanges();
            return RedirectToAction("List", "Doner");
        }
    }
}