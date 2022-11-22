using NGO.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGO.Repository
{
    public class FoodRepository
    {
        static NGOEntities db;

        static FoodRepository()
        {
            db = new NGOEntities();
        }
        public static Food Get(int id)
        {
            var pr = (from e in db.Foods
                      where e.id == id
                      select e).FirstOrDefault();
            var p = db.Foods.FirstOrDefault(e => e.id == id);
            return p;
        }
        public List<Food> GetAll()
        {
            var foods = db.Foods.ToList();
            return foods;
        }
    }
}