namespace EcommercePlatformSearch;

/// <summary>
/// Represents a single product in the e-commerce catalog.
/// Holds the minimal attributes required to support search:
/// a unique identifier, a display name, and a category.
/// </summary>
/// <remarks>
/// Implements <see cref="IComparable{Product}"/> so an array of products can be
/// sorted by <see cref="ProductName"/> (a prerequisite for binary search).
/// </remarks>
public sealed class Product : IComparable<Product>
{
    /// <summary>Unique numeric identifier for the product.</summary>
    public int ProductId { get; }

    /// <summary>Human-readable product name. Used as the search key.</summary>
    public string ProductName { get; }

    /// <summary>Category the product belongs to (e.g. "Electronics").</summary>
    public string Category { get; }

    /// <summary>Creates a new immutable product instance.</summary>
    /// <param name="productId">Unique numeric id.</param>
    /// <param name="productName">Display name (search key).</param>
    /// <param name="category">Product category.</param>
    public Product(int productId, string productName, string category)
    {
        ProductId = productId;
        ProductName = productName;
        Category = category;
    }

    /// <summary>
    /// Orders products alphabetically by <see cref="ProductName"/> using a
    /// case-insensitive ordinal comparison. This ordering is what binary search
    /// relies on, so the same comparison is reused by the search routine.
    /// </summary>
    public int CompareTo(Product? other)
    {
        if (other is null) return 1;
        return string.Compare(ProductName, other.ProductName, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>Returns a friendly one-line representation of the product.</summary>
    public override string ToString()
        => $"[Id={ProductId}, Name=\"{ProductName}\", Category=\"{Category}\"]";
}
