using System;
using System.Collections.Generic;
using InventoryManagementSystem;

Dictionary<int, Product> inventory = new Dictionary<int, Product>();

// Add Product
void AddProduct(Product product)
{
    inventory[product.ProductId] = product;
    Console.WriteLine($"Product '{product.ProductName}' Added.");
}

// Update Product
void UpdateProduct(int id, int quantity, double price)
{
    if (inventory.ContainsKey(id))
    {
        inventory[id].Quantity = quantity;
        inventory[id].Price = price;
        Console.WriteLine($"Product ID {id} Updated.");
    }
    else
    {
        Console.WriteLine("Product Not Found.");
    }
}

// Delete Product
void DeleteProduct(int id)
{
    if (inventory.Remove(id))
        Console.WriteLine($"Product ID {id} Deleted.");
    else
        Console.WriteLine("Product Not Found.");
}

// Display Products
void DisplayProducts()
{
    Console.WriteLine("\nInventory:");

    foreach (var item in inventory.Values)
    {
        Console.WriteLine($"{item.ProductId} | {item.ProductName} | Qty:{item.Quantity} | Price:{item.Price}");
    }
}

// ----------------------

// Add Products
AddProduct(new Product
{
    ProductId = 101,
    ProductName = "Laptop",
    Quantity = 10,
    Price = 55000
});

AddProduct(new Product
{
    ProductId = 102,
    ProductName = "Mouse",
    Quantity = 25,
    Price = 700
});

// Display
DisplayProducts();

// Update
UpdateProduct(101, 15, 56000);

// Delete
DeleteProduct(102);

// Display Again
DisplayProducts();