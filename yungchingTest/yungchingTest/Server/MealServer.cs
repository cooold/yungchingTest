using Microsoft.EntityFrameworkCore;
using System.Web;
using yungchingTest.Data;
using yungchingTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace yungchingTest.Server
{
    public class MealServer:DbContext
    {
        private readonly ApplicationDbContext _context;
        public MealServer(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Meal> QueryAll()
        {
            List<Meal> result = _context.Meals.Where(m => m.Removed == false).ToList();
            return result;
        }
        public List<Meal> QueryByKey(string key)
        {
            List<Meal> result = new List<Meal>();
            if (key == null)
            {
                result = QueryAll();
            }
            else
            {
                result = _context.Meals.Where(m => m.Removed == false && m.Name.Contains(key)).ToList();
            }
            return result;
        }
        public void UpgateMeal(Meal meal)
        {
            Meal adjust = _context.Meals.Where(m => m.Id == meal.Id).First();
            adjust.Name = meal.Name;
            adjust.Price = meal.Price;
            _context.SaveChanges();
        }
        public void CreateMeal(Meal meal, IFormFile mealImg)
        {
            string fileName = "";
            if (mealImg != null)
            {
                if (mealImg.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + ".jpg";
                    var path = Path.Combine
                        (("wwwroot/Image"), fileName);
                    mealImg.CopyTo(File.Create(path));
                }
            }
            Meal Newmeal = new Meal();
            Newmeal.Name = meal.Name;
            Newmeal.Price = meal.Price;
            Newmeal.Img = fileName;
            _context.Meals.Add(Newmeal);
            _context.SaveChanges();
        }
        public void RemoveById(int id)
        {
            Meal deleteMeal = _context.Meals.Where(m => m.Id == id).First();
            deleteMeal.Removed = true;
            _context.SaveChanges();
        }


    }
}
