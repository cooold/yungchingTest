using Microsoft.EntityFrameworkCore;
using yungchingTest.Models;

namespace yungchingTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }

        public DbSet<Meal> Meals { get; set; }
    }
}
