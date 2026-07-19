using System;
using System.Net;

class Program
{
    static void Main()
    {
        string userInput =
            "<script>alert('XSS')</script>";

        string encoded =
            WebUtility.HtmlEncode(
                userInput
            );

        Console.WriteLine(
            "Original:"
        );

        Console.WriteLine(
            userInput
        );

        Console.WriteLine(
            "\nEncoded:"
        );

        Console.WriteLine(
            encoded
        );
    }
}