using System;
using System.IO;
using System.Text.Json;

class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}

class Program
{
    static void Main()
    {
        User user = new()
        {
            Name = "Vardhan",
            Age = 21,
            Email = "vardhan@email.com"
        };

        string json =
            JsonSerializer.Serialize(
                user,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

        File.WriteAllText(
            "user.json",
            json
        );

        string data =
            File.ReadAllText(
                "user.json"
            );

        User? restored =
            JsonSerializer.Deserialize<User>(
                data
            );

        Console.WriteLine(
            $"{restored?.Name} " +
            $"{restored?.Age} " +
            $"{restored?.Email}"
        );
    }
}