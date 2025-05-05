using ProductClient.API.Entities;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.ClientProducts;

public interface IInserirClienteProdutosService
{
    Task Execute(RequestClientProducts request);
}

class InserirClienteProdutosService(IClientProductsRepository clientProductsRepository, IClientRepository clientRepository, 
                                    IProductRepository productRepository) : IInserirClienteProdutosService
{
    private readonly IClientProductsRepository _clientProductsRepository = clientProductsRepository;
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IProductRepository _productRepository = productRepository;

    public async Task Execute(RequestClientProducts request)
    {
        var client = await _clientRepository.ClienteExiste(request.ClientId);
        var produto = await _productRepository.GetProductById(request.ProductId);

        if (!client)
            throw new NotFoundException("Cliente não encontrado.");
        if (produto is null)
            throw new NotFoundException("Produto não encontrado.");

        await _clientProductsRepository.InsertClientProduct(new ClientProduct
        {
            ClientId = request.ClientId,
            ProductId = request.ProductId,
            Quantidade = request.Quantidade,
            ValorTotal = produto.ValorUnitario * request.Quantidade
        });
    }
}