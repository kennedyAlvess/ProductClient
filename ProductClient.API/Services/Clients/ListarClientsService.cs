using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Services.Clients;

public interface IListarClientsService
{
    Task<List<ResponseClient>> Executar();
}
public class ListarClientsService(IClientRepository clientRepository) : IListarClientsService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<List<ResponseClient>> Executar()
    {
        return [.. (await _clientRepository.GetAllClients()).Select(client => new ResponseClient
        {
            Id = client.Id,
            Nome = client.Nome,
            Email = client.Email,
            DataNascimento = client.DataNascimento,
            Cpf = client.Cpf,
            Idade = client.Idade
        })];
    }
}