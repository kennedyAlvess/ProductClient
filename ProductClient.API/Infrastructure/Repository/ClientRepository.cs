using ProductClient.API.Entities;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Infrastructure.Repository
{
    public interface IClientRepository
    {
        public Task<ResponseClient> Add(RequestClient requestClient);

    }
    public class ClientRepository : IClientRepository
    {
        private readonly ProductClienteDbContext _context;

        public ClientRepository(ProductClienteDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseClient> Add(RequestClient requestClient)
        {
            Client entity = new Client(requestClient);
            await _context.Clients.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new ResponseClient
            {
                Id = entity.Id,
                Nome = entity.Nome
            };
        }
    }
}