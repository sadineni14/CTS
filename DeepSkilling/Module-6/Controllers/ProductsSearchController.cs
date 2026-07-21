using Microsoft.AspNetCore.Mvc;

// Attribute routing and query parameters sub-topic
[ApiController]
[Route("api/[controller]")]
public class ProductsSearchController : ControllerBase
{
    private readonly IProductRepository _repo;
    public ProductsSearchController(IProductRepository repo) => _repo = repo;

    // Example: GET /api/productssearch/search?minPrice=10&maxPrice=100&categoryId=1
    [HttpGet("search")]
    public async Task<ActionResult<List<Product>>> Search(
        [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice,
        [FromQuery] int? categoryId)
    {
        var products = await _repo.GetAllAsync();

        var filtered = products.Where(p =>
            (!minPrice.HasValue || p.Price >= minPrice) &&
            (!maxPrice.HasValue || p.Price <= maxPrice) &&
            (!categoryId.HasValue || p.CategoryId == categoryId));

        return Ok(filtered.ToList());
    }

    // Example: GET /api/productssearch/category/2/top/5  (route/attribute-based parameters)
    [HttpGet("category/{categoryId:int}/top/{count:int}")]
    public async Task<ActionResult<List<Product>>> TopByCategory(int categoryId, int count)
    {
        var products = await _repo.GetAllAsync();
        var result = products
            .Where(p => p.CategoryId == categoryId)
            .OrderByDescending(p => p.Price)
            .Take(count)
            .ToList();

        return Ok(result);
    }
}
