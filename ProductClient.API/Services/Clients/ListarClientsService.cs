using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Services.Clients;

public interface IListarClientsService
{
    Task<List<ResponseClient>> Executar();
}
class ListarClientsService(IClientRepository clientRepository) : IListarClientsService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<List<ResponseClient>> Executar()
    {
        return [.. (await _clientRepository.GetAllClients()).Select(client => ConvertEntity.ToClientResponse(client))];
    }
}