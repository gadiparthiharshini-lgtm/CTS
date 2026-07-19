using System;

class Product
{
    public string Name { get; set; }

    private double price;

    public double Price
    {
        get
        {
            return price;
        }

        set
        {
            if (value >= 0)
                price = value;
            else
                Console.WriteLine(
                    "Price cannot be negative"
                );
        }
    }
}

class Program
{
    static void Main()
    {
        Product p = new();

        p.Name = "Laptop";
        p.Price = 50000;

        Console.WriteLine(
            $"{p.Name} - {p.Price}"
        );

        p.Price = -100;
    }
}