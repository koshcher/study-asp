using Microsoft.EntityFrameworkCore;
using StoreCore.Context.Models;

namespace StoreCore.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // primary keys
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);

            modelBuilder.Entity<OrderDetails>().HasKey(od => new { od.Id, od.LineItem });
            
            // fk
            modelBuilder
                .Entity<OrderDetails>().HasOne(od => od.Order)
                .WithOne(o => o.OrderDetails)
                .HasForeignKey<OrderDetails>(od => od.Id)
                .IsRequired();

            modelBuilder
                .Entity<OrderDetails>().HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EmployeeId);

            // props
            modelBuilder.Entity<Customer>().Property(c => c.Phone).HasMaxLength(12);
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Product>().Property(p => p.Weight).HasColumnType("numeric(18,0)");
        }
    }
}
