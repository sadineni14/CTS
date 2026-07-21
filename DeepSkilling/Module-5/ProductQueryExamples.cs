using Microsoft.EntityFrameworkCore;

// Demonstrates: Eager/Lazy/Explicit loading, AsNoTracking, LINQ projection into DTOs,
// and a compiled query — the "Handling Relationships and Data Loading" +
// "Performance Optimizations and Best Practices" sub-topics.
public class ProductQueryExamples
{
    private readonly AppDbContext _context;
    public ProductQueryExamples(AppDbContext context) => _context = context;

    // Eager loading: related Category is loaded in the same query via Include
    public async Task<List<Product>> EagerLoadProductsAsync() =>
        await _context.Products.Include(p => p.Category).ToListAsync();

    // Lazy loading: requires proxies enabled (UseLazyLoadingProxies) and virtual navigation
    // properties. Simply accessing product.Category later triggers a separate query.
    public async Task<Product?> LazyLoadExampleAsync(int id) =>
        await _context.Products.FindAsync(id);
    // e.g. var category = product.Category; // triggers lazy-load query if proxies are enabled

    // Explicit loading: load the related data on demand, explicitly, when needed
    public async Task ExplicitLoadExampleAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is not null)
        {
            await _context.Entry(product).Reference(p => p.Category).LoadAsync();
        }
    }

    // AsNoTracking: read-only queries skip change tracking for better performance
    public async Task<List<Product>> GetReadOnlyProductsAsync() =>
        await _context.Products.AsNoTracking().Include(p => p.Category).ToListAsync();

    // Projection into a DTO instead of returning the full entity graph
    public async Task<List<ProductSummaryDto>> GetProductSummariesAsync() =>
        await _context.Products
            .Select(p => new ProductSummaryDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                CategoryName = p.Category!.Name
            })
            .AsNoTracking()
            .ToListAsync();

    // Filtering and aggregating data
    public async Task<decimal> GetAveragePriceForCategoryAsync(int categoryId) =>
        await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .AverageAsync(p => p.Price);

    // A compiled query for a frequently-executed lookup (Performance Optimizations sub-topic)
    private static readonly Func<AppDbContext, int, Task<Product?>> _getProductByIdCompiled =
        EF.CompileAsyncQuery((AppDbContext context, int id) =>
            context.Products.FirstOrDefault(p => p.ProductId == id));

    public Task<Product?> GetProductByIdCompiledAsync(int id) =>
        _getProductByIdCompiled(_context, id);
}
