using ProductClient.API.Infrastructure.Repository;
using ProductClient.API.Validations;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;
using ProductClient.Exceptions.ExceptionsBase;
using ProductClient.API.Entities;

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

        Validator.ExecuteValidation(client);

        Client entity = new()
        {
            Nome = client.Nome,
            Email = client.Email,
            DataNascimento = client.DataNascimento,
            DataCadastro = DateTime.Now,
            Cpf = client.Cpf
        };

        await _clientRepository.Add(entity);

        return new ResponseClient
        {
            Id = entity.Id,
            Nome = entity.Nome
        };
    }
}