// Creating SOAP services using WCF (CoreWCF, the modern .NET-compatible equivalent) sub-topic.
// Requires NuGet packages: CoreWCF.Primitives, CoreWCF.Http, CoreWCF.WSDL

using System.ServiceModel;

[ServiceContract]
public interface IProductSoapService
{
    [OperationContract]
    string GetProductName(int productId);
}

public class ProductSoapService : IProductSoapService
{
    private readonly IProductRepository _repo;
    public ProductSoapService(IProductRepository repo) => _repo = repo;

    public string GetProductName(int productId)
    {
        var product = _repo.GetByIdAsync(productId).GetAwaiter().GetResult();
        return product?.Name ?? "Not found";
    }
}

/*
 * Wiring this up in Program.cs (CoreWCF hosting):
 *
 *   builder.Services.AddServiceModelServices();
 *   builder.Services.AddServiceModelMetadata();
 *   builder.Services.AddSingleton<IProductSoapService, ProductSoapService>();
 *
 *   app.UseServiceModel(serviceBuilder =>
 *   {
 *       serviceBuilder.AddService<ProductSoapService>();
 *       serviceBuilder.AddServiceEndpoint<ProductSoapService, IProductSoapService>(
 *           new BasicHttpBinding(), "/ProductSoapService.svc");
 *   });
 *
 * The WSDL becomes available at /ProductSoapService.svc?wsdl once running.
 */
