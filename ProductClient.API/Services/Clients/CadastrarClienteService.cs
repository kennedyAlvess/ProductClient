using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.API.Validations;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Services.Clients;

public interface IRegisterClientService
{
    Task<ResponseClient> Execute(RequestClient client);
}

class RegisterClientService(IClientRepository clientRepository) : IRegisterClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<ResponseClient> Execute(RequestClient client)
    {
        Validator<RequestClient>.ExecuteValidation(client);

        var entity = ConvertDTO.ToClient(client);

        await _clientRepository.Add(entity);

        return ConvertEntity.ToClientResponse(entity);
    }
}