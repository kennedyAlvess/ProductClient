using ProductClient.API.Infrastructure.Repository;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Clients;

public interface IDeleteClientService
{
    Task Execute(long id);
}

class DeleteClientService(IClientRepository clientRepository) : IDeleteClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task Execute(long id)
    {
        if (!await _clientRepository.ClienteExiste(id)) throw new NotFoundException("Cliente não encontrado.");

        await _clientRepository.Deletar(id);
    }
}
