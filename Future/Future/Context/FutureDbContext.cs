using Future.Models;
using System.Data.Entity;

namespace Future.Context
{
  public class FutureDbContext : DbContext
  {
    public DbSet<Something> Somethings { get; set; }
  }
}