using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi_Handson.Filters;

// =====================================================================
//  WebApi_Handson - ASP.NET Core 8.0 Web API
//  In .NET 8 the minimal-hosting Program.cs replaces the classic
//  Startup.cs. The ConfigureServices work happens on `builder.Services`
//  and the Configure (middleware) work happens on the built `app`.
// =====================================================================

var builder = WebApplication.CreateBuilder(args);

// --- ConfigureServices ------------------------------------------------

// Hands-on 3: register the global exception filter that logs to a file.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

// Hands-on 2: Swagger / OpenAPI with API metadata.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "WebApi_Handson - Cognizant Digital Nurture .NET FSE",
        Contact = new OpenApiContact
        {
            Name = "John Doe",
            Email = "john@xyzmail.com",
            Url = new Uri("https://www.example.com")
        },
        License = new OpenApiLicense
        {
            Name = "License Terms",
            Url = new Uri("https://www.example.com")
        }
    });
});

// Hands-on 5: enable CORS so a local front-end app can call this API.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalApps", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// Hands-on 5: JWT bearer authentication. The issuer, audience and security key
// below MUST match the ones used by AuthController.GenerateJSONWebToken.
string securityKey = "mysuperdupersecret";
var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        // what to validate
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        // values to validate against
        ValidIssuer = "mySystem",
        ValidAudience = "myUsers",
        IssuerSigningKey = symmetricSecurityKey
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// --- Configure (middleware pipeline) ----------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowLocalApps");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
