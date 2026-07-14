namespace RetailInventory.Models;

// Lab 2, Step 1 - Create Models.
// A Category groups many Products (one-to-many). EF Core infers the
// relationship from the Product.CategoryId foreign key + navigation property.
public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Navigation property - the products that belong to this category.
    public List<Product> Products { get; set; } = new();
}
