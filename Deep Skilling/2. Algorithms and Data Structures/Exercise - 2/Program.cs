using SearchAlgorithms;

Product[] products =
{
    new Product { ProductId = 101, ProductName = "Keyboard", Category = "Electronics"},
    new Product { ProductId = 102, ProductName = "Laptop", Category = "Electronics"},
    new Product { ProductId = 103, ProductName = "Mobile", Category = "Electronics"},
    new Product { ProductId = 104, ProductName = "Mouse", Category = "Accessories"},
    new Product { ProductId = 105, ProductName = "Printer", Category = "Electronics"}
};

// ---------- Linear Search ----------
Product? LinearSearch(string name)
{
    foreach (var product in products)
    {
        if (product.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
            return product;
    }
    return null;
}

// ---------- Binary Search ----------
Array.Sort(products, (a, b) => a.ProductName.CompareTo(b.ProductName));

Product? BinarySearch(string name)
{
    int left = 0;
    int right = products.Length - 1;

    while (left <= right)
    {
        int mid = (left + right) / 2;

        int compare = string.Compare(products[mid].ProductName, name, true);

        if (compare == 0)
            return products[mid];

        if (compare < 0)
            left = mid + 1;
        else
            right = mid - 1;
    }

    return null;
}

// ----------------------------

Console.WriteLine("Linear Search");

var result1 = LinearSearch("Laptop");

if (result1 != null)
    Console.WriteLine($"{result1.ProductId} - {result1.ProductName}");
else
    Console.WriteLine("Product Not Found");

Console.WriteLine();

Console.WriteLine("Binary Search");

var result2 = BinarySearch("Laptop");

if (result2 != null)
    Console.WriteLine($"{result2.ProductId} - {result2.ProductName}");
else
    Console.WriteLine("Product Not Found");