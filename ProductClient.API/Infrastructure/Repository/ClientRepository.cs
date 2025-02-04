using ProductClient.API.Entities;

namespace ProductClient.API.Infrastructure.Repository
{
    public interface IClientRepository
    {
        public Task<Client> Add(Client entity);

    }
    public class ClientRepository : IClientRepository
    {
        private readonly ProductClienteDbContext _context;

        public ClientRepository(ProductClienteDbContext context)
        {
            _context = context;
        }
        public async Task<Client> Add(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}