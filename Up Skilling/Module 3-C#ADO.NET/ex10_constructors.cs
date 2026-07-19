using System;

class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car()
    {
        Make = "Unknown";
        Model = "Unknown";
        Year = 0;
    }

    public Car(
        string make,
        string model,
        int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public void Display()
    {
        Console.WriteLine(
            $"{Make} {Model} {Year}"
        );
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new();
        Car car2 = new(
            "Toyota",
            "Camry",
            2024);

        car1.Display();
        car2.Display();
    }
}