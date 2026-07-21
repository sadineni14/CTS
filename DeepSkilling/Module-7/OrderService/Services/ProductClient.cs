public class ProductClient
{
    private readonly HttpClient _httpClient;
    public ProductClient(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<bool> ProductExistsAsync(int productId)
    {
        var response = await _httpClient.GetAsync($"/api/products/{productId}");
        return response.IsSuccessStatusCode;
    }
}
