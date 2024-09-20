using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Wizardry.Models;

namespace Wizardry.Data
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            Batteries_V2.Init();
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=DriversDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Person p1 = new Person() { Id = 1, Name = "Jerome" };
            Car c1 = new Car() { Id = 1, Brand = "Dodge Challenger", Model = "Hellcat", Fuel = Fuel.Gas, PersonId = 1 };
            Car c2 = new Car() { Id = 2, Brand = "Tesla", Model = "Cybertruck", Fuel = Fuel.Electric, PersonId = 1 };

            modelBuilder.Entity<Person>().HasData(p1);
            modelBuilder.Entity<Car>().HasData(c1,c2);
        }
    }
}
