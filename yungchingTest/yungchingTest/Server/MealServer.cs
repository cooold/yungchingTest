using Microsoft.EntityFrameworkCore;
using yungchingTest.Data;
using yungchingTest.Models;

namespace yungchingTest.Server
{
    public class MealServer
    {
        private readonly ApplicationDbContext _context;
        public MealServer(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<Meal> QueryAll()
        {
            List<Meal> result = _context.Meals.ToList();
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
                result = _context.Meals.Where(m => m.Name.Contains(key)).ToList();
            }
            return result;
        }
        public void upgateMeal(Meal meal)
        {
            Meal adjust = _context.Meals.Where(m => m.Id == meal.Id).First();
            adjust.Name = meal.Name;
            adjust.Price = meal.Price;
            _context.SaveChanges();
        }

    }
}
