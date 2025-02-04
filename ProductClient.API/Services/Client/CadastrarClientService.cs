using ProductClient.API.Infrastructure.Repository;
using ProductClient.API.Validations;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Services.Client;

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
        var validator = new ClientValidation();
        var result = validator.Validate(client);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(erros => erros.ErrorMessage).ToList();
            throw new ArgumentException();
        }

        return await _clientRepository.Add(client);
    }
}