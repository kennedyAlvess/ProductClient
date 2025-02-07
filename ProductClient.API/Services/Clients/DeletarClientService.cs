using ProductClient.API.Entities;
using ProductClient.API.Entities.CustomConvert;
using ProductClient.API.Infrastructure.Repository;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Clients
{
    public interface IDeletarClientService
    {
        Task Executar(long id);
    }

    public class DeletarClientService : IDeletarClientService
    {
        private readonly IClientRepository _clientRepository;
        public DeletarClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task Executar(long id)
        {
            await _clientRepository.ClientExists(id) ? throw new NotFoundException("Cliente não encontrado.");

            await _clientRepository.Delete(long id);  
        }
    }
}