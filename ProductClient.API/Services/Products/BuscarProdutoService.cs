using ProductClient.API.Entities.CustomConvert;
using ProductClient.Communication.ResponseDTO;
using ProductClient.Exceptions.ExceptionsBase;
using ProductClient.API.Infrastructure.Repository;

namespace ProductClient.API.Services.Products;

public interface IGetProductService
{
    Task<ResponseProduct> Execute(long id);
}

class BuscarProdutoService(IProductRepository ProductsRepository) : IGetProductService
{
    private readonly IProductRepository _ProductsRepository = ProductsRepository;

    public async Task<ResponseProduct> Execute(long id)
    {
        if(!await _ProductsRepository.ProducteExiste(id))
        {
            throw new NotFoundException("Produto não encontrado.");
        }
        var Products = await _ProductsRepository.GetProductById(id);
        
        return ConvertEntity.ToProductResponse(Products!);
    }
}