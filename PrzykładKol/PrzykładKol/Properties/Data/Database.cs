using Microsoft.EntityFrameworkCore;
using PrzykładKol.Properties.Models;

namespace PrzykładKol.Properties.Data;

public class Database : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Product_Order> ProductOrders { get; set; }
    public DbSet<Status> Status { get; set; }

    protected Database()
    {
    }

    public Database(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(a =>
            a.Property(x => x.Price).HasColumnType("numeric(10,2)")
        );
    }
}