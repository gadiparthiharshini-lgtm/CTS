using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory.Data;

// Lab 2, Step 2 - Create AppDbContext.
// The DbContext is the bridge (ORM) between the C# model classes and the
// SQL Server tables. Each DbSet<T> maps to a table.
public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Update the Server value to match your SQL Server instance.
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=RetailInventoryDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
