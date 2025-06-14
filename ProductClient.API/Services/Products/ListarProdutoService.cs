using ProductClient.API.Entities.CustomConvert;
using ProductClient.Communication.ResponseDTO;
using ProductClient.API.Infrastructure.Repository;

namespace ProductClient.API.Services.Products;

public interface IListProductService
{
    Task<List<ResponseProduct>> Execute();
}
class ListProductservice(IProductRepository ProductRepository) : IListProductService
{
    private readonly IProductRepository _ProductRepository = ProductRepository;

    public async Task<List<ResponseProduct>> Execute()
    {
        return [.. (await _ProductRepository.GetAllProducts()).Select(ConvertEntity.ToProductResponse)];
    }
}