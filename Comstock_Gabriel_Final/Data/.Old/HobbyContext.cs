using Comstock_Gabriel_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Comstock_Gabriel_Final.Data
{
    public class HobbyContext : DbContext
    {
        public HobbyContext(DbContextOptions<HobbyContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, FullName = "Gabriel Comstock", CostOfHobby = 500, TypeOfHobby = "Sport", YearsDoingHobby = 5 },
                new Hobby { Id = 2, FullName = "Person McName", CostOfHobby = 1000, TypeOfHobby = "Gaming", YearsDoingHobby = 3 }
                );
        }

        public DbSet<Hobby> Hobbies { get; set; }
    }
}