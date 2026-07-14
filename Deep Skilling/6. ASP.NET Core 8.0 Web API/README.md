# 6. ASP.NET Core 8.0 Web API — Hands-On Solutions

ASP.NET Core 8.0 Web API hands-on for the Cognizant **Digital Nurture — .NET FSE
Deepskilling** program (the `WebApi_Handson` document). All projects target **.NET 8**.

## Index

| # | Hands-on | Covers | Description |
|---|----------|--------|-------------|
| 1 | [WebApi_Handson](./WebApi_Handson/) | Hands-on 1–5 | One cumulative Web API: REST + action verbs, Swagger, custom model + filters, CRUD, CORS & JWT auth. |
| 2 | [Kafka-Chat-Handson](./Kafka-Chat-Handson/) | Hands-on 6 | Kafka streaming chat app (Confluent.Kafka producer/consumer over a `chat` topic). |

## Tooling

- Target framework: `net8.0`
- `Swashbuckle.AspNetCore` `6.6.2` (Swagger/OpenAPI)
- `Microsoft.AspNetCore.Authentication.JwtBearer` `8.0.8` (JWT)
- `Confluent.Kafka` `2.5.3` (Kafka chat)

See each subfolder's `README.md` for the full walkthrough and run instructions.
Hands-on 1–5 build on the same API (`WebApi_Handson`), matching how the source
documents accumulate; Hands-on 6 (Kafka) is a standalone streaming demo.
