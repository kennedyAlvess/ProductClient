using ProductClient.API.Infrastructure.Repository;
using ProductClient.API.Validations;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Clients;

public interface IAtualizarClienteServicie
{
    Task Executar(RequestClient client);   
}
class AtualizarClienteServicie(IClientRepository clientRepository) : IAtualizarClienteServicie
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task Executar(RequestClient client)
    {
        if (!await _clientRepository.ClienteExiste(client.Id))
        {
            throw new NotFoundException("Cliente não encontrado.");
        }
        var entity = await _clientRepository.GetClientById(client.Id);
        
        var clientPropriedades = client?.GetType().GetProperties().Where(p => p.GetValue(client) is not null && p.Name != "Id");

        foreach (var propriedade in clientPropriedades!)
        {
            var novoValor = client?.GetType().GetProperty(propriedade.Name)?.GetValue(client);

            ValidadorIndividual.Validar(propriedade.Name, client!);

            entity?.GetType().GetProperty(propriedade.Name)?.SetValue(entity, novoValor);
        }

        await _clientRepository.SaveChangesAsync();
    }
}