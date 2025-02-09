using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Clients;

public interface IAtualizarClienteServicie
{
    Task<ResponseClient> Executar(RequestClient client);   
}
class AtualizarClienteServicie(IClientRepository clientRepository) : IAtualizarClienteServicie
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<ResponseClient> Executar(RequestClient client)
    {
        if(!await _clientRepository.ClienteExiste(client.Id))
        {
            throw new NotFoundException("Cliente não encontrado.");
        }
        var entity = await _clientRepository.GetClientById(client.Id);
        

        return ConvertEntity.ToClientResponse(await _clientRepository.Update(entity!));
    }
}