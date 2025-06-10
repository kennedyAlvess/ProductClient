using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.ResponseDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Clients;

public interface IGetClientService
{
    Task<ResponseClient> Execute(long id);
}

class BuscarClienteService(IClientRepository clientRepository) : IGetClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<ResponseClient> Execute(long id)
    {
        if(!await _clientRepository.ClienteExiste(id))
        {
            throw new NotFoundException("Cliente não encontrado.");
        }
        var client = await _clientRepository.GetClientById(id);
        
        return ConvertEntity.ToClientResponse(client!);
    }
}