# Exercise 2 — E-commerce Platform Search Function

## Scenario / Goal
I am working on the search functionality of an e-commerce platform. Customers
search the product catalog constantly, so the lookup must be optimized for fast
performance. This exercise compares **linear search** against **binary search**
over a product catalog and reasons about which is more suitable.

> Implemented in **C# (.NET 8)**.

## Concept — Big O notation & asymptotic analysis
Big O notation describes how an algorithm's running time (or memory) grows as the
input size `n` grows, ignoring constant factors and lower-order terms. It lets us
compare algorithms independent of hardware. We usually analyse three cases:

- **Best case** — the most favourable input (e.g. the item is the first one checked).
- **Average case** — the expected cost over typical/random inputs.
- **Worst case** — the most unfavourable input (e.g. the item is last or missing).

### Linear Search
Walks the array element by element comparing each name to the target.

| Case    | Complexity | Why |
|---------|-----------|-----|
| Best    | O(1)      | Target is the first element. |
| Average | O(n)      | Target is roughly in the middle; on average `n/2` comparisons. |
| Worst   | O(n)      | Target is the last element, or not present at all. |

Works on **unsorted** data — no preprocessing required.

### Binary Search
Requires a **sorted** array. Repeatedly inspects the midpoint and discards half of
the remaining range each step.

| Case    | Complexity | Why |
|---------|-----------|-----|
| Best    | O(1)      | Target is exactly at the first midpoint. |
| Average | O(log n)  | Each comparison halves the search space. |
| Worst   | O(log n)  | Target absent/at a boundary — still only `log2(n)` steps. |

### Comparison

| Algorithm     | Best | Average  | Worst    | Requires sorted? |
|---------------|------|----------|----------|------------------|
| Linear Search | O(1) | O(n)     | O(n)     | No               |
| Binary Search | O(1) | O(log n) | O(log n) | Yes              |

**Which is more suitable and why?**
For a large, search-heavy catalog, **binary search wins** — `O(log n)` scales
dramatically better than `O(n)` (1,000,000 items ≈ 20 comparisons vs up to
1,000,000). The trade-off is that the data must be kept sorted (a one-time
`O(n log n)` sort, or an index that is maintained as products change). That cost
is amortized across many fast lookups. Linear search is only preferable for very
small or constantly-changing unsorted datasets where maintaining order is not
worth it.

## Project structure
```
Exercise2-EcommerceSearch/
├── EcommercePlatformSearch.csproj   # net8.0 console app
├── Product.cs                       # Product model (IComparable by name)
├── SearchService.cs                 # LinearSearch + BinarySearch
├── Program.cs                       # Demo: catalog, searches, comparison
└── README.md
```

## How to run
```bash
cd Exercise2-EcommerceSearch
dotnet run
```

## Expected output
```
=== E-commerce Platform Search ===

Catalog contains 7 products (unsorted):
  [Id=101, Name="Wireless Mouse", Category="Electronics"]
  [Id=102, Name="Yoga Mat", Category="Fitness"]
  [Id=103, Name="Coffee Maker", Category="Home"]
  [Id=104, Name="Bluetooth Speaker", Category="Electronics"]
  [Id=105, Name="Running Shoes", Category="Footwear"]
  [Id=106, Name="Desk Lamp", Category="Home"]
  [Id=107, Name="Notebook", Category="Stationery"]

[Linear Search]  Looking for "Running Shoes" in the unsorted array...
  Found: [Id=105, Name="Running Shoes", Category="Footwear"]

Catalog sorted by name (required for binary search):
  [Id=104, Name="Bluetooth Speaker", Category="Electronics"]
  [Id=103, Name="Coffee Maker", Category="Home"]
  [Id=106, Name="Desk Lamp", Category="Home"]
  [Id=107, Name="Notebook", Category="Stationery"]
  [Id=105, Name="Running Shoes", Category="Footwear"]
  [Id=101, Name="Wireless Mouse", Category="Electronics"]
  [Id=102, Name="Yoga Mat", Category="Fitness"]

[Binary Search]  Looking for "Running Shoes" in the sorted array...
  Found: [Id=105, Name="Running Shoes", Category="Footwear"]

[Binary Search]  Looking for "Smart Watch" (not in catalog)...
  Not found.

=== Time Complexity Comparison ===
Algorithm      | Best | Average  | Worst    | Requires sorted?
---------------|------|----------|----------|-----------------
Linear Search  | O(1) | O(n)     | O(n)     | No
Binary Search  | O(1) | O(log n) | O(log n) | Yes

Conclusion: For a large, search-heavy catalog, binary search is far
more suitable - O(log n) vs O(n). The one-time cost of keeping the data
sorted (or maintaining an index) is amortized across many fast lookups.
Linear search is fine only for tiny or frequently-changing unsorted data.
```

## Key takeaways
- Big O captures growth rate, letting us compare algorithms regardless of hardware.
- Linear search is simple and needs no ordering, but is `O(n)`.
- Binary search is `O(log n)` but requires a **sorted** array.
- For an e-commerce search feature, keep products sorted/indexed and use binary
  search (or a hash index / search engine) so lookups stay fast as the catalog grows.
