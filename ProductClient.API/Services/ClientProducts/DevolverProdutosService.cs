using ProductClient.API.Entities;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.ClientProducts;

public interface IDevolverProdutosService
{
    Task Execute(RequestClientProducts request, long Id);
}

public class DevolverProdutosService(IClientProductsRepository clientProductsRepository, IProductRepository productRepository) : IDevolverProdutosService
{
    private readonly IClientProductsRepository _clientProductsRepository = clientProductsRepository;
    private readonly IProductRepository _productRepository = productRepository;

    public async Task Execute(RequestClientProducts request, long Id)
    {
        var clientProduct = await _clientProductsRepository.GetClientProduct(Id) ?? throw new NotFoundException("Venda não encontrada.");
        var produto = await _productRepository.GetProductById(clientProduct.ProductId);

        if(clientProduct.Quantidade < request.Quantidade)
        {
            throw new BadRequestException("Quantidade de produtos a ser devolvida é maior que a quantidade de produtos existentes.");
        }
        
        clientProduct.Quantidade -= request.Quantidade;
        clientProduct.ValorTotal -= produto!.ValorUnitario * request.Quantidade;

        await _clientProductsRepository.SaveChangesAsync();
    }
}
