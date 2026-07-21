# Module 6 - ASP.NET Core 8.0 Web API

## What this demonstrates
- RESTful controller (`ProductsController`) with GET/POST/PUT/DELETE actions
- Swagger/OpenAPI setup for API documentation and testing
- JWT-based authentication (`AuthController` issues a token) and authorization
  (`[Authorize]` on write operations)
- Depends on the models/DbContext/repository from Module 5

This module now also demonstrates:
- Global exception handling middleware (`Middleware/ExceptionHandlingMiddleware.cs`)
- Structured logging with Serilog (console + rolling file), wired up in `Program.cs`
- A custom action filter (`Filters/LogActionFilter.cs`) logging each request/response
- Attribute routing with route + query parameters (`Controllers/ProductsSearchController.cs`)
- CORS configuration for a separate Angular frontend (Module 8)

## To run
1. Copy Module 5's `Models`, `Data`, and `Repositories` folders into this project (or reference
   them as a shared project).
2. Add NuGet packages: `Microsoft.AspNetCore.Authentication.JwtBearer`, `Swashbuckle.AspNetCore`,
   `Serilog.AspNetCore`, `Serilog.Sinks.Console`, `Serilog.Sinks.File`, plus the EF Core packages
   from Module 5.
3. `dotnet run`, then open `/swagger` to test endpoints.
4. Call `POST /api/auth/login` with `{ "username": "admin", "password": "password" }` to get a
   JWT, then use it as a Bearer token for POST/PUT/DELETE on `/api/products`.
5. Try `GET /api/productssearch/search?minPrice=10&maxPrice=500` and
   `GET /api/productssearch/category/1/top/3` to see query/route parameter handling.
6. Logs land in the console and in `logs/log-YYYYMMDD.txt`.

Note: this module intentionally does not include SOAP/WCF consumption — that sub-topic is
legacy and rarely used with modern .NET 8 projects; mention this to your POC if it's checked.

**Update:** SOAP/WCF is now covered in `SoapClient/` — see its README for the two practical
approaches (consuming an existing SOAP service via `dotnet-svcutil`, and hosting one with
CoreWCF), plus example code showing the calling pattern and a minimal service contract.
