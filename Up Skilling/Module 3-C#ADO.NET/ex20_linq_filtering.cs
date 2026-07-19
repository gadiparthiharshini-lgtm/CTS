using System;
using System.Collections.Generic;
using System.Linq;

class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public double TotalAmount { get; set; }
}

class Program
{
    static void Main()
    {
        List<Order> orders = new()
        {
            new Order
            {
                OrderId = 1,
                CustomerName = "Vardhan",
                TotalAmount = 5000
            },
            new Order
            {
                OrderId = 2,
                CustomerName = "Ravi",
                TotalAmount = 2000
            },
            new Order
            {
                OrderId = 3,
                CustomerName = "Sai",
                TotalAmount = 7000
            }
        };

        var result =
            orders
            .Where(o => o.TotalAmount > 3000)
            .Select(o => new
            {
                o.OrderId,
                o.CustomerName
            });

        foreach (var item in result)
        {
            Console.WriteLine(
                $"{item.OrderId} {item.CustomerName}"
            );
        }
    }
}