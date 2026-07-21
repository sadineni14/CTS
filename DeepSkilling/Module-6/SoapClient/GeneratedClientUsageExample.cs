// Consuming SOAP services in ASP.NET Core sub-topic.
//
// After running `dotnet svcutil <wsdl-url>`, you get a generated client class
// (name varies by service, e.g. WeatherServiceSoapClient). Usage typically looks like this:

public class WeatherSoapConsumer
{
    // Example: a generated client implementing IWeatherServiceSoap
    private readonly IWeatherServiceSoap _client;

    public WeatherSoapConsumer(IWeatherServiceSoap client) => _client = client;

    public async Task<string> GetForecastAsync(string city)
    {
        // Generated proxies expose the SOAP operations as regular async methods
        var result = await _client.GetCityForecastByZIPAsync(city);
        return result?.ToString() ?? "No forecast available.";
    }
}

// Placeholder interface representing what dotnet-svcutil would generate for you —
// replace with the actual generated interface/class once you run svcutil against a real WSDL.
public interface IWeatherServiceSoap
{
    Task<object> GetCityForecastByZIPAsync(string zip);
}

// Register in Program.cs (after generating the real client):
//   builder.Services.AddScoped<IWeatherServiceSoap, WeatherServiceSoapClient>();
//   builder.Services.AddScoped<WeatherSoapConsumer>();
