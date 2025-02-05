using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.API.Validations;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Services.Clients;

public interface ICadastrarClientService
{
    Task<ResponseClient> Executar(RequestClient client);
}

public class CadastrarClientService : ICadastrarClientService
{
    private readonly IClientRepository _clientRepository;
    public CadastrarClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    public async Task<ResponseClient> Executar(RequestClient client)
    {
        Validator<RequestClient>.ExecuteValidation(client);

        var entity = ConvertEntity.ToClient(client);

        await _clientRepository.Add(entity);

        return new ResponseClient
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
}