using ProductClient.API.Infrastructure.Repository;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Clients;

public interface IDeletarClienteService
{
    Task Execute(long id);
}

class DeletarClienteService(IClientRepository clientRepository) : IDeletarClienteService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task Execute(long id)
    {
        if (!await _clientRepository.ClienteExiste(id)) throw new NotFoundException("Cliente não encontrado.");

        await _clientRepository.Deletar(id);
    }
}
