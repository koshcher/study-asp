using CookieProj.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CookieProj.Context
{
  public class AnimalContext : DbContext
  {
    public AnimalContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarManager;")
    { }

    public DbSet<Animal> Animals { get; set; }
    public DbSet<User> Users { get; set; }
  }
}