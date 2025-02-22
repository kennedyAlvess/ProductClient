using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Services.Products;

public interface ICadastrarProdutoService
{
    Task<ResponseProduct> Executar(RequestProduct client);
}

class CadastrarProdutoService(IProductRepository productRepository) : ICadastrarProdutoService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<ResponseProduct> Executar(RequestProduct client)
    {
        var entity = ConvertDTO.ToProduct(client);

        await _productRepository.Add(entity);

        return ConvertEntity.ToProductResponse(entity);
    }
}