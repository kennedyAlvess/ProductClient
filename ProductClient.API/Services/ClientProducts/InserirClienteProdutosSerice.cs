using ProductClient.API.Entities;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.ClientProducts;

public interface IInserirClienteProdutosService
{
    Task Executar(RequestClientProducts request);
}

class InserirClienteProdutosService : IInserirClienteProdutosService
{
    private readonly IClientProductsRepository _clientProductsRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IProductRepository _productRepository;
    public InserirClienteProdutosService(IClientProductsRepository clientProductsRepository, IClientRepository clientRepository, IProductRepository productRepository)
    {
        _clientProductsRepository = clientProductsRepository;
        _clientRepository = clientRepository;
        _productRepository = productRepository;
    }
    public async Task Executar(RequestClientProducts request)
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