using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Services.Clients;

public interface IListarClientesService
{
    Task<List<ResponseClient>> Executar();
}
class ListarClientesService(IClientRepository clientRepository) : IListarClientesService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<List<ResponseClient>> Executar()
    {
        return [.. (await _clientRepository.GetAllClients()).Select(ConvertEntity.ToClientResponse)];
    }
}