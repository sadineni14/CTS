using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ProductClient _productClient;
    private static readonly List<Order> _orders = new();

    public OrdersController(ProductClient productClient) => _productClient = productClient;

    [HttpPost]
    public async Task<IActionResult> Create(Order order)
    {
        var exists = await _productClient.ProductExistsAsync(order.ProductId);
        if (!exists) return BadRequest("Product does not exist in ProductService.");

        order.OrderId = _orders.Count + 1;
        _orders.Add(order);
        return CreatedAtAction(nameof(GetById), new { id = order.OrderId }, order);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var order = _orders.FirstOrDefault(o => o.OrderId == id);
        return order is null ? NotFound() : Ok(order);
    }
}
