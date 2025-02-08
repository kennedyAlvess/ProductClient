using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.ResponseDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Clients;

public interface IBuscarClienteService
{
    Task<ResponseClient> Executar(long id);
}

public class BuscarClienteService(IClientRepository clientRepository) : IBuscarClienteService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<ResponseClient> Executar(long id)
    {
        if(!await _clientRepository.ClienteExiste(id))
        {
            throw new NotFoundException("Cliente não encontrado.");
        }

        return ConvertEntity.ToClientResponse(await _clientRepository.GetClientById(id));
    }
}