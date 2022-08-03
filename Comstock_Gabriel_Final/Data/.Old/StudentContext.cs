using Comstock_Gabriel_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Comstock_Gabriel_Final.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>().HasData(
                new Student { Id = 1, FullName = "Gabriel Comstock", Birthdate = 1994, CollegeProgram = "IT", YearInProgram = 5 },
                new Student { Id = 2, FullName = "Person McName", Birthdate = 1990, CollegeProgram = "Music", YearInProgram = 3 }
                );
        }

        public DbSet<Student> Students { get; set; }
    }
}