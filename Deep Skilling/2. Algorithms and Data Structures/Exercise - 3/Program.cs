using SortingOrders;

Order[] orders =
{
    new Order { OrderId = 101, CustomerName = "Rahul", TotalPrice = 2500 },
    new Order { OrderId = 102, CustomerName = "Amit", TotalPrice = 1800 },
    new Order { OrderId = 103, CustomerName = "Priya", TotalPrice = 5200 },
    new Order { OrderId = 104, CustomerName = "Neha", TotalPrice = 3100 },
    new Order { OrderId = 105, CustomerName = "Kiran", TotalPrice = 1500 }
};

// ---------- Bubble Sort ----------
void BubbleSort(Order[] arr)
{
    int n = arr.Length;

    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j].TotalPrice > arr[j + 1].TotalPrice)
            {
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }
        }
    }
}

// ---------- Quick Sort ----------
void QuickSort(Order[] arr, int low, int high)
{
    if (low < high)
    {
        int pi = Partition(arr, low, high);

        QuickSort(arr, low, pi - 1);
        QuickSort(arr, pi + 1, high);
    }
}

int Partition(Order[] arr, int low, int high)
{
    double pivot = arr[high].TotalPrice;
    int i = low - 1;

    for (int j = low; j < high; j++)
    {
        if (arr[j].TotalPrice < pivot)
        {
            i++;
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }

    (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);

    return i + 1;
}

void Display(Order[] arr)
{
    foreach (var order in arr)
    {
        Console.WriteLine($"{order.OrderId} | {order.CustomerName} | ₹{order.TotalPrice}");
    }
}

// ----------------------------

Console.WriteLine("Bubble Sort");

Order[] bubbleOrders = (Order[])orders.Clone();

BubbleSort(bubbleOrders);

Display(bubbleOrders);

Console.WriteLine();

Console.WriteLine("Quick Sort");

Order[] quickOrders = (Order[])orders.Clone();

QuickSort(quickOrders, 0, quickOrders.Length - 1);

Display(quickOrders);