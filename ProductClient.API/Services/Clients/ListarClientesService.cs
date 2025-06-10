using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Services.Clients;

public interface IListAllClientsService
{
    Task<List<ResponseClient>> Execute();
}
class ListAllClientsService(IClientRepository clientRepository) : IListAllClientsService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<List<ResponseClient>> Execute()
    {
        return [.. (await _clientRepository.GetAllClients()).Select(ConvertEntity.ToClientResponse)];
    }
}