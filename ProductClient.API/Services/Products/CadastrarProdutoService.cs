using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Services.Products;

public interface IRegisterProductService
{
    Task<ResponseProduct> Execute(RequestProduct client);
}

class RegisterProductService(IProductRepository productRepository) : IRegisterProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<ResponseProduct> Execute(RequestProduct client)
    {
        var entity = ConvertDTO.ToProduct(client);

        await _productRepository.Add(entity);

        return ConvertEntity.ToProductResponse(entity);
    }
}