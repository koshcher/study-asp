using CarManager.Models;
using System.Data.Entity;

namespace CarManager.Context
{
  public class CarManagerDbContext : DbContext
  {
    public CarManagerDbContext(string connStr) : base(connStr)
    {
    }

    public DbSet<Car> Cars { get; set; }

    public DbSet<User> Users { get; set; }
  }
}