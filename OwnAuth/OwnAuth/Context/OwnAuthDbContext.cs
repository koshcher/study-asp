using OwnAuth.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OwnAuth.Context
{
  public class OwnAuthDbContext : DbContext
  {
    public OwnAuthDbContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OwnAuth;")
    { }

    public DbSet<User> Users { get; set; }
  }
}