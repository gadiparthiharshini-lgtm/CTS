using System;

abstract class Vehicle
{
    public abstract void Drive();
}

interface IDrivable
{
    void Start();
}

class Car : Vehicle, IDrivable
{
    public override void Drive()
    {
        Console.WriteLine(
            "Car is Driving"
        );
    }

    public void Start()
    {
        Console.WriteLine(
            "Car Started"
        );
    }
}

class Program
{
    static void Main()
    {
        Vehicle vehicle = new Car();

        vehicle.Drive();

        IDrivable d = new Car();

        d.Start();
    }
}