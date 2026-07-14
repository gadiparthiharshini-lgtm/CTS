namespace EcommercePlatformSearch;

/// <summary>
/// Provides two search strategies over a product catalog, keyed on
/// <see cref="Product.ProductName"/>:
/// <list type="bullet">
///   <item><description>Linear search  - O(n), no ordering required.</description></item>
///   <item><description>Binary search  - O(log n), requires a sorted array.</description></item>
/// </list>
/// </summary>
public static class SearchService
{
    /// <summary>
    /// Scans the array element by element until a product whose name matches
    /// <paramref name="targetName"/> is found.
    /// </summary>
    /// <param name="products">The (unsorted) catalog to scan.</param>
    /// <param name="targetName">Product name to look for (case-insensitive).</param>
    /// <returns>The matching <see cref="Product"/>, or <c>null</c> if not found.</returns>
    /// <remarks>
    /// Best case  : O(1)  - the target is the first element.
    /// Average    : O(n)  - the target is somewhere in the middle.
    /// Worst case : O(n)  - the target is last or absent.
    /// </remarks>
    public static Product? LinearSearch(Product[] products, string targetName)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (string.Equals(products[i].ProductName, targetName, StringComparison.OrdinalIgnoreCase))
            {
                return products[i];
            }
        }

        return null;
    }

    /// <summary>
    /// Performs a classic binary search over an array that has already been
    /// sorted by <see cref="Product.ProductName"/> (ascending, case-insensitive).
    /// </summary>
    /// <param name="sortedProducts">Catalog sorted by product name.</param>
    /// <param name="targetName">Product name to look for (case-insensitive).</param>
    /// <returns>The matching <see cref="Product"/>, or <c>null</c> if not found.</returns>
    /// <remarks>
    /// Each comparison halves the remaining search space, so:
    /// Best case  : O(1)      - the target is exactly at the midpoint.
    /// Average    : O(log n).
    /// Worst case : O(log n)  - the target is absent or at a boundary.
    /// The input MUST be sorted with the same comparison used here, otherwise
    /// the result is undefined.
    /// </remarks>
    public static Product? BinarySearch(Product[] sortedProducts, string targetName)
    {
        int low = 0;
        int high = sortedProducts.Length - 1;

        while (low <= high)
        {
            // Compute midpoint without risking integer overflow.
            int mid = low + (high - low) / 2;

            int comparison = string.Compare(
                sortedProducts[mid].ProductName,
                targetName,
                StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
            {
                return sortedProducts[mid]; // Found it.
            }

            if (comparison < 0)
            {
                low = mid + 1;  // Target is in the upper half.
            }
            else
            {
                high = mid - 1; // Target is in the lower half.
            }
        }

        return null; // Exhausted the search space without a match.
    }
}
