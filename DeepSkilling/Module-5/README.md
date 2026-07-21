# Module 5 - Entity Framework Core 8.0

## What this demonstrates
- Code-first entity models (`Product`, `Category`) with a one-to-many relationship
- `AppDbContext` configuring the relationship and seeding initial data
- Repository pattern (`IProductRepository` / `ProductRepository`) using EF Core for CRUD
- LINQ queries (`Include`, `FirstOrDefaultAsync`, `ToListAsync`)

`ProductQueryExamples.cs` additionally demonstrates:
- Eager loading (`Include`), lazy loading (via proxies), and explicit loading (`Entry().LoadAsync()`)
- `AsNoTracking()` for read-only query performance
- LINQ projection into a DTO (`ProductSummaryDto`)
- Filtering + aggregation (`Where` + `AverageAsync`)
- A compiled query (`EF.CompileAsyncQuery`) for a hot-path lookup

`Models/Tag.cs` adds a `Tag` entity to demonstrate a many-to-many relationship. To wire it up,
add `public List<Tag> Tags { get; set; } = new();` to `Product.cs` — EF Core 8 will infer the
join table automatically (no separate join entity class needed).

## To run
1. Add these NuGet packages to your project:
   - Microsoft.EntityFrameworkCore.SqlServer
   - Microsoft.EntityFrameworkCore.Tools
2. Update the connection string in `appsettings.json` to match your SQL Server instance.
3. Register the DbContext and repository in `Program.cs` (see Module 6, which builds on this).
4. Run migrations:
   ```
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
