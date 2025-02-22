using ProductClient.API.Entities.CustomConvert;
using ProductClient.Communication.ResponseDTO;
using ProductClient.Exceptions.ExceptionsBase;
using ProductClient.API.Infrastructure.Repository;

namespace ProductClient.API.Services.Products;

public interface IBuscarProdutoService
{
    Task<ResponseProduct> Executar(long id);
}

class BuscarProdutoService(IProductRepository ProductsRepository) : IBuscarProdutoService
{
    private readonly IProductRepository _ProductsRepository = ProductsRepository;

    public async Task<ResponseProduct> Executar(long id)
    {
        if(!await _ProductsRepository.ProducteExiste(id))
        {
            throw new NotFoundException("Produto não encontrado.");
        }
        var Products = await _ProductsRepository.GetProductById(id);
        
        return ConvertEntity.ToProductResponse(Products!);
    }
}