using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.API.Validations;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Clients;

public interface IUpdateClientServicie
{
    Task Execute(RequestAtualizarClient client, long Id);   
}
class UpdateClientServicie(IClientRepository clientRepository) : IUpdateClientServicie
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task Execute(RequestAtualizarClient client, long Id)
    {

        if (!await _clientRepository.ClienteExiste(Id))
        {
            throw new NotFoundException("Cliente não encontrado.");
        }
        var entity = await _clientRepository.GetClientById(Id);

        Validator<RequestAtualizarClient>.ExecuteValidation(client);

        entity!.Nome = client.Nome;
        entity!.DataNascimento = client.DataNascimento;

        await _clientRepository.Update(entity!);
    }
}