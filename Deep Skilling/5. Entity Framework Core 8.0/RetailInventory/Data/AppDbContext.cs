using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=LAPTOP-A5M4D3U5\\SQLEXPRESS;Database=RetailInventoryDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
// LAB - 2