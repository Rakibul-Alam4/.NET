using NGO.DB;
using NGO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace NGO.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var db = new NGOEntities();
            var foods = db.Foods.ToList();
            return View(foods);
        }
        public ActionResult AddToCart(int id)
        {
            var p = FoodRepository.Get(id);


            List<Food> foods;
            if (Session["cart"] == null)
            {
                foods = new List<Food>();
            }
            else
            {
                var json = Session["cart"].ToString();
                foods = new JavaScriptSerializer().Deserialize<List<Food>>(json);

            }
            p.Quantity = 1;
            foods.Add(p);
            var json2 = new JavaScriptSerializer().Serialize(foods);
            Session["cart"] = json2;
            return RedirectToAction("List", "Admin");


        }
        public ActionResult Cart()
        {
            var json = Session["cart"].ToString();
            var foods = new JavaScriptSerializer().Deserialize<List<Food>>(json);

            return View(foods);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
    }
}