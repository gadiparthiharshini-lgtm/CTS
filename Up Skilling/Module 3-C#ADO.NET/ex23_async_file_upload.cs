using System;
using System.Threading.Tasks;

class Program
{
    static async Task<string> UploadFileAsync()
    {
        await Task.Delay(3000);

        return "File Uploaded Successfully";
    }

    static async Task Main()
    {
        try
        {
            Console.WriteLine(
                "Uploading..."
            );

            string result =
                await UploadFileAsync();

            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                ex.Message
            );
        }
    }
}