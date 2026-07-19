using System;

class BaseClass
{
    public string PublicData =
        "Public Member";

    private string PrivateData =
        "Private Member";

    protected string ProtectedData =
        "Protected Member";

    public void ShowPrivate()
    {
        Console.WriteLine(
            PrivateData
        );
    }
}

class DerivedClass : BaseClass
{
    public void Display()
    {
        Console.WriteLine(
            PublicData
        );

        Console.WriteLine(
            ProtectedData
        );
    }
}

class Program
{
    static void Main()
    {
        BaseClass obj = new();

        Console.WriteLine(
            obj.PublicData
        );

        obj.ShowPrivate();

        DerivedClass d = new();

        d.Display();
    }
}