using CarManager.Models;
using System.Data.Entity;

namespace CarManager.Context
{
  public class CarManagerDbContext : DbContext
  {
    public CarManagerDbContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarManager;")
    {
    }

    public DbSet<Car> Cars { get; set; }
  }
}