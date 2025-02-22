using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.API.Validations;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Services.Clients;

public interface ICadastrarClienteService
{
    Task<ResponseClient> Executar(RequestClient client);
}

class CadastrarClienteService(IClientRepository clientRepository) : ICadastrarClienteService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<ResponseClient> Executar(RequestClient client)
    {
        Validator<RequestClient>.ExecuteValidation(client);

        var entity = ConvertDTO.ToClient(client);

        await _clientRepository.Add(entity);

        return ConvertEntity.ToClientResponse(entity);
    }
}