using ProductClient.API.Entities.CustomConvert;
using ProductClient.Communication.ResponseDTO;
using ProductClient.API.Infrastructure.Repository;

namespace ProductClient.API.Services.Products;

public interface IListarProdutoService
{
    Task<List<ResponseProduct>> Execute();
}
class ListarProdutoService(IProductRepository ProductRepository) : IListarProdutoService
{
    private readonly IProductRepository _ProductRepository = ProductRepository;

    public async Task<List<ResponseProduct>> Execute()
    {
        return [.. (await _ProductRepository.GetAllProducts()).Select(ConvertEntity.ToProductResponse)];
    }
}