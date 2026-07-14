# WebApi_Handson — ASP.NET Core 8.0 Web API

A single cumulative **ASP.NET Core 8.0 Web API** built up across hands-on 1–5 of
the Cognizant **Digital Nurture — .NET FSE Deepskilling** WebApi_Handson document.
(Hands-on 6 — Kafka — is a separate app under
[`../Kafka-Chat-Handson`](../Kafka-Chat-Handson/).)

> **.NET 8 note:** the HOL is written against the classic `Startup.cs`
> (`ConfigureServices` / `Configure`). .NET 8 uses minimal hosting, so all of that
> lives in **`Program.cs`** — the code is annotated to show which HOL step each
> block corresponds to.

## Hands-on covered

| # | Topic | Where |
|---|-------|-------|
| 1 | First Web API (REST, action verbs, status codes, `ValuesController` Read/Write) | `Controllers/ValuesController.cs` |
| 2 | Swagger (Swashbuckle), `AddSwaggerGen`/`UseSwaggerUI`, `ProducesResponseType`, routing & names | `Program.cs`, all controllers |
| 3 | Custom model class + `EmployeeController`, `CustomAuthFilter`, `CustomExceptionFilter` | `Models/`, `Filters/`, `Controllers/EmployeeController.cs` |
| 4 | CRUD (`POST`/`PUT`/`DELETE`) with `[FromBody]` and id validation | `Controllers/EmployeeController.cs` |
| 5 | CORS + JWT bearer auth, `AuthController`, `[Authorize(Roles=...)]`, token expiry | `Program.cs`, `Controllers/AuthController.cs` |

## Project structure

```
WebApi_Handson/
├── WebApi_Handson.csproj      # net8.0 web API + Swashbuckle + JwtBearer
├── Program.cs                 # DI + middleware (Swagger, CORS, JWT)
├── appsettings.json           # logging (JWT key/issuer/audience are set in code)
├── Properties/launchSettings.json
├── Controllers/
│   ├── ValuesController.cs     # Hands-on 1
│   ├── EmployeeController.cs    # Hands-on 3/4/5
│   └── AuthController.cs        # Hands-on 5 (issues JWTs)
├── Models/
│   ├── Employee.cs             # Hands-on 3
│   ├── Department.cs
│   └── Skill.cs
└── Filters/
    ├── CustomAuthFilter.cs      # Hands-on 3 (ActionFilterAttribute)
    └── CustomExceptionFilter.cs # Hands-on 3 (IExceptionFilter, logs to file)
```

## How to run

**Prerequisite:** [.NET 8 SDK](https://dotnet.microsoft.com/download).

```bash
cd WebApi_Handson
dotnet restore
dotnet run
```

Then open **`https://localhost:7099/swagger`** (or the port shown in the console).

## Walkthrough

### Hands-on 1 — First Web API
`ValuesController` exposes `GET/POST/PUT/DELETE` mapped to the HTTP action verbs.
A controller derives from `ControllerBase` and is marked `[ApiController]` (the
.NET Core replacement for the old `ApiController` base). REST is stateless and can
return JSON (not just XML); status codes like `200 Ok`, `400 BadRequest`,
`401 Unauthorized`, `500 InternalServerError` are surfaced through action results.

### Hands-on 2 — Swagger
`AddSwaggerGen` registers the OpenAPI document with title/version/contact/license;
`UseSwaggerUI` serves it at `/swagger`. `ProducesResponseType` annotations make the
documented status codes show up per action. Test the same endpoints from **Postman**
(set the request type, add an `Authorization` header, send a JSON body).

### Hands-on 3 — Custom model + filters
- `Employee` (with `Department`, `List<Skill>`, `DateOfBirth`) is returned by the
  private `GetStandardEmployeeList()` used to seed the controller.
- **`CustomAuthFilter`** (`ActionFilterAttribute.OnActionExecuting`) rejects requests
  with no `Authorization` header (`Invalid request - No Auth token`) or a header
  lacking `Bearer` (`Invalid request - Token present but Bearer unavailable`).
- **`CustomExceptionFilter`** (`IExceptionFilter.OnException`) writes exception
  detail to `exceptions.log` and returns `500`. Trigger it with `GET /api/Employee/error`.
  *(WebApiCompatShim is a .NET Core 2.x artifact and is not needed on .NET 8.)*

### Hands-on 4 — CRUD
`POST` creates, `PUT/{id}` updates, `DELETE/{id}` removes. `PUT`/`DELETE` return
`400 BadRequest` with **"Invalid employee id"** when `id <= 0` or the id is not in
the hardcoded list; otherwise the record is updated/removed and returned.

### Hands-on 5 — CORS + JWT
- CORS is enabled via a permissive `AllowLocalApps` policy.
- `AuthController` (`[AllowAnonymous]`) issues a JWT via `GenerateJSONWebToken`,
  embedding a **role** claim. `Program.cs` validates issuer/audience/lifetime/key.
- `EmployeeController` is protected with `[Authorize(Roles = "POC,Admin")]`, which
  supersedes the earlier `CustomAuthFilter`.

**Try the JWT flow (with Postman, as in the HOL):**
1. `GET /api/Auth?userId=1&userRole=Admin` → copy the returned `token`.
2. In Postman add a header `Authorization: Bearer <token>`.
3. `GET /api/Employee` → `200 OK`. Remove/alter the token → `401 Unauthorized`.
4. Change `AddMinutes(10)` to `AddMinutes(2)` in `AuthController`, wait 2 minutes, retry → `401` (expired).
5. Request a token with `userRole=POC` → still allowed; any other role → `403`.

## Key takeaways
- Controllers + action verbs + `ActionResult<T>` are the core of a REST Web API.
- Swagger/OpenAPI documents and exercises the API; `ProducesResponseType` describes responses.
- Action filters (`OnActionExecuting`) and exception filters (`OnException`) are cross-cutting hooks.
- Model binding with `[FromBody]` maps JSON to model classes for create/update.
- JWT bearer auth + `[Authorize(Roles=...)]` secures endpoints; issuer/audience/key must match on both sides.
