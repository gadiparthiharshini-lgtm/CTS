using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Handson.Filters;

// Hands-on 3: Custom exception filter.
// Implements IExceptionFilter, fetches the exception detail from the context,
// writes it to a log file, and returns a 500 result to the caller.
//
// NOTE: The HOL mentions Microsoft.AspNetCore.Mvc.WebApiCompatShim - that package
// belonged to the ASP.NET Core 2.x migration story and is NOT required on .NET 8;
// IExceptionFilter is built in.
public class CustomExceptionFilter : IExceptionFilter
{
    private readonly IWebHostEnvironment _env;

    public CustomExceptionFilter(IWebHostEnvironment env)
    {
        _env = env;
    }

    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        // Capture the exception detail and append it to a file in the app root.
        var logPath = Path.Combine(_env.ContentRootPath, "exceptions.log");
        var entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {exception.GetType().Name} | " +
                    $"{exception.Message}{Environment.NewLine}{exception.StackTrace}{Environment.NewLine}";
        File.AppendAllText(logPath, entry);

        // Set the Result so the client receives a clean 500 response.
        context.Result = new ObjectResult(new { error = exception.Message })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
        context.ExceptionHandled = true;
    }
}
