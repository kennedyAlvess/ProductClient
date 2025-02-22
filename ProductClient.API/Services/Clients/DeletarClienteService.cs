using ProductClient.API.Infrastructure.Repository;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Clients;

public interface IDeletarClientService
{
    Task Executar(long id);
}

class DeletarClientService(IClientRepository clientRepository) : IDeletarClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task Executar(long id)
    {
        if (!await _clientRepository.ClienteExiste(id)) throw new NotFoundException("Cliente não encontrado.");

        await _clientRepository.Deletar(id);
    }
}
