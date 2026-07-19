#nullable enable
using System;

class Contact
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
}

class Program
{
    static void Main()
    {
        Contact? contact = null;

        Console.WriteLine(
            contact?.Name ?? "Contact Not Found"
        );

        contact = new Contact
        {
            Name = "Vardhan",
            PhoneNumber = "9876543210"
        };

        Console.WriteLine(
            contact?.Name ?? "Contact Not Found"
        );
    }
}