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

        public List<Meal> QueryByKey(string key)
        {
            List<Meal> result = new List<Meal>();
            if (key == null)
            {
                result = _context.Meals.ToList();
            }
            else
            {
                result = _context.Meals.Where(m => m.Name.Contains(key)).ToList();
            }
            return result;
        }

    }
}
