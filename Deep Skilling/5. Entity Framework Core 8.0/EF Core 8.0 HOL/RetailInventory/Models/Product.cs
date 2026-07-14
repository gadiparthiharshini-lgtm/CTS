namespace RetailInventory.Models;

// Lab 2, Step 1 - Create Models.
// Each Product belongs to exactly one Category (many-to-one).
public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    // Foreign key to Category.
    public int CategoryId { get; set; }

    // Navigation property to the owning category.
    public Category Category { get; set; } = null!;
}
