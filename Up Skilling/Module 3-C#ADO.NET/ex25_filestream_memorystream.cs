using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string text = "Welcome to C# Streams";

        using (FileStream fs =
               new FileStream(
                   "sample.txt",
                   FileMode.Create,
                   FileAccess.Write))
        {
            byte[] data =
                Encoding.UTF8.GetBytes(text);

            fs.Write(
                data,
                0,
                data.Length
            );
        }

        using (FileStream fs =
               new FileStream(
                   "sample.txt",
                   FileMode.Open,
                   FileAccess.Read))
        {
            byte[] buffer =
                new byte[fs.Length];

            fs.Read(
                buffer,
                0,
                buffer.Length
            );

            Console.WriteLine(
                Encoding.UTF8.GetString(buffer)
            );
        }

        using (MemoryStream ms =
               new MemoryStream())
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(
                    "MemoryStream Example"
                );

            ms.Write(
                bytes,
                0,
                bytes.Length
            );

            Console.WriteLine(
                Encoding.UTF8.GetString(
                    ms.ToArray()
                )
            );
        }
    }
}