using Microsoft.EntityFrameworkCore;
using PrzykładKol.Properties.Models;

namespace PrzykładKol.Properties.Data;

public class Database : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Product_Order> Product_Orders { get; set; }
    public DbSet<Status> Status { get; set; }

    protected Database()
    {
    }

    public Database(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product_Order>(a =>
        {
            a.HasKey(x => new { x.ProductId, x.OrderId });
            
            a.HasOne(po=>po.Product)
                .WithMany(p=>p.ProductOrders)
                .HasForeignKey(po => po.ProductId);
            
            a.HasOne(po=>po.Order)
                .WithMany(p=>p.ProductOrders)
                .HasForeignKey(po => po.OrderId);
        });


        modelBuilder.Entity<Product>(a =>
            a.Property(x => x.Price).HasColumnType("numeric(10,2)")
        );
       
        modelBuilder.Entity<Client>().HasData(new List<Client>()
        {
            new Client() { ID = 1, FirstName = "John", LastName = "Doe" },
            new Client() { ID = 2, FirstName = "Jane", LastName = "Doe" },
            new Client() { ID = 3, FirstName = "Julie", LastName = "Doe" },
        });
        
        modelBuilder.Entity<Status>().HasData(new List<Status>()
        {
            new Status() { ID = 1, Name = "Created" },
            new Status() { ID = 2, Name = "Ongoing" },
            new Status() { ID = 3, Name = "Completed" },
        });
        
        modelBuilder.Entity<Product>().HasData(new List<Product>()
        {
            new Product() { ID = 1, Name = "Apple", Price = 3.45 },
            new Product() { ID = 2, Name = "Bananas", Price = 5.55 },
            new Product() { ID = 3, Name = "Orange", Price = 12.37 },
        });
        
        modelBuilder.Entity<Order>().HasData(new List<Order>()
        {
            new Order()
            {
                ID = 1,
                CreatedAt = DateTime.SpecifyKind(DateTime.Parse("2025-05-01"), DateTimeKind.Utc),
                FulfilledAt = DateTime.SpecifyKind(DateTime.Parse("2025-05-02"), DateTimeKind.Utc),
                ClientId = 1,
                StatusId = 3
            },
            new Order()
            {
                ID = 2,
                CreatedAt = DateTime.SpecifyKind(DateTime.Parse("2025-05-02"), DateTimeKind.Utc),
                FulfilledAt = null,
                ClientId = 1,
                StatusId = 2
            },
            new Order()
            {
                ID = 3,
                CreatedAt = DateTime.SpecifyKind(DateTime.Parse("2025-05-03"), DateTimeKind.Utc),
                FulfilledAt = null,
                ClientId = 1,
                StatusId = 1
            },
            new Order()
            {
                ID = 4,
                CreatedAt = DateTime.SpecifyKind(DateTime.Parse("2025-05-04"), DateTimeKind.Utc),
                FulfilledAt = null,
                ClientId = 2,
                StatusId = 1
            }
        });
        
        modelBuilder.Entity<Product_Order>().HasData(new List<Product_Order>()
        {
            new Product_Order() { ProductId = 1, OrderId = 1, Amount = 3},
            new Product_Order() { ProductId = 2, OrderId = 1, Amount = 5},
            new Product_Order() { ProductId = 3, OrderId = 1, Amount = 8},
            new Product_Order() { ProductId = 3, OrderId = 2, Amount = 1},
            new Product_Order() { ProductId = 2, OrderId = 2, Amount = 2},
            new Product_Order() { ProductId = 3, OrderId = 3, Amount = 8},
            new Product_Order() { ProductId = 1, OrderId = 3, Amount = 12},
        });
    }
}

