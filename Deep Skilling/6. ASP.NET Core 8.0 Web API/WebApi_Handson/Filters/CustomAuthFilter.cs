using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Handson.Filters;

// Hands-on 3: Custom action filter for authorization.
// Intercepts incoming requests and checks the "Authorization" header:
//   - missing header            -> 400 "Invalid request - No Auth token"
//   - present but no "Bearer"    -> 400 "Invalid request - Token present but Bearer unavailable"
//
// NOTE: Hands-on 5 replaces this filter on EmployeeController with the built-in
// [Authorize] attribute + JWT validation. The class is kept here to show the
// progression; setting context.Result short-circuits the pipeline.
public class CustomAuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var headers = context.HttpContext.Request.Headers;

        if (!headers.ContainsKey("Authorization"))
        {
            context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
            return;
        }

        var authValue = headers["Authorization"].ToString();
        if (!authValue.Contains("Bearer"))
        {
            context.Result = new BadRequestObjectResult(
                "Invalid request - Token present but Bearer unavailable");
            return;
        }

        base.OnActionExecuting(context);
    }
}
