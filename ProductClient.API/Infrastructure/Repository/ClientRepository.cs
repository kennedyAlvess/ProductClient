using Microsoft.EntityFrameworkCore;
using ProductClient.API.Entities;

namespace ProductClient.API.Infrastructure.Repository
{
    public interface IClientRepository
    {
        Task<Client> Add(Client entity);
        Task<Client> Update(Client entity);
        Task Delete(Client entity);
        Task<Client> GetClientById(long id);
        Task<List<Client>> GetAllClients();
        Task<bool> ClientExists(long id);

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

        public async Task Delete(Client entity)
        {
            _context.Clients.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(long id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> Update(Client entity)
        {
            _context.Clients.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ClientExists(long id)
        {
            return await _context.Clients.AnyAsync(e => e.Id == id);
        }
    }
}