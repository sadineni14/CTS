using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

public class ProductsControllerTests
{
    private Mock<IProductRepository> _mockRepo = null!;
    private ProductsController _controller = null!;

    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<IProductRepository>();
        _controller = new ProductsController(_mockRepo.Object);
    }

    [Test]
    public async Task GetAll_ReturnsOkWithProductList()
    {
        var products = new List<Product>
        {
            new() { ProductId = 1, Name = "Laptop", Price = 999.99m }
        };
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(products);

        var result = await _controller.GetAll();

        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult!.Value, Is.EqualTo(products));
    }

    [Test]
    public async Task GetById_ProductExists_ReturnsOk()
    {
        var product = new Product { ProductId = 1, Name = "Phone", Price = 499.99m };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);

        var result = await _controller.GetById(1);

        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetById_ProductMissing_ReturnsNotFound()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Product?)null);

        var result = await _controller.GetById(99);

        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public async Task Create_ValidProduct_ReturnsCreatedAtAction()
    {
        var product = new Product { ProductId = 1, Name = "Tablet", Price = 299.99m };
        _mockRepo.Setup(r => r.AddAsync(It.IsAny<Product>())).ReturnsAsync(product);

        var result = await _controller.Create(product);

        Assert.That(result.Result, Is.TypeOf<CreatedAtActionResult>());
        _mockRepo.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
    }

    [Test]
    public async Task Delete_ProductExists_ReturnsNoContent()
    {
        _mockRepo.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _controller.Delete(1);

        Assert.That(result, Is.TypeOf<NoContentResult>());
    }
}
