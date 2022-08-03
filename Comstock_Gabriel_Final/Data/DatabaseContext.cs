using Comstock_Gabriel_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Comstock_Gabriel_Final.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<BreakfastFood> BreakfastFoods { get; set; }
        public DbSet<Music> FavoriteMusic { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}