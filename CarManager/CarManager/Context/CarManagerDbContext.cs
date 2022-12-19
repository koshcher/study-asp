using CarManager.Context.Models;
using System.Data.Entity;

namespace CarManager.Context
{
    public class CarManagerDbContext : DbContext
    {
        public CarManagerDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserCar> UserCars { get; set; }

        public DbSet<Car> Cars { get; set; }
    }
}