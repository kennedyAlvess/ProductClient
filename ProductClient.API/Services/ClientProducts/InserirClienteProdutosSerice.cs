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
    public InserirClienteProdutosService(IClientProductsRepository clientProductsRepository, IClientRepository clientRepository)
    {
        _clientProductsRepository = clientProductsRepository;
        _clientRepository = clientRepository;
    }
    public async Task Executar(RequestClientProducts request)
    {
        var client = await _clientRepository.ClienteExiste(request.ClientId);

        if (!client)
            throw new NotFoundException("Cliente não encontrado.");
        
        
    }
}