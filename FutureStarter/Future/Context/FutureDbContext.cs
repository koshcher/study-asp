using Future.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Future.Context
{
  public class FutureDbContext : DbContext
  {
    public DbSet<Something> Somethings { get; set; }
  }
}