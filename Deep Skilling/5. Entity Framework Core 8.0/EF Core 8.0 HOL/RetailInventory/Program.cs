using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

// =====================================================================
//  EF Core 8.0 HOL - Retail Inventory System
//  This console app demonstrates Labs 4-7 end to end. Labs 1-3 (project
//  setup, DbContext, and migrations) are covered in the README and by the
//  Migrations/ folder. Run `dotnet ef database update` before running this.
// =====================================================================

Console.OutputEncoding = System.Text.Encoding.UTF8; // so the ₹ (rupee) sign prints

// Run `dotnet ef database update` (Lab 3) before running this app.
using var context = new AppDbContext();

// ---------------------------------------------------------------------
// Lab 4: Inserting Initial Data into the Database
// ---------------------------------------------------------------------
Console.WriteLine("=== Lab 4: Inserting Initial Data ===");

var electronics = new Category { Name = "Electronics" };
var groceries = new Category { Name = "Groceries" };
await context.Categories.AddRangeAsync(electronics, groceries);

var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
await context.Products.AddRangeAsync(product1, product2);

await context.SaveChangesAsync();
Console.WriteLine("Inserted 2 categories and 2 products.");

// ---------------------------------------------------------------------
// Lab 5: Retrieving Data from the Database
// ---------------------------------------------------------------------
Console.WriteLine("\n=== Lab 5: Retrieving Data ===");

// 1. Retrieve all products.
var products = await context.Products.ToListAsync();
Console.WriteLine("All products:");
foreach (var p in products)
    Console.WriteLine($"  {p.Name} - ₹{p.Price}");

// 2. Find by primary key.
var byId = await context.Products.FindAsync(1);
Console.WriteLine($"Find(1): {byId?.Name}");

// 3. FirstOrDefault with a condition.
var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
Console.WriteLine($"First product over 50000: {expensive?.Name}");

// ---------------------------------------------------------------------
// Lab 6: Updating and Deleting Records
// ---------------------------------------------------------------------
Console.WriteLine("\n=== Lab 6: Updating and Deleting ===");

// 1. Update a product's price.
var laptop = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
if (laptop != null)
{
    laptop.Price = 70000;
    await context.SaveChangesAsync();
    Console.WriteLine($"Updated Laptop price to ₹{laptop.Price}");
}

// 2. Delete a discontinued product.
var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
if (toDelete != null)
{
    context.Products.Remove(toDelete);
    await context.SaveChangesAsync();
    Console.WriteLine("Deleted 'Rice Bag'.");
}

// ---------------------------------------------------------------------
// Lab 7: Writing Queries with LINQ
// ---------------------------------------------------------------------
Console.WriteLine("\n=== Lab 7: LINQ Queries ===");

// 1. Filter and sort.
var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();
Console.WriteLine("Products over 1000 (desc by price):");
foreach (var p in filtered)
    Console.WriteLine($"  {p.Name} - ₹{p.Price}");

// 2. Project into a lightweight anonymous DTO.
var productDtos = await context.Products
    .Select(p => new { p.Name, p.Price })
    .ToListAsync();
Console.WriteLine("Projected DTOs (Name, Price):");
foreach (var dto in productDtos)
    Console.WriteLine($"  {dto.Name}, {dto.Price}");

Console.WriteLine("\nDone.");
