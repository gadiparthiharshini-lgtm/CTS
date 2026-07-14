using EcommercePlatformSearch;

// ---------------------------------------------------------------------------
// Exercise 2 - E-commerce Platform Search Function
// Demonstrates linear search (unsorted array) vs binary search (sorted array)
// over a small product catalog, then prints a complexity comparison.
// ---------------------------------------------------------------------------

Console.WriteLine("=== E-commerce Platform Search ===\n");

// 1. Build a sample catalog (intentionally unsorted by name).
Product[] catalog =
{
    new(101, "Wireless Mouse",    "Electronics"),
    new(102, "Yoga Mat",          "Fitness"),
    new(103, "Coffee Maker",      "Home"),
    new(104, "Bluetooth Speaker", "Electronics"),
    new(105, "Running Shoes",     "Footwear"),
    new(106, "Desk Lamp",         "Home"),
    new(107, "Notebook",          "Stationery"),
};

Console.WriteLine($"Catalog contains {catalog.Length} products (unsorted):");
foreach (Product p in catalog)
{
    Console.WriteLine($"  {p}");
}
Console.WriteLine();

// 2. Linear search over the unsorted array.
const string target = "Running Shoes";
Console.WriteLine($"[Linear Search]  Looking for \"{target}\" in the unsorted array...");
Product? linearResult = SearchService.LinearSearch(catalog, target);
Console.WriteLine(linearResult is not null
    ? $"  Found: {linearResult}"
    : "  Not found.");
Console.WriteLine();

// 3. Sort the array by name, then binary search.
Product[] sortedCatalog = (Product[])catalog.Clone();
Array.Sort(sortedCatalog); // Uses Product.CompareTo (by ProductName).

Console.WriteLine("Catalog sorted by name (required for binary search):");
foreach (Product p in sortedCatalog)
{
    Console.WriteLine($"  {p}");
}
Console.WriteLine();

Console.WriteLine($"[Binary Search]  Looking for \"{target}\" in the sorted array...");
Product? binaryResult = SearchService.BinarySearch(sortedCatalog, target);
Console.WriteLine(binaryResult is not null
    ? $"  Found: {binaryResult}"
    : "  Not found.");
Console.WriteLine();

// A miss, to show both algorithms handle "absent" correctly.
const string missing = "Smart Watch";
Console.WriteLine($"[Binary Search]  Looking for \"{missing}\" (not in catalog)...");
Product? missResult = SearchService.BinarySearch(sortedCatalog, missing);
Console.WriteLine(missResult is not null
    ? $"  Found: {missResult}"
    : "  Not found.");
Console.WriteLine();

// 4. Complexity comparison.
Console.WriteLine("=== Time Complexity Comparison ===");
Console.WriteLine("Algorithm      | Best | Average  | Worst    | Requires sorted?");
Console.WriteLine("---------------|------|----------|----------|-----------------");
Console.WriteLine("Linear Search  | O(1) | O(n)     | O(n)     | No");
Console.WriteLine("Binary Search  | O(1) | O(log n) | O(log n) | Yes");
Console.WriteLine();
Console.WriteLine("Conclusion: For a large, search-heavy catalog, binary search is far");
Console.WriteLine("more suitable - O(log n) vs O(n). The one-time cost of keeping the data");
Console.WriteLine("sorted (or maintaining an index) is amortized across many fast lookups.");
Console.WriteLine("Linear search is fine only for tiny or frequently-changing unsorted data.");
