// LAB - 5
/* using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

using var context = new AppDbContext();

// Retrieve all products
Console.WriteLine("===== All Products =====");

var products = await context.Products.ToListAsync();

foreach (var p in products)
{
    Console.WriteLine($"{p.Id}. {p.Name} - ₹{p.Price}");
}

// Find Product by ID
Console.WriteLine("\n===== Find Product By ID =====");

var product = await context.Products.FindAsync(1);

if (product != null)
{
    Console.WriteLine($"Found: {product.Name}");
}
else
{
    Console.WriteLine("Product not found.");
}

// First product with Price > 50000
Console.WriteLine("\n===== Expensive Product =====");

var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);

if (expensive != null)
{
    Console.WriteLine($"Expensive: {expensive.Name}");
}
else
{
    Console.WriteLine("No expensive product found.");
}*/


//LAB - 6


/*
using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

using var context = new AppDbContext();

// ---------------- UPDATE ----------------
var product = await context.Products
    .FirstOrDefaultAsync(p => p.Name == "Laptop");

if (product != null)
{
    product.Price = 70000;

    await context.SaveChangesAsync();

    Console.WriteLine("Laptop price updated successfully!");
}
else
{
    Console.WriteLine("Laptop not found.");
}

// ---------------- DELETE ----------------
var toDelete = await context.Products
    .FirstOrDefaultAsync(p => p.Name == "Rice Bag");

if (toDelete != null)
{
    context.Products.Remove(toDelete);

    await context.SaveChangesAsync();

    Console.WriteLine("Rice Bag deleted successfully!");
}
else
{
    Console.WriteLine("Rice Bag not found.");
}*/


// LAB -7 



using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

using var context = new AppDbContext();

// ---------------- Filter and Sort ----------------
Console.WriteLine("===== Products with Price > 1000 =====");

var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();

foreach (var product in filtered)
{
    Console.WriteLine($"{product.Name} - ₹{product.Price}");
}

// ---------------- DTO Projection ----------------
Console.WriteLine("\n===== Product DTOs =====");

var productDTOs = await context.Products
    .Select(p => new
    {
        p.Name,
        p.Price
    })
    .ToListAsync();

foreach (var item in productDTOs)
{
    Console.WriteLine($"{item.Name} - ₹{item.Price}");
}