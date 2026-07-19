using System;

class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine(
            "Drawing Shape"
        );
    }
}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine(
            "Drawing Circle"
        );
    }
}

class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine(
            "Drawing Rectangle"
        );
    }
}

class Program
{
    static void Main()
    {
        Shape s1 = new Circle();
        Shape s2 = new Rectangle();

        s1.Draw();
        s2.Draw();
    }
}