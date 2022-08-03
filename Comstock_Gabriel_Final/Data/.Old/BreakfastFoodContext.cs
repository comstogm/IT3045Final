using Comstock_Gabriel_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Comstock_Gabriel_Final.Data
{
    public class BreakfastFoodContext : DbContext
    {
        public BreakfastFoodContext(DbContextOptions<BreakfastFoodContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BreakfastFood>().HasData(
                new BreakfastFood { Id = 1, FullName = "Gabriel Comstock", FoodName = "Eggs", Cost = 3.50, TimeToPrepare = 5 },
                new BreakfastFood { Id = 2, FullName = "Person McName", FoodName = "Oatmeal", Cost = 1.50, TimeToPrepare = 10 }
                );
        }

        public DbSet<BreakfastFood> BreakfastFoods { get; set; }
    }
}